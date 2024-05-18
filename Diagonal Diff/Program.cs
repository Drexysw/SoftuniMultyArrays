int n = int.Parse(Console.ReadLine());
int[,] matrix = new int[n, n];
for (int row = 0; row < matrix.GetLength(0); row++)
{
    int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = input[col];
    }
}
int sumOfPrimaryDiagonal = 0;
int sumOfSecondaryDiagonal = 0;
for (int row = 0; row < n; row++)
{
    sumOfPrimaryDiagonal += matrix[row, row];
    sumOfSecondaryDiagonal += matrix[row, n - 1 - row];

}

Console.WriteLine(Math.Abs(sumOfPrimaryDiagonal - sumOfSecondaryDiagonal));