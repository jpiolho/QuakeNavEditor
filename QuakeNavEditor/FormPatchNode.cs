using QuakeNavEditor.Nav;
using QuakeNavEditor.Patches;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuakeNavEditor
{
    public partial class FormPatchNode : Form
    {
        public NavPatch[] Patches { get; private set; }

        private NavFile _nav;
        private int _nodeId;

        public FormPatchNode(NavFile nav, int nodeId)
        {
            InitializeComponent();

            _nav = nav;
            _nodeId = nodeId;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var patches = new List<NavPatch>();

            var node = _nav.Nodes[_nodeId];

            if (checkBoxFlags.Checked)
            {
                patches.Add(new NodeFlagsNavPatch()
                {
                    Node = node.Position,
                    Flags = node.Flags
                });
            }

            if(checkBoxRadius.Checked)
            {
                patches.Add(new NodeRadiusNavPatch()
                {
                    Node = node.Position,
                    Radius = node.Radius
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
