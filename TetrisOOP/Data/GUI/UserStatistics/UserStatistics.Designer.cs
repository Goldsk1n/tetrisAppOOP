namespace TetrisOOP.Data.GUI.UserStatistics
{
	partial class UserStatistic
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbMaxPerGame = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbNumberOfGame = new System.Windows.Forms.Label();
            this.lbTimeInGame = new System.Windows.Forms.Label();
            this.lbScore = new System.Windows.Forms.Label();
            this.lbPlayerLevel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.lbMaxPerGame);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lbNumberOfGame);
            this.panel1.Controls.Add(this.lbTimeInGame);
            this.panel1.Controls.Add(this.lbScore);
            this.panel1.Controls.Add(this.lbPlayerLevel);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbUserName);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 375);
            this.panel1.TabIndex = 0;
            // 
            // lbMaxPerGame
            // 
            this.lbMaxPerGame.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TetrisOOP.Properties.Settings.Default, "UserRecord", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lbMaxPerGame.Location = new System.Drawing.Point(195, 245);
            this.lbMaxPerGame.Name = "lbMaxPerGame";
            this.lbMaxPerGame.Size = new System.Drawing.Size(183, 20);
            this.lbMaxPerGame.TabIndex = 14;
            this.lbMaxPerGame.Text = global::TetrisOOP.Properties.Settings.Default.UserRecord;
            this.lbMaxPerGame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(45, 243);
            this.label8.Margin = new System.Windows.Forms.Padding(25, 0, 3, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(170, 25);
            this.label8.TabIndex = 13;
            this.label8.Text = "Рекорд за гру";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbNumberOfGame
            // 
            this.lbNumberOfGame.Location = new System.Drawing.Point(195, 287);
            this.lbNumberOfGame.Name = "lbNumberOfGame";
            this.lbNumberOfGame.Size = new System.Drawing.Size(183, 20);
            this.lbNumberOfGame.TabIndex = 11;
            this.lbNumberOfGame.Text = "0";
            this.lbNumberOfGame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTimeInGame
            // 
            this.lbTimeInGame.Location = new System.Drawing.Point(195, 203);
            this.lbTimeInGame.Name = "lbTimeInGame";
            this.lbTimeInGame.Size = new System.Drawing.Size(183, 20);
            this.lbTimeInGame.TabIndex = 10;
            this.lbTimeInGame.Text = "0";
            this.lbTimeInGame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbScore
            // 
            this.lbScore.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TetrisOOP.Properties.Settings.Default, "UserScore", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lbScore.Location = new System.Drawing.Point(196, 116);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(182, 20);
            this.lbScore.TabIndex = 7;
            this.lbScore.Text = global::TetrisOOP.Properties.Settings.Default.UserScore;
            this.lbScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPlayerLevel
            // 
            this.lbPlayerLevel.BackColor = System.Drawing.Color.Transparent;
            this.lbPlayerLevel.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TetrisOOP.Properties.Settings.Default, "Level", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lbPlayerLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbPlayerLevel.Location = new System.Drawing.Point(195, 159);
            this.lbPlayerLevel.Name = "lbPlayerLevel";
            this.lbPlayerLevel.Size = new System.Drawing.Size(183, 24);
            this.lbPlayerLevel.TabIndex = 9;
            this.lbPlayerLevel.Text = global::TetrisOOP.Properties.Settings.Default.Level;
            this.lbPlayerLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(45, 287);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "Кількість ігор";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(45, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Час у грі";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(45, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Очки";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(45, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Рівень";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.Location = new System.Drawing.Point(25, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(353, 29);
            this.label3.TabIndex = 8;
            this.label3.Text = "Статистика";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(50, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ім\'я";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbUserName
            // 
            this.lbUserName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TetrisOOP.Properties.Settings.Default, "userName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lbUserName.Location = new System.Drawing.Point(196, 74);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(182, 25);
            this.lbUserName.TabIndex = 7;
            this.lbUserName.Text = global::TetrisOOP.Properties.Settings.Default.UserName;
            this.lbUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::TetrisOOP.Properties.Settings.Default.Background;
            this.ClientSize = new System.Drawing.Size(424, 401);
            this.Controls.Add(this.panel1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::TetrisOOP.Properties.Settings.Default, "Background", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "UserStatistic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Тетріс | Статистика";
            this.Load += new System.EventHandler(this.UserStatistic_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lbUserName;
		private System.Windows.Forms.Label lbPlayerLevel;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lbMaxPerGame;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lbNumberOfGame;
		private System.Windows.Forms.Label lbTimeInGame;
		private System.Windows.Forms.Label lbScore;
	}
}