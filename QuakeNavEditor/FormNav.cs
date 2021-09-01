using QuakeNavEditor.Nav;
using QuakeNavEditor.Patches;
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
        private NavFile _nav;
        private NavPreview _navPreview;


        private FormPatch _patch;
        private NavPatches _patches;


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
                NavFile nav;
                using (var fs = new FileStream(filename, FileMode.Open))
                    nav = await NavFile.LoadFromStreamAsync(fs);

                this._nav = nav;
            }
            else
            {
                this._nav = new NavFile();
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

        private void PopulateNodes()
        {
            listViewNodes.Enabled = false;
            listViewNodes.Items.Clear();
            listViewNodes.SelectedItems.Clear();


            for (var nodeId = 0; nodeId < _nav.Nodes.Count; nodeId++)
                AddNodeToList(nodeId, _nav.Nodes[nodeId]);

            listViewNodes.Enabled = true;
        }

        private void PopulateLinks(int nodeId)
        {
            listViewLinks.Enabled = false;
            listViewLinks.Items.Clear();


            var node = _nav.Nodes[nodeId];

            for (var linkId = 0; linkId < node.OutgoingLinks.Count; linkId++)
                AddLinkToList(linkId, node.OutgoingLinks[linkId]);



            listViewLinks.Enabled = true;
        }

        private (int, NavNode)[] GetSelectedNodes()
        {
            var array = new (int, NavNode)[listViewNodes.SelectedItems.Count];

            for (var i = 0; i < array.Length; i++)
                array[i] = ((int, NavNode))listViewNodes.SelectedItems[i].Tag;

            return array;
        }

        private (int, NavLink)[] GetSelectedLinks()
        {
            var array = new (int, NavLink)[listViewLinks.SelectedItems.Count];

            for (var i = 0; i < array.Length; i++)
                array[i] = ((int, NavLink))listViewLinks.SelectedItems[i].Tag;

            return array;
        }

        private void OnNodesSelected(params (int, NavNode)[] nodes)
        {
            _navPreview.SelectedNodes = nodes.Select(n => n.Item1).ToArray();

            // Repopulate the link list
            listViewLinks.Items.Clear();


            toolStripButtonDeleteNode.Enabled = nodes.Length > 0;

            if (nodes.Length == 1)
            {
                PopulateLinks(nodes[0].Item1);

                toolStripButtonAddLink.Enabled = true;
                listViewLinks.Enabled = true;
            }
            else
            {
                toolStripButtonAddLink.Enabled = false;
                listViewLinks.Enabled = false;
            }

        }

        private void AddLinkToList(int id, NavLink link)
        {
            var item = new ListViewItem();
            item.Tag = (id, link);
            item.Text = id.ToString();

            item.SubItems.Add(link.Destination.ToString());
            item.SubItems.Add(link.Type.ToString());
            item.SubItems.Add(link.Edict != null ? "✅" : "");
            item.SubItems.Add(link.Traversal != null ? "✅" : "");

            listViewLinks.Items.Add(item);
        }

        private void AddNodeToList(int id, NavNode node)
        {
            var item = new ListViewItem();
            item.Tag = (id, node);
            item.Text = id.ToString();
            item.SubItems.Add(node.Position.X.ToString(CultureInfo.InvariantCulture));
            item.SubItems.Add(node.Position.Y.ToString(CultureInfo.InvariantCulture));
            item.SubItems.Add(node.Position.Z.ToString(CultureInfo.InvariantCulture));
            item.SubItems.Add(node.Radius.ToString());

            var flags = new List<string>();
            if (node.Flags != 0)
            {
                var flagValues = Enum.GetValues<NavNodeFlags>();
                var flagNames = Enum.GetNames<NavNodeFlags>();

                for (int flagIndex = 0; flagIndex < flagValues.Length; flagIndex++)
                {
                    NavNodeFlags value = flagValues[flagIndex];

                    if (value == NavNodeFlags.None)
                        continue;

                    if (node.Flags.HasFlag(value))
                        flags.Add(flagNames[flagIndex]);
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
                await _nav.SaveToStreamAsync(fs);
        }

        private async void loadToolStripMenuItem_Click(object sender, EventArgs e)
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

            EditNode(selectedNodes[0].Item1);
        }

        private void toolStripButtonAddNode_Click(object sender, EventArgs e)
        {
            var newIndex = _nav.Nodes.Count;
            _nav.Nodes.Add(new NavNode());

            PopulateNodes();

            // Select node
            listViewNodes.SelectedIndices.Add(newIndex);
            listViewNodes.Items[newIndex].EnsureVisible();
        }

        private void listViewLinks_DoubleClick(object sender, EventArgs e)
        {
            if (listViewLinks.SelectedItems.Count != 1)
                return;

            var selectedNode = ((int, NavNode))listViewNodes.SelectedItems[0].Tag;
            var selectedLink = ((int, NavLink))listViewLinks.SelectedItems[0].Tag;

            EditLink(selectedNode.Item1, selectedLink.Item1);
        }

        private void toolStripButtonDeleteNode_Click(object sender, EventArgs e)
        {
            var selectedNodes = GetSelectedNodes();

            if (MessageBox.Show($"Are you sure you want to delete {selectedNodes.Length} node(s)?", "Delete node(s)", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            // Delete all nodes
            foreach (var node in selectedNodes.OrderByDescending(n => n.Item1))
                DeleteNode(node.Item1);

            OnNodesSelected();
            PopulateNodes();
        }

        private void OnNodeEdited(int nodeId,NavNode node)
        {
            PopulateNodes();

            // Re-select node
            listViewNodes.SelectedIndices.Add(nodeId);
            listViewNodes.Items[nodeId].EnsureVisible();
        }

        private void OnLinkEdited(int nodeId,int linkId)
        {
            PopulateLinks(nodeId);

            // Re-select link
            listViewLinks.SelectedIndices.Add(linkId);
            listViewLinks.Items[linkId].EnsureVisible();
        }


        private void EditNode(int nodeId)
        {
            var node = _nav.Nodes[nodeId];
            if (new FormNodeEdit(node).ShowDialog() == DialogResult.OK)
            {
                OnNodeEdited(nodeId,node);
            }
        }

        private void EditLink(int nodeId,int linkId)
        {
            var link = _nav.Nodes[nodeId].OutgoingLinks[linkId];

            if (new FormLinkEdit(link).ShowDialog() == DialogResult.OK)
            {
                OnLinkEdited(nodeId, linkId);
            }
        }


        private void DeleteNode(int nodeId)
        {
            foreach (var node in _nav.Nodes)
            {
                foreach (var link in node.OutgoingLinks.Reverse<NavLink>())
                {
                    if (link.Destination == nodeId)
                    {
                        // Delete connection
                        node.OutgoingLinks.Remove(link);
                    }
                    else if (link.Destination > nodeId)
                    {
                        // Decrement ids by one above the node being deleted, since all node ids are about to shift down
                        link.Destination--;
                    }
                }
            }

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
            var contextNodes = ((int,NavNode)[])contextMenuStripNode.Tag;

            EditNode(contextNodes[0].Item1);

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
            var contextNodes = ((int, NavNode)[])contextMenuStripNode.Tag;

            // Delete all nodes
            foreach (var node in contextNodes.OrderByDescending(n => n.Item1))
                DeleteNode(node.Item1);

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
            var selectedNode = GetSelectedNodes()[0];
            var selectedLink = GetSelectedLinks()[0];

            EditLink(selectedNode.Item1,selectedLink.Item1);

            contextMenuStripLink.Hide();
        }

        private void addToPatchToolStripMenuItemLink_Click(object sender, EventArgs e)
        {
            var selectedNode = GetSelectedNodes()[0];
            var selectedLink = GetSelectedLinks()[0];

            var form = new FormPatchLink(_nav, selectedNode.Item1, selectedLink.Item1);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _patches.AddPatches(form.Patches);
            }
        }

        private void addToPatchToolStripMenuItemNode_Click(object sender, EventArgs e)
        {
            var selectedNode = GetSelectedNodes()[0];

            var form = new FormPatchNode(_nav, selectedNode.Item1);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _patches.AddPatches(form.Patches);
            }
        }

        private async void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await SaveAsAsync();
        }
    }
}
