namespace ItemPacker2013
{
	partial class SettingsForm
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
			System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "Name",
            "String",
            "-",
            ""}, -1);
			System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(new string[] {
            "Price",
            "Int",
            "-1",
            "0"}, -1);
			this.label1 = new System.Windows.Forms.Label();
			this.settingGMXsource = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.settingGMXspritePattern = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.settingItemGroups = new System.Windows.Forms.ListBox();
			this.label4 = new System.Windows.Forms.Label();
			this.settingDefinitions = new System.Windows.Forms.ListView();
			this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnDropdown = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnDefault = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label5 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.settingGMXglobalItemsName = new System.Windows.Forms.TextBox();
			this.settingsGroupDefinitions = new System.Windows.Forms.ListBox();
			this.label7 = new System.Windows.Forms.Label();
			this.groupEditB = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.groupAddB = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.attrAddB = new System.Windows.Forms.Button();
			this.attrEditB = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.attrDeleteB = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "GMX Project Source:";
			// 
			// settingGMXsource
			// 
			this.settingGMXsource.Location = new System.Drawing.Point(12, 25);
			this.settingGMXsource.Name = "settingGMXsource";
			this.settingGMXsource.ReadOnly = true;
			this.settingGMXsource.Size = new System.Drawing.Size(568, 20);
			this.settingGMXsource.TabIndex = 1;
			this.settingGMXsource.WordWrap = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(101, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Item Sprites pattern:";
			// 
			// settingGMXspritePattern
			// 
			this.settingGMXspritePattern.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.settingGMXspritePattern.Location = new System.Drawing.Point(12, 77);
			this.settingGMXspritePattern.Name = "settingGMXspritePattern";
			this.settingGMXspritePattern.Size = new System.Drawing.Size(327, 21);
			this.settingGMXspritePattern.TabIndex = 3;
			this.settingGMXspritePattern.Text = "sprInv*|sprEquip*";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label3.Location = new System.Drawing.Point(11, 61);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(326, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "(ex: sprInv* you can also split more using | like: sprInv*|*equip|oth*er)";
			// 
			// settingItemGroups
			// 
			this.settingItemGroups.FormattingEnabled = true;
			this.settingItemGroups.Items.AddRange(new object[] {
            "Default"});
			this.settingItemGroups.Location = new System.Drawing.Point(12, 157);
			this.settingItemGroups.Name = "settingItemGroups";
			this.settingItemGroups.Size = new System.Drawing.Size(104, 134);
			this.settingItemGroups.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 141);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(67, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Item Groups:";
			// 
			// settingDefinitions
			// 
			this.settingDefinitions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnType,
            this.columnDropdown,
            this.columnDefault});
			this.settingDefinitions.FullRowSelect = true;
			this.settingDefinitions.GridLines = true;
			this.settingDefinitions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.settingDefinitions.HideSelection = false;
			this.settingDefinitions.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem7,
            listViewItem8});
			this.settingDefinitions.LabelWrap = false;
			this.settingDefinitions.Location = new System.Drawing.Point(123, 157);
			this.settingDefinitions.MultiSelect = false;
			this.settingDefinitions.Name = "settingDefinitions";
			this.settingDefinitions.ShowGroups = false;
			this.settingDefinitions.Size = new System.Drawing.Size(340, 134);
			this.settingDefinitions.TabIndex = 7;
			this.settingDefinitions.UseCompatibleStateImageBehavior = false;
			this.settingDefinitions.View = System.Windows.Forms.View.Details;
			// 
			// columnName
			// 
			this.columnName.Text = "Attr Name";
			this.columnName.Width = 105;
			// 
			// columnType
			// 
			this.columnType.Text = "Type";
			this.columnType.Width = 50;
			// 
			// columnDropdown
			// 
			this.columnDropdown.Text = "Dropdown Group";
			this.columnDropdown.Width = 95;
			// 
			// columnDefault
			// 
			this.columnDefault.Text = "Default Value";
			this.columnDefault.Width = 83;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(120, 141);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(77, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Item Attributes:";
			// 
			// button3
			// 
			this.button3.Enabled = false;
			this.button3.Location = new System.Drawing.Point(586, 23);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(25, 24);
			this.button3.TabIndex = 11;
			this.button3.Text = "...";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.Enabled = false;
			this.button4.Location = new System.Drawing.Point(344, 75);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(25, 24);
			this.button4.TabIndex = 12;
			this.button4.Text = "...";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(13, 101);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(252, 13);
			this.label6.TabIndex = 19;
			this.label6.Text = "Global variable name for items 2D array (without [ ] ):";
			// 
			// settingGMXglobalItemsName
			// 
			this.settingGMXglobalItemsName.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.settingGMXglobalItemsName.Location = new System.Drawing.Point(12, 117);
			this.settingGMXglobalItemsName.Name = "settingGMXglobalItemsName";
			this.settingGMXglobalItemsName.Size = new System.Drawing.Size(163, 21);
			this.settingGMXglobalItemsName.TabIndex = 20;
			this.settingGMXglobalItemsName.Text = "global.items";
			// 
			// settingsGroupDefinitions
			// 
			this.settingsGroupDefinitions.FormattingEnabled = true;
			this.settingsGroupDefinitions.Location = new System.Drawing.Point(469, 157);
			this.settingsGroupDefinitions.Name = "settingsGroupDefinitions";
			this.settingsGroupDefinitions.Size = new System.Drawing.Size(140, 134);
			this.settingsGroupDefinitions.TabIndex = 21;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(466, 141);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(96, 13);
			this.label7.TabIndex = 22;
			this.label7.Text = "Dropdown Groups:";
			// 
			// groupEditB
			// 
			this.groupEditB.Image = global::ItemPacker2013.Properties.Resources.pencil;
			this.groupEditB.Location = new System.Drawing.Point(555, 297);
			this.groupEditB.Name = "groupEditB";
			this.groupEditB.Size = new System.Drawing.Size(24, 24);
			this.groupEditB.TabIndex = 25;
			this.groupEditB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.groupEditB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.groupEditB.UseVisualStyleBackColor = true;
			this.groupEditB.Click += new System.EventHandler(this.groupEditB_Click);
			// 
			// button7
			// 
			this.button7.Enabled = false;
			this.button7.Image = global::ItemPacker2013.Properties.Resources.delete;
			this.button7.Location = new System.Drawing.Point(585, 297);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(24, 24);
			this.button7.TabIndex = 24;
			this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button7.UseVisualStyleBackColor = true;
			// 
			// groupAddB
			// 
			this.groupAddB.Image = global::ItemPacker2013.Properties.Resources.add;
			this.groupAddB.Location = new System.Drawing.Point(525, 297);
			this.groupAddB.Name = "groupAddB";
			this.groupAddB.Size = new System.Drawing.Size(24, 24);
			this.groupAddB.TabIndex = 23;
			this.groupAddB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.groupAddB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.groupAddB.UseVisualStyleBackColor = true;
			this.groupAddB.Click += new System.EventHandler(this.groupAddB_Click);
			// 
			// button10
			// 
			this.button10.Enabled = false;
			this.button10.Image = global::ItemPacker2013.Properties.Resources.pencil;
			this.button10.Location = new System.Drawing.Point(42, 297);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(24, 24);
			this.button10.TabIndex = 18;
			this.button10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button10.UseVisualStyleBackColor = true;
			// 
			// button9
			// 
			this.button9.Enabled = false;
			this.button9.Image = global::ItemPacker2013.Properties.Resources.delete;
			this.button9.Location = new System.Drawing.Point(72, 297);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(24, 24);
			this.button9.TabIndex = 17;
			this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button9.UseVisualStyleBackColor = true;
			// 
			// attrAddB
			// 
			this.attrAddB.Image = global::ItemPacker2013.Properties.Resources.add;
			this.attrAddB.Location = new System.Drawing.Point(379, 297);
			this.attrAddB.Name = "attrAddB";
			this.attrAddB.Size = new System.Drawing.Size(24, 24);
			this.attrAddB.TabIndex = 16;
			this.attrAddB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.attrAddB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.attrAddB.UseVisualStyleBackColor = true;
			this.attrAddB.Click += new System.EventHandler(this.attrAddB_Click);
			// 
			// attrEditB
			// 
			this.attrEditB.Image = global::ItemPacker2013.Properties.Resources.pencil;
			this.attrEditB.Location = new System.Drawing.Point(409, 297);
			this.attrEditB.Name = "attrEditB";
			this.attrEditB.Size = new System.Drawing.Size(24, 24);
			this.attrEditB.TabIndex = 15;
			this.attrEditB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.attrEditB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.attrEditB.UseVisualStyleBackColor = true;
			this.attrEditB.Click += new System.EventHandler(this.attrEditB_Click);
			// 
			// button6
			// 
			this.button6.Enabled = false;
			this.button6.Image = global::ItemPacker2013.Properties.Resources.add;
			this.button6.Location = new System.Drawing.Point(12, 297);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(24, 24);
			this.button6.TabIndex = 14;
			this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button6.UseVisualStyleBackColor = true;
			// 
			// attrDeleteB
			// 
			this.attrDeleteB.Image = global::ItemPacker2013.Properties.Resources.delete;
			this.attrDeleteB.Location = new System.Drawing.Point(439, 297);
			this.attrDeleteB.Name = "attrDeleteB";
			this.attrDeleteB.Size = new System.Drawing.Size(24, 24);
			this.attrDeleteB.TabIndex = 13;
			this.attrDeleteB.UseVisualStyleBackColor = true;
			this.attrDeleteB.Click += new System.EventHandler(this.attrDeleteB_Click);
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.button2.Image = global::ItemPacker2013.Properties.Resources.cross;
			this.button2.Location = new System.Drawing.Point(469, 327);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(80, 32);
			this.button2.TabIndex = 10;
			this.button2.Text = "Cancel";
			this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.button1.Image = global::ItemPacker2013.Properties.Resources.tick;
			this.button1.Location = new System.Drawing.Point(555, 327);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(54, 32);
			this.button1.TabIndex = 9;
			this.button1.Text = "OK";
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button8
			// 
			this.button8.Image = global::ItemPacker2013.Properties.Resources.arrow_down;
			this.button8.Location = new System.Drawing.Point(153, 297);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(24, 24);
			this.button8.TabIndex = 26;
			this.button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button8.UseVisualStyleBackColor = true;
			// 
			// button11
			// 
			this.button11.Image = global::ItemPacker2013.Properties.Resources.arrow_up;
			this.button11.Location = new System.Drawing.Point(123, 297);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(24, 24);
			this.button11.TabIndex = 27;
			this.button11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button11.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button11.UseVisualStyleBackColor = true;
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(623, 373);
			this.Controls.Add(this.button11);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.groupEditB);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.groupAddB);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.settingsGroupDefinitions);
			this.Controls.Add(this.settingGMXglobalItemsName);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.button10);
			this.Controls.Add(this.button9);
			this.Controls.Add(this.attrAddB);
			this.Controls.Add(this.attrEditB);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.attrDeleteB);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.settingDefinitions);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.settingItemGroups);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.settingGMXspritePattern);
			this.Controls.Add(this.settingGMXsource);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Settings";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ColumnHeader columnName;
		private System.Windows.Forms.ColumnHeader columnType;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		public System.Windows.Forms.TextBox settingGMXsource;
		private System.Windows.Forms.Button attrDeleteB;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button attrEditB;
		private System.Windows.Forms.Button attrAddB;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Label label6;
		public System.Windows.Forms.TextBox settingGMXspritePattern;
		public System.Windows.Forms.ListBox settingItemGroups;
		public System.Windows.Forms.ListView settingDefinitions;
		public System.Windows.Forms.TextBox settingGMXglobalItemsName;
		private System.Windows.Forms.ColumnHeader columnDropdown;
		public System.Windows.Forms.ListBox settingsGroupDefinitions;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button groupEditB;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button groupAddB;
		private System.Windows.Forms.ColumnHeader columnDefault;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button11;
	}
}