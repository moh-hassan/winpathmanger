namespace WinPathManager
{
    partial class UserControlPathView
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonRepair = new System.Windows.Forms.Button();
            this.listBoxCurrentPath = new System.Windows.Forms.ListBox();
            this.labelPathLength = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.buttonRepair, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.listBoxCurrentPath, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelPathLength, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(612, 433);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // buttonRepair
            // 
            this.buttonRepair.Location = new System.Drawing.Point(3, 398);
            this.buttonRepair.Name = "buttonRepair";
            this.buttonRepair.Size = new System.Drawing.Size(75, 23);
            this.buttonRepair.TabIndex = 19;
            this.buttonRepair.Text = "Repair";
            this.buttonRepair.UseVisualStyleBackColor = true;
            // 
            // listBoxCurrentPath
            // 
            this.listBoxCurrentPath.BackColor = System.Drawing.SystemColors.HighlightText;
            this.listBoxCurrentPath.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBoxCurrentPath.FormattingEnabled = true;
            this.listBoxCurrentPath.Location = new System.Drawing.Point(3, 101);
            this.listBoxCurrentPath.Name = "listBoxCurrentPath";
            this.listBoxCurrentPath.Size = new System.Drawing.Size(588, 291);
            this.listBoxCurrentPath.TabIndex = 18;
            // 
            // labelPathLength
            // 
            this.labelPathLength.AutoSize = true;
            this.labelPathLength.Location = new System.Drawing.Point(3, 61);
            this.labelPathLength.Name = "labelPathLength";
            this.labelPathLength.Size = new System.Drawing.Size(35, 13);
            this.labelPathLength.TabIndex = 17;
            this.labelPathLength.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 55);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select List";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(151, 24);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(68, 17);
            this.radioButton3.TabIndex = 15;
            this.radioButton3.Text = "Not Exist";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(69, 24);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(75, 17);
            this.radioButton2.TabIndex = 13;
            this.radioButton2.Text = "Duplicated";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(17, 24);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(36, 17);
            this.radioButton1.TabIndex = 12;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "All";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // UserControlPathView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserControlPathView";
            this.Size = new System.Drawing.Size(612, 433);
            this.Load += new System.EventHandler(this.UserControlPathView_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonRepair;
        private System.Windows.Forms.ListBox listBoxCurrentPath;
        private System.Windows.Forms.Label labelPathLength;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;


    }
}
