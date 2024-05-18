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
string command = string.Empty;
while ((command = Console.ReadLine()) != "END")
{
    string[] commandToSplit = command.Split();
    if (commandToSplit[0] == "swap" && commandToSplit.Length == 5)
    {
        int row1 = int.Parse(commandToSplit[1]);
        int col1 = int.Parse(commandToSplit[2]);
        int row2 = int.Parse(commandToSplit[3]);
        int col2 = int.Parse(commandToSplit[4]);
        if (row1 < 0 || row1 >= matrix.GetLength(0) 
                     || row2 < 0 || row2 >= matrix.GetLength(0) 
                     || col1 < 0 || col1 >= matrix.GetLength(1) 
                     || col2 < 0 || col2 >= matrix.GetLength(1))
        {
            Console.WriteLine("Invalid input!");
            continue;
        }
        string elementToSwap = matrix[row1, col1];
        matrix[row1, col1] = matrix[row2, col2];
        matrix[row2, col2] = elementToSwap.ToString();
    }
    else
    {
        Console.WriteLine("Invalid input!");
        continue;
    }
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            Console.Write(matrix[row, col] + " ");
        }
        Console.WriteLine();
    }
}