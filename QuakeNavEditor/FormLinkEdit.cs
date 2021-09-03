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
    public partial class FormLinkEdit : Form
    {
        private NavigationGraph.Link _link;
        public FormLinkEdit(NavigationGraph.Link link)
        {
            InitializeComponent();

            _link = link;
        }

        private void checkBoxTraversal_CheckedChanged(object sender, EventArgs e)
        {
            vectorBoxNodeExit.ReadOnly =
            vectorBoxJumpStart.ReadOnly = 
            vectorBoxJumpEnd.ReadOnly = !checkBoxTraversal.Checked;
            
            vectorBoxNodeExit.Enabled = 
            vectorBoxJumpStart.Enabled =
            vectorBoxJumpEnd.Enabled = checkBoxTraversal.Checked;
        }

        private void checkBoxEdict_CheckedChanged(object sender, EventArgs e)
        {
            vectorBoxMins.ReadOnly =
            vectorBoxMaxs.ReadOnly =
            textBoxTargetname.ReadOnly =
            textBoxClassname.ReadOnly = !checkBoxEdict.Checked;

            vectorBoxMins.Enabled = 
            vectorBoxMaxs.Enabled = 
            textBoxTargetname.Enabled = 
            textBoxClassname.Enabled = checkBoxEdict.Checked;
        }

        private void FormLinkEdit_Load(object sender, EventArgs e)
        {
            // Populate types
            foreach (var value in Enum.GetValues<NavigationGraph.LinkType>())
                comboBoxType.Items.Add(value);

            textBoxDestination.Text = _link.Target.Id.ToString();
            comboBoxType.SelectedItem = _link.Type;

            if (_link.Edict != null)
            {
                checkBoxEdict.Checked = true;

                vectorBoxMins.Value = _link.Edict.Mins;
                vectorBoxMaxs.Value = _link.Edict.Maxs;
                textBoxTargetname.Text = _link.Edict.Targetname.ToString();
                textBoxClassname.Text = _link.Edict.Classname.ToString();
            }
            else
            {
                checkBoxEdict.Checked = false;
            }

            if (_link.Traversal != null)
            {
                checkBoxTraversal.Checked = true;

                vectorBoxNodeExit.Value = _link.Traversal.Point1;
                vectorBoxJumpStart.Value = _link.Traversal.Point2;
                vectorBoxJumpEnd.Value = _link.Traversal.Point3;
            }
            else
            {
                checkBoxTraversal.Checked = false;
            }

            // Trigger the event handlers to update enable / disable
            checkBoxTraversal_CheckedChanged(this, EventArgs.Empty);
            checkBoxEdict_CheckedChanged(this, EventArgs.Empty);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxDestination.Text,out var destination))
            {
                MessageBox.Show("Error", "Invalid destination", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            NavigationGraph.Edict edict = null;
            if (checkBoxEdict.Checked)
            {
                
                if(!vectorBoxMins.IsValid)
                {
                    ShowError("Invalid edict mins");
                    return;
                }

                if(!vectorBoxMaxs.IsValid)
                {
                    ShowError("Invalid edict maxs");
                    return;
                }

                if (!int.TryParse(textBoxTargetname.Text, out var targetname))
                {
                    ShowError("Invalid edict targetname");
                    return;
                }

                if(!int.TryParse(textBoxClassname.Text,out var classname))
                {
                    ShowError("Invalid edict classname");
                    return;
                }

                edict = new NavigationGraph.Edict();
                edict.Mins = vectorBoxMins.Value;
                edict.Maxs = vectorBoxMaxs.Value;
                edict.Classname = classname;
                edict.Targetname = targetname;
            }

            NavigationGraph.Traversal traversal = null;
            if(checkBoxTraversal.Checked)
            {
                if(!vectorBoxNodeExit.IsValid)
                {
                    ShowError("Invalid traversal node exit");
                    return;
                }

                if(!vectorBoxJumpStart.IsValid)
                {
                    ShowError("Invalid traversal jump start");
                    return;
                }

                if(!vectorBoxJumpEnd.IsValid)
                {
                    ShowError("Invalid traversal jump end");
                    return;
                }

                traversal = new NavigationGraph.Traversal();
                traversal.Point1 = vectorBoxNodeExit.Value;
                traversal.Point2 = vectorBoxJumpStart.Value;
                traversal.Point3 = vectorBoxJumpEnd.Value;
            }

            _link.Target = _link.Graph.Nodes[destination];
            _link.Type = (NavigationGraph.LinkType)comboBoxType.SelectedItem;
            _link.Edict = edict;
            _link.Traversal = traversal;

            this.Close();
        }


        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
