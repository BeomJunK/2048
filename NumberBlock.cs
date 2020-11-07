using System;
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
        private Thread UpandDown;
        public Thread move;
  

        private Color color;
        private SolidBrush brush;


        private Brush textbrush;
        private Font textfont;

       

        private int blocksize;


        private long number;
        private int Rows;
        private int Column;



        private bool moved;
        private bool destroyed;
        private bool changeSize;


        private int x;
        private int y;




        private Main main;
        

        public NumberBlock(int Row, int Column, long num, Main m)
        {
            main = m;
            t = new Thread(new ThreadStart(sizeUp));
            StartAnimation();
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
            textfont = new Font("Verdana", 40, FontStyle.Bold, GraphicsUnit.Point);


      

            textbrush = Brushes.Black;

            x = 30 + 100 * Column + 10 * Column + 29;
            y = 200 + 100 * Rows + 10 * Rows + 29;

        }

      

        public void Draw(Graphics g)
        {
            

            DrawRoundRect(g, brush, x, y, blocksize, blocksize, 5);

            Rectangle rect1 = new Rectangle(x, y, blocksize, blocksize);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            
            if(!changeSize)
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
            bool max = false;
            while (true)
            {
                if (blocksize > 125)
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
                        main.Invalidate();
                        break;
                    }
                    x +=2;
                    y += 2;
                    blocksize -= 4;
                    main.Invalidate();
                }
                Thread.Sleep(15);
            }

            changeSize = false;
        }

        public void StartAnimation()
        {
            t.Start();
        }
   

        public long getNumber()
        {
            return number;
        }
        public void multiple()
        {
            changeSize = true;
            number *= 2;
            if (number > 9999)
                textfont = new Font("Verdana", 10, FontStyle.Bold, GraphicsUnit.Point);
            else if (number > 999)
                textfont = new Font("Verdana", 20, FontStyle.Bold, GraphicsUnit.Point);
            else if (number > 99)
                textfont = new Font("Verdana", 25, FontStyle.Bold, GraphicsUnit.Point);
            else
                textfont = new Font("Verdana", 40, FontStyle.Bold, GraphicsUnit.Point);
        }
        public void setMoveThread(Thread t)
        {
           
            move = t;
            t.Start();


        }
        public void setSizeUpDownThread()
        {
            UpandDown = new Thread(new ThreadStart(sizeUpandDown));
            UpandDown.Start();
        }
        public void LeftMove(bool d)
        {
            destroyed = d;
            moved = true;
            Column--;
        }
        public void RightMove(bool d)
        {
            destroyed = d;
            moved = true;
            Column++;
        }
        public void UpMove(bool d)
        {
            destroyed = d;
            moved = true;
            Rows--;
        }
        public void DownMove(bool d)
        {
            destroyed = d;
            moved = true;
            Rows++;
        }
        public void moveAnimation()
        {
            int destinationX = 10 + 100 * Column + main.getDist() * Column;
            int destinationY = 180 + 100 * Rows + main.getDist() * Rows;

            if (destinationX < x)
            {
                while (true)
                {
                    if (destinationX < x)
                        x -= 10;
                    else if (destinationX >= x)
                        break;
                    main.Invalidate();
                    Thread.Sleep(3);
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
                    Thread.Sleep(3);
                }
            
            }
            if (destinationY < y)
            {
                while (true)
                {
                    if (destinationY < y)
                        y -= 10;
                    else if (destinationY >= y)
                        break;
                    main.Invalidate();
                    Thread.Sleep(3);
                }
            }
            else if (destinationY > y)
            {
                while (true)
                {
                    if (destinationY > y)
                        y += 10;
                    else if (destinationY <=y)
                        break;
                    main.Invalidate();
                    Thread.Sleep(3);
                }

            }

            x = destinationX;
            y = destinationY;
            moved = false;
          
            main.Invalidate();

        }
        public bool Blockmoved()
        {
            return moved;
        }
        
       public bool sizeChanged()
        {
            return changeSize;
        }
        public Thread getmoveThread()
        {
            return move;
        }
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }



    }


}