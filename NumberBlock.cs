﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace _2048
{
    class NumberBlock
    {
        private Thread t;

        private  Color color;
        private SolidBrush brush;

        
        private Brush textbrush;
        private Font textfont;

        private long number;

        private int blocksize;

        private int r;
        private int g;
        private int b;

        private int Rows;
        private int Column;

        private int x;
        private int y;

        private Main main;

        public NumberBlock(int Row,int Column , long num ,Main m)
        {
            main = m;
            t = new Thread(new ThreadStart(sizeUp));
            Animation();

            blocksize = 0;
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

            x = 30 + 100 * Column + 10 * Column +29;
            y = 200 + 100 * Rows + 10 * Rows +29;

        }
        public void Draw(Graphics g)
        {
          
            DrawRoundRect(g, brush, x,y, blocksize, blocksize, 5);

            Rectangle rect1 = new Rectangle(x, y, blocksize, blocksize);
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
        private void sizeUp()
        {
            while (true)
            {
                x -= 2;
                y -= 2;
                blocksize += 4;
                main.Invalidate();
                if (blocksize >= 100)
                {
                    break;
                }
                Thread.Sleep(10);
            }
        }
        private void sizeUpandDown()
        {
            bool max= false;
            while (true)
            {
                if (blocksize > 130)
                {
                    max = true;
                }
                if (!max)
                {
                    x -= 2;
                    y -= 2;
                    blocksize += 4;
                    main.Invalidate();
                }
                else if (max)
                {
                    if (blocksize <= 100)
                    {
                        x = 10 + 100 * Column + 10 * Column;
                        y = 180 + 100 * Rows + 10 * Rows;
                        blocksize = 100;
                        break;
                    }
                    x += 2;
                    y += 2;
                    blocksize -= 4;
                    main.Invalidate();
                }
                Thread.Sleep(10);
            }
            main.Invalidate();
        }

        public void Animation()
        {
            t.Start();
        }
    }
   

}
