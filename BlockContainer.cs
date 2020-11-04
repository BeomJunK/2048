using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using System.Drawing;

namespace _2048
{
    class BlockContainer
    {

        private int size;

        NumberBlock[,] blockarr;
        Random random;

        private int column;
        private int row;
        private Main main;


        public BlockContainer(int size, Main m)
        {
            main = m;

            random = new Random();
            this.size = size;
            blockarr = new NumberBlock[size, size];

            blockarr[0, 0] = new NumberBlock(0, 0, 4, main);
            blockarr[0,2] = new NumberBlock(0, 2, 2, main);
            /*   blockarr[0, 1] = new NumberBlock(0, 1, 2, main);
               blockarr[0, 2] = new NumberBlock(0, 2, 4, main)*/
            ;

            blockarr[0, 3] = new NumberBlock(0, 3, 4, main);

        
      
         
            /* AddBlock();
             AddBlock();*/


        }
        //block start point 10 , 180
        public void Draw(Graphics g)
        {
            for (int i = 0; i < size; i++)
            {
                for (int z = 0; z < size; z++)
                {
                    if (blockarr[i, z] != null)
                        blockarr[i, z].Draw(g);
                }
            }
        }
        public void AddBlock()
        {
            bool fullcontainer = true;

            for (int i = 0; i < size; i++)
            {
                for (int z = 0; z < size; z++)
                {
                    if (blockarr[i, z] == null)
                    {
                        fullcontainer = false;
                        i = size;
                        break;
                    }
                }
            }

            if (fullcontainer)
                return;


            while (true)
            {
                column = random.Next(0, size);
                row = random.Next(0, size);

                if (blockarr[row, column] == null)
                {
                    if (random.Next(0, 3) == 0)
                        blockarr[row, column] = new NumberBlock(row, column, 4, main);
                    else
                        blockarr[row, column] = new NumberBlock(row, column, 2, main);
                    break;
                }
            }

        }

        public void BlocksLeft()
        {

            for (int i = 0; i < size; i++)
            {
                for (int k = size - 1; k > 0; k--)
                {
                    for (int z = k; z > 0; z--)
                    {
                        if (blockarr[i, z] != null && blockarr[i, z - 1] == null)
                        {
                            blockarr[i, z].LeftMove();
                            blockarr[i, z - 1] = blockarr[i, z];
                            blockarr[i, z] = null;
                        }
                        if (blockarr[i, z] != null && blockarr[i, z].getNumber() == blockarr[i, z - 1].getNumber())
                        {
                            blockarr[i, z - 1].multiple();
                            blockarr[i, z - 1].addUpAnimation();
                            blockarr[i, z]=null;
                            break;
                        }

                    }
                  

                }
               
            }

            for (int i = 0; i < size; i++)
            {
                for (int z = 0; z < size; z++)
                {
                    if (blockarr[i, z] != null && blockarr[i, z].Blockmoved())
                        blockarr[i, z].setMoveThread(new Thread(new ThreadStart(blockarr[i, z].leftAnimation)), blockarr, i, z);
                }
            }

        }
    }
}

  

