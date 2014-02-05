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
            this.components = new System.ComponentModel.Container();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.labelPathLength = new System.Windows.Forms.Label();
            this.buttonRepair = new System.Windows.Forms.Button();
            this.listBoxCurrentPath = new System.Windows.Forms.ListBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(524, 61);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 41;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
          
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(162, 61);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(76, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Text = "Duplicated";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(279, 61);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(67, 17);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.Text = "Not Exist";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // labelPathLength
            // 
            this.labelPathLength.AutoSize = true;
            this.labelPathLength.Location = new System.Drawing.Point(19, 27);
            this.labelPathLength.Name = "labelPathLength";
            this.labelPathLength.Size = new System.Drawing.Size(35, 13);
            this.labelPathLength.TabIndex = 40;
            this.labelPathLength.Text = "label1";
            // 
            // buttonRepair
            // 
            this.buttonRepair.Location = new System.Drawing.Point(524, 98);
            this.buttonRepair.Name = "buttonRepair";
            this.buttonRepair.Size = new System.Drawing.Size(75, 23);
            this.buttonRepair.TabIndex = 43;
            this.buttonRepair.Text = "Repair";
            this.buttonRepair.UseVisualStyleBackColor = true;
            // 
            // listBoxCurrentPath
            // 
            this.listBoxCurrentPath.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.listBoxCurrentPath.FormattingEnabled = true;
            this.listBoxCurrentPath.Location = new System.Drawing.Point(7, 90);
            this.listBoxCurrentPath.Name = "listBoxCurrentPath";
            this.listBoxCurrentPath.Size = new System.Drawing.Size(497, 329);
            this.listBoxCurrentPath.TabIndex = 0;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(68, 61);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(36, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "All";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // UserControlPathView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.labelPathLength);
            this.Controls.Add(this.listBoxCurrentPath);
            this.Controls.Add(this.buttonRepair);
            this.Name = "UserControlPathView";
            this.Size = new System.Drawing.Size(612, 433);
            this.Load += new System.EventHandler(this.UserControlPathView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Label labelPathLength;
        private System.Windows.Forms.Button buttonRepair;
        private System.Windows.Forms.ListBox listBoxCurrentPath;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ErrorProvider errorProvider1;

    }
}
