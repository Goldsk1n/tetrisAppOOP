﻿namespace TetrisOOP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btPlay = new System.Windows.Forms.Button();
            this.pnMenuButtons = new System.Windows.Forms.Panel();
            this.btAbout = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.btSettings = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbScore = new System.Windows.Forms.Label();
            this.lbScoreForNextLevel = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.btUserStatistic = new System.Windows.Forms.Button();
            this.btChangeUser = new System.Windows.Forms.Button();
            this.lbPlayerLevelPercent = new System.Windows.Forms.Label();
            this.lbPlayerLevel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.prbPlayerLevel = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.scoresList = new System.Windows.Forms.ListBox();
            this.topList = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnMenuButtons.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btPlay
            // 
            this.btPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPlay.Location = new System.Drawing.Point(75, 45);
            this.btPlay.Margin = new System.Windows.Forms.Padding(5);
            this.btPlay.Name = "btPlay";
            this.btPlay.Size = new System.Drawing.Size(150, 50);
            this.btPlay.TabIndex = 1;
            this.btPlay.Text = "Почати гру";
            this.btPlay.UseVisualStyleBackColor = true;
            this.btPlay.Click += new System.EventHandler(this.BtPlay_Click);
            // 
            // pnMenuButtons
            // 
            this.pnMenuButtons.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnMenuButtons.BackColor = System.Drawing.Color.PaleGreen;
            this.pnMenuButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnMenuButtons.Controls.Add(this.btAbout);
            this.pnMenuButtons.Controls.Add(this.btExit);
            this.pnMenuButtons.Controls.Add(this.btSettings);
            this.pnMenuButtons.Controls.Add(this.btPlay);
            this.pnMenuButtons.Location = new System.Drawing.Point(350, 260);
            this.pnMenuButtons.Margin = new System.Windows.Forms.Padding(0);
            this.pnMenuButtons.Name = "pnMenuButtons";
            this.pnMenuButtons.Size = new System.Drawing.Size(300, 400);
            this.pnMenuButtons.TabIndex = 1;
            // 
            // btAbout
            // 
            this.btAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAbout.Location = new System.Drawing.Point(75, 215);
            this.btAbout.Margin = new System.Windows.Forms.Padding(5);
            this.btAbout.Name = "btAbout";
            this.btAbout.Size = new System.Drawing.Size(150, 50);
            this.btAbout.TabIndex = 3;
            this.btAbout.Text = "Про гру";
            this.btAbout.UseVisualStyleBackColor = true;
            this.btAbout.Click += new System.EventHandler(this.BtAbout_Click);
            // 
            // btExit
            // 
            this.btExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExit.Location = new System.Drawing.Point(75, 300);
            this.btExit.Margin = new System.Windows.Forms.Padding(5);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(150, 50);
            this.btExit.TabIndex = 4;
            this.btExit.Text = "Вихід";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.BtExit_Click);
            // 
            // btSettings
            // 
            this.btSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSettings.Location = new System.Drawing.Point(75, 130);
            this.btSettings.Margin = new System.Windows.Forms.Padding(5);
            this.btSettings.Name = "btSettings";
            this.btSettings.Size = new System.Drawing.Size(150, 50);
            this.btSettings.TabIndex = 2;
            this.btSettings.Text = "Налаштування";
            this.btSettings.UseVisualStyleBackColor = true;
            this.btSettings.Click += new System.EventHandler(this.BtSettings_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(9, 50);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(964, 200);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.Color.PaleGreen;
            this.label1.Font = new System.Drawing.Font("Arial", 110F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(964, 198);
            this.label1.TabIndex = 0;
            this.label1.Text = "TetrisOOP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lbScore);
            this.panel2.Controls.Add(this.lbScoreForNextLevel);
            this.panel2.Controls.Add(this.lbUserName);
            this.panel2.Controls.Add(this.btUserStatistic);
            this.panel2.Controls.Add(this.btChangeUser);
            this.panel2.Controls.Add(this.lbPlayerLevelPercent);
            this.panel2.Controls.Add(this.lbPlayerLevel);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.prbPlayerLevel);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(65, 292);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 220);
            this.panel2.TabIndex = 3;
            // 
            // lbScore
            // 
            this.lbScore.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TetrisOOP.Properties.Settings.Default, "UserScore", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lbScore.Location = new System.Drawing.Point(15, 104);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(110, 20);
            this.lbScore.TabIndex = 6;
            this.lbScore.Text = global::TetrisOOP.Properties.Settings.Default.UserScore;
            this.lbScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbScoreForNextLevel
            // 
            this.lbScoreForNextLevel.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TetrisOOP.Properties.Settings.Default, "scoreForNextLevel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lbScoreForNextLevel.Location = new System.Drawing.Point(131, 104);
            this.lbScoreForNextLevel.Name = "lbScoreForNextLevel";
            this.lbScoreForNextLevel.Size = new System.Drawing.Size(106, 20);
            this.lbScoreForNextLevel.TabIndex = 6;
            this.lbScoreForNextLevel.Text = global::TetrisOOP.Properties.Settings.Default.ScoreForNextLevel;
            this.lbScoreForNextLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbUserName
            // 
            this.lbUserName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TetrisOOP.Properties.Settings.Default, "userName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbUserName.Location = new System.Drawing.Point(12, 11);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(225, 20);
            this.lbUserName.TabIndex = 6;
            this.lbUserName.Text = global::TetrisOOP.Properties.Settings.Default.UserName;
            this.lbUserName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btUserStatistic
            // 
            this.btUserStatistic.Location = new System.Drawing.Point(16, 165);
            this.btUserStatistic.Name = "btUserStatistic";
            this.btUserStatistic.Size = new System.Drawing.Size(222, 32);
            this.btUserStatistic.TabIndex = 5;
            this.btUserStatistic.Text = "Статистика";
            this.btUserStatistic.UseVisualStyleBackColor = true;
            this.btUserStatistic.Click += new System.EventHandler(this.BtUserStatistic_Click);
            // 
            // btChangeUser
            // 
            this.btChangeUser.Location = new System.Drawing.Point(16, 127);
            this.btChangeUser.Name = "btChangeUser";
            this.btChangeUser.Size = new System.Drawing.Size(222, 32);
            this.btChangeUser.TabIndex = 5;
            this.btChangeUser.Text = "Змінити користувача";
            this.btChangeUser.UseVisualStyleBackColor = true;
            this.btChangeUser.Click += new System.EventHandler(this.BtChangeUser_Click);
            // 
            // lbPlayerLevelPercent
            // 
            this.lbPlayerLevelPercent.BackColor = System.Drawing.Color.Transparent;
            this.lbPlayerLevelPercent.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TetrisOOP.Properties.Settings.Default, "levelScorePerc", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lbPlayerLevelPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbPlayerLevelPercent.Location = new System.Drawing.Point(196, 41);
            this.lbPlayerLevelPercent.Name = "lbPlayerLevelPercent";
            this.lbPlayerLevelPercent.Size = new System.Drawing.Size(41, 20);
            this.lbPlayerLevelPercent.TabIndex = 3;
            this.lbPlayerLevelPercent.Text = global::TetrisOOP.Properties.Settings.Default.LevelScorePerc;
            this.lbPlayerLevelPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbPlayerLevel
            // 
            this.lbPlayerLevel.BackColor = System.Drawing.Color.Transparent;
            this.lbPlayerLevel.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TetrisOOP.Properties.Settings.Default, "Level", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lbPlayerLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPlayerLevel.Location = new System.Drawing.Point(16, 37);
            this.lbPlayerLevel.Name = "lbPlayerLevel";
            this.lbPlayerLevel.Size = new System.Drawing.Size(32, 24);
            this.lbPlayerLevel.TabIndex = 3;
            this.lbPlayerLevel.Text = global::TetrisOOP.Properties.Settings.Default.Level;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(54, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Рівень";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // prbPlayerLevel
            // 
            this.prbPlayerLevel.DataBindings.Add(new System.Windows.Forms.Binding("Maximum", global::TetrisOOP.Properties.Settings.Default, "LevelScoreMax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.prbPlayerLevel.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::TetrisOOP.Properties.Settings.Default, "LevelScore", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.prbPlayerLevel.Location = new System.Drawing.Point(16, 76);
            this.prbPlayerLevel.Maximum = global::TetrisOOP.Properties.Settings.Default.LevelScoreMax;
            this.prbPlayerLevel.Name = "prbPlayerLevel";
            this.prbPlayerLevel.Size = new System.Drawing.Size(222, 23);
            this.prbPlayerLevel.Step = 100;
            this.prbPlayerLevel.TabIndex = 1;
            this.prbPlayerLevel.Value = global::TetrisOOP.Properties.Settings.Default.LevelScore;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(21, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "/";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.scoresList);
            this.panel3.Controls.Add(this.topList);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(680, 280);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(250, 290);
            this.panel3.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(146, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 26);
            this.label6.TabIndex = 4;
            this.label6.Text = "Рахунок";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scoresList
            // 
            this.scoresList.FormattingEnabled = true;
            this.scoresList.ItemHeight = 25;
            this.scoresList.Location = new System.Drawing.Point(146, 75);
            this.scoresList.Name = "scoresList";
            this.scoresList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.scoresList.Size = new System.Drawing.Size(98, 204);
            this.scoresList.TabIndex = 3;
            // 
            // topList
            // 
            this.topList.FormattingEnabled = true;
            this.topList.ItemHeight = 25;
            this.topList.Location = new System.Drawing.Point(8, 75);
            this.topList.Name = "topList";
            this.topList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.topList.Size = new System.Drawing.Size(138, 204);
            this.topList.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 26);
            this.label5.TabIndex = 1;
            this.label5.Text = "Нікнейм";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 32);
            this.label4.TabIndex = 0;
            this.label4.Text = "Топ гравців";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = global::TetrisOOP.Properties.Settings.Default.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(982, 703);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnMenuButtons);
            this.Controls.Add(this.panel1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::TetrisOOP.Properties.Settings.Default, "Background", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("WindowState", global::TetrisOOP.Properties.Settings.Default, "SizeScreen", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("FormBorderStyle", global::TetrisOOP.Properties.Settings.Default, "BorderStyle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = global::TetrisOOP.Properties.Settings.Default.BorderStyle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тетріс | Меню";
            this.WindowState = global::TetrisOOP.Properties.Settings.Default.SizeScreen;
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnMenuButtons.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btPlay;
		private System.Windows.Forms.Panel pnMenuButtons;
		private System.Windows.Forms.Button btExit;
		private System.Windows.Forms.Button btSettings;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btAbout;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ProgressBar prbPlayerLevel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lbPlayerLevelPercent;
		private System.Windows.Forms.Label lbPlayerLevel;
		private System.Windows.Forms.Button btChangeUser;
		private System.Windows.Forms.Label lbUserName;
		private System.Windows.Forms.Label lbScore;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lbScoreForNextLevel;
		private System.Windows.Forms.Button btUserStatistic;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox topList;
        private System.Windows.Forms.ListBox scoresList;
        private System.Windows.Forms.Label label6;
    }
}