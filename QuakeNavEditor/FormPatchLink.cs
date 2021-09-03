using QuakeNavEditor.Patches;
using QuakeNavEditor.Patches.Link;
using QuakeNavSharp.Navigation;
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


        private NavigationGraph.Link _link;

        public FormPatchLink(NavigationGraph.Link link)
        {
            InitializeComponent();

            _link = link;
        }

        private void FormPatchLink_Load(object sender, EventArgs e)
        {
            checkBoxEdict.Enabled = _link.Edict != null;
            checkBoxTraversal.Enabled = _link.Traversal != null;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var patches = new List<NavPatch>();


            if (checkBoxType.Checked)
            {
                patches.Add(new LinkTypeNavPatch()
                {
                    Node = _link.Node.Origin,
                    DestinationNode = _link.Target.Origin,
                    Type = _link.Type
                });
            }

            if (checkBoxEdict.Checked)
            {
                patches.Add(new LinkEdictNavPatch()
                {
                    Node = _link.Node.Origin,
                    DestinationNode = _link.Target.Origin,
                    Edict = new NavigationGraph.Edict()
                    {
                        Mins = _link.Edict.Mins,
                        Maxs = _link.Edict.Maxs,
                        Classname = _link.Edict.Classname,
                        Targetname = _link.Edict.Targetname
                    }
                });
            }

            if(checkBoxTraversal.Checked)
            {
                patches.Add(new LinkTraversalNavPatch()
                {
                    Node = _link.Node.Origin,
                    DestinationNode = _link.Target.Origin,
                    Traversal = new NavigationGraph.Traversal()
                    {
                        Point1 = _link.Traversal.Point1,
                        Point2 = _link.Traversal.Point2,
                        Point3 = _link.Traversal.Point3
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
