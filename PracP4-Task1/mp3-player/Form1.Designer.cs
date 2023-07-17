namespace mp3_player
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.songToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearSongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstPlaylists = new System.Windows.Forms.ListBox();
            this.lstSongs = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.uieOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.trackBarPosition = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.labelPath = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelDuration = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelElapsedTime = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnSelectSong = new System.Windows.Forms.Button();
            this.labelFilename = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRating = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.timerHalfSecs = new System.Windows.Forms.Timer(this.components);
            this.labelTags = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.songToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(741, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPlaylistToolStripMenuItem,
            this.openPlaylistToolStripMenuItem,
            this.savePlaylistToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newPlaylistToolStripMenuItem
            // 
            this.newPlaylistToolStripMenuItem.Name = "newPlaylistToolStripMenuItem";
            this.newPlaylistToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newPlaylistToolStripMenuItem.Text = "New Playlist";
            this.newPlaylistToolStripMenuItem.Click += new System.EventHandler(this.newPlaylistToolStripMenuItem_Click);
            // 
            // openPlaylistToolStripMenuItem
            // 
            this.openPlaylistToolStripMenuItem.Name = "openPlaylistToolStripMenuItem";
            this.openPlaylistToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openPlaylistToolStripMenuItem.Text = "Open Playlist";
            this.openPlaylistToolStripMenuItem.Click += new System.EventHandler(this.openPlaylistToolStripMenuItem_Click);
            // 
            // savePlaylistToolStripMenuItem
            // 
            this.savePlaylistToolStripMenuItem.Name = "savePlaylistToolStripMenuItem";
            this.savePlaylistToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.savePlaylistToolStripMenuItem.Text = "Save Playlist";
            this.savePlaylistToolStripMenuItem.Click += new System.EventHandler(this.savePlaylistToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // songToolStripMenuItem
            // 
            this.songToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSongToolStripMenuItem,
            this.clearSongToolStripMenuItem});
            this.songToolStripMenuItem.Name = "songToolStripMenuItem";
            this.songToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.songToolStripMenuItem.Text = "Song";
            // 
            // addSongToolStripMenuItem
            // 
            this.addSongToolStripMenuItem.Name = "addSongToolStripMenuItem";
            this.addSongToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.addSongToolStripMenuItem.Text = "Add/&Update Song";
            this.addSongToolStripMenuItem.Click += new System.EventHandler(this.addSongToolStripMenuItem_Click);
            // 
            // clearSongToolStripMenuItem
            // 
            this.clearSongToolStripMenuItem.Name = "clearSongToolStripMenuItem";
            this.clearSongToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.clearSongToolStripMenuItem.Text = "C&lear Song Information";
            this.clearSongToolStripMenuItem.Click += new System.EventHandler(this.clearSongToolStripMenuItem_Click);
            // 
            // lstPlaylists
            // 
            this.lstPlaylists.FormattingEnabled = true;
            this.lstPlaylists.Location = new System.Drawing.Point(13, 63);
            this.lstPlaylists.Name = "lstPlaylists";
            this.lstPlaylists.Size = new System.Drawing.Size(144, 251);
            this.lstPlaylists.TabIndex = 2;
            // 
            // lstSongs
            // 
            this.lstSongs.FormattingEnabled = true;
            this.lstSongs.Location = new System.Drawing.Point(188, 63);
            this.lstSongs.Name = "lstSongs";
            this.lstSongs.Size = new System.Drawing.Size(143, 251);
            this.lstSongs.TabIndex = 3;
            this.lstSongs.SelectedIndexChanged += new System.EventHandler(this.lstSongs_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Playlists";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Songs";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(352, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Song Info";
            // 
            // uieOpenFileDialog
            // 
            this.uieOpenFileDialog.FileName = "openFileDialog2";
            // 
            // trackBarPosition
            // 
            this.trackBarPosition.AutoSize = false;
            this.trackBarPosition.Location = new System.Drawing.Point(354, 183);
            this.trackBarPosition.Margin = new System.Windows.Forms.Padding(2);
            this.trackBarPosition.Maximum = 20;
            this.trackBarPosition.Name = "trackBarPosition";
            this.trackBarPosition.Size = new System.Drawing.Size(376, 45);
            this.trackBarPosition.TabIndex = 39;
            this.trackBarPosition.Scroll += new System.EventHandler(this.trackBarPosition_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(639, 257);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "Volume";
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Location = new System.Drawing.Point(620, 222);
            this.trackBarVolume.Margin = new System.Windows.Forms.Padding(2);
            this.trackBarVolume.Maximum = 1000;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(78, 45);
            this.trackBarVolume.SmallChange = 25;
            this.trackBarVolume.TabIndex = 37;
            this.trackBarVolume.TickFrequency = 100;
            this.trackBarVolume.Value = 800;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarVolume_Scroll);
            // 
            // labelPath
            // 
            this.labelPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPath.Location = new System.Drawing.Point(426, 129);
            this.labelPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(300, 23);
            this.labelPath.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(352, 100);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Filename:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(362, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Elapsed Time    /     Duration";
            // 
            // labelDuration
            // 
            this.labelDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDuration.Location = new System.Drawing.Point(451, 230);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(108, 13);
            this.labelDuration.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(436, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "/";
            // 
            // labelElapsedTime
            // 
            this.labelElapsedTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelElapsedTime.Location = new System.Drawing.Point(365, 230);
            this.labelElapsedTime.Name = "labelElapsedTime";
            this.labelElapsedTime.Size = new System.Drawing.Size(65, 13);
            this.labelElapsedTime.TabIndex = 31;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(547, 291);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(179, 23);
            this.btnStop.TabIndex = 30;
            this.btnStop.Text = "&Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(355, 291);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(186, 23);
            this.btnPlay.TabIndex = 29;
            this.btnPlay.Text = "&Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnSelectSong
            // 
            this.btnSelectSong.Location = new System.Drawing.Point(651, 98);
            this.btnSelectSong.Name = "btnSelectSong";
            this.btnSelectSong.Size = new System.Drawing.Size(75, 23);
            this.btnSelectSong.TabIndex = 28;
            this.btnSelectSong.Text = "&Browse";
            this.btnSelectSong.UseVisualStyleBackColor = true;
            this.btnSelectSong.Click += new System.EventHandler(this.btnSelectSong_Click);
            // 
            // labelFilename
            // 
            this.labelFilename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelFilename.Location = new System.Drawing.Point(426, 99);
            this.labelFilename.Name = "labelFilename";
            this.labelFilename.Size = new System.Drawing.Size(219, 22);
            this.labelFilename.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(351, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Path:";
            // 
            // txtRating
            // 
            this.txtRating.Location = new System.Drawing.Point(512, 69);
            this.txtRating.Name = "txtRating";
            this.txtRating.Size = new System.Drawing.Size(29, 20);
            this.txtRating.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(465, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Rating:";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(391, 72);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(0, 13);
            this.labelID.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(352, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "ID:";
            // 
            // timerHalfSecs
            // 
            this.timerHalfSecs.Enabled = true;
            this.timerHalfSecs.Interval = 500;
            this.timerHalfSecs.Tick += new System.EventHandler(this.timerHalfSecs_Tick);
            // 
            // labelTags
            // 
            this.labelTags.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTags.Location = new System.Drawing.Point(426, 158);
            this.labelTags.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTags.Name = "labelTags";
            this.labelTags.Size = new System.Drawing.Size(300, 23);
            this.labelTags.TabIndex = 40;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(352, 159);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 41;
            this.label12.Text = "Tags:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 323);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.labelTags);
            this.Controls.Add(this.trackBarPosition);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.trackBarVolume);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelDuration);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelElapsedTime);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnSelectSong);
            this.Controls.Add(this.labelFilename);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtRating);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstSongs);
            this.Controls.Add(this.lstPlaylists);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "PracP4";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem songToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearSongToolStripMenuItem;
        private System.Windows.Forms.ListBox lstPlaylists;
        private System.Windows.Forms.ListBox lstSongs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog uieOpenFileDialog;
        private System.Windows.Forms.TrackBar trackBarPosition;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelElapsedTime;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnSelectSong;
        private System.Windows.Forms.Label labelFilename;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRating;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer timerHalfSecs;
        private System.Windows.Forms.Label labelTags;
        private System.Windows.Forms.Label label12;
    }
}

