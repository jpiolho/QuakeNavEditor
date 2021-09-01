using QuakeNavEditor.Nav;
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
        private NavLink _link;
        public FormLinkEdit(NavLink link)
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
            foreach (var value in Enum.GetValues<NavLinkType>())
                comboBoxType.Items.Add(value);

            textBoxDestination.Text = _link.Destination.ToString();
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

                vectorBoxNodeExit.Value = _link.Traversal.NodeExit;
                vectorBoxJumpStart.Value = _link.Traversal.JumpStart;
                vectorBoxJumpEnd.Value = _link.Traversal.JumpEnd;
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


            NavLinkEdict edict = null;
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

                edict = new NavLinkEdict();
                edict.Mins = vectorBoxMins.Value;
                edict.Maxs = vectorBoxMaxs.Value;
                edict.Classname = classname;
                edict.Targetname = targetname;
            }

            NavLinkTraversal traversal = null;
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

                traversal = new NavLinkTraversal();
                traversal.NodeExit = vectorBoxNodeExit.Value;
                traversal.JumpStart = vectorBoxJumpStart.Value;
                traversal.JumpEnd = vectorBoxJumpEnd.Value;
            }

            _link.Destination = destination;
            _link.Type = (NavLinkType)comboBoxType.SelectedValue;
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
