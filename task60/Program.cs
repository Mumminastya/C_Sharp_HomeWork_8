// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая
//будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

int[,,] FillMatrixWithRandom(int row, int column, int shift)
{
    int max = row * column * shift * 10;
    int[] usedValues = new int[0];

    int[,,] matrix = new int[row, column, shift];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                int nextUnused = NextUnused(usedValues, max);
                matrix[i, j, k] = nextUnused;

                Array.Resize(ref usedValues, usedValues.Length + 1);
                usedValues[usedValues.Length - 1] = nextUnused;
            }
        }
    }
    return matrix;
}

int NextUnused(int[] usedValues, int maxValue)
{   
    Random rnd = new Random();
    while(true)
    {
        bool exists = false;

        int next = rnd.Next(1, maxValue);
        for (int i = 0; i < usedValues.Length; i++)
        {
            var current = usedValues[i];
            if (current == next)
            {
                exists = true;
                break;
            }  
        }

        if(!exists) 
        {
            return next;
        }
    }
}

void PrintMatrix(int[,,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                System.Console.Write($"{matrix[i, j, k]} ({i}, {j}, {k}) ");
            }
            Console.WriteLine();
        }
    }
}


System.Console.Write("Введите длину: ");
int row = Convert.ToInt32(Console.ReadLine());
System.Console.Write("Введите ширину: ");
int column = Convert.ToInt32(Console.ReadLine());
System.Console.Write("Введите высоту: ");
int shift = Convert.ToInt32(Console.ReadLine());
int[,,] matrix = FillMatrixWithRandom(row, column, shift);
PrintMatrix(matrix);