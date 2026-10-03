using System;
using System.Collections.Generic; 
using System.Drawing; 
using System.Linq;
using System.Windows.Forms;

namespace Hafıza_Oyunu
{
    public partial class Form1 : Form

    {
        private class Card
        {
            public int Id { get; set; } 
            public string ImageUrl { get; set; }
            public bool IsMatched { get; set; } = false;
            public PictureBox PictureBox { get; set; } 
        }

       
        private List<Card> gameCards;
        private List<PictureBox> flippedBoxes;
        private int currentPlayer;
        private int scorePlayer1;
        private int scorePlayer2;

       
        private const int CARD_ROWS = 5;
        private const int CARD_COLS = 8;
        private const int FLIP_DURATION_SECONDS = 5; 
        private const int WAIT_DURATION_SECONDS = 2;

        private int flipTimerCounter;
        private bool isWaitingForMatch; 




        public Form1()
        {
            InitializeComponent();
            InitializeGameComponents();


        }
        private void InitializeGameComponents()
        {
            
            gameCards = new List<Card>();
            flippedBoxes = new List<PictureBox>();
            currentPlayer = 1;
            scorePlayer1 = 0;
            scorePlayer2 = 0;
            flipTimerCounter = 0;
            isWaitingForMatch = false;

            
            List<string> imageNames = new List<string>
            {
                "sss.jpg", "aycoregi.jpg", "balık.jpg", "banana bread.jpg", "corba.jpg",
                "cop sis.jpg", "donat.jpg", "dondurma.jpg", "durum.jpg",
                "hamburger.jpg", "makarna.jpg", "muffin.jpg", "pasta.jpg",
                "patates.jpg", "pizza.jpg", "sandvic.jpg", "sosis.jpg",
                "tavuk.jpg", "turta.jpg", "yumurta.jpg"
            };

            
            for (int i = 0; i < imageNames.Count; i++)
            {
                int cardId = i + 1;
                string fileName = imageNames[i];

                gameCards.Add(new Card { Id = cardId, ImageUrl = fileName });
                gameCards.Add(new Card { Id = cardId, ImageUrl = fileName });
            }

            
            Random rng = new Random();
            gameCards = gameCards.OrderBy(c => rng.Next()).ToList();

            PlaceCardsOnGrid();
            UpdateUIStatus(false, "Oyun Hazır. BAŞLAT düğmesine basınız.");
        }
        private void PlaceCardsOnGrid()
        {
            pnlGameGrid.Controls.Clear();

            int cardWidth = pnlGameGrid.Width / CARD_COLS;
            int cardHeight = pnlGameGrid.Height / CARD_ROWS;

            for (int i = 0; i < gameCards.Count; i++)
            {
                Card card = gameCards[i];

                PictureBox pb = new PictureBox();
                pb.Name = $"pbCard{i}";
                pb.Size = new Size(cardWidth, cardHeight);

                pb.Location = new Point((i % CARD_COLS) * cardWidth, (i / CARD_COLS) * cardHeight);

                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Tag = i;

                
                pb.Image = Image.FromFile("Images/soru işareti.png");

                pb.Click += PictureBox_Click; 
                pb.Enabled = false; 

                card.PictureBox = pb;

                pnlGameGrid.Controls.Add(pb);
            }
        }
        private void UpdateUIStatus(bool gameActive, string statusMessage)
        {
            lblScore1.Text = $"Puan : {scorePlayer1}";
            lblScore2.Text = $"Puan : {scorePlayer2}";
            lblTurn.Text = $"Sıra: Oyuncu {currentPlayer}";
            lblStatus.Text = statusMessage;

            pnlGameGrid.Enabled = gameActive;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
           
            InitializeGameComponents();

           
            tmrGame.Interval = 1000; 
            flipTimerCounter = FLIP_DURATION_SECONDS;
            tmrGame.Start();

            
            foreach (var card in gameCards)
            {
                card.PictureBox.Image = Image.FromFile($"Images/{card.ImageUrl}");
                card.PictureBox.Enabled = false;
            }

            UpdateUIStatus(false, $"Tüm kartlar {FLIP_DURATION_SECONDS} saniye açık. Ezberleyin!");
            btnStart.Enabled = false; 
        }
        private void tmrGame_Tick(object sender, EventArgs e)
        {
           
            if (isWaitingForMatch)
            {
                
                tmrGame.Stop();
                isWaitingForMatch = false;

               
                foreach (var pb in flippedBoxes)
                {
                    pb.Image = Image.FromFile("Images/soru işareti.png");
                    pb.Enabled = true; 
                }

               
                SwitchPlayer();
                return;
            }
            
            if (flipTimerCounter > 0)
            {
                flipTimerCounter--;

                
                if (flipTimerCounter == 0)
                {
                    tmrGame.Stop();

                    
                    foreach (var card in gameCards)
                    {
                        card.PictureBox.Image = Image.FromFile("Images/soru işareti.png");
                        card.PictureBox.Enabled = true;
                    }

                    UpdateUIStatus(true, $"Oyun başladı! Sıra Oyuncu {currentPlayer}.");
                    btnStart.Enabled = true; 
                }
            }
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
           
            if (isWaitingForMatch) return;

            PictureBox clickedBox = (PictureBox)sender;
            int clickedIndex = (int)clickedBox.Tag;
            Card clickedCard = gameCards[clickedIndex];

            
            clickedBox.Image = Image.FromFile($"Images/{clickedCard.ImageUrl}");
            clickedBox.Enabled = false;

            
            if (flippedBoxes.Count == 0)
            {
                flippedBoxes.Add(clickedBox);
                UpdateUIStatus(true, $"1. Kart seçildi. Sıra {currentPlayer}. Oyuncuda.");
            }

           
            else if (flippedBoxes.Count == 1)
            {
                flippedBoxes.Add(clickedBox);

                Card card1 = gameCards[(int)flippedBoxes[0].Tag];
                Card card2 = clickedCard;

                
                if (card1.Id == card2.Id)
                {
                   
                    card1.IsMatched = true;
                    card2.IsMatched = true;

                    if (currentPlayer == 1) scorePlayer1++; else scorePlayer2++;

                    flippedBoxes.Clear();
                    UpdateUIStatus(true, $"✅ Eşleşme bulundu! Sıra Oyuncu {currentPlayer}'da kalır.");
                    CheckGameOver();
                }
                else
                {
                    
                    isWaitingForMatch = true;

          
                    tmrGame.Interval = (int)TimeSpan.FromSeconds(WAIT_DURATION_SECONDS).TotalMilliseconds;
                    tmrGame.Start();

                    UpdateUIStatus(true, "Eşleşme yok. 2 saniye sonra sıra geçecek.");
                }
            }
        }
        private void SwitchPlayer()
        {
            
            currentPlayer = (currentPlayer == 1) ? 2 : 1;
            flippedBoxes.Clear();

            
            foreach (var card in gameCards.Where(c => !c.IsMatched))
            {
                card.PictureBox.Enabled = true;
            }

            UpdateUIStatus(true, $"Sıra Oyuncu {currentPlayer}'a geçti.");
        }

