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
        bool infinityMode;

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


        BlockContainer container;

        Thread t;
        Thread over;
        int a;

        public Main()
        {
            InitializeComponent();
            infinityText = Color.FromArgb(255, 0, 0);
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
            infinityTextFont = new Font("Airal", 10, FontStyle.Bold);
            infinityMode = false;
            typeof(Panel).InvokeMember("DoubleBuffered", System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic, null, panel1, new object[] { true });

            containerSize = 4;
            container = new BlockContainer(containerSize, this);
            panel1.Visible = false;
            panel1.BackColor = Color.FromArgb(0, Color.White);
            button1.BackColor = Color.FromArgb(0, Color.White);
            label1.BackColor = Color.Transparent;



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
        private void lockKey()
        {
            Thread.Sleep(300);
            keylock = false;
        }
        public void gameOver()
        {
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
            containerSize = 4;
            container = new BlockContainer(containerSize, this);
            panel1.Visible = false;
            panel1.BackColor = Color.FromArgb(0, Color.White);
            button1.BackColor = Color.FromArgb(0, Color.White);
            label1.BackColor = Color.Transparent;
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

       

        private void x4모드ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = new Size(466, 659);
            containerSize = 4;
            container = new BlockContainer(containerSize, this);
            this.CenterToScreen();

        }

        private void x5모드ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = new Size(576, 769);
            containerSize = 5;
            container = new BlockContainer(containerSize, this);
            this.CenterToScreen();
        }
        private void x6모드ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = new Size(686, 879);
            containerSize = 6;
            container = new BlockContainer(containerSize, this);
            this.CenterToScreen();


        }
        private void x7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = new Size(796, 989);
            containerSize = 7;
            container = new BlockContainer(containerSize, this);
            this.CenterToScreen();

        }

        private void x8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = new Size(906, 1099);
            containerSize = 8;
            container = new BlockContainer(containerSize, this);
            this.CenterToScreen();


        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
