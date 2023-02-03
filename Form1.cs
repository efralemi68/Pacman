namespace Laboratorio2
{
    public partial class Form1 : Form

    {
        Bitmap bmp;
        static Graphics g;

        bool up, down, left, right, over;
        int score, playerSpeed, enemie1speed, enemie2speed, enemie3speed, enemie4speed;

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(250, 250);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            DrawMap();

            reset();
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
             
        }

        private void DrawMap()
        {
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Green);

            for( int x=0; x < Mapa.map0.GetLength(0); x++)
            {
                for (int y = 0; y < Mapa.map0.GetLength(1); y++)
                {
                    if(Mapa.map0[x, y] != 0)
                    {
                        g.FillRectangle(new SolidBrush(Color.FromArgb(35, 35, 35)), x * 10, y * 10, 10, 10);
                    }
                    else
                    {
                        g.DrawRectangle(Pens.Gray, x * 10, y * 10, 10, 10);
                    }
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e) // ventana
        {
            label1.Text = "SCORE: " + score;

            if (left == true)
            {
                PACMAN.Left -= playerSpeed;
                PACMAN.Image = Properties.Resources.left;

            }
            if (right == true)
            {
                PACMAN.Left += playerSpeed;
                PACMAN.Image = Properties.Resources.right;

            }

            if (down == true)
            {
                PACMAN.Top += playerSpeed;
                PACMAN.Image = Properties.Resources.down;

            }

            if (up == true)
            {
                PACMAN.Top -= playerSpeed;
                PACMAN.Image = Properties.Resources.Up;

            }

            if (PACMAN.Left < -2)
            {
                PACMAN.Left = 300;

            }

            if (PACMAN.Left > 300)
            {
                PACMAN.Left = -2;
            }

            if (PACMAN.Top < -2)
            {
                PACMAN.Top = 300;

            }

            if (PACMAN.Top > 300)
            {
                PACMAN.Top = -2;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "coin" && x.Visible == true) // score 
                    {
                        if (PACMAN.Bounds.IntersectsWith(x.Bounds))
                        {
                            score += 1;
                            x.Visible = false;
                        }
                    }

                    if ((string)x.Tag == "enem")
                    {
                        if (PACMAN.Bounds.IntersectsWith(x.Bounds))
                        {
                            Game_over("YOU LOOSE :( ");
                        }


                    }
                }
            }

            enemie1.Left += enemie1speed;
            if (enemie1.Bounds.IntersectsWith(pictureBox33.Bounds) || enemie1.Bounds.IntersectsWith(pictureBox34.Bounds))
            {
                enemie1speed = -enemie1speed;
            }
            enemie2.Left += enemie2speed;
            if (enemie2.Bounds.IntersectsWith(pictureBox36.Bounds) || enemie2.Bounds.IntersectsWith(pictureBox35.Bounds))
            {
                enemie2speed = -enemie2speed;
            }

            enemi3.Left += enemie3speed;
            if (enemi3.Bounds.IntersectsWith(pictureBox37.Bounds) || enemi3.Bounds.IntersectsWith(pictureBox38.Bounds))
            {
                enemie3speed = -enemie3speed;
            }

            enemie4.Left += enemie4speed;

            
            if (enemie4.Bounds.IntersectsWith(pictureBox39.Bounds) || enemie4.Bounds.IntersectsWith(pictureBox40.Bounds))
            {
                enemie4speed = -enemie4speed;
            }

            if (score == 30)
            {
                Game_over("AMAZING! YOU WIN! ");
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e) //pacman
        {

        }

        private void enemie1_Click(object sender, EventArgs e) // enemie 1
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.Up)
            {
                up = true;
            }

            if(e.KeyCode == Keys.Down)
            {
                down = true;
            }

            if (e.KeyCode == Keys.Left)
            {
                left = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                right = true;
            }

            if (e.KeyCode == Keys.Enter && over== true)
            {
                reset();
            }


        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                up = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                down =false;
            }

            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }

        }

        private void reset()
        {
            label1.Text = "SCORE: 0";
            score = 0;

            enemie1speed = 1;
            enemie2speed = 1;
            enemie3speed = 1;
            enemie4speed = 1;

           playerSpeed = 2;

            over = false;

            PACMAN.Left = 3;
            PACMAN.Top = 0;

            enemie1.Left = 206;
            enemie1.Top = 100;

            enemie2.Left = 109;
            enemie2.Top = 141;

            enemi3.Left = 118;
            enemi3.Top = 211;

            enemie4.Left = 118;
            enemie4.Top = 192;

            

            gameTimer.Start();

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    x.Visible = true;
                }
            }


        }

        private void Game_over(string m)
        {
            over = true;

            gameTimer.Stop();

            label1.Text = "Score" + score + Environment.NewLine + m;
        }
    }
}