        private void CheckGameOver()
        {
            bool allMatched = gameCards.All(c => c.IsMatched);

            
            bool player1WonEarly = scorePlayer1 >= 11;
            bool player2WonEarly = scorePlayer2 >= 11;

            if (player1WonEarly || player2WonEarly || allMatched)
            {
                string winnerMessage;

                if (player1WonEarly) winnerMessage = $"Oyuncu 1, 11 çifte ulaşarak KAZANDI!";
                else if (player2WonEarly) winnerMessage = $"Oyuncu 2, 11 çifte ulaşarak KAZANDI!";
                else
                {
                    if (scorePlayer1 > scorePlayer2) winnerMessage = $"KAZANAN: Oyuncu 1 ({scorePlayer1} çift)";
                    else if (scorePlayer2 > scorePlayer1) winnerMessage = $"KAZANAN: Oyuncu 2 ({scorePlayer2} çift)";
                    else winnerMessage = "BERABERLİK!";
                }

                tmrGame.Stop();
                pnlGameGrid.Enabled = false;
                UpdateUIStatus(false, "!!! OYUN BİTTİ !!! " + winnerMessage);
                btnStart.Text = "YENİDEN BAŞLAT";
                btnStart.Enabled = true;
            }
        }

        
        private void Form1_Load(object sender, EventArgs e) { }







    }
}
        

        
