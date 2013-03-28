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
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolSave = new System.Windows.Forms.ToolStripButton();
			this.toolOpen = new System.Windows.Forms.ToolStripButton();
			this.toolPackage = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolOptions = new System.Windows.Forms.ToolStripButton();
			this.itemListView = new System.Windows.Forms.ListView();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSave,
            this.toolOpen,
            this.toolPackage,
            this.toolStripSeparator1,
            this.toolOptions});
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
			this.toolSave.Text = "toolSave";
			this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
			// 
			// toolOpen
			// 
			this.toolOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolOpen.Image = global::ItemPacker2013.Properties.Resources.folder;
			this.toolOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolOpen.Name = "toolOpen";
			this.toolOpen.Size = new System.Drawing.Size(36, 36);
			this.toolOpen.Text = "toolOpen";
			this.toolOpen.Click += new System.EventHandler(this.toolOpen_Click);
			// 
			// toolPackage
			// 
			this.toolPackage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolPackage.Image = global::ItemPacker2013.Properties.Resources.package;
			this.toolPackage.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolPackage.Name = "toolPackage";
			this.toolPackage.Size = new System.Drawing.Size(36, 36);
			this.toolPackage.Text = "toolPakage";
			this.toolPackage.Click += new System.EventHandler(this.toolPackage_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
			// 
			// toolOptions
			// 
			this.toolOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolOptions.Image = global::ItemPacker2013.Properties.Resources.setting_tools;
			this.toolOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolOptions.Name = "toolOptions";
			this.toolOptions.Size = new System.Drawing.Size(36, 36);
			this.toolOptions.Text = "toolSettings";
			this.toolOptions.Click += new System.EventHandler(this.toolOptions_Click);
			// 
			// itemListView
			// 
			this.itemListView.Dock = System.Windows.Forms.DockStyle.Fill;
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
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(790, 478);
			this.Controls.Add(this.itemListView);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
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
	}
}

