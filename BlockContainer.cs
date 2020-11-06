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

            for (int i = 0; i < size; i++)
            {
                blockarr[i, 0] = new NumberBlock(i, 0, 2, main);
                blockarr[i, 2] = new NumberBlock(i, 2, 2, main);

                blockarr[i, 3] = new NumberBlock(i, 3, 2, main);
            }
          




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
            for (int z = 0; z < size; z++)// array update
            {
                for (int k = 0; k < 4; k++)
                {
                    for (int i = 0; i < size - 1; i++)
                    {
                        if (blockarr[z, i] == null && blockarr[z, i + 1] != null)
                        {
                            blockarr[z, i + 1].LeftMove(false);
                            blockarr[z, i] = blockarr[z, i + 1];
                            blockarr[z, i + 1] = null;
                        }
                        if (blockarr[z, i] != null && blockarr[z, i + 1] != null && blockarr[z, i].getNumber() == blockarr[z, i + 1].getNumber())
                        {
                            blockarr[z, i + 1].LeftMove(true);
                            blockarr[z, i].multiple();

                        }
                    }
                }
            }
          

            for (int i = 0; i < size; i++) // updateBlock
            {
                for (int z = 0; z < size; z++)
                {
                    if (blockarr[i, z] != null && blockarr[i, z].Blockmoved())
                        blockarr[i, z].setMoveThread(new Thread(new ThreadStart(blockarr[i, z].leftAnimation)), blockarr, i, z);
                    if (blockarr[i, z] != null && blockarr[i, z].sizeChanged())
                    {
                        /*if(blockarr[i, z].move.ThreadState == ThreadState.Running)
                        {
                            blockarr[i, z].move.Join();
                            blockarr[i, z].setSizeUpDownThread();
                        }else*/
                            blockarr[i, z].setSizeUpDownThread();

                    }



                }
            }

        }

    }
}