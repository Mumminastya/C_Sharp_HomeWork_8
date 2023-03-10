// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой
//строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2


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

int[,] OrderMatrix(int[,] matrix)
{
   for (int n = 0; n < matrix.GetLength(0); n++)//перебор строк
   {
        int l = matrix.GetLength(1);

        for (int i = 0; i < l; i++)//перебор элементов строки
        {
            for (int j = 0; j < l - 1 - i; j++)
            {
                if (matrix[n, j] > matrix[n, j + 1])
                {
                    int temp = matrix[n, j];
                    matrix[n, j] = matrix[n, j + 1];
                    matrix[n, j + 1] = temp;
                }
            }
        }
   }

   return matrix;
}

System.Console.Write("Введите кол-во строк: ");
int row = Convert.ToInt32(Console.ReadLine());
System.Console.Write("Введите кол-во столбцов: ");
int column = Convert.ToInt32(Console.ReadLine());
int[,] matrix = FillMatrixWithRandom(row, column);
PrintMatrix(matrix);
int[,] orderedMatrix = OrderMatrix(matrix);
System.Console.WriteLine("В итоге получается вот такой массив:");
PrintMatrix(orderedMatrix);