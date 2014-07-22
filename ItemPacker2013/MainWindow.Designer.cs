namespace ItemPacker2013
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolSave = new System.Windows.Forms.ToolStripButton();
			this.toolOpen = new System.Windows.Forms.ToolStripButton();
			this.toolPackage = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolAddItem = new System.Windows.Forms.ToolStripButton();
			this.toolEditItem = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolViewIcons = new System.Windows.Forms.ToolStripButton();
			this.toolViewDetail = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.toolExport = new System.Windows.Forms.ToolStripButton();
			this.toolExportCSV = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolOptions = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.toolImportCSV = new System.Windows.Forms.ToolStripButton();
			this.imageListBig = new System.Windows.Forms.ImageList(this.components);
			this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.itemListViewExt = new BrightIdeasSoftware.FastObjectListView();
			this.toolFilterBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.toolStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.itemListViewExt)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSave,
            this.toolOpen,
            this.toolPackage,
            this.toolStripSeparator1,
            this.toolAddItem,
            this.toolEditItem,
            this.toolStripSeparator3,
            this.toolViewIcons,
            this.toolViewDetail,
            this.toolStripSeparator4,
            this.toolExport,
            this.toolExportCSV,
            this.toolStripSeparator2,
            this.toolOptions,
            this.toolStripSeparator5,
            this.toolImportCSV});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(790, 39);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolSave
			// 
			this.toolSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolSave.Image = global::ItemPacker2013.Properties.Resources.disk;
			this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolSave.Name = "toolSave";
			this.toolSave.Size = new System.Drawing.Size(36, 36);
			this.toolSave.Text = "Save";
			this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
			// 
			// toolOpen
			// 
			this.toolOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolOpen.Image = global::ItemPacker2013.Properties.Resources.folder;
			this.toolOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolOpen.Name = "toolOpen";
			this.toolOpen.Size = new System.Drawing.Size(36, 36);
			this.toolOpen.Text = "Open...";
			this.toolOpen.Click += new System.EventHandler(this.toolOpen_Click);
			// 
			// toolPackage
			// 
			this.toolPackage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolPackage.Image = global::ItemPacker2013.Properties.Resources.package;
			this.toolPackage.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolPackage.Name = "toolPackage";
			this.toolPackage.Size = new System.Drawing.Size(36, 36);
			this.toolPackage.Text = "Create new Project...";
			this.toolPackage.Click += new System.EventHandler(this.toolPackage_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
			// 
			// toolAddItem
			// 
			this.toolAddItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolAddItem.Image = global::ItemPacker2013.Properties.Resources.database_add;
			this.toolAddItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolAddItem.Name = "toolAddItem";
			this.toolAddItem.Size = new System.Drawing.Size(36, 36);
			this.toolAddItem.Text = "Add Item...";
			this.toolAddItem.Click += new System.EventHandler(this.toolAddItem_Click);
			// 
			// toolEditItem
			// 
			this.toolEditItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolEditItem.Image = global::ItemPacker2013.Properties.Resources.database_edit;
			this.toolEditItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolEditItem.Name = "toolEditItem";
			this.toolEditItem.Size = new System.Drawing.Size(36, 36);
			this.toolEditItem.Text = "Edit Item...";
			this.toolEditItem.Click += new System.EventHandler(this.toolEditItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
			// 
			// toolViewIcons
			// 
			this.toolViewIcons.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolViewIcons.Image = global::ItemPacker2013.Properties.Resources.application_view_icons;
			this.toolViewIcons.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolViewIcons.Name = "toolViewIcons";
			this.toolViewIcons.Size = new System.Drawing.Size(36, 36);
			this.toolViewIcons.Text = "Icon View";
			this.toolViewIcons.Click += new System.EventHandler(this.toolViewIcons_Click);
			// 
			// toolViewDetail
			// 
			this.toolViewDetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolViewDetail.Image = global::ItemPacker2013.Properties.Resources.application_view_detail;
			this.toolViewDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolViewDetail.Name = "toolViewDetail";
			this.toolViewDetail.Size = new System.Drawing.Size(36, 36);
			this.toolViewDetail.Text = "Detail View";
			this.toolViewDetail.Click += new System.EventHandler(this.toolViewDetail_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
			// 
			// toolExport
			// 
			this.toolExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolExport.Image = global::ItemPacker2013.Properties.Resources.page_white_code;
			this.toolExport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolExport.Name = "toolExport";
			this.toolExport.Size = new System.Drawing.Size(36, 36);
			this.toolExport.Text = "Export to GML";
			this.toolExport.Click += new System.EventHandler(this.toolExport_Click);
			// 
			// toolExportCSV
			// 
			this.toolExportCSV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolExportCSV.Image = global::ItemPacker2013.Properties.Resources.page_white_excel;
			this.toolExportCSV.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolExportCSV.Name = "toolExportCSV";
			this.toolExportCSV.Size = new System.Drawing.Size(36, 36);
			this.toolExportCSV.Text = "Export to CSV...";
			this.toolExportCSV.Click += new System.EventHandler(this.toolExportCSV_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
			// 
			// toolOptions
			// 
			this.toolOptions.Image = global::ItemPacker2013.Properties.Resources.setting_tools;
			this.toolOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolOptions.Name = "toolOptions";
			this.toolOptions.Size = new System.Drawing.Size(125, 36);
			this.toolOptions.Text = "Project Settings";
			this.toolOptions.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.toolOptions.ToolTipText = "Project Settings...";
			this.toolOptions.Click += new System.EventHandler(this.toolOptions_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
			// 
			// toolImportCSV
			// 
			this.toolImportCSV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolImportCSV.Image = global::ItemPacker2013.Properties.Resources.page_white_get;
			this.toolImportCSV.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolImportCSV.Name = "toolImportCSV";
			this.toolImportCSV.Size = new System.Drawing.Size(36, 36);
			this.toolImportCSV.Text = "CSV Import";
			this.toolImportCSV.Click += new System.EventHandler(this.toolImportCSV_Click);
			// 
			// imageListBig
			// 
			this.imageListBig.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListBig.ImageStream")));
			this.imageListBig.TransparentColor = System.Drawing.Color.Transparent;
			this.imageListBig.Images.SetKeyName(0, "error.png");
			// 
			// imageListSmall
			// 
			this.imageListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListSmall.ImageStream")));
			this.imageListSmall.TransparentColor = System.Drawing.Color.Transparent;
			this.imageListSmall.Images.SetKeyName(0, "error.png");
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 456);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(790, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(12, 17);
			this.toolStripStatusLabel1.Text = "-";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.SupportMultiDottedExtensions = true;
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.CreatePrompt = true;
			this.saveFileDialog1.DefaultExt = "*.gml";
			this.saveFileDialog1.Filter = "GML files|*gml";
			// 
			// itemListViewExt
			// 
			this.itemListViewExt.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.itemListViewExt.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemListViewExt.EmptyListMsg = "No items";
			this.itemListViewExt.EmptyListMsgFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.itemListViewExt.FullRowSelect = true;
			this.itemListViewExt.GridLines = true;
			this.itemListViewExt.HasCollapsibleGroups = false;
			this.itemListViewExt.HeaderUsesThemes = false;
			this.itemListViewExt.HideSelection = false;
			this.itemListViewExt.LabelWrap = false;
			this.itemListViewExt.LargeImageList = this.imageListBig;
			this.itemListViewExt.Location = new System.Drawing.Point(0, 39);
			this.itemListViewExt.MultiSelect = false;
			this.itemListViewExt.Name = "itemListViewExt";
			this.itemListViewExt.OwnerDraw = true;
			this.itemListViewExt.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
			this.itemListViewExt.ShowCommandMenuOnRightClick = true;
			this.itemListViewExt.ShowFilterMenuOnRightClick = false;
			this.itemListViewExt.ShowGroups = false;
			this.itemListViewExt.ShowImagesOnSubItems = true;
			this.itemListViewExt.ShowItemCountOnGroups = true;
			this.itemListViewExt.Size = new System.Drawing.Size(790, 417);
			this.itemListViewExt.SmallImageList = this.imageListSmall;
			this.itemListViewExt.SortGroupItemsByPrimaryColumn = false;
			this.itemListViewExt.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.itemListViewExt.TabIndex = 3;
			this.itemListViewExt.TintSortColumn = true;
			this.itemListViewExt.UseAlternatingBackColors = true;
			this.itemListViewExt.UseCompatibleStateImageBehavior = false;
			this.itemListViewExt.UseFilterIndicator = true;
			this.itemListViewExt.UseFiltering = true;
			this.itemListViewExt.View = System.Windows.Forms.View.Details;
			this.itemListViewExt.VirtualMode = true;
			this.itemListViewExt.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.itemListViewExt_FormatCell);
			this.itemListViewExt.SelectedIndexChanged += new System.EventHandler(this.itemListViewExt_SelectedIndexChanged);
			this.itemListViewExt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.itemListViewExt_MouseClick);
			this.itemListViewExt.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.itemListViewExt_MouseDoubleClick);
			// 
			// toolFilterBox
			// 
			this.toolFilterBox.Location = new System.Drawing.Point(678, 12);
			this.toolFilterBox.Name = "toolFilterBox";
			this.toolFilterBox.Size = new System.Drawing.Size(100, 20);
			this.toolFilterBox.TabIndex = 4;
			this.toolFilterBox.TextChanged += new System.EventHandler(this.toolFilterBox_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(637, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Filter:";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(790, 478);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.toolFilterBox);
			this.Controls.Add(this.itemListViewExt);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Extendible Item Editor (C) by Gear-Studio 2013";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.itemListViewExt)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolOpen;
		private System.Windows.Forms.ToolStripButton toolSave;
		private System.Windows.Forms.ToolStripButton toolPackage;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton toolOptions;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton toolAddItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton toolViewIcons;
		private System.Windows.Forms.ToolStripButton toolViewDetail;
		private System.Windows.Forms.ToolStripButton toolEditItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton toolExport;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ImageList imageListBig;
		private System.Windows.Forms.ToolStripButton toolExportCSV;
		private System.Windows.Forms.ToolStripButton toolImportCSV;
		private System.Windows.Forms.ImageList imageListSmall;
		private BrightIdeasSoftware.FastObjectListView itemListViewExt;
		private System.Windows.Forms.TextBox toolFilterBox;
		private System.Windows.Forms.Label label1;
	}
}

