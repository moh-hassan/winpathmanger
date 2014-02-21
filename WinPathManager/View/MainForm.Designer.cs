namespace WinPathManager
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportPathToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.ListViewToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.TextViewToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.AddToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.RemoveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ExportToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.userControlPathView1 = new WinPathManager.UserControlPathView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.userControlViewText1 = new WinPathManager.UserControls.UserControlViewText();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.userControlAddEntry1 = new WinPathManager.UserControls.UserControlAddEntry();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.userControlRemoveEntry1 = new WinPathManager.UserControls.UserControlRemoveEntry();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.userControlReorder1 = new WinPathManager.UserControls.UserControlReorder();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(603, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportPathToFileToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exportPathToFileToolStripMenuItem
            // 
            this.exportPathToFileToolStripMenuItem.Name = "exportPathToFileToolStripMenuItem";
            this.exportPathToFileToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.exportPathToFileToolStripMenuItem.Text = "Export Path to File";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewEntryToolStripMenuItem,
            this.removeEntryToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // addNewEntryToolStripMenuItem
            // 
            this.addNewEntryToolStripMenuItem.Name = "addNewEntryToolStripMenuItem";
            this.addNewEntryToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.addNewEntryToolStripMenuItem.Text = "Add New Entry";
            // 
            // removeEntryToolStripMenuItem
            // 
            this.removeEntryToolStripMenuItem.Name = "removeEntryToolStripMenuItem";
            this.removeEntryToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.removeEntryToolStripMenuItem.Text = "Remove Entry";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(641, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "edit-remove-3.ico");
            this.imageList1.Images.SetKeyName(1, "document-preview.ico");
            this.imageList1.Images.SetKeyName(2, "view-refresh-3.ico");
            this.imageList1.Images.SetKeyName(3, "edit-add-2.ico");
            this.imageList1.Images.SetKeyName(4, "document-export.ico");
            this.imageList1.Images.SetKeyName(5, "system-settings.ico");
            this.imageList1.Images.SetKeyName(6, "view-list-details-3.ico");
            this.imageList1.Images.SetKeyName(7, "view-list-icons-2.ico");
            this.imageList1.Images.SetKeyName(8, "format-list-ordered.ico");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 484);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(603, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ListViewToolStripButton,
            this.TextViewToolStripButton,
            this.AddToolStripButton,
            this.RemoveToolStripButton,
            this.ExportToolStripButton,
            this.RefreshToolStripButton});
            this.toolStrip2.Location = new System.Drawing.Point(0, 24);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(603, 25);
            this.toolStrip2.TabIndex = 6;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // ListViewToolStripButton
            // 
            this.ListViewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ListViewToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ListViewToolStripButton.Image")));
            this.ListViewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ListViewToolStripButton.Name = "ListViewToolStripButton";
            this.ListViewToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ListViewToolStripButton.Text = "Path List";
            // 
            // TextViewToolStripButton
            // 
            this.TextViewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TextViewToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("TextViewToolStripButton.Image")));
            this.TextViewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TextViewToolStripButton.Name = "TextViewToolStripButton";
            this.TextViewToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.TextViewToolStripButton.Text = "Preview Text";
            // 
            // AddToolStripButton
            // 
            this.AddToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AddToolStripButton.Image")));
            this.AddToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddToolStripButton.Name = "AddToolStripButton";
            this.AddToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.AddToolStripButton.Text = "Add Entry";
            // 
            // RemoveToolStripButton
            // 
            this.RemoveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RemoveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("RemoveToolStripButton.Image")));
            this.RemoveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveToolStripButton.Name = "RemoveToolStripButton";
            this.RemoveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.RemoveToolStripButton.Text = "Remove Entry";
            // 
            // ExportToolStripButton
            // 
            this.ExportToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ExportToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ExportToolStripButton.Image")));
            this.ExportToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExportToolStripButton.Name = "ExportToolStripButton";
            this.ExportToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ExportToolStripButton.Text = "Export";
            // 
            // RefreshToolStripButton
            // 
            this.RefreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefreshToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshToolStripButton.Image")));
            this.RefreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshToolStripButton.Name = "RefreshToolStripButton";
            this.RefreshToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.RefreshToolStripButton.Text = "Refresh";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 49);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(603, 435);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.userControlPathView1);
            this.tabPage1.ImageIndex = 6;
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(595, 408);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "View Path List";
            // 
            // userControlPathView1
            // 
            this.userControlPathView1.Location = new System.Drawing.Point(0, 0);
            this.userControlPathView1.Name = "userControlPathView1";
            this.userControlPathView1.Size = new System.Drawing.Size(612, 388);
            this.userControlPathView1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.userControlViewText1);
            this.tabPage4.ImageIndex = 1;
            this.tabPage4.Location = new System.Drawing.Point(4, 23);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(595, 408);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "View Path Text";
            // 
            // userControlViewText1
            // 
            this.userControlViewText1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlViewText1.Location = new System.Drawing.Point(0, 0);
            this.userControlViewText1.Name = "userControlViewText1";
            this.userControlViewText1.Size = new System.Drawing.Size(192, 74);
            this.userControlViewText1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.userControlAddEntry1);
            this.tabPage2.ImageIndex = 3;
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(595, 408);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Add Entry";
            // 
            // userControlAddEntry1
            // 
            this.userControlAddEntry1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlAddEntry1.Location = new System.Drawing.Point(3, 3);
            this.userControlAddEntry1.Name = "userControlAddEntry1";
            this.userControlAddEntry1.Size = new System.Drawing.Size(186, 68);
            this.userControlAddEntry1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.userControlRemoveEntry1);
            this.tabPage3.ImageIndex = 0;
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(595, 408);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Remove Entry";
            // 
            // userControlRemoveEntry1
            // 
            this.userControlRemoveEntry1.DataSource = ((object)(resources.GetObject("userControlRemoveEntry1.DataSource")));
            this.userControlRemoveEntry1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlRemoveEntry1.Location = new System.Drawing.Point(0, 0);
            this.userControlRemoveEntry1.Name = "userControlRemoveEntry1";
            this.userControlRemoveEntry1.Size = new System.Drawing.Size(192, 74);
            this.userControlRemoveEntry1.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.userControlReorder1);
            this.tabPage5.ImageIndex = 8;
            this.tabPage5.Location = new System.Drawing.Point(4, 23);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(595, 408);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "ReOrder";
            // 
            // userControlReorder1
            // 
            this.userControlReorder1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlReorder1.Location = new System.Drawing.Point(0, 0);
            this.userControlReorder1.Name = "userControlReorder1";
            this.userControlReorder1.SelectedIndex = -1;
            this.userControlReorder1.Size = new System.Drawing.Size(192, 74);
            this.userControlReorder1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 506);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Window Path Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem addNewEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportPathToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton AddToolStripButton;
        private System.Windows.Forms.ToolStripButton RemoveToolStripButton;
        private System.Windows.Forms.ToolStripButton ExportToolStripButton;
        private System.Windows.Forms.ToolStripButton TextViewToolStripButton;
        private System.Windows.Forms.ToolStripButton RefreshToolStripButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private UserControls.UserControlViewText userControlViewText1;
        private System.Windows.Forms.ToolStripButton ListViewToolStripButton;
        private UserControls.UserControlAddEntry userControlAddEntry1;
        private UserControls.UserControlRemoveEntry userControlRemoveEntry1;
        private System.Windows.Forms.TabPage tabPage5;
        private UserControlPathView userControlPathView1;
        private UserControls.UserControlReorder userControlReorder1;
    }
}

