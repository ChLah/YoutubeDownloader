namespace YoutubeDownloader
{
    partial class FrmMain
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
            this.gbAddVideo = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.txtVidUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbDownload = new System.Windows.Forms.GroupBox();
            this.lblAdditionalInfo = new System.Windows.Forms.Label();
            this.pbProgressCurrentFile = new System.Windows.Forms.ProgressBar();
            this.btnStartDownload = new System.Windows.Forms.Button();
            this.ckAddIdeTags = new System.Windows.Forms.CheckBox();
            this.ckPersistVideo = new System.Windows.Forms.CheckBox();
            this.ckConvertFlvToMp3 = new System.Windows.Forms.CheckBox();
            this.btnChooseDestPath = new System.Windows.Forms.Button();
            this.txtDestPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvVideos = new System.Windows.Forms.DataGridView();
            this.cmGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.qualiWählenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbAddVideo.SuspendLayout();
            this.gbDownload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVideos)).BeginInit();
            this.cmGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAddVideo
            // 
            this.gbAddVideo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAddVideo.Controls.Add(this.btnSearch);
            this.gbAddVideo.Controls.Add(this.btnPaste);
            this.gbAddVideo.Controls.Add(this.txtVidUrl);
            this.gbAddVideo.Controls.Add(this.label1);
            this.gbAddVideo.Location = new System.Drawing.Point(12, 12);
            this.gbAddVideo.Name = "gbAddVideo";
            this.gbAddVideo.Size = new System.Drawing.Size(697, 115);
            this.gbAddVideo.TabIndex = 1;
            this.gbAddVideo.TabStop = false;
            this.gbAddVideo.Text = "Video hinzufügen";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(142, 71);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Suchen";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Location = new System.Drawing.Point(9, 71);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(127, 23);
            this.btnPaste.TabIndex = 2;
            this.btnPaste.Text = "Aus Zwischenablage";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // txtVidUrl
            // 
            this.txtVidUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVidUrl.Location = new System.Drawing.Point(9, 45);
            this.txtVidUrl.Name = "txtVidUrl";
            this.txtVidUrl.Size = new System.Drawing.Size(682, 20);
            this.txtVidUrl.TabIndex = 1;
            this.txtVidUrl.TextChanged += new System.EventHandler(this.txtVidUrl_TextChanged);
            this.txtVidUrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVidUrl_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Youtube-Url oder Suchbegriff hier einfügen:";
            // 
            // gbDownload
            // 
            this.gbDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDownload.Controls.Add(this.lblAdditionalInfo);
            this.gbDownload.Controls.Add(this.pbProgressCurrentFile);
            this.gbDownload.Controls.Add(this.btnStartDownload);
            this.gbDownload.Controls.Add(this.ckAddIdeTags);
            this.gbDownload.Controls.Add(this.ckPersistVideo);
            this.gbDownload.Controls.Add(this.ckConvertFlvToMp3);
            this.gbDownload.Controls.Add(this.btnChooseDestPath);
            this.gbDownload.Controls.Add(this.txtDestPath);
            this.gbDownload.Controls.Add(this.label2);
            this.gbDownload.Location = new System.Drawing.Point(12, 322);
            this.gbDownload.Name = "gbDownload";
            this.gbDownload.Size = new System.Drawing.Size(696, 136);
            this.gbDownload.TabIndex = 2;
            this.gbDownload.TabStop = false;
            this.gbDownload.Text = "Download";
            // 
            // lblAdditionalInfo
            // 
            this.lblAdditionalInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdditionalInfo.Location = new System.Drawing.Point(6, 83);
            this.lblAdditionalInfo.Name = "lblAdditionalInfo";
            this.lblAdditionalInfo.Size = new System.Drawing.Size(683, 21);
            this.lblAdditionalInfo.TabIndex = 8;
            this.lblAdditionalInfo.Text = "Zusätzliche Infos";
            this.lblAdditionalInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAdditionalInfo.Visible = false;
            // 
            // pbProgressCurrentFile
            // 
            this.pbProgressCurrentFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProgressCurrentFile.Location = new System.Drawing.Point(89, 107);
            this.pbProgressCurrentFile.Name = "pbProgressCurrentFile";
            this.pbProgressCurrentFile.Size = new System.Drawing.Size(601, 23);
            this.pbProgressCurrentFile.TabIndex = 7;
            this.pbProgressCurrentFile.Visible = false;
            // 
            // btnStartDownload
            // 
            this.btnStartDownload.Location = new System.Drawing.Point(10, 107);
            this.btnStartDownload.Name = "btnStartDownload";
            this.btnStartDownload.Size = new System.Drawing.Size(75, 23);
            this.btnStartDownload.TabIndex = 5;
            this.btnStartDownload.Text = "Starten";
            this.btnStartDownload.UseVisualStyleBackColor = true;
            this.btnStartDownload.Click += new System.EventHandler(this.btnStartDownload_Click);
            // 
            // ckAddIdeTags
            // 
            this.ckAddIdeTags.AutoSize = true;
            this.ckAddIdeTags.Checked = true;
            this.ckAddIdeTags.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckAddIdeTags.Location = new System.Drawing.Point(156, 45);
            this.ckAddIdeTags.Name = "ckAddIdeTags";
            this.ckAddIdeTags.Size = new System.Drawing.Size(126, 17);
            this.ckAddIdeTags.TabIndex = 4;
            this.ckAddIdeTags.Text = "IDE Tags hinzufügen";
            this.ckAddIdeTags.UseVisualStyleBackColor = true;
            // 
            // ckPersistVideo
            // 
            this.ckPersistVideo.AutoSize = true;
            this.ckPersistVideo.Location = new System.Drawing.Point(288, 45);
            this.ckPersistVideo.Name = "ckPersistVideo";
            this.ckPersistVideo.Size = new System.Drawing.Size(198, 17);
            this.ckPersistVideo.TabIndex = 4;
            this.ckPersistVideo.Text = "Bei Konvertierung Video beibehalten";
            this.ckPersistVideo.UseVisualStyleBackColor = true;
            // 
            // ckConvertFlvToMp3
            // 
            this.ckConvertFlvToMp3.AutoSize = true;
            this.ckConvertFlvToMp3.Checked = true;
            this.ckConvertFlvToMp3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckConvertFlvToMp3.Location = new System.Drawing.Point(9, 45);
            this.ckConvertFlvToMp3.Name = "ckConvertFlvToMp3";
            this.ckConvertFlvToMp3.Size = new System.Drawing.Size(141, 17);
            this.ckConvertFlvToMp3.TabIndex = 3;
            this.ckConvertFlvToMp3.Text = "FLV zu MP3 umwandeln";
            this.ckConvertFlvToMp3.UseVisualStyleBackColor = true;
            // 
            // btnChooseDestPath
            // 
            this.btnChooseDestPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseDestPath.Location = new System.Drawing.Point(663, 17);
            this.btnChooseDestPath.Name = "btnChooseDestPath";
            this.btnChooseDestPath.Size = new System.Drawing.Size(27, 23);
            this.btnChooseDestPath.TabIndex = 2;
            this.btnChooseDestPath.Text = "...";
            this.btnChooseDestPath.UseVisualStyleBackColor = true;
            this.btnChooseDestPath.Click += new System.EventHandler(this.btnChooseDestPath_Click);
            // 
            // txtDestPath
            // 
            this.txtDestPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestPath.Location = new System.Drawing.Point(89, 19);
            this.txtDestPath.Name = "txtDestPath";
            this.txtDestPath.Size = new System.Drawing.Size(566, 20);
            this.txtDestPath.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Zielverzeichnis";
            // 
            // dgvVideos
            // 
            this.dgvVideos.AllowUserToAddRows = false;
            this.dgvVideos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVideos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvVideos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvVideos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVideos.ContextMenuStrip = this.cmGrid;
            this.dgvVideos.Location = new System.Drawing.Point(12, 133);
            this.dgvVideos.Name = "dgvVideos";
            this.dgvVideos.RowHeadersVisible = false;
            this.dgvVideos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVideos.Size = new System.Drawing.Size(696, 183);
            this.dgvVideos.TabIndex = 3;
            // 
            // cmGrid
            // 
            this.cmGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.qualiWählenToolStripMenuItem});
            this.cmGrid.Name = "cmGrid";
            this.cmGrid.Size = new System.Drawing.Size(144, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.toolStripMenuItem1.Text = "Löschen";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // qualiWählenToolStripMenuItem
            // 
            this.qualiWählenToolStripMenuItem.Name = "qualiWählenToolStripMenuItem";
            this.qualiWählenToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.qualiWählenToolStripMenuItem.Text = "Quali wählen";
            this.qualiWählenToolStripMenuItem.Click += new System.EventHandler(this.tsmiChooseQuality_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 470);
            this.Controls.Add(this.dgvVideos);
            this.Controls.Add(this.gbDownload);
            this.Controls.Add(this.gbAddVideo);
            this.Name = "FrmMain";
            this.Text = "YoutubeDownloader by Mocki";
            this.gbAddVideo.ResumeLayout(false);
            this.gbAddVideo.PerformLayout();
            this.gbDownload.ResumeLayout(false);
            this.gbDownload.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVideos)).EndInit();
            this.cmGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAddVideo;
        private System.Windows.Forms.TextBox txtVidUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.GroupBox gbDownload;
        private System.Windows.Forms.Button btnChooseDestPath;
        private System.Windows.Forms.TextBox txtDestPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckConvertFlvToMp3;
        private System.Windows.Forms.CheckBox ckPersistVideo;
        private System.Windows.Forms.Button btnStartDownload;
        private System.Windows.Forms.ProgressBar pbProgressCurrentFile;
        private System.Windows.Forms.Label lblAdditionalInfo;
        private System.Windows.Forms.DataGridView dgvVideos;
        private System.Windows.Forms.ContextMenuStrip cmGrid;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem qualiWählenToolStripMenuItem;
        private System.Windows.Forms.CheckBox ckAddIdeTags;
    }
}

