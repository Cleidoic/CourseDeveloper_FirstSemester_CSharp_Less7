/* Задача 1:
Задайте двумерный массив размером m×n, 
заполненный случайными вещественными числами.

m = 3, n = 4.

0,5 7 -2 -0,2
1 -3,3 8 -9,9
8 7,8 -7,1 9
*/

int GetNumber (string message) {
    int result = 0;
    bool isCorrect = false;
    Console.WriteLine(message);
    while (!isCorrect) {
        isCorrect = int.TryParse(Console.ReadLine(), out result);
        if (!isCorrect) {
            Console.WriteLine($"Ввели не число или оно слишком большое. Введите корректное число \n");
        }
    }
    return result;
}

double[,] GetArray (int m, int n) {
    Random random = new Random();
    double[,] array = new double[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            array[i, j] = Math.Round(random.NextDouble()*1000, 1);
        }
    }
    return array;
}

void PrintArray (double[,] array) {
    Console.WriteLine("Получили матрицу:\n");
    int row = array.GetLength(0);
    int columns = array.GetLength(1);
    for (int i = 0; i < row; i++){
        for (int j = 0; j < columns; j++)
        {
            Console.Write("{0,7}", array[i, j]);
        }
        Console.WriteLine();
    }
}

int columns = GetNumber("Введите количество столбцов: ");
int row = GetNumber("Введите количество строк: ");

PrintArray(GetArray(row, columns));
