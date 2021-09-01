using QuakeNavEditor.Nav;
using QuakeNavEditor.Patches;
using QuakeNavEditor.Patches.Link;
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
    public partial class FormPatchLink : Form
    {
        public NavPatch[] Patches { get; private set; }


        private NavFile _nav;
        private int _nodeId;
        private int _linkId;

        public FormPatchLink(NavFile nav, int nodeId, int linkId)
        {
            InitializeComponent();

            _nav = nav;
            _nodeId = nodeId;
            _linkId = linkId;
        }

        private void FormPatchLink_Load(object sender, EventArgs e)
        {
            var link = _nav.Nodes[_nodeId].OutgoingLinks[_linkId];

            checkBoxEdict.Enabled = link.Edict != null;
            checkBoxTraversal.Enabled = link.Traversal != null;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var patches = new List<NavPatch>();

            var node = _nav.Nodes[_nodeId];
            var link = node.OutgoingLinks[_linkId];

            if (checkBoxType.Checked)
            {
                patches.Add(new LinkTypeNavPatch()
                {
                    Node = node.Position,
                    DestinationNode = _nav.Nodes[link.Destination].Position,
                    Type = link.Type
                });
            }

            if (checkBoxEdict.Checked)
            {
                patches.Add(new LinkEdictNavPatch()
                {
                    Node = node.Position,
                    DestinationNode = _nav.Nodes[link.Destination].Position,
                    Edict = new NavLinkEdict()
                    {
                        Mins = link.Edict.Mins,
                        Maxs = link.Edict.Maxs,
                        Classname = link.Edict.Classname,
                        Targetname = link.Edict.Targetname
                    }
                });
            }

            if(checkBoxTraversal.Checked)
            {
                patches.Add(new LinkTraversalNavPatch()
                {
                    Node = node.Position,
                    DestinationNode = _nav.Nodes[link.Destination].Position,
                    Traversal = new NavLinkTraversal()
                    {
                        NodeExit = link.Traversal.NodeExit,
                        JumpStart = link.Traversal.JumpStart,
                        JumpEnd = link.Traversal.JumpEnd
                    }
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
