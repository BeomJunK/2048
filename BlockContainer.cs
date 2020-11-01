using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



        public BlockContainer(int size)
        {
            random = new Random();
            this.size = size;
            blockarr = new NumberBlock[size, size];

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
        }
        public void AddBlock()
        {
            bool fullcontainer = true;

            for (int i = 0; i < size; i++)
            {
                for (int z = 0; z < size; z++)
                {
                    if(blockarr[i, z] == null)
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

                if (blockarr[column, row] == null)
                {
                    blockarr[column, row] = new NumberBlock(column, row, 2);
                    break;
                }
            }

        }


    }
}
