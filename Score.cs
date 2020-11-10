using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2048
{
    class Score
    {
        Main main;

        long score;
        long addnum;
        long bestscore;
        Thread s;

        private Brush textbrush;
        private Font textfont;
        private Font animtext;

        private int animtextSize;

        private bool animate;
        private RectangleF rect2;

        public Score(Main m)
        {
            

            main = m;
            textfont = new Font("Verdana", 30, FontStyle.Regular, GraphicsUnit.Point);
            textbrush = Brushes.LightGray;

            animtextSize = 50;
            animtext = new Font("Verdana", animtextSize, FontStyle.Regular, GraphicsUnit.Point);
        }

        public void Draw(Graphics g)
        {
            Rectangle rect1 = new Rectangle(150, 75, 220, 40);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            g.DrawString(score.ToString(), textfont, textbrush, rect1, stringFormat);


            if (animate)
            {
                g.DrawString("+"+addnum.ToString(), animtext, textbrush, rect2, stringFormat);
            }

        }
        public void AddScore(long num)
        {
            addnum = num;
            score += addnum;
            s = new Thread(new ThreadStart(AddAnimation));
            animate = true;
            rect2 = new Rectangle(0, -55, 520, 340);
            s.Start();
            if(score > 9999)
            {
                textfont = new Font("Verdana", 10, FontStyle.Regular, GraphicsUnit.Point);
            }else if (score > 999)
            {
                textfont = new Font("Verdana", 15, FontStyle.Regular, GraphicsUnit.Point);
            }
            else if (score > 99)
            {
                textfont = new Font("Verdana", 19, FontStyle.Regular, GraphicsUnit.Point);
            }
            else if (score > 9)
            {
                textfont = new Font("Verdana", 23, FontStyle.Regular, GraphicsUnit.Point);
            }
            else
            {
                textfont = new Font("Verdana", 35, FontStyle.Regular, GraphicsUnit.Point);
            }

        }
        private void AddAnimation()
        {
            bool max = false;
            animtextSize = 0;

            while (true)
            {
                rect2.Y -= 1.7f;
                if (animtextSize <= 50 && !max)
                {
                    animtextSize += 3;
                    animtext = new Font("Verdana", animtextSize, FontStyle.Regular, GraphicsUnit.Point);
                    main.Invalidate();
                }else if(animtextSize > 50 && !max)
                {
                    max = true;
                }

                if (animtextSize <= 0)
                {
                    main.Invalidate();
                    break;
                }

                if (max)
                {
                    animtext = new Font("Verdana", animtextSize, FontStyle.Regular, GraphicsUnit.Point);
                    animtextSize -= 1;
                    main.Invalidate();
                }
                Thread.Sleep(10);
               
            }
            animate = false;


        }
        public void Reset()
        {
            score = 0;
        }


    }
}
