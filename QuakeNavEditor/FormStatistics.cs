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
    public partial class FormStatistics : Form
    {
        public FormStatistics(string statistics)
        {
            InitializeComponent();

            this.textBoxStatistics.Text = statistics;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
