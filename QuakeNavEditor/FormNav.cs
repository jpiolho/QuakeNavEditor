using QuakeNavEditor.Patches;
using QuakeNavSharp.Files;
using QuakeNavSharp.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuakeNavEditor
{
    public partial class FormNav : Form
    {
        private NavigationGraph _nav;
        private NavPreview _navPreview;


        private FormPatch _patch;
        private NavPatches _patches;

        private FileSystemWatcher _fswatcher;


        private string filename;

        public FormNav()
        {
            InitializeComponent();
        }

        public FormNav(string filename) : this()
        {
            this.filename = filename;            
        }

        private async void FormNav_Load(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(filename))
            {
                this._nav = await LoadNavAsync(filename);
            }
            else
            {
                this._nav = new NavigationGraph();
            }


            this._navPreview = new NavPreview()
            {
                PictureBox = pictureBoxPreview,
                Nav = this._nav,

                ShowEdicts = true,
                ShowNodes = true,
                ShowLinks = true,
                ShowNodeIds = true
            };

            this._patches = new NavPatches();

            this.Icon = global::QuakeNavEditor.Properties.Resources.Icon;



            PopulateNodes();
        }

        private async Task<NavigationGraph> LoadNavAsync(string filename)
        {
            NavigationGraph nav;
            using (var fs = new FileStream(filename, FileMode.Open))
                nav = NavigationGraph.FromNavFile(await NavFile.FromStreamAsync(fs));

            return nav;
        }

        private void PopulateNodes()
        {
            listViewNodes.Enabled = false;
            listViewNodes.Items.Clear();
            listViewNodes.SelectedItems.Clear();


            for (var nodeId = 0; nodeId < _nav.Nodes.Count; nodeId++)
                AddNodeToList(nodeId, _nav.Nodes[nodeId]);

            listViewNodes.Enabled = true;
        }

        private void PopulateLinks(NavigationGraph.Node node)
        {
            listViewLinks.Enabled = false;
            listViewLinks.Items.Clear();


            for (var linkId = 0; linkId < node.Links.Count; linkId++)
                AddLinkToList(linkId, node.Links[linkId]);



            listViewLinks.Enabled = true;
        }

        private NavigationGraph.Node[] GetSelectedNodes()
        {
            var array = new NavigationGraph.Node[listViewNodes.SelectedItems.Count];

            for (var i = 0; i < array.Length; i++)
                array[i] = (NavigationGraph.Node)listViewNodes.SelectedItems[i].Tag;

            return array;
        }

        private NavigationGraph.Link[] GetSelectedLinks()
        {
            var array = new NavigationGraph.Link[listViewLinks.SelectedItems.Count];

            for (var i = 0; i < array.Length; i++)
                array[i] = (NavigationGraph.Link)listViewLinks.SelectedItems[i].Tag;

            return array;
        }

        private void OnNodesSelected(params NavigationGraph.Node[] nodes)
        {
            _navPreview.SelectedNodes = nodes.Select(n => n.Id);

            // Repopulate the link list
            listViewLinks.Items.Clear();


            toolStripButtonDeleteNode.Enabled = nodes.Length > 0;

            if (nodes.Length == 1)
            {
                PopulateLinks(nodes[0]);

                toolStripButtonAddLink.Enabled = true;
                listViewLinks.Enabled = true;
            }
            else
            {
                toolStripButtonAddLink.Enabled = false;
                listViewLinks.Enabled = false;
            }

        }

        private void AddLinkToList(int id, NavigationGraph.Link link)
        {
            var item = new ListViewItem();
            item.Tag = link;
            item.Text = id.ToString();

            item.SubItems.Add(link.Target.Id.ToString());
            item.SubItems.Add(link.Type.ToString());
            item.SubItems.Add(link.Edict != null ? "✅" : "");
            item.SubItems.Add(link.Traversal != null ? "✅" : "");

            listViewLinks.Items.Add(item);
        }

        private void AddNodeToList(int id, NavigationGraph.Node node)
        {
            var item = new ListViewItem();
            item.Tag = node;
            item.Text = id.ToString();
            item.SubItems.Add(node.Origin.X.ToString(CultureInfo.InvariantCulture));
            item.SubItems.Add(node.Origin.Y.ToString(CultureInfo.InvariantCulture));
            item.SubItems.Add(node.Origin.Z.ToString(CultureInfo.InvariantCulture));
            item.SubItems.Add(node.Radius.ToString());

            var flags = new List<string>();
            if (node.Flags != 0)
            {
                foreach(var flag in Enum.GetValues<NavigationGraph.NodeFlags>().Where(flag => flag != NavigationGraph.NodeFlags.None))
                {
                    if (node.Flags.HasFlag(flag))
                        flags.Add(flag.ToString());
                }
            }

            item.SubItems.Add(string.Join(", ", flags));



            listViewNodes.Items.Add(item);
        }


        private void listViewNodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedNodes = GetSelectedNodes();
            OnNodesSelected(selectedNodes);

        }

        private async void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filename))
                await SaveAsAsync();
            else
                await SaveAsync(filename);
        }

        private async Task SaveAsAsync()
        {
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            await SaveAsync(saveFileDialog.FileName);

            filename = saveFileDialog.FileName;
        }


        private async Task SaveAsync(string path)
        {
            using (var fs = new FileStream(path, File.Exists(path) ? FileMode.Truncate : FileMode.OpenOrCreate))
                await _nav.ToNavFile().SaveAsync(fs);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            Process.Start(Application.ExecutablePath,new string[] { openFileDialog.FileName });
            
        }

        private void newNavFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Application.ExecutablePath);
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listViewNodes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var selectedNodes = GetSelectedNodes();
            if (selectedNodes.Length != 1)
                return;

            EditNode(selectedNodes[0]);
        }

        private void toolStripButtonAddNode_Click(object sender, EventArgs e)
        {
            var newIndex = _nav.NewNode().Id;

            PopulateNodes();

            // Select node
            listViewNodes.SelectedIndices.Add(newIndex);
            listViewNodes.Items[newIndex].EnsureVisible();
        }

        private void listViewLinks_DoubleClick(object sender, EventArgs e)
        {
            if (listViewLinks.SelectedItems.Count != 1)
                return;

            var selectedLink = (NavigationGraph.Link)listViewLinks.SelectedItems[0].Tag;
            EditLink(selectedLink);
        }

        private void toolStripButtonDeleteNode_Click(object sender, EventArgs e)
        {
            var selectedNodes = GetSelectedNodes();

            if (MessageBox.Show($"Are you sure you want to delete {selectedNodes.Length} node(s)?", "Delete node(s)", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            // Delete all nodes
            foreach (var node in selectedNodes)
                DeleteNode(node.Id);

            OnNodesSelected();
            PopulateNodes();
        }

        private void OnNodeEdited(NavigationGraph.Node node)
        {
            PopulateNodes();

            // Re-select node
            listViewNodes.SelectedIndices.Add(node.Id);
            listViewNodes.Items[node.Id].EnsureVisible();
        }

        private void OnLinkEdited(NavigationGraph.Link link)
        {
            PopulateLinks(link.Node);

            // Re-select link
            listViewLinks.SelectedIndices.Add(link.Id);
            listViewLinks.Items[link.Id].EnsureVisible();
        }


        private void EditNode(NavigationGraph.Node node)
        {
            if (new FormNodeEdit(node).ShowDialog() == DialogResult.OK)
            {
                OnNodeEdited(node);
            }
        }

        private void EditLink(NavigationGraph.Link link)
        {
            if (new FormLinkEdit(link).ShowDialog() == DialogResult.OK)
            {
                OnLinkEdited(link);
            }
        }


        private void DeleteNode(NavigationGraph.Node node) => DeleteNode(node.Id);
        private void DeleteNode(int nodeId)
        {
            _nav.Nodes.RemoveAt(nodeId);
        }

        private void toolStripButtonShowNodeIds_Click(object sender, EventArgs e)
        {
            toolStripButtonShowNodeIds.Checked = !toolStripButtonShowNodeIds.Checked;

            _navPreview.ShowNodeIds = toolStripButtonShowNodeIds.Checked;
        }

        private void toolStripButtonShowNodes_Click(object sender, EventArgs e)
        {
            toolStripButtonShowNodes.Checked = !toolStripButtonShowNodes.Checked;

            _navPreview.ShowNodes = toolStripButtonShowNodes.Checked;
        }

        private void toolStripButtonShowLinks_Click(object sender, EventArgs e)
        {
            toolStripButtonShowLinks.Checked = !toolStripButtonShowLinks.Checked;

            _navPreview.ShowLinks = toolStripButtonShowLinks.Checked;
        }

        private void toolStripButtonShowEdicts_Click(object sender, EventArgs e)
        {
            toolStripButtonShowEdicts.Checked = !toolStripButtonShowEdicts.Checked;

            _navPreview.ShowEdicts = toolStripButtonShowEdicts.Checked;
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var selectedNode = GetSelectedNodes()[0];

            EditNode(selectedNode);

            contextMenuStripNode.Hide();
        }

        private void listViewNodes_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                var selectedNodes = GetSelectedNodes();

                if (selectedNodes.Length == 0)
                    return;

                editToolStripMenuItemNode.Enabled = 
                addToPatchToolStripMenuItemNode.Enabled = selectedNodes.Length == 1;

                contextMenuStripNode.Tag = selectedNodes;
                contextMenuStripNode.Show(listViewNodes.PointToScreen(e.Location));
            }
        }


        private void deleteNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var contextNodes = (NavigationGraph.Node[])contextMenuStripNode.Tag;

            // Delete all nodes
            foreach (var node in contextNodes)
                DeleteNode(node);

            OnNodesSelected();
            PopulateNodes();

            contextMenuStripNode.Hide();
        }

        private void patchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_patch == null || _patch.IsDisposed)
            {
                _patch = new FormPatch(_nav,_patches);
            }

            _patch.Show();
        }

        private void listViewLinks_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var selectedLinks = GetSelectedLinks();

                if (selectedLinks.Length == 0)
                    return;

                editToolStripMenuItemLink.Enabled =
                addToPatchToolStripMenuItemLink.Enabled = selectedLinks.Length == 1;

                contextMenuStripLink.Tag = selectedLinks;
                contextMenuStripLink.Show(listViewLinks.PointToScreen(e.Location));
            }
        }

        private void editToolStripMenuItemLink_Click(object sender, EventArgs e)
        {
            var selectedLink = GetSelectedLinks()[0];

            EditLink(selectedLink);

            contextMenuStripLink.Hide();
        }

        private void addToPatchToolStripMenuItemLink_Click(object sender, EventArgs e)
        {
            var selectedLink = GetSelectedLinks()[0];

            var form = new FormPatchLink(selectedLink);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _patches.AddPatches(form.Patches);
            }
        }

        private void addToPatchToolStripMenuItemNode_Click(object sender, EventArgs e)
        {
            var selectedNode = GetSelectedNodes()[0];

            var form = new FormPatchNode(selectedNode);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _patches.AddPatches(form.Patches);
            }
        }

        private async void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await SaveAsAsync();
        }

        private async void toolStripButtonReload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filename))
                return;

            int maxTries = 5;
            for (var i = 0; i < maxTries; i++) {
                try
                {
                    this._navPreview.Nav = this._nav = await LoadNavAsync(filename);
                    break;
                }
                catch (IOException)
                {
                    if (i < maxTries - 1)
                        await Task.Delay(TimeSpan.FromSeconds(250));
                    else
                        throw;
                }
            }

            PopulateNodes();
            _navPreview.Render();
        }


        
        private void toolStripButtonAutoReload_Click(object sender, EventArgs e)
        {
            if(!toolStripButtonAutoReload.Checked)
            {
                if (string.IsNullOrEmpty(filename))
                    return;

                toolStripButtonAutoReload.Checked = true;

                _fswatcher = new FileSystemWatcher();
                _fswatcher.NotifyFilter = NotifyFilters.LastWrite;
                _fswatcher.Path = Path.GetDirectoryName(filename);
                _fswatcher.Changed += FileSystemWatcher_Changed;
                _fswatcher.EnableRaisingEvents = true;
            }
            else
            {
                _fswatcher.EnableRaisingEvents = false;
                _fswatcher.Changed -= FileSystemWatcher_Changed;
                _fswatcher.Dispose();
                _fswatcher = null;

                toolStripButtonAutoReload.Checked = false;
            }

        }

        private void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            // Only react to the current nav changing
            if(e.FullPath == filename)
            {
                // Invoke to make sure it runs on the correct thread
                this.Invoke((MethodInvoker)delegate { toolStripButtonReload_Click(sender, EventArgs.Empty); });
            }
        }
    }
}
