using QuakeNavEditor.Patches;
using QuakeNavSharp.Navigation;
using System;
using System.IO;
using System.Windows.Forms;

namespace QuakeNavEditor
{
    public partial class FormPatch : Form
    {
        private NavPatches _patches;
        private NavigationGraph _nav;

        public FormPatch(NavigationGraph nav, NavPatches patches)
        {
            InitializeComponent();

            _nav = nav;
            _patches = patches;

            _patches.OnPatchesChanged += OnPatchesChanged;
        }

        public void UpdateNavigationGraph(NavigationGraph nav)
        {
            _nav = nav;
        }

        private void OnPatchesChanged(object sender, EventArgs e)
        {
            PopulateList();
        }

        private void PopulateList()
        {
            listBox.Items.Clear();

            var patches = _patches.Patches;
            for (var i = 0; i < patches.Count; i++)
            {
                listBox.Items.Add(patches[i].PatchDescription);
            }
        }

        private void FormPatch_FormClosed(object sender, FormClosedEventArgs e)
        {
            _patches.OnPatchesChanged -= OnPatchesChanged;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnPatchSelected(listBox.SelectedIndex);
        }

        private void OnPatchSelected(int index)
        {
            buttonComment.Enabled = true;

            // Enable buttons when something is selected
            buttonDelete.Enabled = index >= 0;


            // Enable up & down if applicable
            buttonMoveUp.Enabled = index != -1 && index > 0;
            buttonMoveDown.Enabled = index != -1 && index < listBox.Items.Count - 1;
        }

        private void FormPatch_Load(object sender, EventArgs e)
        {
            this.Icon = global::QuakeNavEditor.Properties.Resources.Icon;

            PopulateList();
            OnPatchSelected(-1);
        }

        private void executeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _patches.Apply(_nav);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The following error occured:\n{ex.GetType().Name}: {ex.Message}", "Failed to apply patch");
                return;
            }

            MessageBox.Show($"Patch applied successfully", "Success");
        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            var index = listBox.SelectedIndex;
            _patches.Move(index, index - 1);
            listBox.SelectedIndex = index - 1;
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            var index = listBox.SelectedIndex;
            _patches.Move(index, index + 1);
            listBox.SelectedIndex = index + 1;
        }

        private void buttonComment_Click(object sender, EventArgs e)
        {
            var form = new FormPatchComment();

            if (form.ShowDialog() == DialogResult.OK)
            {
                // Add or insert
                if (listBox.SelectedIndex >= 0)
                    _patches.InsertPatches(listBox.SelectedIndex, new CommentNavPatch() { Comment = form.Comment });
                else
                    _patches.AddPatches(new CommentNavPatch() { Comment = form.Comment });
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear all the patches and start fresh?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            _patches.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            using (var fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                _patches.LoadFromStream(fs);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;


            using (var fs = new FileStream(saveFileDialog.FileName, File.Exists(saveFileDialog.FileName) ? FileMode.Truncate : FileMode.OpenOrCreate))
                _patches.SaveToStream(fs);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            _patches.RemoveAt(listBox.SelectedIndex);
        }
    }
}
