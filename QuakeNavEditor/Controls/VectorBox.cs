using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuakeNavEditor.Controls
{
    public partial class VectorBox : UserControl
    {
        private Vector3 _lastValidVector;
        public Vector3 Value
        {
            get
            {
                if (!float.TryParse(textBoxX.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float x))
                    return _lastValidVector;

                if (!float.TryParse(textBoxY.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float y))
                    return _lastValidVector;

                if (!float.TryParse(textBoxZ.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float z))
                    return _lastValidVector;

                return _lastValidVector = new Vector3(x, y, z);
            }
            set
            {
                textBoxX.Text = value.X.ToString(CultureInfo.InvariantCulture);
                textBoxY.Text = value.Y.ToString(CultureInfo.InvariantCulture);
                textBoxZ.Text = value.Z.ToString(CultureInfo.InvariantCulture);
                _lastValidVector = value;
            }
        }

        public bool IsValid
        {
            get
            {
                if (!float.TryParse(textBoxX.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out _))
                    return false;

                if (!float.TryParse(textBoxY.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out _))
                    return false;

                if (!float.TryParse(textBoxZ.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out _))
                    return false;

                return true;
            }
        }

        public bool ReadOnly
        {
            get => textBoxX.ReadOnly;
            set
            {
                textBoxX.ReadOnly = value;
                textBoxY.ReadOnly = value;
                textBoxZ.ReadOnly = value;
            }
        }

        public VectorBox()
        {
            InitializeComponent();
        }
    }
}
