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

        public NumberBlock[,] blockarr;
        public List<DeadBlock> deadblocks;

        Random random;

        private int column;
        private int row;
        private Main main;



        public BlockContainer(int size, Main m)
        {
            main = m;

            deadblocks = new List<DeadBlock>();
            random = new Random();
            this.size = size;
            blockarr = new NumberBlock[size, size];
            
          
                blockarr[0,0] = new NumberBlock(0, 0, 4, main);
                blockarr[0, 3] = new NumberBlock(0, 3, 4, main);

            blockarr[1, 2] = new NumberBlock(1, 2, 4, main);
            blockarr[1, 3] = new NumberBlock(1, 3, 2, main);




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
           
            for(int i = 0; i < deadblocks.Count; i++)
            {
                deadblocks[i].Draw(g);
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
                for (int k = 0; k < size; k++)
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
                            deadblocks.Add(new DeadBlock(blockarr[z, i+1].getNumber(), z, i, blockarr[z, i + 1].getX(), blockarr[z, i + 1].getY(), main, deadblocks));
                            blockarr[z, i].multiple();
                            blockarr[z, i + 1] = null;
                        }
                    }
                }
            }

            for (int i = 0; i < size; i++) // updateBlock
            {
                for (int z = 0; z < size; z++)
                {
                    if (blockarr[i, z] != null && blockarr[i, z].Blockmoved())
                        blockarr[i, z].setMoveThread(new Thread(new ThreadStart(blockarr[i, z].moveAnimation)));
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


        public void BlocksRight()
        {
            for (int z = 0; z < size; z++)// array update
            {
                for (int k = 0; k < size; k++)
                {
                    for (int i = 0; i < size - 1; i++)
                    {
                        if (blockarr[z, i] != null && blockarr[z, i + 1] == null)
                        {
                            blockarr[z, i].RightMove(false);
                            blockarr[z, i+1] = blockarr[z, i];
                            blockarr[z, i] = null;
                        }
                        if (blockarr[z, i] != null && blockarr[z, i + 1] != null && blockarr[z, i].getNumber() == blockarr[z, i + 1].getNumber())
                        {
                            deadblocks.Add(new DeadBlock(blockarr[z, i].getNumber(), z, i+1, blockarr[z, i].getX(), blockarr[z, i].getY(), main, deadblocks));
                            blockarr[z, i+1].multiple();
                            blockarr[z, i] = null;
                        }
                    }
                }
            }

            for (int i = 0; i < size; i++) // updateBlock
            {
                for (int z = 0; z < size; z++)
                {
                    if (blockarr[i, z] != null && blockarr[i, z].Blockmoved())
                        blockarr[i, z].setMoveThread(new Thread(new ThreadStart(blockarr[i, z].moveAnimation)));
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