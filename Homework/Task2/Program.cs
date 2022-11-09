/* Задача 2: 
Напишите программу, которая на вход принимает 
позиции элемента в двумерном массиве, 
и возвращает значение этого элемента или же указание, 
что такого элемента нет.

Например, задан массив:

1 4 7 2
5 9 2 3
8 4 2 4

17 -> такого числа в массиве нет
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

int rows = GetNumber("Введите количество строк в массиве: ");
int columns = GetNumber("Введите количество столбцов в массиве: ");

double[,] GetArray (int rows, int columns) {
    Random random = new Random();
    double[,] array = new double[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            array[i, j] = Math.Round(random.NextDouble()*1000, 1);
        }
    }
    return array;
}

void PrintArray (double[,] array) {
    Console.WriteLine("\nПолучили матрицу:\n");
    int row = array.GetLength(0);
    int columns = array.GetLength(1);
    for (int i = 0; i < row; i++){
        for (int j = 0; j < columns; j++)
        {
            Console.Write("{0,7}", array[i, j]);
        }
        Console.WriteLine("\n");
    }
}

double[,] array = GetArray(rows, columns); 

PrintArray(array);

double GetElement (double[,] array, int row, int column) {
    while (row >= array.GetLength(0) || column >= array.GetLength(1)) {
        Console.WriteLine("\nТакой строки или столбца не существует. Элемента [{0}, {1}] в массиве нет\n", row + 1, column + 1);
        row = GetNumber("Введите существующую строку: ") - 1;
        column = GetNumber("Введите существующий столбец: ") - 1;
    }
    return array[row, column];
}

int row = GetNumber("Введите номер строки: ") - 1;
int column = GetNumber("Введите номер столбца: ") - 1;
double element = GetElement(array, row, column);

Console.WriteLine("На позиции [{0}, {1}] находится элемент: {2}", row + 1, column + 1, element);