Start();

void Start()
{
    while (true)
    {
        Console.WriteLine();
        Console.Write("Press enter: ");
        Console.ReadLine();
        Console.Clear();

        Console.WriteLine("Задача 47. Задайте двумерный массив размером mxn, заполненный случайными" +
        " вещественными числами. m = 3, n = 4.   0,5 7 -2 -0,2   1 -3,3 8 -9,9   8 7,8 -7,1 9");
        Console.WriteLine();
        Console.WriteLine("Задача 50. Напишите программу, которая на вход принимает позиции элемента" +
        " в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет. " +
        "Например, задан массив: 1 4 7 2   5 9 2 3   8 4 2 4   (строка 1, столбец 7) -> такого числа в массиве нет");
        Console.WriteLine();
        Console.WriteLine("Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое" +
        " элементов в каждом столбце. Например, задан массив:" +
        " 1 4 7 2   5 9 2 3   8 4 2 4  Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.");
        Console.WriteLine();
        Console.WriteLine("0) End");

        int numTask = SetNumber("task");

        switch (numTask)
        {
            case 0: return;
            case 47: task47(); break;
            case 50: task50(); break;
            case 52: task52(); break;

            default: Console.WriteLine("error"); break;
        }
    }
}
//task47
void task47()
{
    int row = DataInputRow();
    int column = DataInputColumn();

    double[,] array = new double[row, column];                   /// создаем массив
    FillArrayRandomArray(array);                                 /// метод для заполнения массива рандомными числами
    PrintArray(array);                                           ///печать массива

    void FillArrayRandomArray(double[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)                ///заполняем строки
        {
            for (int j = 0; j < array.GetLength(1); j++)            ///заполняем столбцы
            {
                array[i, j] = Convert.ToDouble(new Random().Next(-100, 100)) / 10;   ///рандомное заполнение 
            }
        }
    }
    void PrintArray(double[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)                                 ///бежим по строкам
        {
            for (int j = 0; j < array.GetLength(1); j++)                             ///бежим по столбцам
            {
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
    return;
}
//task50
void task50()
{
    int row = DataInputRow() - 1;
    int column = DataInputColumn() - 1;

    int n = 3;
    int m = 4;
    Random random = new Random();
    int[,] arr = new int[n, m];
    Console.WriteLine("Исходный массив: ");
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] = random.Next(10, 99);
            Console.Write("{0} ", arr[i, j]);
        }
        Console.WriteLine();
    }
    if (row < 0 | row > arr.GetLength(0) - 1 | column < 0 | column > arr.GetLength(1) - 1)
    {
        Console.WriteLine("Элемент не существует  ");
    }
    else
    {
        Console.WriteLine("Значение элемента массива = {0}", arr[row, column]);
    }
    return;
}
//task52
void task52()
{
    int row = DataInputRow();
    int column = DataInputColumn();

    int[,] Array2_D(int row, int column, int from, int to) //метод coздания двумерного массива
    {
        int[,] array = new int[row, column];

        for (int i = 0; i < row; i++)
            for (int j = 0; j < column; j++)
                array[i, j] = new Random().Next(from, to);
        return array;
    }

    void ArithmeticMean(int[,] array) //метод вычисления среднего арифметического в двумерном массиве
    {
        int row = array.GetLength(0);
        int column = array.GetLength(1);
        double result;

        for (int i = 0; i < column; i++)
        {
            result = 0;
            for (int j = 0; j < row; j++) result += array[j, i];
            Console.Write($"{Math.Round(result / row, 2)}; ");
        }

    }

    int[,] array_1 = Array2_D(row, column, 1, 10);
    Print(array_1);

    ArithmeticMean(array_1);

    void Print(int[,] array) //метод печати двумерного массива
    {

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
                Console.Write($" {array[i, j]} ");
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    return;
}

int DataInputRow()
{
    Console.Write("Row: ");
    int row = int.Parse(Console.ReadLine());
    return row;
}

int DataInputColumn()
{
    Console.Write("Column: ");
    int column = int.Parse(Console.ReadLine());
    return column;
}

int SetNumber(string numberName)
{
    Console.Write($"Enter number {numberName}: ");
    int num = Convert.ToInt32(Console.ReadLine());
    return num;
}