int sizeOfMatrix = int.Parse(Console.ReadLine());
var commands = Console.ReadLine().Split(", ");
var matrix = new char[sizeOfMatrix, sizeOfMatrix];
int currentSquirrelRow = 0;
int currentSquirrelCol = 0;
int countOfHazelnuts = 0;
bool IsGameWon = false;
bool IsGameOver = false;
bool IsSquirrelOutside = false;
for (int row = 0; row < matrix.GetLength(0); row++)
{
    var input = Console.ReadLine().ToCharArray();
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = input[col];
        if (matrix[row, col] == 's')
        {
            currentSquirrelRow = row;
            currentSquirrelCol = col;
        }
    }
}

foreach (var command in commands)
{
    if (command == "up")
    {
        if (IsOutside(currentSquirrelRow - 1, currentSquirrelCol, sizeOfMatrix, sizeOfMatrix))
        {
            matrix[currentSquirrelRow, currentSquirrelCol] = '*';
            Console.WriteLine("The squirrel is out of the field.");
            Console.WriteLine($"Hazelnuts collected: {countOfHazelnuts}");
            return;
        }
        else
        {
            switch (matrix[currentSquirrelRow - 1, currentSquirrelCol])
            {
                case 'h':
                    countOfHazelnuts++;
                    if (countOfHazelnuts == 3)
                    {
                        matrix[currentSquirrelRow, currentSquirrelCol] = '*';
                        matrix[currentSquirrelRow - 1, currentSquirrelCol] = 's';
                        Console.WriteLine("Good job! You have collected all hazelnuts!");
                        Console.WriteLine($"Hazelnuts collected: {countOfHazelnuts}");
                        return;
                    }

                    currentSquirrelRow--;
                    break;
                case 't':
                    matrix[currentSquirrelRow, currentSquirrelCol] = '*';
                    Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                    Console.WriteLine($"Hazelnuts collected: {countOfHazelnuts}");
                    return;
                case '*':
                    matrix[currentSquirrelRow, currentSquirrelCol] = '*';
                    matrix[currentSquirrelRow - 1, currentSquirrelCol] = 's';
                    currentSquirrelRow--;
                    break;
            }
        }

    }
    else if (command == "down")
    {
        if (IsOutside(currentSquirrelRow + 1, currentSquirrelCol, sizeOfMatrix, sizeOfMatrix))
        {
            matrix[currentSquirrelRow, currentSquirrelCol] = '*';
            Console.WriteLine("The squirrel is out of the field.");
            Console.WriteLine($"Hazelnuts collected: {countOfHazelnuts}");
            return;
        }
        else
        {
            switch (matrix[currentSquirrelRow + 1, currentSquirrelCol])
            {
                case 'h':
                    countOfHazelnuts++;
                    if (countOfHazelnuts == 3)
                    {
                        matrix[currentSquirrelRow, currentSquirrelCol] = '*';
                        matrix[currentSquirrelRow + 1, currentSquirrelCol] = 's';
                        Console.WriteLine("Good job! You have collected all hazelnuts!");
                        Console.WriteLine($"Hazelnuts collected: {countOfHazelnuts}");
                        return;
                    }

                    currentSquirrelRow++;
                    break;
                case 't':
                    matrix[currentSquirrelRow, currentSquirrelCol] = '*';
                    Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                    Console.WriteLine($"Hazelnuts collected: {countOfHazelnuts}");
                    return;
                case '*':
                    matrix[currentSquirrelRow, currentSquirrelCol] = '*';
                    matrix[currentSquirrelRow + 1, currentSquirrelCol] = 's';
                    currentSquirrelRow++;
                    break;
            }
        }
    }
    else if (command == "right")
    {
        if (IsOutside(currentSquirrelRow, currentSquirrelCol + 1, sizeOfMatrix, sizeOfMatrix))
        {
            matrix[currentSquirrelRow, currentSquirrelCol] = '*';
            Console.WriteLine("The squirrel is out of the field.");
            Console.WriteLine($"Hazelnuts collected: {countOfHazelnuts}");
            return;
        }
        else
        {
            switch (matrix[currentSquirrelRow, currentSquirrelCol + 1])
            {
                case 'h':
                    countOfHazelnuts++;
                    if (countOfHazelnuts == 3)
                    {
                        matrix[currentSquirrelRow, currentSquirrelCol] = '*';
                        matrix[currentSquirrelRow, currentSquirrelCol + 1] = 's';
                        Console.WriteLine("Good job! You have collected all hazelnuts!");
                        Console.WriteLine($"Hazelnuts collected: {countOfHazelnuts}");
                        return;
                    }

                    currentSquirrelCol++;
                    break;
                case 't':
                    matrix[currentSquirrelRow, currentSquirrelCol] = '*';
                    Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                    Console.WriteLine($"Hazelnuts collected: {countOfHazelnuts}");
                    return;
                case '*':
                    matrix[currentSquirrelRow, currentSquirrelCol] = '*';
                    matrix[currentSquirrelRow, currentSquirrelCol + 1] = 's';
                    currentSquirrelCol++;
                    break;
            }
        }
    }
    else if (command == "left")
    {
        if (IsOutside(currentSquirrelRow, currentSquirrelCol - 1, sizeOfMatrix, sizeOfMatrix))
        {
            matrix[currentSquirrelRow, currentSquirrelCol] = '*';
            Console.WriteLine("The squirrel is out of the field.");
            Console.WriteLine($"Hazelnuts collected: {countOfHazelnuts}");
            return;
        }
        else
        {
            switch (matrix[currentSquirrelRow, currentSquirrelCol - 1])
            {
                case 'h':
                    countOfHazelnuts++;
                    if (countOfHazelnuts == 3)
                    {
                        matrix[currentSquirrelRow, currentSquirrelCol] = '*';
                        matrix[currentSquirrelRow, currentSquirrelCol - 1] = 's';
                        Console.WriteLine("Good job! You have collected all hazelnuts!");
                        Console.WriteLine($"Hazelnuts collected: {countOfHazelnuts}");
                        return;
                    }

                    currentSquirrelCol--;
                    break;
                case 't':
                    matrix[currentSquirrelRow, currentSquirrelCol] = '*';
                    Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                    Console.WriteLine($"Hazelnuts collected: {countOfHazelnuts}");
                    return;
                case '*':
                    matrix[currentSquirrelRow, currentSquirrelCol] = '*';
                    matrix[currentSquirrelRow, currentSquirrelCol - 1] = 's';
                    currentSquirrelCol--;
                    break;
            }
        }
    }
}
Console.WriteLine("There are more hazelnuts to collect.");
Console.WriteLine($"Hazelnuts collected: {countOfHazelnuts}");
bool IsOutside(int row, int col, int rows, int cols)
{
    return row < 0 || row >= rows || col < 0 || col >= cols;
}
void PrintMatrix(char[,] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            Console.Write(matrix[row, col]);
        }
        Console.WriteLine();
    }
}