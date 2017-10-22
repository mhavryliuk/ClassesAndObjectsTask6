using System;

/*
Классы и Объекты.
Задание 6. Создать класс для работы с двумерным массивом целых чисел.
Разработать следующие члены класса:
1. Поля:
· int [,] intArray;
2. Конструктор, позволяющий создать массив размерности n×m.
3. Методы, позволяющие:
· ввести элементы массива с клавиатуры;
· вывести элементы массива на экран;
· вычислить сумму элементов i-того столбца.
4. Свойство:
· позволяющее вычислить количество нулевых элементов в массиве (доступное только для чтения);
· позволяющее установить значение всех элементов главной диагонали массива равное скаляру (доступное только для записи).
5. Двумерный индексатор, позволяющий обращаться к соответствующему элементу массива.
6. Перегрузку:
· операции ++ (--): одновременно увеличивает (уменьшает) значение всех элементов массива на 1;
· констант true и false: обращение к экземпляру класса дает значение true, если двумерный массив является квадратным;
· операции бинарный +: сложить два массива соответствующих размерностей;
· операции преобразования класса массив в двумерный массив (и наоборот).

Продемонстрировать работу класса.
*/

namespace ClassesAndObjectsTask6
{
    class TwoDimensionalArray
    {
        // Поля
        int[,] intArray;
        int n;   // Количество строк 
        int m;   // Количество столбцов

        // Конструктор, позволяющий создать массив размерности n×m.
        public TwoDimensionalArray(int n, int m)
        {
            this.n = n;
            this.m = m;
            intArray = new int[n, m];
        }

        // Метод, позволяющий ввести элементы массива с клавиатуры.
        public void InputIntArray()
        {
            Console.WriteLine("Введите элементы массива:");
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    Console.Write("A[{0}][{1}] = ", i, j);
                    intArray[i, j] = int.Parse(Console.ReadLine());
                }
        }

        // Метод, позволяющий вывести элементы массива на экран.
        public void ShowIntArray()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0} ", intArray[i, j]);
                }
                Console.WriteLine();
            }
        }

        // Метод, позволяющий вычислить сумму элементов i-того столбца.
        public string CalculatingSumElements(int column)
        {
            int sum = 0;
            if (column <= 0 || column > m)
            {
                return $"Столбец {column} не существует. Доступны значения от 1 до {m}.";
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    sum += intArray[i, column - 1];   // "column-1", т.к. пользователь считает столбцы с единицы, а не с нуля
                }
                return $"Сумма элементов {column} столбца: {sum}";
            }
        }

        // Свойство, позволяющее вычислить количество нулевых элементов в массиве (доступное только для чтения).
        public string SearchForZeros
        {
            get
            {
                int zero = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (intArray[i, j] == 0)
                        {
                            zero++;
                        }
                    }
                }
                return $"\nКоличество нулевых элементов массива составлеят: {zero}";
            }
        }

        // Свойство, позволяющее установить значение всех элементов главной диагонали массива равное скаляру(доступное только для записи).
        public int MainDiagonal
        {
            set
            {
                for (int i = 0; i < n; i++)
                {
                    intArray[i, i] = value;
                }
            }
        }

        // Двумерный индексатор, позволяющий обращаться к соответствующему элементу массива.
        public string this[int index1, int index2]
        {
            get
            {
                if (index1 < 0 || index1 > intArray.GetLength(0) - 1 && index2 < 0 || index2 > intArray.GetLength(1) - 1)
                {
                    return $"\nИндекс [{index1},{index2}] является недопустимым.";
                }
                return $"\nИндексу [{index1},{index2}] соответствует элемент со значением {intArray[index1, index2]}";
            }
        }

        // Перегрузка операции ++ (--): одновременно увеличивает(уменьшает) значение всех элементов массива на 1.
        public static TwoDimensionalArray operator ++(TwoDimensionalArray increment)
        {
            TwoDimensionalArray array = new TwoDimensionalArray(increment.intArray.GetLength(0), increment.intArray.GetLength(1));
            for (int i = 0; i < increment.intArray.GetLength(0); i++)
                for (int j = 0; j < increment.intArray.GetLength(1); j++)
                {
                    increment.intArray[i, j]++;
                }
            return increment;
        }

        public static TwoDimensionalArray operator --(TwoDimensionalArray decrement)
        {
            TwoDimensionalArray array = new TwoDimensionalArray(decrement.intArray.GetLength(0), decrement.intArray.GetLength(1));
            for (int i = 0; i < decrement.intArray.GetLength(0); i++)
                for (int j = 0; j < decrement.intArray.GetLength(1); j++)
                {
                    decrement.intArray[i, j]--;
                }
            return decrement;
        }

        // Перегрузка констант true и false: обращение к экземпляру класса дает значение true, если двумерный массив является квадратным.

        // Перегрузка операции бинарный +: сложить два массива соответствующих размерностей.

        // Перегрузка операции преобразования класса массив в двумерный массив(и наоборот).
    }
}
