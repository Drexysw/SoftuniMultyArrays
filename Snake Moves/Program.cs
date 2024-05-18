int[] sizeOfMatrix = Console.ReadLine().Split().Select(int.Parse).ToArray();
string[,] matrix = new string[sizeOfMatrix[0], sizeOfMatrix[1]];
string input = Console.ReadLine();
string currentWord = string.Empty;
for (int row = 0; row < matrix.GetLength(0); row++)
{
    if (row % 2 == 0)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            if (currentWord.Any())
            {
                matrix[row, col] = currentWord[0].ToString();
                currentWord = currentWord.Remove(0,1);
            }
            else
            {
                currentWord = input;
                matrix[row, col] = currentWord[0].ToString();
                currentWord =  currentWord.Remove(0, 1);
            }
        }
    }
    else
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            if (currentWord.Any())
            {
                matrix[row, matrix.GetLength(1) - col - 1] = currentWord[0].ToString();
                currentWord = currentWord.Remove(0, 1);
            }
            else
            {
                currentWord = input;
                matrix[row, matrix.GetLength(1) - col - 1] = currentWord[0].ToString();
                currentWord =  currentWord.Remove(0, 1);
            }
        }
    }
}

for (int row = 0; row < matrix.GetLength(0); row++)
{
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        Console.Write(matrix[row, col]);

    }
    Console.WriteLine();
}