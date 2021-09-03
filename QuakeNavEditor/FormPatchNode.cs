using QuakeNavEditor.Patches;
using QuakeNavSharp.Navigation;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuakeNavEditor
{
    public partial class FormPatchNode : Form
    {
        public NavPatch[] Patches { get; private set; }


        private NavigationGraph.Node _node;

        public FormPatchNode(NavigationGraph.Node node)
        {
            InitializeComponent();

            _node = node;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var patches = new List<NavPatch>();

            if (checkBoxFlags.Checked)
            {
                patches.Add(new NodeFlagsNavPatch()
                {
                    Node = _node.Origin,
                    Flags = _node.Flags
                });
            }

            if (checkBoxRadius.Checked)
            {
                patches.Add(new NodeRadiusNavPatch()
                {
                    Node = _node.Origin,
                    Radius = _node.Radius
                });
            }

            this.Patches = patches.ToArray();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
