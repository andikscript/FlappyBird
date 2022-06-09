namespace FlappyBird
{
    public partial class FormDesign : System.Windows.Forms.Form
    {
        int pipeSpeed = 8;
        int gravity = 0;
        int score = 0;

        public FormDesign()
        {
            InitializeComponent();
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                gravity = 6;
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                gravity = -6;
            }
        }

        private void EndGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game Over !!!";
            pipeSpeed = 8;
            gravity = 0;
            score = 0;
            buttonStart.Enabled = true;
            buttonExit.Enabled = true;
        }

        private void Button_Start(object sender, EventArgs e)
        {
            gameTimer.Start();
            flappyBird.Location = new Point(54, 171);
            pipeTop.Location = new Point(380, -1);
            pipeTop2.Location = new Point(716, -1);
            pipeBottom.Location = new Point(279, 253);
            pipeBottom.Location = new Point(553, 295);
            buttonStart.Enabled = false; 
            buttonExit.Enabled = false;
        }

        private void Button_Exit(object sender, EventArgs e)
        {
            var YesOrNo = new DialogResult();
            YesOrNo = MessageBox.Show("Apakah Anda Ingin Keluar??",
                    "Picture Puzzle-Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (YesOrNo == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            // untuk mengatur naik turun posisi image dengan menambahkannya dari gravity
            // nilai 0 berarti posisi image default
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeBottom2.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            pipeTop2.Left -= pipeSpeed;

            scoreText.Text = "Score : " + score.ToString();

            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 550;
                score++;
            }

            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 580;
            }

            if (pipeBottom2.Left < -50)
            {
                pipeBottom2.Left = 650;
                score++;
            }

            if (pipeTop2.Left < -25)
            {
                pipeTop2.Left = 750;
            }

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeBottom2.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop2.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -25)
            {

                EndGame();
            }

            if (score > 50)
            {
                pipeSpeed = 15;
            }
        }
    }
}