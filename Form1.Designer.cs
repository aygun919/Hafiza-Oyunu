namespace Hafıza_Oyunu
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            lblPlayer1 = new Label();
            lblScore1 = new Label();
            lblPlayer2 = new Label();
            lblScore2 = new Label();
            lblTurn = new Label();
            lblStatus = new Label();
            btnStart = new Button();
            pnlGameGrid = new Panel();
            tmrGame = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(485, 7);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(228, 41);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Hafıza Oyunu";
            // 
            // lblPlayer1
            // 
            lblPlayer1.AutoSize = true;
            lblPlayer1.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblPlayer1.Location = new Point(32, 16);
            lblPlayer1.Name = "lblPlayer1";
            lblPlayer1.Size = new Size(131, 32);
            lblPlayer1.TabIndex = 2;
            lblPlayer1.Text = "Oyuncu 1";
            // 
            // lblScore1
            // 
            lblScore1.AutoSize = true;
            lblScore1.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblScore1.Location = new Point(189, 17);
            lblScore1.Name = "lblScore1";
            lblScore1.Size = new Size(107, 33);
            lblScore1.TabIndex = 3;
            lblScore1.Text = "Puan : 0";
            // 
            // lblPlayer2
            // 
            lblPlayer2.AutoSize = true;
            lblPlayer2.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblPlayer2.Location = new Point(811, 14);
            lblPlayer2.Name = "lblPlayer2";
            lblPlayer2.Size = new Size(131, 32);
            lblPlayer2.TabIndex = 4;
            lblPlayer2.Text = "Oyuncu 2";
            // 
            // lblScore2
            // 
            lblScore2.AutoSize = true;
            lblScore2.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblScore2.Location = new Point(966, 13);
            lblScore2.Name = "lblScore2";
            lblScore2.Size = new Size(107, 33);
            lblScore2.TabIndex = 5;
            lblScore2.Text = "Puan : 0";
            // 
            // lblTurn
            // 
            lblTurn.AutoSize = true;
            lblTurn.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblTurn.Location = new Point(1229, 13);
            lblTurn.Name = "lblTurn";
            lblTurn.Size = new Size(197, 32);
            lblTurn.TabIndex = 6;
            lblTurn.Text = "Sıra: Oyuncu 1";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblStatus.Location = new Point(32, 540);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(296, 26);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Oyun Başladı / Eşleşme Yok";
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnStart.Location = new Point(1199, 528);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(306, 50);
            btnStart.TabIndex = 9;
            btnStart.TabStop = false;
            btnStart.Text = "YENİDEN BAŞLAT";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // pnlGameGrid
            // 
            pnlGameGrid.Location = new Point(3, 53);
            pnlGameGrid.Name = "pnlGameGrid";
            pnlGameGrid.Size = new Size(1557, 469);
            pnlGameGrid.TabIndex = 10;
            // 
            // tmrGame
            // 
            tmrGame.Tick += tmrGame_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Aquamarine;
            ClientSize = new Size(1572, 601);
            Controls.Add(pnlGameGrid);
            Controls.Add(btnStart);
            Controls.Add(lblStatus);
            Controls.Add(lblTurn);
            Controls.Add(lblScore2);
            Controls.Add(lblPlayer2);
            Controls.Add(lblScore1);
            Controls.Add(lblPlayer1);
            Controls.Add(lblTitle);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblTitle;
        private Label lblPlayer1;
        private Label lblScore1;
        private Label lblPlayer2;
        private Label lblScore2;
        private Label lblTurn;
        private Label lblStatus;
        private Button btnStart;
        private Panel pnlGameGrid;
        private System.Windows.Forms.Timer tmrGame;
    }
}
