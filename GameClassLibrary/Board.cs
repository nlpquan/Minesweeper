using System;

namespace GameClassLibrary
{
    public class Board
    {
        // the board is square
        public int Size { get; set; }

        // 2d array of Cell objects
        public Cell[,] theGrid;

        public Board(int s)
        {
            Size = s;
            // must initialize to avoid Null exception
            theGrid = new Cell[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }

        // set the live neighbors
        public void setupLiveNeighbors(Cell currentCell, int difficulty)
        {
            for (int r = 0; r < Size; r++)
            {
                for (int c = 0; c < Size; c++)
                {
                    theGrid[r, c].Live = false;
                }
            }

            // easy mode difficulty
            switch (difficulty)
            {
                case 1:
                    try
                    {
                        theGrid[currentCell.Row, currentCell.Column].Live = true;
                        theGrid[currentCell.Row, currentCell.Column - 1].Live = true;
                        theGrid[currentCell.Row, currentCell.Column + 1].Live = true;
                        theGrid[currentCell.Row - 1, currentCell.Column].Live = true;
                        theGrid[currentCell.Row + 1, currentCell.Column].Live = true;
                        theGrid[currentCell.Row - 1, currentCell.Column - 1].Live = true;
                        theGrid[currentCell.Row + 1, currentCell.Column + 1].Live = true;
                        theGrid[currentCell.Row + 1, currentCell.Column - 1].Live = true;
                    }
                    catch
                    {

                    }
                    break;
            }
        }

        // calculate the number of live neighbors
        public string calculateLiveNeighbors()
        {
            Random rand = new Random();
            
            string[] num1 = { "", "0", "1", "2", "3" };
            string[] num2 = { "", "0", "1", "2", "3" };

            int randNum1 = rand.Next(num1.Length);
            int randNum2 = rand.Next(num2.Length);
            while(randNum1 == randNum2)
            {
                randNum2 = rand.Next(num2.Length);
                return num2[randNum2];
            }
            return num1[randNum2];

        }
    }
}
