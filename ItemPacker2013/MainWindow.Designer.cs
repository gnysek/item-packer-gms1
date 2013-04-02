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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.itemListView = new System.Windows.Forms.ListView();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.toolSave = new System.Windows.Forms.ToolStripButton();
			this.toolOpen = new System.Windows.Forms.ToolStripButton();
			this.toolPackage = new System.Windows.Forms.ToolStripButton();
			this.toolOptions = new System.Windows.Forms.ToolStripButton();
			this.toolAddItem = new System.Windows.Forms.ToolStripButton();
			this.toolEditItem = new System.Windows.Forms.ToolStripButton();
			this.toolViewIcons = new System.Windows.Forms.ToolStripButton();
			this.toolViewDetail = new System.Windows.Forms.ToolStripButton();
			this.toolExport = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1.SuspendLayout();
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
            this.toolOptions,
            this.toolStripSeparator2,
            this.toolAddItem,
            this.toolEditItem,
            this.toolStripSeparator3,
            this.toolViewIcons,
            this.toolViewDetail,
            this.toolStripSeparator4,
            this.toolExport});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(790, 39);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
			// 
			// itemListView
			// 
			this.itemListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemListView.FullRowSelect = true;
			this.itemListView.GridLines = true;
			this.itemListView.Location = new System.Drawing.Point(0, 39);
			this.itemListView.Name = "itemListView";
			this.itemListView.Size = new System.Drawing.Size(790, 417);
			this.itemListView.TabIndex = 1;
			this.itemListView.UseCompatibleStateImageBehavior = false;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 456);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(790, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.SupportMultiDottedExtensions = true;
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
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
			// toolOptions
			// 
			this.toolOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolOptions.Image = global::ItemPacker2013.Properties.Resources.setting_tools;
			this.toolOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolOptions.Name = "toolOptions";
			this.toolOptions.Size = new System.Drawing.Size(36, 36);
			this.toolOptions.Text = "Global Settings";
			this.toolOptions.Click += new System.EventHandler(this.toolOptions_Click);
			// 
			// toolAddItem
			// 
			this.toolAddItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolAddItem.Image = global::ItemPacker2013.Properties.Resources.database_add;
			this.toolAddItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolAddItem.Name = "toolAddItem";
			this.toolAddItem.Size = new System.Drawing.Size(36, 36);
			this.toolAddItem.Text = "Add Item";
			this.toolAddItem.Click += new System.EventHandler(this.toolAddItem_Click);
			// 
			// toolEditItem
			// 
			this.toolEditItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolEditItem.Image = global::ItemPacker2013.Properties.Resources.database_edit;
			this.toolEditItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolEditItem.Name = "toolEditItem";
			this.toolEditItem.Size = new System.Drawing.Size(36, 36);
			this.toolEditItem.Text = "toolEditItem";
			this.toolEditItem.Click += new System.EventHandler(this.toolEditItem_Click);
			// 
			// toolViewIcons
			// 
			this.toolViewIcons.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolViewIcons.Image = global::ItemPacker2013.Properties.Resources.application_view_icons;
			this.toolViewIcons.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolViewIcons.Name = "toolViewIcons";
			this.toolViewIcons.Size = new System.Drawing.Size(36, 36);
			this.toolViewIcons.Text = "toolStripButton1";
			this.toolViewIcons.Click += new System.EventHandler(this.toolViewIcons_Click);
			// 
			// toolViewDetail
			// 
			this.toolViewDetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolViewDetail.Image = global::ItemPacker2013.Properties.Resources.application_view_detail;
			this.toolViewDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolViewDetail.Name = "toolViewDetail";
			this.toolViewDetail.Size = new System.Drawing.Size(36, 36);
			this.toolViewDetail.Text = "toolStripButton2";
			this.toolViewDetail.Click += new System.EventHandler(this.toolViewDetail_Click);
			// 
			// toolExport
			// 
			this.toolExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolExport.Image = global::ItemPacker2013.Properties.Resources.page_white_code;
			this.toolExport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolExport.Name = "toolExport";
			this.toolExport.Size = new System.Drawing.Size(36, 36);
			this.toolExport.Text = "toolStripButton1";
			this.toolExport.Click += new System.EventHandler(this.toolExport_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(790, 478);
			this.Controls.Add(this.itemListView);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Extendible Item Editor (C) by Gear-Studio 2013";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
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
		private System.Windows.Forms.ListView itemListView;
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
	}
}

