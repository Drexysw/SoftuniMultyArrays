var sizeOfMatrix = int.Parse(Console.ReadLine());
var matrix = new string[sizeOfMatrix, sizeOfMatrix];
var commands = Console.ReadLine().Split();
var currentMinerRowIndex = 0;
var currentMinerColIndex = 0;
var countOfCoals = 0;
for (int row = 0; row < matrix.GetLength(0); row++)
{
    var input = Console.ReadLine().Split();
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = input[col];
        if (matrix[row,col] == "s")
        {
            currentMinerRowIndex = row;
            currentMinerColIndex = col;
        }
        else if (matrix[row,col] == "c")
        {
            countOfCoals++;
        }
    }
}

var currentNumberOfCoals = 0;
bool IsGameOver = false;
for (int i = 0; i < commands.Length; i++)
{
    MoveMinerToNextPosition(commands, i, ref currentMinerRowIndex, sizeOfMatrix, matrix, ref currentMinerColIndex, ref currentNumberOfCoals, ref IsGameOver);
}

if (IsGameOver)
{
    Console.WriteLine($"Game over! ({currentMinerRowIndex}, {currentMinerColIndex})");
}
else
{
    if (currentNumberOfCoals == countOfCoals)
    {
        Console.WriteLine($"You collected all coals! ({currentMinerRowIndex}, {currentMinerColIndex})");
    }
    else
    {
        Console.WriteLine($"{countOfCoals - currentNumberOfCoals} coals left. ({currentMinerRowIndex}, {currentMinerColIndex})");
    }
}

void MoveMinerToNextPosition(string[] tokens, int index, ref int currentMinerRowIndex1, int sizeOfMatrix1,
    string[,] matrix1, ref int currentMinerColIndex1, ref int currentNumberOfCoals1, ref bool isGameOver)
{
    if (tokens[index] == "up")
    {
        if (IsInside(currentMinerRowIndex1-1,currentMinerColIndex1, sizeOfMatrix1, sizeOfMatrix1))
        {
            switch (matrix1[currentMinerRowIndex1 - 1,currentMinerColIndex1])
            {
                case "*":
                    matrix1[currentMinerRowIndex1, currentMinerColIndex1] = "*";
                    matrix1[currentMinerRowIndex1-1, currentMinerColIndex1] = "s";
                    currentMinerRowIndex1--;
                    break;
                case "c":
                    matrix1[currentMinerRowIndex1, currentMinerColIndex1] = "*";
                    matrix1[currentMinerRowIndex1 - 1, currentMinerColIndex1] = "s";
                    currentMinerRowIndex1--;
                    currentNumberOfCoals1++;
                    break;
                case "e":
                    isGameOver = true;
                    currentMinerRowIndex1--;
                    break;
            }
        }
    }
    else if (tokens[index] == "down")
    {
        if (IsInside(currentMinerRowIndex1 + 1, currentMinerColIndex1, sizeOfMatrix1, sizeOfMatrix1))
        {
            switch (matrix1[currentMinerRowIndex1 + 1, currentMinerColIndex1])
            {
                case "*":
                    matrix1[currentMinerRowIndex1, currentMinerColIndex1] = "*";
                    matrix1[currentMinerRowIndex1 + 1, currentMinerColIndex1] = "s";
                    currentMinerRowIndex1++;
                    break;
                case "c":
                    matrix1[currentMinerRowIndex1, currentMinerColIndex1] = "*";
                    matrix1[currentMinerRowIndex1 + 1, currentMinerColIndex1] = "s";
                    currentMinerRowIndex1++;
                    currentNumberOfCoals1++;
                    break;
                case "e":
                    isGameOver = true;
                    currentMinerRowIndex1++;
                    break;
            }
        }
    }
    else if (tokens[index] == "right")
    {
        if (IsInside(currentMinerRowIndex1, currentMinerColIndex1 +1, sizeOfMatrix1, sizeOfMatrix1))
        {
            switch (matrix1[currentMinerRowIndex1, currentMinerColIndex1+1])
            {
                case "*":
                    matrix1[currentMinerRowIndex1, currentMinerColIndex1] = "*";
                    matrix1[currentMinerRowIndex1 , currentMinerColIndex1+1] = "s";
                    currentMinerColIndex1++;
                    break;
                case "c":
                    matrix1[currentMinerRowIndex1, currentMinerColIndex1] = "*";
                    matrix1[currentMinerRowIndex1, currentMinerColIndex1+1] = "s";
                    currentMinerColIndex1++;
                    currentNumberOfCoals1++;
                    break;
                case "e":
                    isGameOver = true;
                    currentMinerColIndex1++;
                    break;
            }
        }
    }
    else if (tokens[index] == "left")
    {
        if (IsInside(currentMinerRowIndex1, currentMinerColIndex1 - 1, sizeOfMatrix1, sizeOfMatrix1))
        {
            switch (matrix1[currentMinerRowIndex1, currentMinerColIndex1 - 1])
            {
                case "*":
                    matrix1[currentMinerRowIndex1, currentMinerColIndex1] = "*";
                    matrix1[currentMinerRowIndex1, currentMinerColIndex1 - 1] = "s";
                    currentMinerColIndex1--;
                    break;
                case "c":
                    matrix1[currentMinerRowIndex1, currentMinerColIndex1] = "*";
                    matrix1[currentMinerRowIndex1, currentMinerColIndex1 - 1] = "s";
                    currentMinerColIndex1--;
                    currentNumberOfCoals1++;
                    break;
                case "e":
                    isGameOver = true;
                    currentMinerColIndex1--;
                    break;
            }
        }
    }

    bool IsInside(int row, int col, int rows, int cols)
    {
        return row >= 0 && row < rows && col >= 0 && col < cols;
    }
}