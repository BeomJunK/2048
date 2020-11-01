using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _2048
{
    class NumberBlock
    {
        private  Color color;
        private SolidBrush brush;

        
        private Brush textbrush;
        private Font textfont;

        private long number;
        private int r;
        private int g;
        private int b;

        private int Rows;
        private int Column;

        private int x;
        private int y;

        public NumberBlock(int Row,int Column , long num)
        {
            number = num;
            this.Rows = Row;
            this.Column = Column;
            color = Color.FromArgb(238, 228, 218);
            /*ColorTabel
              238 228 218
              238 225 201
              243 178 122
              247 95 59*/


            brush = new SolidBrush(color);


            if(number > 9999)
                textfont = new Font("Verdana", 15, FontStyle.Bold, GraphicsUnit.Point);
            else
                textfont = new Font("Verdana", 40,FontStyle.Bold, GraphicsUnit.Point);
            textbrush = Brushes.Black;

        }
        public void Draw(Graphics g)
        {
            x = 10 + 100 * Column + 10 * Column;
            y = 180 + 100 * Rows + 10 * Rows;
            DrawRoundRect(g, brush, x,y, 100, 100, 5);

            Rectangle rect1 = new Rectangle(x, y, 100, 100);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            g.DrawString(number.ToString(), textfont, textbrush, rect1, stringFormat);
        }
        void DrawRoundRect(Graphics g, Brush b, int x, int y, int w, int h, int r)
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
            g.FillPath(b, path);
        }
    }

  
}
