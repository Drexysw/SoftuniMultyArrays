int[] sizeOfMatrix = Console.ReadLine().Split().Select(int.Parse).ToArray();
string[,] matrix = new string[sizeOfMatrix[0], sizeOfMatrix[1]];
for (int row = 0; row < matrix.GetLength(0); row++)
{
    string[] rowToInput = Console.ReadLine().Split().ToArray();
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[row, j] = rowToInput[j];
    }
}
int countOfSquares = 0;
for (int row = 0; row <= matrix.GetLength(0) - 2; row++)
{
    for (int col = 0; col <= matrix.GetLength(1) - 2; col++)
    {
        if (matrix[row,col] == matrix[row,col + 1] && matrix[row, col] == matrix[row+1,col] && matrix[row, col] == matrix[row + 1, col + 1])
        {
            countOfSquares++;
        }
    }
}

Console.WriteLine(countOfSquares);
