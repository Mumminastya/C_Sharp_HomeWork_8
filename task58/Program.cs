// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

int[,] FillMatrixWithRandom(int row, int column)
{
int[,] matrix = new int[row, column];
Random rnd = new Random();
for (int i = 0; i < matrix.GetLength(0); i++)
{
for (int j = 0; j < matrix.GetLength(1); j++)
{
matrix[i, j] = rnd.Next(1, 10);
}
}
return matrix;
}

int[,] GiveMatrix()
{
    System.Console.Write("Введите кол-во строк: ");
    int row = Convert.ToInt32(Console.ReadLine());
    System.Console.Write("Введите кол-во столбцов: ");
    int column = Convert.ToInt32(Console.ReadLine());
    int[,] matrix = FillMatrixWithRandom(row, column);
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
for (int i = 0; i < matrix.GetLength(0); i++)
{
for (int j = 0; j < matrix.GetLength(1); j++)
{
System.Console.Write(matrix[i, j] + " ");
}
Console.WriteLine();
}
}

int[,] MultiMatrix(int[,] matrix1, int[,] matrix2)
{
    int row1 = matrix1.GetLength(0);
    int column1 = matrix1.GetLength(1);
    int row2 = matrix2.GetLength(0);
    int column2 = matrix2.GetLength(1);
    
    int[,] multimatrix;
    int[,] m1;
    int[,] m2;
    int count;


    if (column2 == row1)
    {
        m1 = matrix2;
        m2 = matrix1;
        multimatrix = new int[row2, column1];
        count = column2;
    }
    else if (column1 == row2)
    {
        m1 = matrix1;
        m2 = matrix2;
        multimatrix = new int[row1, column2];
        count = column1;
    }
    else
    {
        throw new Exception("Multiple not available");//исключение
    }

    for (int i = 0; i < multimatrix.GetLength(0); i++)
    {
        for (int j = 0; j < multimatrix.GetLength(1); j++)
        {
           int sum = 0;

           for (int k = 0; k < count; k++)
           {
                sum = sum + m1[i,k] * m2[k,j]; 
           }

           multimatrix[i,j] = sum;
        }
    }

    return multimatrix;
}


int[,] matrix1 = GiveMatrix();
int[,] matrix2 = GiveMatrix();
Console.WriteLine();
PrintMatrix(matrix1);
Console.WriteLine();
PrintMatrix(matrix2);
Console.WriteLine();
var r = MultiMatrix(matrix1, matrix2);
PrintMatrix(r);

