using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class Main : Form
    {
        Color Color;
        Color TitleColor;
        Color ScoreColor;
        Color ScoreFontColor;


        SolidBrush brush;
        SolidBrush Titlebrush;
        SolidBrush Scorebrush;
        SolidBrush ScoreFontbrush;
        int dist;
        Font titleFont;
        Font scoreFont;

        BlockContainer container;

        public Main()
        {
            InitializeComponent();
            Color = Color.FromArgb(202, 193, 181);
            TitleColor = Color.FromArgb(117, 110, 102);
            ScoreColor = Color.FromArgb(157, 150, 142);
            ScoreFontColor = Color.FromArgb(240, 240, 240);
            brush = new SolidBrush(Color);
            Titlebrush = new SolidBrush(TitleColor);
            Scorebrush = new SolidBrush(ScoreColor);
            ScoreFontbrush = new SolidBrush(ScoreFontColor);
            dist = 10;
            titleFont = new Font("Verdana", 50,FontStyle.Bold);
            scoreFont = new Font("Airal", 20);

            container = new BlockContainer(4,this);

        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            //메인 폼 draw
            for (int i = 0; i < 4; i++)
            {
                for (int z = 0; z < 4; z++)
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
            container.BlocksLeft();
        }

        private void 무한모드ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        public int getDist()
        {
            return dist;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            container.AddBlock();

        }
    }
}
