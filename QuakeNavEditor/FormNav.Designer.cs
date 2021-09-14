
namespace QuakeNavEditor
{
    partial class FormNav
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listViewNodes = new System.Windows.Forms.ListView();
            this.columnHeaderId = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderX = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderY = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderZ = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderRadius = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderFlags = new System.Windows.Forms.ColumnHeader();
            this.labelNodes = new System.Windows.Forms.Label();
            this.listViewLinks = new System.Windows.Forms.ListView();
            this.columnHeaderLinkId = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderLinkDestination = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderLinkType = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderLinkEdict = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderLinkTraversal = new System.Windows.Forms.ColumnHeader();
            this.labelLinks = new System.Windows.Forms.Label();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddNode = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDeleteNode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonAddLink = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonShowNodeIds = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonShowNodes = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonShowLinks = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonShowEdicts = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonReload = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAutoReload = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newNavFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllTraversalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStripNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItemNode = new System.Windows.Forms.ToolStripMenuItem();
            this.addToPatchToolStripMenuItemNode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteNodeToolStripMenuItemNode = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripLink = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItemLink = new System.Windows.Forms.ToolStripMenuItem();
            this.addToPatchToolStripMenuItemLink = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteLinksToolStripMenuItemLink = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.contextMenuStripNode.SuspendLayout();
            this.contextMenuStripLink.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 49);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.pictureBoxPreview);
            this.splitContainer.Panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer.Panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.splitContainer.Size = new System.Drawing.Size(742, 622);
            this.splitContainer.SplitterDistance = 353;
            this.splitContainer.TabIndex = 0;
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPreview.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(353, 622);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxPreview.TabIndex = 0;
            this.pictureBoxPreview.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewNodes);
            this.splitContainer1.Panel1.Controls.Add(this.labelNodes);
            this.splitContainer1.Panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listViewLinks);
            this.splitContainer1.Panel2.Controls.Add(this.labelLinks);
            this.splitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.splitContainer1.Size = new System.Drawing.Size(385, 622);
            this.splitContainer1.SplitterDistance = 311;
            this.splitContainer1.TabIndex = 7;
            // 
            // listViewNodes
            // 
            this.listViewNodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderX,
            this.columnHeaderY,
            this.columnHeaderZ,
            this.columnHeaderRadius,
            this.columnHeaderFlags});
            this.listViewNodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewNodes.FullRowSelect = true;
            this.listViewNodes.HideSelection = false;
            this.listViewNodes.Location = new System.Drawing.Point(0, 15);
            this.listViewNodes.Name = "listViewNodes";
            this.listViewNodes.Size = new System.Drawing.Size(385, 296);
            this.listViewNodes.TabIndex = 5;
            this.listViewNodes.UseCompatibleStateImageBehavior = false;
            this.listViewNodes.View = System.Windows.Forms.View.Details;
            this.listViewNodes.SelectedIndexChanged += new System.EventHandler(this.listViewNodes_SelectedIndexChanged);
            this.listViewNodes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewNodes_MouseDoubleClick);
            this.listViewNodes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewNodes_MouseDown);
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "Id";
            // 
            // columnHeaderX
            // 
            this.columnHeaderX.Text = "X";
            // 
            // columnHeaderY
            // 
            this.columnHeaderY.Text = "Y";
            // 
            // columnHeaderZ
            // 
            this.columnHeaderZ.Text = "Z";
            // 
            // columnHeaderRadius
            // 
            this.columnHeaderRadius.Text = "Radius";
            // 
            // columnHeaderFlags
            // 
            this.columnHeaderFlags.Text = "Flags";
            // 
            // labelNodes
            // 
            this.labelNodes.AutoSize = true;
            this.labelNodes.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelNodes.Location = new System.Drawing.Point(0, 0);
            this.labelNodes.Name = "labelNodes";
            this.labelNodes.Size = new System.Drawing.Size(44, 15);
            this.labelNodes.TabIndex = 2;
            this.labelNodes.Text = "Nodes:";
            // 
            // listViewLinks
            // 
            this.listViewLinks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLinkId,
            this.columnHeaderLinkDestination,
            this.columnHeaderLinkType,
            this.columnHeaderLinkEdict,
            this.columnHeaderLinkTraversal});
            this.listViewLinks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLinks.FullRowSelect = true;
            this.listViewLinks.HideSelection = false;
            this.listViewLinks.Location = new System.Drawing.Point(0, 15);
            this.listViewLinks.Name = "listViewLinks";
            this.listViewLinks.Size = new System.Drawing.Size(385, 292);
            this.listViewLinks.TabIndex = 6;
            this.listViewLinks.UseCompatibleStateImageBehavior = false;
            this.listViewLinks.View = System.Windows.Forms.View.Details;
            this.listViewLinks.DoubleClick += new System.EventHandler(this.listViewLinks_DoubleClick);
            this.listViewLinks.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewLinks_MouseDown);
            // 
            // columnHeaderLinkId
            // 
            this.columnHeaderLinkId.Text = "Id";
            // 
            // columnHeaderLinkDestination
            // 
            this.columnHeaderLinkDestination.Text = "Destination";
            // 
            // columnHeaderLinkType
            // 
            this.columnHeaderLinkType.Text = "Type";
            // 
            // columnHeaderLinkEdict
            // 
            this.columnHeaderLinkEdict.Text = "Edict";
            // 
            // columnHeaderLinkTraversal
            // 
            this.columnHeaderLinkTraversal.Text = "Traversal";
            // 
            // labelLinks
            // 
            this.labelLinks.AutoSize = true;
            this.labelLinks.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelLinks.Location = new System.Drawing.Point(0, 0);
            this.labelLinks.Name = "labelLinks";
            this.labelLinks.Size = new System.Drawing.Size(37, 15);
            this.labelLinks.TabIndex = 4;
            this.labelLinks.Text = "Links:";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddNode,
            this.toolStripButtonDeleteNode,
            this.toolStripSeparator1,
            this.toolStripButtonAddLink,
            this.toolStripSeparator2,
            this.toolStripButtonShowNodeIds,
            this.toolStripButtonShowNodes,
            this.toolStripButtonShowLinks,
            this.toolStripButtonShowEdicts,
            this.toolStripSeparator3,
            this.toolStripButtonReload,
            this.toolStripButtonAutoReload});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(742, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButtonAddNode
            // 
            this.toolStripButtonAddNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddNode.Image = global::QuakeNavEditor.Properties.Resources.AddControl_16x;
            this.toolStripButtonAddNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddNode.Name = "toolStripButtonAddNode";
            this.toolStripButtonAddNode.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAddNode.Text = "Add Node";
            this.toolStripButtonAddNode.Click += new System.EventHandler(this.toolStripButtonAddNode_Click);
            // 
            // toolStripButtonDeleteNode
            // 
            this.toolStripButtonDeleteNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDeleteNode.Enabled = false;
            this.toolStripButtonDeleteNode.Image = global::QuakeNavEditor.Properties.Resources.DeleteDatabase_16x;
            this.toolStripButtonDeleteNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteNode.Name = "toolStripButtonDeleteNode";
            this.toolStripButtonDeleteNode.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDeleteNode.Text = "Delete node...";
            this.toolStripButtonDeleteNode.Click += new System.EventHandler(this.toolStripButtonDeleteNode_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonAddLink
            // 
            this.toolStripButtonAddLink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddLink.Enabled = false;
            this.toolStripButtonAddLink.Image = global::QuakeNavEditor.Properties.Resources.AddDelegation_16x;
            this.toolStripButtonAddLink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddLink.Name = "toolStripButtonAddLink";
            this.toolStripButtonAddLink.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAddLink.Text = "Add Link";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonShowNodeIds
            // 
            this.toolStripButtonShowNodeIds.Checked = true;
            this.toolStripButtonShowNodeIds.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonShowNodeIds.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonShowNodeIds.Image = global::QuakeNavEditor.Properties.Resources.data_number_on_16x;
            this.toolStripButtonShowNodeIds.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowNodeIds.Name = "toolStripButtonShowNodeIds";
            this.toolStripButtonShowNodeIds.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonShowNodeIds.Text = "Show Node Ids";
            this.toolStripButtonShowNodeIds.Click += new System.EventHandler(this.toolStripButtonShowNodeIds_Click);
            // 
            // toolStripButtonShowNodes
            // 
            this.toolStripButtonShowNodes.Checked = true;
            this.toolStripButtonShowNodes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonShowNodes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonShowNodes.Image = global::QuakeNavEditor.Properties.Resources.Control_16x;
            this.toolStripButtonShowNodes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowNodes.Name = "toolStripButtonShowNodes";
            this.toolStripButtonShowNodes.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonShowNodes.Text = "Show nodes...";
            this.toolStripButtonShowNodes.Click += new System.EventHandler(this.toolStripButtonShowNodes_Click);
            // 
            // toolStripButtonShowLinks
            // 
            this.toolStripButtonShowLinks.Checked = true;
            this.toolStripButtonShowLinks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonShowLinks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonShowLinks.Image = global::QuakeNavEditor.Properties.Resources.Delegation_16x;
            this.toolStripButtonShowLinks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowLinks.Name = "toolStripButtonShowLinks";
            this.toolStripButtonShowLinks.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonShowLinks.Text = "Show links";
            this.toolStripButtonShowLinks.Click += new System.EventHandler(this.toolStripButtonShowLinks_Click);
            // 
            // toolStripButtonShowEdicts
            // 
            this.toolStripButtonShowEdicts.Checked = true;
            this.toolStripButtonShowEdicts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonShowEdicts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonShowEdicts.Image = global::QuakeNavEditor.Properties.Resources.InfraredDevice_16x;
            this.toolStripButtonShowEdicts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowEdicts.Name = "toolStripButtonShowEdicts";
            this.toolStripButtonShowEdicts.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonShowEdicts.Text = "Show edicts";
            this.toolStripButtonShowEdicts.Click += new System.EventHandler(this.toolStripButtonShowEdicts_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonReload
            // 
            this.toolStripButtonReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonReload.Image = global::QuakeNavEditor.Properties.Resources.Refresh_16x;
            this.toolStripButtonReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonReload.Name = "toolStripButtonReload";
            this.toolStripButtonReload.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonReload.Text = "Reload file";
            this.toolStripButtonReload.Click += new System.EventHandler(this.toolStripButtonReload_Click);
            // 
            // toolStripButtonAutoReload
            // 
            this.toolStripButtonAutoReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAutoReload.Image = global::QuakeNavEditor.Properties.Resources.RefreshServer_16x;
            this.toolStripButtonAutoReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAutoReload.Name = "toolStripButtonAutoReload";
            this.toolStripButtonAutoReload.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAutoReload.Text = "Automatic reload";
            this.toolStripButtonAutoReload.Click += new System.EventHandler(this.toolStripButtonAutoReload_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "nav";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.patchToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(742, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newNavFileToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newNavFileToolStripMenuItem
            // 
            this.newNavFileToolStripMenuItem.Name = "newNavFileToolStripMenuItem";
            this.newNavFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newNavFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newNavFileToolStripMenuItem.Text = "New";
            this.newNavFileToolStripMenuItem.Click += new System.EventHandler(this.newNavFileToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load...";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::QuakeNavEditor.Properties.Resources.Save_16x;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quitToolStripMenuItem.Text = "Exit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // patchToolStripMenuItem
            // 
            this.patchToolStripMenuItem.Name = "patchToolStripMenuItem";
            this.patchToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.patchToolStripMenuItem.Text = "Patch";
            this.patchToolStripMenuItem.Click += new System.EventHandler(this.patchToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeAllTraversalsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // removeAllTraversalsToolStripMenuItem
            // 
            this.removeAllTraversalsToolStripMenuItem.Name = "removeAllTraversalsToolStripMenuItem";
            this.removeAllTraversalsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.removeAllTraversalsToolStripMenuItem.Text = "Remove all traversals...";
            this.removeAllTraversalsToolStripMenuItem.Click += new System.EventHandler(this.removeAllTraversalsToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "nav";
            this.openFileDialog.Filter = "Quake bot navigation files|*.nav|All files|*.*";
            // 
            // contextMenuStripNode
            // 
            this.contextMenuStripNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItemNode,
            this.addToPatchToolStripMenuItemNode,
            this.toolStripMenuItem3,
            this.deleteNodeToolStripMenuItemNode});
            this.contextMenuStripNode.Name = "contextMenuStripNode";
            this.contextMenuStripNode.Size = new System.Drawing.Size(153, 76);
            // 
            // editToolStripMenuItemNode
            // 
            this.editToolStripMenuItemNode.Name = "editToolStripMenuItemNode";
            this.editToolStripMenuItemNode.Size = new System.Drawing.Size(152, 22);
            this.editToolStripMenuItemNode.Text = "Edit...";
            this.editToolStripMenuItemNode.Click += new System.EventHandler(this.editToolStripMenuItem1_Click);
            // 
            // addToPatchToolStripMenuItemNode
            // 
            this.addToPatchToolStripMenuItemNode.Name = "addToPatchToolStripMenuItemNode";
            this.addToPatchToolStripMenuItemNode.Size = new System.Drawing.Size(152, 22);
            this.addToPatchToolStripMenuItemNode.Text = "Add to patch...";
            this.addToPatchToolStripMenuItemNode.Click += new System.EventHandler(this.addToPatchToolStripMenuItemNode_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(149, 6);
            // 
            // deleteNodeToolStripMenuItemNode
            // 
            this.deleteNodeToolStripMenuItemNode.Name = "deleteNodeToolStripMenuItemNode";
            this.deleteNodeToolStripMenuItemNode.Size = new System.Drawing.Size(152, 22);
            this.deleteNodeToolStripMenuItemNode.Text = "Delete node(s)";
            this.deleteNodeToolStripMenuItemNode.Click += new System.EventHandler(this.deleteNodeToolStripMenuItem_Click);
            // 
            // contextMenuStripLink
            // 
            this.contextMenuStripLink.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItemLink,
            this.addToPatchToolStripMenuItemLink,
            this.toolStripMenuItem2,
            this.deleteLinksToolStripMenuItemLink});
            this.contextMenuStripLink.Name = "contextMenuStripLink";
            this.contextMenuStripLink.Size = new System.Drawing.Size(153, 76);
            // 
            // editToolStripMenuItemLink
            // 
            this.editToolStripMenuItemLink.Name = "editToolStripMenuItemLink";
            this.editToolStripMenuItemLink.Size = new System.Drawing.Size(152, 22);
            this.editToolStripMenuItemLink.Text = "Edit...";
            this.editToolStripMenuItemLink.Click += new System.EventHandler(this.editToolStripMenuItemLink_Click);
            // 
            // addToPatchToolStripMenuItemLink
            // 
            this.addToPatchToolStripMenuItemLink.Name = "addToPatchToolStripMenuItemLink";
            this.addToPatchToolStripMenuItemLink.Size = new System.Drawing.Size(152, 22);
            this.addToPatchToolStripMenuItemLink.Text = "Add to patch...";
            this.addToPatchToolStripMenuItemLink.Click += new System.EventHandler(this.addToPatchToolStripMenuItemLink_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // deleteLinksToolStripMenuItemLink
            // 
            this.deleteLinksToolStripMenuItemLink.Name = "deleteLinksToolStripMenuItemLink";
            this.deleteLinksToolStripMenuItemLink.Size = new System.Drawing.Size(152, 22);
            this.deleteLinksToolStripMenuItemLink.Text = "Delete link(s)";
            // 
            // FormNav
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 671);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormNav";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quake Nav Editor";
            this.Load += new System.EventHandler(this.FormNav_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.contextMenuStripNode.ResumeLayout(false);
            this.contextMenuStripLink.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Label labelNodes;
        private System.Windows.Forms.Label labelLinks;
        private System.Windows.Forms.ListView listViewNodes;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.ColumnHeader columnHeaderX;
        private System.Windows.Forms.ColumnHeader columnHeaderY;
        private System.Windows.Forms.ColumnHeader columnHeaderZ;
        private System.Windows.Forms.ColumnHeader columnHeaderFlags;
        private System.Windows.Forms.ColumnHeader columnHeaderRadius;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newNavFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ListView listViewLinks;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ColumnHeader columnHeaderLinkId;
        private System.Windows.Forms.ColumnHeader columnHeaderLinkDestination;
        private System.Windows.Forms.ColumnHeader columnHeaderLinkType;
        private System.Windows.Forms.ColumnHeader columnHeaderLinkEdict;
        private System.Windows.Forms.ColumnHeader columnHeaderLinkTraversal;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddNode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddLink;
        private System.Windows.Forms.ToolStripMenuItem patchToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteNode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonShowNodeIds;
        private System.Windows.Forms.ToolStripButton toolStripButtonShowNodes;
        private System.Windows.Forms.ToolStripButton toolStripButtonShowLinks;
        private System.Windows.Forms.ToolStripButton toolStripButtonShowEdicts;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNode;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItemNode;
        private System.Windows.Forms.ToolStripMenuItem addToPatchToolStripMenuItemNode;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem deleteNodeToolStripMenuItemNode;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripLink;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItemLink;
        private System.Windows.Forms.ToolStripMenuItem addToPatchToolStripMenuItemLink;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem deleteLinksToolStripMenuItemLink;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonReload;
        private System.Windows.Forms.ToolStripButton toolStripButtonAutoReload;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAllTraversalsToolStripMenuItem;
    }
}