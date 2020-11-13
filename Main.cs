using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class Main : Form
    {
        bool keylock;
        private bool infinityMode { set; get; }
        public int multipleMode { set; get; }




        Color infinityText;
        Color Color;
        Color TitleColor;
        Color ScoreColor;
        Color ScoreFontColor;


        SolidBrush infinityTextbrush;
        SolidBrush brush;
        SolidBrush Titlebrush;
        SolidBrush Scorebrush;
        SolidBrush ScoreFontbrush;
        int dist;
        int containerSize;

        Font titleFont;
        Font scoreFont;
        Font infinityTextFont;


        private BlockContainer container;
        private Score score;
        
        Thread t;
        Thread over;
        int a;

        public Main()
        {
            InitializeComponent();
            containerSize = Properties.Settings.Default.gameSizeMode;
            multipleMode = Properties.Settings.Default.gameMultipleMode;
            switch (containerSize)
            {
                case 4:
                    this.Size = new Size(466, 659);
                    break;
                case 5:
                    this.Size = new Size(686, 769);
                    break;
                case 6:
                    this.Size = new Size(686, 879);
                    break;
                case 7:
                    this.Size = new Size(796, 989);
                    break;
                case 8:
                    this.Size = new Size(906, 1099);
                    break;
            }
            if (Properties.Settings.Default.clearGame == true)
            {
                infinityMode = true;
                ((ToolStripMenuItem)무한모드ToolStripMenuItem).Enabled = true;
                ((ToolStripMenuItem)무한모드ToolStripMenuItem).Checked = true;
            }
            else
            {
                infinityMode = false;
                ((ToolStripMenuItem)무한모드ToolStripMenuItem).Enabled = false;
                ((ToolStripMenuItem)무한모드ToolStripMenuItem).Checked = false;
            }


            infinityText = Color.FromArgb(245, 213, 228);
            Color = Color.FromArgb(202, 193, 181);
            TitleColor = Color.FromArgb(117, 110, 102);
            ScoreColor = Color.FromArgb(157, 150, 142);
            ScoreFontColor = Color.FromArgb(240, 240, 240);
            brush = new SolidBrush(Color);
            infinityTextbrush = new SolidBrush(infinityText);
            Titlebrush = new SolidBrush(TitleColor);
            Scorebrush = new SolidBrush(ScoreColor);
            ScoreFontbrush = new SolidBrush(ScoreFontColor);
            dist = 10;
            titleFont = new Font("Verdana", 50, FontStyle.Bold);
            scoreFont = new Font("Airal", 20);
            infinityTextFont = new Font("휴먼편지체", 15, FontStyle.Bold);
            typeof(Panel).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic, null, panel1, new object[] { true });



            container = new BlockContainer(containerSize, this);
            panel1.Visible = false;
            panel1.BackColor = Color.FromArgb(0, Color.White);
            button1.BackColor = Color.FromArgb(0, Color.White);
            label1.BackColor = Color.Transparent;

            score = new Score(this);


           
        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            //메인 폼 draw
            for (int i = 0; i < containerSize; i++)
            {
                for (int z = 0; z < containerSize; z++)
                {
                    DrawRoundRect(e.Graphics, brush, 10 + 100 * i + dist*i, 180+100 * z + dist * z, 100,100, 5);
                }
            }
            e.Graphics.DrawString("2048", titleFont, Titlebrush, new Point(10,40));
            DrawRoundRect(e.Graphics, Scorebrush, 220,40, 80,80, 5);
            DrawRoundRect(e.Graphics, Scorebrush, 320,40, 120,80, 5);
            e.Graphics.DrawString("score", scoreFont, ScoreFontbrush, new Point(220, 40));
            e.Graphics.DrawString("best", scoreFont, ScoreFontbrush, new Point(350, 40));


            container.Draw(e.Graphics);

            if(infinityMode)
                e.Graphics.DrawString("무한모드", infinityTextFont, infinityTextbrush, new Point(80, 120));

            score.Draw(e.Graphics);
        }

        void DrawRoundRect(Graphics g, Brush b, int x, int y, int w,int h, int r)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(x, y, r + r, r + r, 180, 90);
            path.AddLine(x + r, y, x + w - r, y);
            path.AddArc(x + w - 2 * r, y, 2 * r, 2 * r, 270, 90);
            path.AddLine(x + w, y + r, x + w, y + h - r);
            path.AddArc(x + w - 2 * r, y + h - 2 * r, r + r, r + r, 0, 91);
            path.AddLine(x + r, y + h, x + w - r, y + h);
            path.AddArc(x, y + h - 2 * r, 2 * r, 2 * r, 90, 91);
            path.CloseFigure();
            g.FillPath(b,path);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            gameOver();
        }

        private void 무한모드ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)무한모드ToolStripMenuItem).Checked == true)
            {
                ((ToolStripMenuItem)무한모드ToolStripMenuItem).Checked = false;
                infinityMode = false;
            }
            else
            {
                ((ToolStripMenuItem)무한모드ToolStripMenuItem).Checked = true;
                infinityMode = true;
            }
            Invalidate();
        }
        public int getDist()
        {
            return dist;
        }
        public bool getInfinitymode()
        {
            return infinityMode;
        }
        private void lockKey()
        {
            Thread.Sleep(300);
            keylock = false;
        }
        public void gameOver()
        {
            keylock = true;
            label1.Text = "Game Over!";
            label1.Location = new Point(this.Size.Width / 2 - label1.Width / 2,-100+ this.Size.Height / 2 - label1.Height / 2);
            button1.Location = new Point(this.Size.Width / 2 - button1.Width / 2, (this.Size.Height / 2 - button1.Height / 2));
            panel1.Enabled = true;
            panel1.Visible = true;
            a = 0;
            over = new Thread(new ThreadStart(endTitle));
            over.Start();
        }
        public void gameClear()
        {
            if (Properties.Settings.Default.clearGame == false)
            {
            ((ToolStripMenuItem)무한모드ToolStripMenuItem).Enabled = true;
                Properties.Settings.Default.clearGame = true;
                Properties.Settings.Default.Save();
            }

          

            keylock = true;
            label1.Text = "Game Clear!";
            label1.Location = new Point(this.Size.Width / 2 - label1.Width / 2, -100 + this.Size.Height / 2 - label1.Height / 2);
            button1.Location = new Point(this.Size.Width / 2 - button1.Width / 2, (this.Size.Height / 2 - button1.Height / 2));
            panel1.Enabled = true;
            panel1.Visible = true;
            a = 0;
            over = new Thread(new ThreadStart(endTitle));
            over.Start();
        }
        private void endTitle()
        {
            while (true)
            {
                panel1.BackColor = Color.FromArgb(a, Color.White);
                button1.BackColor = Color.FromArgb(a, Color.White);
                a+=2;
                panel1.Invalidate();
                Invalidate();
                Thread.Sleep(10);
                if (a > 200)
                    break;

              
            }
            
        }
        public void Restart()
        {
            lockKey();
            container = new BlockContainer(containerSize, this);

            score.Reset();
            a = 0;
            panel1.BackColor = Color.FromArgb(0, Color.White);
            button1.BackColor = Color.FromArgb(0, Color.White);
            label1.BackColor = Color.Transparent;
            panel1.AutoSize = false;
            panel1.Size = this.Size;
            panel1.Visible = false;
            panel1.Enabled = false;

        }
        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (!keylock)
                    {
                        keylock = true;
                        container.BlocksLeft();
                        t = new Thread(new ThreadStart(lockKey));
                        t.Start();
                    }
                    break;
                case Keys.Right:
                    if (!keylock)
                    {
                        keylock = true;
                        container.BlocksRight();
                        t = new Thread(new ThreadStart(lockKey));
                        t.Start();

                    }
                    break;
                case Keys.Down:
                    if (!keylock)
                    {
                        keylock = true;
                        container.BlocksDown();
                        t = new Thread(new ThreadStart(lockKey));
                        t.Start();

                    }
                    break;
                case Keys.Up:
                    if (!keylock)
                    {
                        keylock = true;
                        container.BlocksUp();
                        t = new Thread(new ThreadStart(lockKey));
                        t.Start();

                    }
                    break;
            }
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            keylock = false;
            Restart();
            if (infinityMode == false)
            {
                ((ToolStripMenuItem)무한모드ToolStripMenuItem).Enabled = true;
                ((ToolStripMenuItem)무한모드ToolStripMenuItem).Checked = true;
                infinityMode = true;
            }
                
        }
         public void addscore(long num)
        {
            score.AddScore(num);
        }
      

        private void 데이터초기화ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = new Size(466, 659);
            containerSize = 4;
            container = new BlockContainer(containerSize, this);
            this.CenterToScreen();

            Properties.Settings.Default.gameSizeMode = 4;

            multipleMode = 0;
            Restart();
            Properties.Settings.Default.gameMultipleMode = 0;
            Properties.Settings.Default.clearGame = false;
            Properties.Settings.Default.bestScore = 0;
            Properties.Settings.Default.Save();
            infinityMode = false;
            ((ToolStripMenuItem)무한모드ToolStripMenuItem).Checked = false;
            ((ToolStripMenuItem)무한모드ToolStripMenuItem).Enabled = false;
            Restart();
        }

        private void x4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = new Size(466, 659);
            containerSize = 4;
            container = new BlockContainer(containerSize, this);
            this.CenterToScreen();

            Properties.Settings.Default.gameSizeMode = 4;
            Properties.Settings.Default.Save();
        }

        private void x5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = new Size(576, 769);
            containerSize = 5;
            container = new BlockContainer(containerSize, this);
            this.CenterToScreen();

            Properties.Settings.Default.gameSizeMode = 5;
            Properties.Settings.Default.Save();
        }

        private void x6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = new Size(686, 879);
            containerSize = 6;
            container = new BlockContainer(containerSize, this);
            this.CenterToScreen();
            Properties.Settings.Default.gameSizeMode = 6;
            Properties.Settings.Default.Save();
        }

        private void x7ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Size = new Size(796, 989);
            containerSize = 7;
            container = new BlockContainer(containerSize, this);
            this.CenterToScreen();
            Properties.Settings.Default.gameSizeMode = 7;
            Properties.Settings.Default.Save();
        }

        private void x8ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Size = new Size(906, 1099);
            containerSize = 8;
            container = new BlockContainer(containerSize, this);
            this.CenterToScreen();
            Properties.Settings.Default.gameSizeMode = 8;
            Properties.Settings.Default.Save();
        }

        private void 배수모드ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            multipleMode = 0;
            Restart();
            Properties.Settings.Default.gameMultipleMode = 0;
            Properties.Settings.Default.Save();
        }

        private void 모드ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            multipleMode = 1;
            Restart();

            Properties.Settings.Default.gameMultipleMode = 1;
            Properties.Settings.Default.Save();
        }

        private void 모드ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            multipleMode = 2;
            Restart();

            Properties.Settings.Default.gameMultipleMode = 2;
            Properties.Settings.Default.Save();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            multipleMode = 3;
            Restart();
            Properties.Settings.Default.gameMultipleMode = 3;
            Properties.Settings.Default.Save();
        }
    }
}
