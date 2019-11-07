using System;

namespace GameOfLife
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[,] grid = new int[,] { { 1, 1, 1, 1 }, { 0, 1, 1, 0 }, { 1, 1, 0, 0 } };
            
            Console.WriteLine("Input = ");
            DisplayGrid(grid);
            var outputArray = GetNextGridState(grid);
            Console.WriteLine("Output = ");
            DisplayGrid(outputArray);
        }

        public static bool GetBoolVal() {
            return true;
        }

        public static int[,] GetNextGridState(int[,] grid)
        {
            int[,] outputArray = new int[grid.GetLength(0), grid.GetLength(1)];
            int val, newVal = 0, liveNeighbourCount = 0;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    val = grid[i, j];
                    liveNeighbourCount = _GetLiveNeighboursCount(grid, i, j);
                    // Console.WriteLine("Count = "+ liveNeighboursCount);
                    if (val == 1)
                    {
                        if (liveNeighbourCount < 2 || liveNeighbourCount > 3)
                        {
                            newVal = 0;
                        }
                        else
                            newVal = 1;
                    }
                    if (val == 0)
                    {
                        if (liveNeighbourCount == 3)
                            newVal = 1;
                        else
                            newVal = 0;
                    }
                    outputArray[i, j] = newVal;
                }
            }

            return outputArray;
        }

        static int _GetLiveNeighboursCount(int[,] grid, int xCordinate, int yCordinate) {
        // What is the bug in this implementation
            int count = 0;

            if(yCordinate > 0 && grid[xCordinate,yCordinate - 1] == 1) {
                count++;
            }
            if(yCordinate < grid.GetLength(1)-1 && grid[xCordinate,yCordinate + 1] == 1) {
                count++;
            }
            if(xCordinate > 0 && grid[xCordinate - 1,yCordinate] == 1) {
                count++;
            }
            if(xCordinate < grid.GetLength(0)-1 && grid[xCordinate + 1,yCordinate] == 1) {
                count++;
            }
            return count;
        }

        public static void DisplayGrid(int[,] grid) {
            for(int i=0; i < grid.GetLength(0); i++) {
                for(int j=0; j < grid.GetLength(1); j++) {
                    Console.Write(grid[i,j]);
                }
                Console.WriteLine();
            }
        }
        
    }
}
