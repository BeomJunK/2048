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
        private bool movedBlocks;

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

            int a = 1;



            AddBlock();
            AddBlock();



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
                            movedBlocks = true;
                        }
                        if (blockarr[z, i] != null && blockarr[z, i + 1] != null && blockarr[z, i].getNumber() == blockarr[z, i + 1].getNumber()
                            && !blockarr[z, i].getMultiped() && !blockarr[z, i + 1].getMultiped())
                        {
                            deadblocks.Add(new DeadBlock(blockarr[z, i + 1].getNumber(), z, i, blockarr[z, i + 1].getX(), blockarr[z, i + 1].getY(), main, deadblocks));
                            blockarr[z, i].multiple();
                            main.addscore(blockarr[z, i].getNumber());
                            blockarr[z, i + 1] = null;
                            movedBlocks = true;

                        }
                    }
                }
            }

            for (int i = 0; i < size; i++) // updateBlock
            {
                for (int z = 0; z < size; z++)
                {
                    if (blockarr[i, z] != null)
                        blockarr[i, z].setMultiped(false);

                    if (blockarr[i, z] != null && blockarr[i, z].Blockmoved())
                        blockarr[i, z].setMoveThread(new Thread(new ThreadStart(blockarr[i, z].moveAnimation)));
                    if (blockarr[i, z] != null && blockarr[i, z].sizeChanged())
                    {
                        blockarr[i, z].setSizeUpDownThread();
                    }
                }
            }

            if (movedBlocks)
            {
                AddBlock();
                movedBlocks = false;
            }
            if (!canMove())
            {
                main.gameOver();
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
                            movedBlocks = true;

                        }
                        if (blockarr[z, i] != null && blockarr[z, i + 1] != null && blockarr[z, i].getNumber() == blockarr[z, i + 1].getNumber()
                             && !blockarr[z, i].getMultiped() && !blockarr[z, i + 1].getMultiped())
                        {
                            deadblocks.Add(new DeadBlock(blockarr[z, i].getNumber(), z, i+1, blockarr[z, i].getX(), blockarr[z, i].getY(), main, deadblocks));
                            blockarr[z, i+1].multiple();
                            main.addscore(blockarr[z, i+1].getNumber());
                            blockarr[z, i] = null;
                            movedBlocks = true;

                        }
                    }
                }
            }

            for (int i = 0; i < size; i++) // updateBlock
            {
                for (int z = 0; z < size; z++)
                {
                    if (blockarr[i, z] != null)
                        blockarr[i, z].setMultiped(false);

                    if (blockarr[i, z] != null && blockarr[i, z].Blockmoved())
                        blockarr[i, z].setMoveThread(new Thread(new ThreadStart(blockarr[i, z].moveAnimation)));
                    if (blockarr[i, z] != null && blockarr[i, z].sizeChanged())
                    {
                        blockarr[i, z].setSizeUpDownThread();
                    }
                }
            }
            if (movedBlocks)
            {
                AddBlock();
                movedBlocks = false;
            }
            if (!canMove())
            {
                main.gameOver();
            }
        }
        public void BlocksUp()
        {

            for (int z = 0; z < size; z++)// array update
            {
                for (int k = 0; k < size; k++)
                {
                    for (int i = 0; i < size - 1; i++)
                    {
                        if (blockarr[i, z] == null && blockarr[i + 1, z] != null)
                        {
                            blockarr[i + 1, z].UpMove(false);
                            blockarr[i, z] = blockarr[i + 1, z ];
                            blockarr[i + 1, z ] = null;
                            movedBlocks = true;

                        }
                        if (blockarr[i, z] != null && blockarr[i + 1, z] != null && blockarr[i, z].getNumber() == blockarr[i+1,z].getNumber()
                             && !blockarr[i, z].getMultiped() && !blockarr[i+1, z].getMultiped())
                        {
                            deadblocks.Add(new DeadBlock(blockarr[i + 1, z].getNumber(), i, z, blockarr[i + 1, z ].getX(), blockarr[i + 1, z].getY(), main, deadblocks));
                            blockarr[i, z].multiple();
                            main.addscore(blockarr[i, z].getNumber());
                            blockarr[i + 1, z ] = null;
                            movedBlocks = true;

                        }
                    }
                }
            }

            for (int i = 0; i < size; i++) // updateBlock
            {
                for (int z = 0; z < size; z++)
                {
                    if (blockarr[i, z] != null)
                        blockarr[i, z].setMultiped(false);
                    if (blockarr[i, z] != null && blockarr[i, z].Blockmoved())
                        blockarr[i, z].setMoveThread(new Thread(new ThreadStart(blockarr[i, z].moveAnimation)));
                    if (blockarr[i, z] != null && blockarr[i, z].sizeChanged())
                    {
                        blockarr[i, z].setSizeUpDownThread();
                    }
                }
            }
            if (movedBlocks)
            {
                AddBlock();
                movedBlocks = false;
            }
            if (!canMove())
            {
                main.gameOver();
            }
        }
        public void BlocksDown()
        {

            for (int z = 0; z < size; z++)// array update
            {
                for (int k = 0; k < size; k++)
                {
                    for (int i = 0; i < size - 1; i++)
                    {
                        if (blockarr[i, z] != null && blockarr[i + 1, z] == null)
                        {
                            blockarr[i, z].DownMove(false);
                            blockarr[i + 1, z ] = blockarr[i, z];
                            blockarr[i, z] = null;
                            movedBlocks = true;

                        }
                        if (blockarr[i, z] != null && blockarr[i + 1, z] != null && blockarr[i, z].getNumber() == blockarr[i + 1, z].getNumber()
                             && !blockarr[i, z].getMultiped() && !blockarr[i+1, z].getMultiped())
                        {
                            deadblocks.Add(new DeadBlock(blockarr[i, z].getNumber(), i + 1, z , blockarr[i, z].getX(), blockarr[i, z].getY(), main, deadblocks));
                            blockarr[i + 1, z].multiple();
                            main.addscore(blockarr[i+1, z].getNumber());
                            blockarr[i, z] = null;
                            movedBlocks = true;

                        }
                    }
                }
            }

            for (int i = 0; i < size; i++) // updateBlock
            {
                for (int z = 0; z < size; z++)
                {
                    if (blockarr[i, z] != null)
                        blockarr[i, z].setMultiped(false);
                    if (blockarr[i, z] != null && blockarr[i, z].Blockmoved())
                        blockarr[i, z].setMoveThread(new Thread(new ThreadStart(blockarr[i, z].moveAnimation)));
                    if (blockarr[i, z] != null && blockarr[i, z].sizeChanged())
                    {
                        blockarr[i, z].setSizeUpDownThread();
                    }
                }
            }
            if (movedBlocks)
            {
                AddBlock();
                movedBlocks = false;
            }
            if (!canMove())
            {
                main.gameOver();
            }
        }

        private bool canMove()
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
            {
                if (fullcontainer)
                {
                    for (int r = 0; r < size; r++)
                    {
                        for (int c = 0; c < size - 1; c++)
                        {
                            if (blockarr[r, c].getNumber() == blockarr[r, c + 1].getNumber())
                            {
                                r = size;
                                return true;
                            }
                        }
                    }
                    for (int c = 0; c < size; c++)
                    {
                        for (int r = 0; r < size - 1; r++)
                        {
                            if (blockarr[r, c].getNumber() == blockarr[r+1, c].getNumber())
                            {
                                r = size;
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
            return true;

        }
    }
}