int n = int.Parse(Console.ReadLine());
int[][] pascalTryangle = new int[n][];
pascalTryangle[0] = new int[] { 1 };
for (int row = 1; row < pascalTryangle.Length; row++)
{
    pascalTryangle[row] = new int[row + 1];
    for (int col = 0; col < pascalTryangle[row].Length; col++)
    {
        if (pascalTryangle[row-1].Length > col)
        {
            pascalTryangle[row][col] += pascalTryangle[row - 1][col];
        }
        if (col > 0)
        {
            pascalTryangle[row][col] += pascalTryangle[row - 1][col - 1];
        }
    }
}
for (int row = 0; row < pascalTryangle.Length; row++)
{
    for (int col = 0; col < pascalTryangle[row].Length; col++)
    {
        Console.Write(pascalTryangle[row][col] + " ");
    }
    Console.WriteLine();
}