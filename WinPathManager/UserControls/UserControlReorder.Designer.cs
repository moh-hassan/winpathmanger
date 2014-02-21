namespace WinPathManager.UserControls
{
    partial class UserControlReorder
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlReorder));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listBoxCurrentPath = new System.Windows.Forms.ListBox();
            this.buttonTop = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonBottom = new System.Windows.Forms.Button();
            this.buttonSort = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.10866F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.89134F));
            this.tableLayoutPanel1.Controls.Add(this.buttonSave, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.listBoxCurrentPath, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonTop, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonUp, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonDown, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonBottom, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonSort, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonReset, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.18899F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.202957F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.860312F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.531634F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.531634F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.47541F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.47541F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.81967F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(543, 305);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSave.ImageIndex = 6;
            this.buttonSave.ImageList = this.imageList1;
            this.buttonSave.Location = new System.Drawing.Point(476, 179);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(64, 28);
            this.buttonSave.TabIndex = 20;
            this.buttonSave.Text = "Save";
            this.buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "arrow-up-3.ico");
            this.imageList1.Images.SetKeyName(1, "arrow-down-double-3.ico");
            this.imageList1.Images.SetKeyName(2, "arrow-down-3.ico");
            this.imageList1.Images.SetKeyName(3, "arrow-up-double-3.ico");
            this.imageList1.Images.SetKeyName(4, "edit-sort-increase.ico");
            this.imageList1.Images.SetKeyName(5, "format-list-unordered.ico");
            this.imageList1.Images.SetKeyName(6, "document-save-6.ico");
            // 
            // listBoxCurrentPath
            // 
            this.listBoxCurrentPath.BackColor = System.Drawing.SystemColors.HighlightText;
            this.listBoxCurrentPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxCurrentPath.FormattingEnabled = true;
            this.listBoxCurrentPath.Location = new System.Drawing.Point(3, 3);
            this.listBoxCurrentPath.Name = "listBoxCurrentPath";
            this.tableLayoutPanel1.SetRowSpan(this.listBoxCurrentPath, 8);
            this.listBoxCurrentPath.Size = new System.Drawing.Size(467, 299);
            this.listBoxCurrentPath.TabIndex = 19;
            // 
            // buttonTop
            // 
            this.buttonTop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTop.ImageIndex = 3;
            this.buttonTop.ImageList = this.imageList1;
            this.buttonTop.Location = new System.Drawing.Point(476, 3);
            this.buttonTop.Name = "buttonTop";
            this.buttonTop.Size = new System.Drawing.Size(64, 23);
            this.buttonTop.TabIndex = 0;
            this.buttonTop.Text = "Top";
            this.buttonTop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonTop.UseVisualStyleBackColor = true;
            // 
            // buttonUp
            // 
            this.buttonUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUp.ImageIndex = 0;
            this.buttonUp.ImageList = this.imageList1;
            this.buttonUp.Location = new System.Drawing.Point(476, 33);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(64, 21);
            this.buttonUp.TabIndex = 1;
            this.buttonUp.Text = "Up";
            this.buttonUp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonUp.UseVisualStyleBackColor = true;
            // 
            // buttonDown
            // 
            this.buttonDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDown.ImageIndex = 2;
            this.buttonDown.ImageList = this.imageList1;
            this.buttonDown.Location = new System.Drawing.Point(476, 60);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(64, 23);
            this.buttonDown.TabIndex = 2;
            this.buttonDown.Text = "Down";
            this.buttonDown.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDown.UseVisualStyleBackColor = true;
            // 
            // buttonBottom
            // 
            this.buttonBottom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBottom.ImageIndex = 1;
            this.buttonBottom.ImageList = this.imageList1;
            this.buttonBottom.Location = new System.Drawing.Point(476, 89);
            this.buttonBottom.Name = "buttonBottom";
            this.buttonBottom.Size = new System.Drawing.Size(64, 22);
            this.buttonBottom.TabIndex = 3;
            this.buttonBottom.Text = "Buttom";
            this.buttonBottom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonBottom.UseVisualStyleBackColor = true;
            // 
            // buttonSort
            // 
            this.buttonSort.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSort.ImageIndex = 4;
            this.buttonSort.ImageList = this.imageList1;
            this.buttonSort.Location = new System.Drawing.Point(476, 117);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(64, 22);
            this.buttonSort.TabIndex = 4;
            this.buttonSort.Text = "Sort";
            this.buttonSort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSort.UseVisualStyleBackColor = true;
            // 
            // buttonReset
            // 
            this.buttonReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonReset.ImageIndex = 5;
            this.buttonReset.ImageList = this.imageList1;
            this.buttonReset.Location = new System.Drawing.Point(476, 145);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(64, 23);
            this.buttonReset.TabIndex = 5;
            this.buttonReset.Text = "Reset";
            this.buttonReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonReset.UseVisualStyleBackColor = true;
            // 
            // UserControlReorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserControlReorder";
            this.Size = new System.Drawing.Size(543, 305);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonTop;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonBottom;
        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.ListBox listBoxCurrentPath;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button buttonSave;
    }
}
