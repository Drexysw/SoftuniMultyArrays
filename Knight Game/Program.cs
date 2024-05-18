var sizeOfMatrix = int.Parse(Console.ReadLine());
var matrix = new int[sizeOfMatrix, sizeOfMatrix];
for (int row = 0; row < matrix.GetLength(0); row++)
{
    var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = input[col];
    }
}
var cordinates = Console.ReadLine().Split();
for (int i = 0; i < cordinates.Length; i++)
{
    var singleCordinate = cordinates[i].Split(",");
    var row = int.Parse(singleCordinate[0]);
    var col = int.Parse(singleCordinate[1]);
    if (matrix[row, col] > 0)
    {
        ReduceValuesOfMatrix(row, col, matrix);
    }
}

Console.WriteLine($"Alive cells: {matrix.Cast<int>().Count(x => x > 0)}");
Console.WriteLine($"Sum: {matrix.Cast<int>().Where(x => x > 0).Sum(x => x)}");
PrintMatrix(matrix);

void PrintMatrix(int[,] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            Console.Write(matrix[row, col] + " ");
        }
        Console.WriteLine();
    }
}
void ReduceValuesOfMatrix(int row, int col, int[,] matrix)
{
    var currnetValue = matrix[row, col];
    //upper
    if (IsInside(row-1,col,matrix.GetLength(0),matrix.GetLength(1)) && matrix[row-1, col] > 0)
    {
        matrix[row - 1, col] -= currnetValue;
    }
    //upperLeft
    if (IsInside(row - 1, col-1, matrix.GetLength(0), matrix.GetLength(1)) && matrix[row - 1, col - 1] > 0)
    {
        matrix[row - 1, col-1] -= currnetValue;
    }
    //upperRight
    if (IsInside(row - 1, col + 1, matrix.GetLength(0), matrix.GetLength(1)) && matrix[row - 1, col + 1] > 0)
    {
        matrix[row - 1, col + 1] -= currnetValue;
    }
    //midLeft
    if (IsInside(row, col - 1, matrix.GetLength(0), matrix.GetLength(1)) && matrix[row, col - 1] > 0)
    {
        matrix[row, col - 1] -= currnetValue;
    }
    //midRight
    if (IsInside(row, col + 1, matrix.GetLength(0), matrix.GetLength(1)) && matrix[row, col + 1] > 0)
    {
        matrix[row, col + 1] -= currnetValue;
    }
    //downLeft
    if (IsInside(row + 1, col - 1, matrix.GetLength(0), matrix.GetLength(1)) && matrix[row+1,col-1] > 0)
    {
        matrix[row+1, col - 1] -= currnetValue;
    }
    //downRight
    if (IsInside(row + 1, col + 1, matrix.GetLength(0), matrix.GetLength(1)) && matrix[row + 1, col + 1] > 0)
    {
        matrix[row+1, col + 1] -= currnetValue;
    }
    //down
    if (IsInside(row + 1, col, matrix.GetLength(0), matrix.GetLength(1)) && matrix[row + 1, col] > 0)
    {
        matrix[row + 1, col] -= currnetValue;
    }
    matrix[row, col] = 0;
}
bool IsInside(int row, int col, int rows, int cols)
{
    return row >= 0 && row < rows && col >= 0 && col < cols;
}

