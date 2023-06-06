using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23
{
    class Program
    {
        static void Main()
        {
            int n = 0, s1 = 0, s2 = 0;
            Console.Write("Введите размерность матрицы: ");
            try
            {
                n = int.Parse(Console.ReadLine());
                if (n <= 0)
                {
                    Console.WriteLine("Ошибка!");
                    Main();
                }
            }
            catch
            {
                Console.WriteLine("Ошибка!");
                Main();
            }
            int[,] matrix = new int[n, n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rand.Next(100);
                }
            }
            Console.WriteLine("Исходная матрица:");
            PrintMatrix(matrix);
            try
            {
                Console.Write("Выберите сортировку (1 - по возрастанию, 2 - по убыванию): ");
                s1 = int.Parse(Console.ReadLine());
                if (s1 != 1 && s1 != 2)
                {
                    Console.WriteLine("Ошибка!");
                    Main();
                }
                Console.Write("Выберите сортировку (1 - по строкам, 2 - по столбцам): ");
                s2 = int.Parse(Console.ReadLine());
                if (s2 != 1 && s2 != 2)
                {
                    Console.WriteLine("Ошибка!");
                    Main();
                }
            }
            catch
            {
                Console.WriteLine("Ошибка!");
                Main();
            }
            if (s2 == 1)
            {
                if (s1 == 1) SortMatrixByRows(matrix, true);
                else SortMatrixByRows(matrix, false);
            }
            else
            {
                if (s1 == 1) SortMatrixByColumns(matrix, true);
                else SortMatrixByColumns(matrix, false);
            }
            Console.WriteLine("Отсортированная матрица:");
            PrintMatrix(matrix);
            Console.WriteLine("Хотите повторить задачу? Если да, нажмите Enter");
            if (Console.ReadKey().Key == ConsoleKey.Enter) Main();
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void SortMatrixByRows(int[,] matrix, bool ascending)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    for (int k = j + 1; k < matrix.GetLength(1); k++)
                    {
                        if ((ascending && matrix[i, j] > matrix[i, k]) || (!ascending && matrix[i, j] < matrix[i, k]))
                        {
                            int temp = matrix[i, j];
                            matrix[i, j] = matrix[i, k];
                            matrix[i, k] = temp;
                        }
                    }
                }
            }
        }
        static void SortMatrixByColumns(int[,] matrix, bool ascending)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < matrix.GetLength(0) - 1; i++)
                {
                    for (int k = i + 1; k < matrix.GetLength(0); k++)
                    {
                        if ((ascending && matrix[i, j] > matrix[k, j]) || (!ascending && matrix[i, j] < matrix[k, j]))
                        {
                            int temp = matrix[i, j];
                            matrix[i, j] = matrix[k, j];
                            matrix[k, j] = temp;
                        }
                    }
                }
            }
        }
    }
}
