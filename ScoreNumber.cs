using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2048
{
    class ScoreNumber
    {
        Thread t;
        private Font animtext;
        private int animtextSize;
        private Brush textbrush;


        private RectangleF rect2;
        private bool max;

        private List<ScoreNumber> buffer;
        private Main main;
        private long num;

        public ScoreNumber(long num,List<ScoreNumber> buffer,Main main)
        {
            this.num = num;
            this.buffer = buffer;
            this.main = main;
            textbrush = Brushes.White;

            max = false;
            animtextSize = 1;
            rect2 = new Rectangle(250, 75, 300, 300);
            animtext = new Font("Verdana", animtextSize, FontStyle.Regular, GraphicsUnit.Point);
            t = new Thread(new ThreadStart(animation));
            t.Start();

        }

        public void Draw(Graphics g)
        {
            g.DrawString("+"+num.ToString(), animtext, textbrush, rect2);
        }
        private void animation()
        {
            while (true)
            {
                rect2.Y -= 0.7f;
                if (animtextSize <= 30 && !max)
                {
                    animtextSize += 5;
                    animtext = new Font("Verdana", animtextSize, FontStyle.Regular, GraphicsUnit.Point);
                    main.Invalidate();
                }
                else if (animtextSize > 30 && !max)
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

            buffer.Remove(this);
           
        }

       
       

    }
}
