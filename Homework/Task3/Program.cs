/* Задача 3: 
Задайте двумерный массив из целых чисел. 
Найдите среднее арифметическое элементов в каждом столбце.

Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.
*/

int GetNumber(string message) {
    bool isCorrect = false;
    int result = 0;
    Console.WriteLine(message);
    while (!isCorrect)
    {
        isCorrect = int.TryParse(Console.ReadLine(), out result);
        if (!isCorrect)
            Console.WriteLine("\nВвели не число или оно слишком большое. Введите заново: ");
    }
    return result;
}

int[,] GetArray(int rows, int columns) {
    int[,] array = new int[rows, columns];
    Random random = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            array[i, j] = random.Next(-100, 100);
        }
    }
    return array;
}

void PrintArray(int[,] array) {
    Console.WriteLine("\nПолучили матрицу:\n");
    int row = array.GetLength(0);
    int columns = array.GetLength(1);
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            Console.Write("{0,6}", array[i, j]);
        }
        Console.WriteLine();
    }
}

void GetAverage(int[,] array) {
    double average = 0;
    Console.WriteLine("\nСреднее арифметическое столбцов: \n");
    for (int i = 0; i < array.GetLength(1); i++) {
        int sum = 0;
        for (int j = 0; j < array.GetLength(0); j++) {
            sum = sum + array[j, i];
        }
        average = (double)sum/array.GetLength(0);
        Console.Write("{0,6}", Math.Round(average, 1));
    }
}

int rows = GetNumber("Введите число строк матрицы: ");
int columns = GetNumber("Введите число столбцов матрицы: ");
int[,] array = GetArray(rows, columns);

PrintArray(array);

GetAverage(array);