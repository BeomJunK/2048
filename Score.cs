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
      
        Thread s;

        private Brush textbrush;
        private Font textfont;
        private Font besttextfont;





        private List<ScoreNumber> buffer;
        public Score(Main m)
        {
            main = m;
            textfont = new Font("Verdana", 30, FontStyle.Regular, GraphicsUnit.Point);
            besttextfont = new Font("Verdana", 30, FontStyle.Regular, GraphicsUnit.Point);
            textbrush = Brushes.LightGray;
            buffer = new List<ScoreNumber>();



            if (Properties.Settings.Default.bestScore > 9999)
            {
                besttextfont = new Font("Verdana", 10, FontStyle.Regular, GraphicsUnit.Point);
            }
            else if (Properties.Settings.Default.bestScore > 999)
            {
                besttextfont = new Font("Verdana", 15, FontStyle.Regular, GraphicsUnit.Point);
            }
            else if (Properties.Settings.Default.bestScore > 99)
            {
                besttextfont = new Font("Verdana", 19, FontStyle.Regular, GraphicsUnit.Point);
            }
            else if (Properties.Settings.Default.bestScore > 9)
            {
                besttextfont = new Font("Verdana", 23, FontStyle.Regular, GraphicsUnit.Point);
            }
            else
            {
                besttextfont = new Font("Verdana", 35, FontStyle.Regular, GraphicsUnit.Point);
            }
        }

        public void Draw(Graphics g)
        {
            Rectangle rect1 = new Rectangle(150, 75, 220, 40);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            g.DrawString(score.ToString(), textfont, textbrush, rect1, stringFormat);
            rect1.X += 120;
            g.DrawString(Properties.Settings.Default.bestScore.ToString(), besttextfont, textbrush, rect1, stringFormat);
        

            for (int i = 0; i < buffer.Count; i++)
            {
                buffer[0].Draw(g);
            }


        }
        public void AddScore(long num)
        {
            addnum = num;
            score += addnum;

            if(score >= 2048)
            {
                if (!main.getInfinitymode())
                {
                    
                    main.gameClear();
                  
                }
                
              
            }
            if (Properties.Settings.Default.bestScore < score)
            {
                Properties.Settings.Default.bestScore = score;
                if (Properties.Settings.Default.bestScore > 9999)
                {
                    besttextfont = new Font("Verdana", 10, FontStyle.Regular, GraphicsUnit.Point);
                }
                else if (Properties.Settings.Default.bestScore > 999)
                {
                    besttextfont = new Font("Verdana", 15, FontStyle.Regular, GraphicsUnit.Point);
                }
                else if (Properties.Settings.Default.bestScore > 99)
                {
                    besttextfont = new Font("Verdana", 19, FontStyle.Regular, GraphicsUnit.Point);
                }
                else if (Properties.Settings.Default.bestScore > 9)
                {
                    besttextfont = new Font("Verdana", 23, FontStyle.Regular, GraphicsUnit.Point);
                }
                else
                {
                    besttextfont = new Font("Verdana", 35, FontStyle.Regular, GraphicsUnit.Point);
                }

                Properties.Settings.Default.Save();
            }


            buffer.Add(new ScoreNumber(addnum, buffer, main));
            if (score > 9999)
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
     
        public void Reset()
        {
            score = 0;
        }


    }
}
