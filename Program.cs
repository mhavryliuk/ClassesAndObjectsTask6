using System;

namespace ClassesAndObjectsTask6
{
    class Program
    {
        static void Main()
        {
            // Создание массива
            Console.Write("Укажите количество строк массива: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Укажите количество столбцов массива: ");
            int m = int.Parse(Console.ReadLine());

            TwoDimensionalArray array = new TwoDimensionalArray(n, m);
            array.InputIntArray();                                   // Ввод элементов массива с клавиатуры
            Console.WriteLine("\nИсходный массив:");
            array.ShowIntArray();                                    // Вывод исходного массива на экран

            Console.Write("\nУкажите номер столбца для подсчета суммы элементов: ");
            int column = int.Parse(Console.ReadLine());
            Console.WriteLine(array.CalculatingSumElements(column)); // Вычисление суммы элементов i-того столбца

            Console.WriteLine(array.SearchForZeros);                 // Вычисление количества нулевых элементов в массиве

            Console.Write("Укажите значение скаляра для замены главной диагонали: ");
            int scalar = int.Parse(Console.ReadLine());
            array.MainDiagonal = scalar;                             // Замена элементов главной диагонали массива на скаляр
            array.ShowIntArray();                                    // Вывод измененного массива на экран

            Console.WriteLine(array[1,2]);                           // Обращение к элементу массива по индексу

            Console.WriteLine("\nПерегрузка операции инкремента");
            ++array;                                                 // Перегрузка операции ++
            array.ShowIntArray();

            Console.WriteLine("\nПерегрузка операции декремента");
            --array;                                                 // Перегрузка операции --
            array.ShowIntArray();

            Console.WriteLine("\nПерегрузка констант true и false");
            if (array)                                               // Перегрузка констант true и false
            {
                Console.WriteLine("Двумерный массив является квадратным");
            }
            else
            {
                Console.WriteLine("Двумерный массив НЕ является квадратным");
            }

            Console.ReadKey();
        }
    }
}
