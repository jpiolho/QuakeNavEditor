using QuakeNavEditor.Nav;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuakeNavEditor
{
    public partial class FormNodeEdit : Form
    {
        private NavNode _node;
        public FormNodeEdit(NavNode node)
        {
            InitializeComponent();

            _node = node;
        }

        private void FormNodeEdit_Load(object sender, EventArgs e)
        {
            // Populate fields
            vectorBoxPosition.Value = _node.Position;
            textBoxRadius.Text = _node.Radius.ToString();

            // Populate flags
            foreach(var value in Enum.GetValues<NavNodeFlags>())
            {
                if (value == NavNodeFlags.None)
                    continue;

                checkedListBoxFlags.Items.Add(value,_node.Flags.HasFlag(value));
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(!vectorBoxPosition.IsValid)
            {
                ShowError("Invalid coordinates");
                return;
            }
            
            if (!ushort.TryParse(textBoxRadius.Text, out var radius))
            {
                ShowError("Invalid radius");
                return;
            }

            _node.Position = vectorBoxPosition.Value;
            _node.Radius = radius;

            _node.Flags = NavNodeFlags.None;

            foreach (NavNodeFlags item in checkedListBoxFlags.CheckedItems)
                _node.Flags |= item;

            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
