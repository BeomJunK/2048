using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2048
{
    class DeadBlock
    {
        List<DeadBlock> deadBlocks;

        private int x, y;
        private int blocksize;


        private Color color;
        private SolidBrush brush;


        private Brush textbrush;
        private Font textfont;

        private long number;
        private int Rows;
        private int Column;
        private int previousRows;
        private int previousColumn;

        private Main main;

        Thread t;
        public DeadBlock(long num,int Row,int Column,int x,int y,Main main , List<DeadBlock> deadBlocks)
        {
          
            blocksize = 100;
            number = num;
            this.Rows = Row;
            this.Column = Column;
            this.x = x;
            this.y = y;
            this.main = main;
            this.deadBlocks = deadBlocks;

            color = Color.FromArgb(238, 228, 218);
            /*ColorTabel
              238 228 218
              238 225 201
              243 178 122
              247 95 59*/


            brush = new SolidBrush(color);


            if (number > 9999)
                textfont = new Font("Verdana", 15, FontStyle.Bold, GraphicsUnit.Point);
            else
                textfont = new Font("Verdana", 40, FontStyle.Bold, GraphicsUnit.Point);
            textbrush = Brushes.Black;

      

            t = new Thread(new ThreadStart(moveAnimation));
            t.Start();
        }

        public void Draw(Graphics g)
        {
            DrawRoundRect(g, brush, x, y, blocksize, blocksize, 5);

            Rectangle rect1 = new Rectangle(x, y, blocksize, blocksize);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            g.DrawString(number.ToString(), textfont, textbrush, rect1, stringFormat);
        }
        public void moveAnimation()
        {
            int destinationX = 10 + 100 * Column + main.getDist() * Column;
            if (destinationX < x)
            {
                while (true)
                {
                    if (destinationX < x)
                        x -= 10;
                    else if (destinationX >= x)
                        break;
                    main.Invalidate();
                    Thread.Sleep(1);
                }
            }
            else if (destinationX > x)
            {
                while (true)
                {
                    if (destinationX > x)
                        x += 10;
                    else if (destinationX <= x)
                        break;
                    main.Invalidate();
                    Thread.Sleep(1);
                }

            }
            x = destinationX;
            main.Invalidate();

            deadBlocks.Remove(this);
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
