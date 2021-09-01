
namespace QuakeNavEditor
{
    partial class FormLinkEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxDestination = new System.Windows.Forms.TextBox();
            this.labelDestination = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.groupBoxEdict = new System.Windows.Forms.GroupBox();
            this.vectorBoxMaxs = new QuakeNavEditor.Controls.VectorBox();
            this.vectorBoxMins = new QuakeNavEditor.Controls.VectorBox();
            this.textBoxClassname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTargetName = new System.Windows.Forms.Label();
            this.textBoxTargetname = new System.Windows.Forms.TextBox();
            this.labelMaxs = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxEdict = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.vectorBoxNodeExit = new QuakeNavEditor.Controls.VectorBox();
            this.vectorBoxJumpEnd = new QuakeNavEditor.Controls.VectorBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.vectorBoxJumpStart = new QuakeNavEditor.Controls.VectorBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxTraversal = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBoxEdict.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxDestination
            // 
            this.textBoxDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDestination.Location = new System.Drawing.Point(96, 12);
            this.textBoxDestination.Name = "textBoxDestination";
            this.textBoxDestination.Size = new System.Drawing.Size(422, 23);
            this.textBoxDestination.TabIndex = 1;
            // 
            // labelDestination
            // 
            this.labelDestination.AutoSize = true;
            this.labelDestination.Location = new System.Drawing.Point(20, 15);
            this.labelDestination.Name = "labelDestination";
            this.labelDestination.Size = new System.Drawing.Size(70, 15);
            this.labelDestination.TabIndex = 9;
            this.labelDestination.Text = "Destination:";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(56, 44);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(34, 15);
            this.labelType.TabIndex = 10;
            this.labelType.Text = "Type:";
            // 
            // comboBoxType
            // 
            this.comboBoxType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(96, 41);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(422, 23);
            this.comboBoxType.TabIndex = 11;
            // 
            // groupBoxEdict
            // 
            this.groupBoxEdict.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxEdict.Controls.Add(this.vectorBoxMaxs);
            this.groupBoxEdict.Controls.Add(this.vectorBoxMins);
            this.groupBoxEdict.Controls.Add(this.textBoxClassname);
            this.groupBoxEdict.Controls.Add(this.label2);
            this.groupBoxEdict.Controls.Add(this.labelTargetName);
            this.groupBoxEdict.Controls.Add(this.textBoxTargetname);
            this.groupBoxEdict.Controls.Add(this.labelMaxs);
            this.groupBoxEdict.Controls.Add(this.label1);
            this.groupBoxEdict.Controls.Add(this.checkBoxEdict);
            this.groupBoxEdict.Location = new System.Drawing.Point(12, 70);
            this.groupBoxEdict.Name = "groupBoxEdict";
            this.groupBoxEdict.Size = new System.Drawing.Size(506, 148);
            this.groupBoxEdict.TabIndex = 12;
            this.groupBoxEdict.TabStop = false;
            // 
            // vectorBoxMaxs
            // 
            this.vectorBoxMaxs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vectorBoxMaxs.Location = new System.Drawing.Point(84, 51);
            this.vectorBoxMaxs.Name = "vectorBoxMaxs";
            this.vectorBoxMaxs.ReadOnly = false;
            this.vectorBoxMaxs.Size = new System.Drawing.Size(416, 23);
            this.vectorBoxMaxs.TabIndex = 14;
            // 
            // vectorBoxMins
            // 
            this.vectorBoxMins.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vectorBoxMins.Location = new System.Drawing.Point(84, 22);
            this.vectorBoxMins.Name = "vectorBoxMins";
            this.vectorBoxMins.ReadOnly = false;
            this.vectorBoxMins.Size = new System.Drawing.Size(416, 23);
            this.vectorBoxMins.TabIndex = 13;
            // 
            // textBoxClassname
            // 
            this.textBoxClassname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxClassname.Location = new System.Drawing.Point(84, 111);
            this.textBoxClassname.Name = "textBoxClassname";
            this.textBoxClassname.Size = new System.Drawing.Size(416, 23);
            this.textBoxClassname.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Classname:";
            // 
            // labelTargetName
            // 
            this.labelTargetName.AutoSize = true;
            this.labelTargetName.Location = new System.Drawing.Point(6, 83);
            this.labelTargetName.Name = "labelTargetName";
            this.labelTargetName.Size = new System.Drawing.Size(72, 15);
            this.labelTargetName.TabIndex = 10;
            this.labelTargetName.Text = "Targetname:";
            // 
            // textBoxTargetname
            // 
            this.textBoxTargetname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTargetname.Location = new System.Drawing.Point(84, 80);
            this.textBoxTargetname.Name = "textBoxTargetname";
            this.textBoxTargetname.Size = new System.Drawing.Size(416, 23);
            this.textBoxTargetname.TabIndex = 9;
            // 
            // labelMaxs
            // 
            this.labelMaxs.AutoSize = true;
            this.labelMaxs.Location = new System.Drawing.Point(40, 54);
            this.labelMaxs.Name = "labelMaxs";
            this.labelMaxs.Size = new System.Drawing.Size(38, 15);
            this.labelMaxs.TabIndex = 8;
            this.labelMaxs.Text = "Maxs:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mins:";
            // 
            // checkBoxEdict
            // 
            this.checkBoxEdict.AutoSize = true;
            this.checkBoxEdict.Location = new System.Drawing.Point(6, 0);
            this.checkBoxEdict.Name = "checkBoxEdict";
            this.checkBoxEdict.Size = new System.Drawing.Size(52, 19);
            this.checkBoxEdict.TabIndex = 0;
            this.checkBoxEdict.Text = "Edict";
            this.checkBoxEdict.UseVisualStyleBackColor = true;
            this.checkBoxEdict.CheckedChanged += new System.EventHandler(this.checkBoxEdict_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.vectorBoxNodeExit);
            this.groupBox1.Controls.Add(this.vectorBoxJumpEnd);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.vectorBoxJumpStart);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.checkBoxTraversal);
            this.groupBox1.Location = new System.Drawing.Point(12, 224);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 119);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // vectorBoxNodeExit
            // 
            this.vectorBoxNodeExit.Location = new System.Drawing.Point(84, 22);
            this.vectorBoxNodeExit.Name = "vectorBoxNodeExit";
            this.vectorBoxNodeExit.ReadOnly = false;
            this.vectorBoxNodeExit.Size = new System.Drawing.Size(416, 23);
            this.vectorBoxNodeExit.TabIndex = 19;
            // 
            // vectorBoxJumpEnd
            // 
            this.vectorBoxJumpEnd.Location = new System.Drawing.Point(84, 80);
            this.vectorBoxJumpEnd.Name = "vectorBoxJumpEnd";
            this.vectorBoxJumpEnd.ReadOnly = false;
            this.vectorBoxJumpEnd.Size = new System.Drawing.Size(416, 23);
            this.vectorBoxJumpEnd.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Jump end:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Jump start:";
            // 
            // vectorBoxJumpStart
            // 
            this.vectorBoxJumpStart.Location = new System.Drawing.Point(84, 51);
            this.vectorBoxJumpStart.Name = "vectorBoxJumpStart";
            this.vectorBoxJumpStart.ReadOnly = false;
            this.vectorBoxJumpStart.Size = new System.Drawing.Size(416, 23);
            this.vectorBoxJumpStart.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Node exit:";
            // 
            // checkBoxTraversal
            // 
            this.checkBoxTraversal.AutoSize = true;
            this.checkBoxTraversal.Location = new System.Drawing.Point(6, 0);
            this.checkBoxTraversal.Name = "checkBoxTraversal";
            this.checkBoxTraversal.Size = new System.Drawing.Size(71, 19);
            this.checkBoxTraversal.TabIndex = 13;
            this.checkBoxTraversal.Text = "Traversal";
            this.checkBoxTraversal.UseVisualStyleBackColor = true;
            this.checkBoxTraversal.CheckedChanged += new System.EventHandler(this.checkBoxTraversal_CheckedChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(362, 349);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.Location = new System.Drawing.Point(443, 349);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 14;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // FormLinkEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 384);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxEdict);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.labelDestination);
            this.Controls.Add(this.textBoxDestination);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLinkEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Link";
            this.Load += new System.EventHandler(this.FormLinkEdit_Load);
            this.groupBoxEdict.ResumeLayout(false);
            this.groupBoxEdict.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDestination;
        private System.Windows.Forms.Label labelDestination;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.GroupBox groupBoxEdict;
        private System.Windows.Forms.CheckBox checkBoxEdict;
        private System.Windows.Forms.Label labelMaxs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTargetName;
        private System.Windows.Forms.TextBox textBoxTargetname;
        private System.Windows.Forms.TextBox textBoxClassname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxTraversal;
        private System.Windows.Forms.Label label3;
        private Controls.VectorBox vectorBoxMins;
        private Controls.VectorBox vectorBoxMaxs;
        private Controls.VectorBox vectorBoxNodeExit;
        private Controls.VectorBox vectorBoxJumpEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Controls.VectorBox vectorBoxJumpStart;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
    }
}