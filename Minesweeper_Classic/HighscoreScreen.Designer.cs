namespace Minesweeper_Classic
{
    partial class HighscoreScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBeginnerTime = new System.Windows.Forms.Label();
            this.lblIntermediateTime = new System.Windows.Forms.Label();
            this.lblExpertTime = new System.Windows.Forms.Label();
            this.lblBeginnerName = new System.Windows.Forms.Label();
            this.lblIntermediateName = new System.Windows.Forms.Label();
            this.lblExpertName = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Beginner:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Intermediate:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Expert:";
            // 
            // lblBeginnerTime
            // 
            this.lblBeginnerTime.AutoSize = true;
            this.lblBeginnerTime.Location = new System.Drawing.Point(102, 27);
            this.lblBeginnerTime.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblBeginnerTime.Name = "lblBeginnerTime";
            this.lblBeginnerTime.Size = new System.Drawing.Size(59, 13);
            this.lblBeginnerTime.TabIndex = 3;
            this.lblBeginnerTime.Text = "-1 seconds";
            // 
            // lblIntermediateTime
            // 
            this.lblIntermediateTime.AutoSize = true;
            this.lblIntermediateTime.Location = new System.Drawing.Point(102, 50);
            this.lblIntermediateTime.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblIntermediateTime.Name = "lblIntermediateTime";
            this.lblIntermediateTime.Size = new System.Drawing.Size(59, 13);
            this.lblIntermediateTime.TabIndex = 4;
            this.lblIntermediateTime.Text = "-1 seconds";
            // 
            // lblExpertTime
            // 
            this.lblExpertTime.AutoSize = true;
            this.lblExpertTime.Location = new System.Drawing.Point(102, 73);
            this.lblExpertTime.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblExpertTime.Name = "lblExpertTime";
            this.lblExpertTime.Size = new System.Drawing.Size(59, 13);
            this.lblExpertTime.TabIndex = 5;
            this.lblExpertTime.Text = "-1 seconds";
            // 
            // lblBeginnerName
            // 
            this.lblBeginnerName.AutoSize = true;
            this.lblBeginnerName.Location = new System.Drawing.Point(186, 27);
            this.lblBeginnerName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblBeginnerName.Name = "lblBeginnerName";
            this.lblBeginnerName.Size = new System.Drawing.Size(100, 13);
            this.lblBeginnerName.TabIndex = 6;
            this.lblBeginnerName.Text = "NAMENAMENAME";
            // 
            // lblIntermediateName
            // 
            this.lblIntermediateName.AutoSize = true;
            this.lblIntermediateName.Location = new System.Drawing.Point(186, 50);
            this.lblIntermediateName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblIntermediateName.Name = "lblIntermediateName";
            this.lblIntermediateName.Size = new System.Drawing.Size(100, 13);
            this.lblIntermediateName.TabIndex = 7;
            this.lblIntermediateName.Text = "NAMENAMENAME";
            // 
            // lblExpertName
            // 
            this.lblExpertName.AutoSize = true;
            this.lblExpertName.Location = new System.Drawing.Point(186, 73);
            this.lblExpertName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblExpertName.Name = "lblExpertName";
            this.lblExpertName.Size = new System.Drawing.Size(100, 13);
            this.lblExpertName.TabIndex = 8;
            this.lblExpertName.Text = "NAMENAMENAME";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(189, 104);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 21);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(44, 104);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(80, 21);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "Reset Scores";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // HighscoreScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 144);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblExpertName);
            this.Controls.Add(this.lblIntermediateName);
            this.Controls.Add(this.lblBeginnerName);
            this.Controls.Add(this.lblExpertTime);
            this.Controls.Add(this.lblIntermediateTime);
            this.Controls.Add(this.lblBeginnerTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HighscoreScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Fastest Mine Sweepers";
            this.Load += new System.EventHandler(this.HighscoreScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBeginnerTime;
        private System.Windows.Forms.Label lblIntermediateTime;
        private System.Windows.Forms.Label lblExpertTime;
        private System.Windows.Forms.Label lblBeginnerName;
        private System.Windows.Forms.Label lblIntermediateName;
        private System.Windows.Forms.Label lblExpertName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnReset;
    }
}