namespace TicTacToe
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
            this.btn00 = new System.Windows.Forms.Button();
            this.btn10 = new System.Windows.Forms.Button();
            this.btn20 = new System.Windows.Forms.Button();
            this.btn01 = new System.Windows.Forms.Button();
            this.btn11 = new System.Windows.Forms.Button();
            this.btn21 = new System.Windows.Forms.Button();
            this.btn02 = new System.Windows.Forms.Button();
            this.btn12 = new System.Windows.Forms.Button();
            this.btn22 = new System.Windows.Forms.Button();
            this.newGameButton = new System.Windows.Forms.Button();
            this.playerAScoreLabel = new System.Windows.Forms.Label();
            this.playerBScoreLabel = new System.Windows.Forms.Label();
            this.aiCheckbox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.statsGroupBox = new System.Windows.Forms.GroupBox();
            this.statsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn00
            // 
            this.btn00.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn00.Location = new System.Drawing.Point(12, 12);
            this.btn00.Name = "btn00";
            this.btn00.Size = new System.Drawing.Size(93, 66);
            this.btn00.TabIndex = 0;
            this.btn00.Tag = "00";
            this.btn00.UseVisualStyleBackColor = true;
            this.btn00.Click += new System.EventHandler(this.OnMakeMove);
            // 
            // btn10
            // 
            this.btn10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn10.Location = new System.Drawing.Point(111, 12);
            this.btn10.Name = "btn10";
            this.btn10.Size = new System.Drawing.Size(93, 66);
            this.btn10.TabIndex = 1;
            this.btn10.Tag = "10";
            this.btn10.UseVisualStyleBackColor = true;
            this.btn10.Click += new System.EventHandler(this.OnMakeMove);
            // 
            // btn20
            // 
            this.btn20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn20.Location = new System.Drawing.Point(210, 12);
            this.btn20.Name = "btn20";
            this.btn20.Size = new System.Drawing.Size(93, 66);
            this.btn20.TabIndex = 2;
            this.btn20.Tag = "20";
            this.btn20.UseVisualStyleBackColor = true;
            this.btn20.Click += new System.EventHandler(this.OnMakeMove);
            // 
            // btn01
            // 
            this.btn01.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn01.Location = new System.Drawing.Point(12, 84);
            this.btn01.Name = "btn01";
            this.btn01.Size = new System.Drawing.Size(93, 66);
            this.btn01.TabIndex = 3;
            this.btn01.Tag = "01";
            this.btn01.UseVisualStyleBackColor = true;
            this.btn01.Click += new System.EventHandler(this.OnMakeMove);
            // 
            // btn11
            // 
            this.btn11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn11.Location = new System.Drawing.Point(111, 84);
            this.btn11.Name = "btn11";
            this.btn11.Size = new System.Drawing.Size(93, 66);
            this.btn11.TabIndex = 4;
            this.btn11.Tag = "11";
            this.btn11.UseVisualStyleBackColor = true;
            this.btn11.Click += new System.EventHandler(this.OnMakeMove);
            // 
            // btn21
            // 
            this.btn21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn21.Location = new System.Drawing.Point(210, 84);
            this.btn21.Name = "btn21";
            this.btn21.Size = new System.Drawing.Size(93, 66);
            this.btn21.TabIndex = 5;
            this.btn21.Tag = "21";
            this.btn21.UseVisualStyleBackColor = true;
            this.btn21.Click += new System.EventHandler(this.OnMakeMove);
            // 
            // btn02
            // 
            this.btn02.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn02.Location = new System.Drawing.Point(12, 156);
            this.btn02.Name = "btn02";
            this.btn02.Size = new System.Drawing.Size(93, 66);
            this.btn02.TabIndex = 6;
            this.btn02.Tag = "02";
            this.btn02.UseVisualStyleBackColor = true;
            this.btn02.Click += new System.EventHandler(this.OnMakeMove);
            // 
            // btn12
            // 
            this.btn12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn12.Location = new System.Drawing.Point(111, 156);
            this.btn12.Name = "btn12";
            this.btn12.Size = new System.Drawing.Size(93, 66);
            this.btn12.TabIndex = 7;
            this.btn12.Tag = "12";
            this.btn12.UseVisualStyleBackColor = true;
            this.btn12.Click += new System.EventHandler(this.OnMakeMove);
            // 
            // btn22
            // 
            this.btn22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn22.Location = new System.Drawing.Point(210, 156);
            this.btn22.Name = "btn22";
            this.btn22.Size = new System.Drawing.Size(93, 66);
            this.btn22.TabIndex = 8;
            this.btn22.Tag = "22";
            this.btn22.UseVisualStyleBackColor = true;
            this.btn22.Click += new System.EventHandler(this.OnMakeMove);
            // 
            // newGameButton
            // 
            this.newGameButton.Location = new System.Drawing.Point(323, 128);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(152, 60);
            this.newGameButton.TabIndex = 9;
            this.newGameButton.Text = "Neues Spiel";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.OnNewGameButtonClick);
            // 
            // playerAScoreLabel
            // 
            this.playerAScoreLabel.AutoSize = true;
            this.playerAScoreLabel.Location = new System.Drawing.Point(6, 28);
            this.playerAScoreLabel.Name = "playerAScoreLabel";
            this.playerAScoreLabel.Size = new System.Drawing.Size(35, 13);
            this.playerAScoreLabel.TabIndex = 10;
            this.playerAScoreLabel.Text = "label1";
            this.playerAScoreLabel.Click += new System.EventHandler(this.OnPlayerANameClicked);
            // 
            // playerBScoreLabel
            // 
            this.playerBScoreLabel.AutoSize = true;
            this.playerBScoreLabel.Location = new System.Drawing.Point(6, 53);
            this.playerBScoreLabel.Name = "playerBScoreLabel";
            this.playerBScoreLabel.Size = new System.Drawing.Size(35, 13);
            this.playerBScoreLabel.TabIndex = 11;
            this.playerBScoreLabel.Text = "label2";
            this.playerBScoreLabel.Click += new System.EventHandler(this.OnPlayerBNameClicked);
            // 
            // aiCheckbox
            // 
            this.aiCheckbox.AutoSize = true;
            this.aiCheckbox.Checked = true;
            this.aiCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aiCheckbox.Location = new System.Drawing.Point(110, 53);
            this.aiCheckbox.Name = "aiCheckbox";
            this.aiCheckbox.Size = new System.Drawing.Size(36, 17);
            this.aiCheckbox.TabIndex = 12;
            this.aiCheckbox.Text = "KI";
            this.aiCheckbox.UseVisualStyleBackColor = true;
            this.aiCheckbox.CheckedChanged += new System.EventHandler(this.OnAICheckboxChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(323, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Punkte zurücksetzen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnResetPointsButtonClicked);
            // 
            // statsGroupBox
            // 
            this.statsGroupBox.Controls.Add(this.aiCheckbox);
            this.statsGroupBox.Controls.Add(this.playerAScoreLabel);
            this.statsGroupBox.Controls.Add(this.playerBScoreLabel);
            this.statsGroupBox.Location = new System.Drawing.Point(323, 12);
            this.statsGroupBox.Name = "statsGroupBox";
            this.statsGroupBox.Size = new System.Drawing.Size(152, 82);
            this.statsGroupBox.TabIndex = 14;
            this.statsGroupBox.TabStop = false;
            this.statsGroupBox.Text = "Stats";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 243);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.statsGroupBox);
            this.Controls.Add(this.btn22);
            this.Controls.Add(this.btn12);
            this.Controls.Add(this.btn02);
            this.Controls.Add(this.btn21);
            this.Controls.Add(this.btn11);
            this.Controls.Add(this.btn01);
            this.Controls.Add(this.btn20);
            this.Controls.Add(this.btn10);
            this.Controls.Add(this.btn00);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.statsGroupBox.ResumeLayout(false);
            this.statsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn00;
        private System.Windows.Forms.Button btn10;
        private System.Windows.Forms.Button btn20;
        private System.Windows.Forms.Button btn01;
        private System.Windows.Forms.Button btn11;
        private System.Windows.Forms.Button btn21;
        private System.Windows.Forms.Button btn02;
        private System.Windows.Forms.Button btn12;
        private System.Windows.Forms.Button btn22;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Label playerAScoreLabel;
        private System.Windows.Forms.Label playerBScoreLabel;
        private System.Windows.Forms.CheckBox aiCheckbox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox statsGroupBox;
    }
}

