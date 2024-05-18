int sizeOfMatrix = int.Parse(Console.ReadLine());
var matrix = new char[sizeOfMatrix, sizeOfMatrix];
int playerRow = 0;
int playerCol = 0;
int playerHealth = 100;
bool playerEscaped = false;
bool playerDead = false;
for (int row = 0; row < matrix.GetLength(0); row++)
{
    var input = Console.ReadLine().ToCharArray();
    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = input[col];
        if (matrix[row, col] == 'P')
        {
            playerRow = row;
            playerCol = col;
        }
    }
}
string command = string.Empty;
while ((command = Console.ReadLine()) != null && !playerEscaped && !playerDead)
{
    PlayerStep(command, ref playerRow, matrix, ref playerCol, ref playerEscaped, ref playerHealth, ref playerDead);
}

if (playerEscaped)
{
    Console.WriteLine("Player escaped the maze. Danger passed!");
    Console.WriteLine($"Player's health: {playerHealth} units");
    PrintMatrix(matrix);
}
else if(playerDead)
{
    Console.WriteLine("Player is dead. Maze over!");
    Console.WriteLine("Player's health: 0 units");
    PrintMatrix(matrix);
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

void PlayerStep(string token, ref int currentPlayerRow, char[,] chars, ref int currentPlayerCol, ref bool IsPlayerEscaped, ref int playerHealth1,
    ref bool IsPlayerDeadth)
{
    if (token == "up")
    {
        if (!IsOutside(currentPlayerRow - 1, currentPlayerCol, chars.GetLength(0), chars.GetLength(1)))
        {
            switch (chars[currentPlayerRow - 1, currentPlayerCol])
            {
                case 'X':
                    chars[currentPlayerRow, currentPlayerCol] = '-';
                    chars[currentPlayerRow - 1, currentPlayerCol] = 'P';
                    IsPlayerEscaped = true;
                    currentPlayerRow--;
                    break;
                case 'M':
                    playerHealth1 -= 40;
                    if (playerHealth1 <= 0)
                    {
                        IsPlayerDeadth = true;
                        chars[currentPlayerRow, currentPlayerCol] = '-';
                        chars[currentPlayerRow - 1, currentPlayerCol] = 'P';
                    }
                    else
                    {
                        chars[currentPlayerRow, currentPlayerCol] = '-';
                        chars[currentPlayerRow - 1, currentPlayerCol] = 'P';
                    }
                    currentPlayerRow--;
                    break;
                case 'H':
                    chars[currentPlayerRow, currentPlayerCol] = '-';
                    chars[currentPlayerRow - 1, currentPlayerCol] = 'P';
                    if (playerHealth1 > 85)
                    {
                        playerHealth1 += 100 - playerHealth1;
                    }
                    else
                    {
                        playerHealth1 += 15;
                    }

                    currentPlayerRow--;
                    break;
                case '-':
                    chars[currentPlayerRow, currentPlayerCol] = '-';
                    chars[currentPlayerRow - 1, currentPlayerCol] = 'P';
                    currentPlayerRow--;
                    break;

            }
        }
    }
    else if (token == "down")
    {
        if (!IsOutside(currentPlayerRow + 1, currentPlayerCol, chars.GetLength(0), chars.GetLength(1)))
        {
            switch (chars[currentPlayerRow + 1, currentPlayerCol])
            {
                case 'X':
                    chars[currentPlayerRow, currentPlayerCol] = '-';
                    chars[currentPlayerRow + 1, currentPlayerCol] = 'P';
                    IsPlayerEscaped = true;
                    currentPlayerRow++;
                    break;
                case 'M':
                    playerHealth1 -= 40;
                    if (playerHealth1 <= 0)
                    {
                        IsPlayerDeadth = true;
                        chars[currentPlayerRow, currentPlayerCol] = '-';
                        chars[currentPlayerRow + 1, currentPlayerCol] = 'P';
                    }
                    else
                    {
                        chars[currentPlayerRow, currentPlayerCol] = '-';
                        chars[currentPlayerRow + 1, currentPlayerCol] = 'P';
                    }
                    currentPlayerRow++;
                    break;
                case 'H':
                    chars[currentPlayerRow, currentPlayerCol] = '-';
                    chars[currentPlayerRow + 1, currentPlayerCol] = 'P';
                    if (playerHealth1 > 85)
                    {
                        playerHealth1 += 100 - playerHealth1;
                    }
                    else
                    {
                        playerHealth1 += 15;
                    }

                    currentPlayerRow++;
                    break;
                case '-':
                    chars[currentPlayerRow, currentPlayerCol] = '-';
                    chars[currentPlayerRow + 1, currentPlayerCol] = 'P';
                    currentPlayerRow++;
                    break;

            }
        }
    }
    else if (token == "right")
    {
        if (!IsOutside(currentPlayerRow, currentPlayerCol+1, chars.GetLength(0), chars.GetLength(1)))
        {
            switch (chars[currentPlayerRow , currentPlayerCol+1])
            {
                case 'X':
                    chars[currentPlayerRow, currentPlayerCol] = '-';
                    chars[currentPlayerRow, currentPlayerCol+1] = 'P';
                    IsPlayerEscaped = true;
                    currentPlayerCol++;
                    break;
                case 'M':
                    playerHealth1 -= 40;
                    if (playerHealth1 <= 0)
                    {
                        IsPlayerDeadth = true;
                        chars[currentPlayerRow, currentPlayerCol] = '-';
                        chars[currentPlayerRow, currentPlayerCol+1] = 'P';
                    }
                    else
                    {
                        chars[currentPlayerRow, currentPlayerCol] = '-';
                        chars[currentPlayerRow, currentPlayerCol+1] = 'P';
                    }
                    currentPlayerCol++;
                    break;
                case 'H':
                    chars[currentPlayerRow, currentPlayerCol] = '-';
                    chars[currentPlayerRow, currentPlayerCol+1] = 'P';
                    if (playerHealth1 > 85)
                    {
                        playerHealth1 += 100 - playerHealth1;
                    }
                    else
                    {
                        playerHealth1 += 15;
                    }

                    currentPlayerCol++;
                    break;
                case '-':
                    chars[currentPlayerRow, currentPlayerCol] = '-';
                    chars[currentPlayerRow, currentPlayerCol+1] = 'P';
                    currentPlayerCol++;
                    break;

            }
        }
    }
    else if (token == "left")
    {
        if (!IsOutside(currentPlayerRow, currentPlayerCol - 1, chars.GetLength(0), chars.GetLength(1)))
        {
            switch (chars[currentPlayerRow, currentPlayerCol - 1])
            {
                case 'X':
                    chars[currentPlayerRow, currentPlayerCol] = '-';
                    chars[currentPlayerRow, currentPlayerCol - 1] = 'P';
                    IsPlayerEscaped = true;
                    currentPlayerCol--;
                    break;
                case 'M':
                    playerHealth1 -= 40;
                    if (playerHealth1 <= 0)
                    {
                        IsPlayerDeadth = true;
                        chars[currentPlayerRow, currentPlayerCol] = '-';
                        chars[currentPlayerRow, currentPlayerCol - 1] = 'P';
                    }
                    else
                    {
                        chars[currentPlayerRow, currentPlayerCol] = '-';
                        chars[currentPlayerRow, currentPlayerCol - 1] = 'P';
                    }
                    currentPlayerCol--;
                    break;
                case 'H':
                    chars[currentPlayerRow, currentPlayerCol] = '-';
                    chars[currentPlayerRow, currentPlayerCol - 1] = 'P';
                    if (playerHealth1 > 85)
                    {
                        playerHealth1 += 100 - playerHealth1;
                    }
                    else
                    {
                        playerHealth1 += 15;
                    }

                    currentPlayerCol--;
                    break;
                case '-':
                    chars[currentPlayerRow, currentPlayerCol] = '-';
                    chars[currentPlayerRow, currentPlayerCol - 1] = 'P';
                    currentPlayerCol--;
                    break;

            }
        }
    }

    bool IsOutside(int row, int col, int rows, int cols)
    {
        return row < 0 || row >= rows || col < 0 || col >= cols;
    }
}