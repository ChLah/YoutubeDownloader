namespace YoutubeDownloader
{
    partial class FrmChooseQuality
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
            this.cbAvailableQualities = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDimension = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bitte eine Qualitätsstufe und Format wählen.\r\nUm MP3 extrahieren zu können, muss " +
    "das Format FLV gewählt sein!";
            // 
            // cbAvailableQualities
            // 
            this.cbAvailableQualities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAvailableQualities.FormattingEnabled = true;
            this.cbAvailableQualities.Location = new System.Drawing.Point(15, 54);
            this.cbAvailableQualities.Name = "cbAvailableQualities";
            this.cbAvailableQualities.Size = new System.Drawing.Size(208, 21);
            this.cbAvailableQualities.TabIndex = 1;
            this.cbAvailableQualities.SelectedIndexChanged += new System.EventHandler(this.cbAvailableQualities_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Extension";
            // 
            // txtExtension
            // 
            this.txtExtension.Location = new System.Drawing.Point(13, 95);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.ReadOnly = true;
            this.txtExtension.Size = new System.Drawing.Size(66, 20);
            this.txtExtension.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Größe";
            // 
            // txtDimension
            // 
            this.txtDimension.Location = new System.Drawing.Point(86, 95);
            this.txtDimension.Name = "txtDimension";
            this.txtDimension.ReadOnly = true;
            this.txtDimension.Size = new System.Drawing.Size(66, 20);
            this.txtDimension.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(266, 136);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FrmChooseQuality
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 171);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtDimension);
            this.Controls.Add(this.txtExtension);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbAvailableQualities);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmChooseQuality";
            this.Text = "Qualität wählen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbAvailableQualities;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtExtension;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDimension;
        private System.Windows.Forms.Button btnOk;
    }
}