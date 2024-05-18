int sizeOfMatrixRows = int.Parse(Console.ReadLine());
int sizeOfMatrixCols = int.Parse(Console.ReadLine());

int numberOfRowToWindow = int.Parse(Console.ReadLine());
int numberOfColToWindow = int.Parse(Console.ReadLine());

int indexOfRowOfSecondMatrix = 0;
int indexOfColOfSecondMatrix = 0;

int sumOfWantedShape = int.MinValue;

int[,] matrix = new int[sizeOfMatrixRows, sizeOfMatrixCols];

for (int row = 0; row < sizeOfMatrixRows; row++)
{
    int[] inpuNumbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
    for (int col = 0; col < sizeOfMatrixCols; col++)
    {
        matrix[row, col] = inpuNumbers[col];
    }
}

int currentSum = 0;
for (int rowOfBasedMatrix = 0; rowOfBasedMatrix <= matrix.GetLength(0) - numberOfRowToWindow; rowOfBasedMatrix++)
{
    for (int colOfBasedMatrix = 0; colOfBasedMatrix <= matrix.GetLength(1) - numberOfColToWindow; colOfBasedMatrix++)
    {
        for (int rowOfSecondMatrix = rowOfBasedMatrix; rowOfSecondMatrix < rowOfBasedMatrix + numberOfRowToWindow; rowOfSecondMatrix++)
        {
            for (int colOfSecondMatrix = colOfBasedMatrix; colOfSecondMatrix < colOfBasedMatrix + numberOfColToWindow; colOfSecondMatrix++)
            {
                currentSum += matrix[rowOfSecondMatrix, colOfSecondMatrix];
            }
        }
        if (currentSum > sumOfWantedShape)
        {
            sumOfWantedShape = currentSum;
            indexOfRowOfSecondMatrix = rowOfBasedMatrix;
            indexOfColOfSecondMatrix = colOfBasedMatrix;
            currentSum = 0;
        }
        else
        {
            currentSum = 0;
        }
    }
}

Console.WriteLine(sumOfWantedShape);

for (int rowOfBasedMatrix = indexOfRowOfSecondMatrix; rowOfBasedMatrix < indexOfRowOfSecondMatrix + numberOfRowToWindow; rowOfBasedMatrix++)
{
    for (int colOfBasedMatrix = indexOfColOfSecondMatrix; colOfBasedMatrix < indexOfColOfSecondMatrix + numberOfColToWindow; colOfBasedMatrix++)
    {
        Console.Write(matrix[rowOfBasedMatrix, colOfBasedMatrix] + " ");
    }
    Console.WriteLine();
}