using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace mod3
{
    internal class Program
    {
        static void Exp01()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            foreach (int element in array)
            {
                Console.WriteLine(element);
            }
        }
        static void Exp02()
        {
            int[] array = { 10, 5, 20, 8, 15 };
            int maxIndex = Array.IndexOf(array, array.Max());
            Console.WriteLine("Индекс максимального значения: " + maxIndex);
        }
        static void Exp03()
        {
            int[] array = { 11, 4, 9, 16, 7, 20 };
            int maxEvenIndex = Array.IndexOf(array, array.Where(x => x % 2 == 0).Max());
            Console.WriteLine("Индекс максимального четного значения: " + maxEvenIndex);
        }
        static void Exp04()
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5 };
            int indexToRemove = 2;
            list.RemoveAt(indexToRemove);

        }
        static void Exp05()
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 3, 5 };
            int valueToRemove = 3;
            list.RemoveAll(x => x == valueToRemove);

        }
        static void Exp06()
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5 };
            int valueToInsert = 6;
            int indexToInsert = 2;
            list.Insert(indexToInsert, valueToInsert);
        }
        static void Exp07()
        {
            List<int> list = new List<int> { 1, 2, 2, 3, 4, 4, 4, 5, 5 };
            var duplicates = list.GroupBy(x => x).Where(g => g.Count() == 2).SelectMany(g => g);
            list.RemoveAll(x => duplicates.Contains(x));
        }
        static void Exp08()
        {
            List<int> list = new List<int> { 1, 2, 2, 3, 4, 4, 4, 5, 5 };
            var duplicates = list.GroupBy(x => x).Where(g => g.Count() == 2).SelectMany(g => g);
            list.RemoveAll(x => duplicates.Contains(x));
        }
        static void Exp09()
        {
            string inputString = "Это пример строки с несколькими словами";
            string[] words = inputString.Split(' ');
            var resultWords = words.Where(word => !word.Contains('a'));
            string resultString = string.Join(" ", resultWords);
            Console.WriteLine(resultString);
        }
        static void Exp10()
        {
            string inputString = "Это пример строки с несколькими словами";
            string[] words = inputString.Split(' ');
            string lastWord = words.Last();
            var resultWords = words.Where(word => !word.Intersect(lastWord).Any());
            string resultString = string.Join(" ", resultWords);
            Console.WriteLine(resultString);
        }
        static void Exp11()
        {
            string inputString = "Это [п]ример стро[к]и с н[ес]колькими словам[и]";
            string resultString = Regex.Replace(inputString, @"\b(\w)\w*\1\b", "[$&]");
            Console.WriteLine(resultString);
        }
        static void Exp12()
        {
            int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] % 2 == 0)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
        }
        static void Exp13()
        {
            int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[j, j] % 2 == 0)
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
        }
        static void Exp14()
        {
            int[,] matrix = { { 1, 2, 3 }, { 4, 2, 6 }, { 7, 8, 7 } };

            List<int> columnsToRemove = new List<int>();

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                HashSet<int> values = new HashSet<int>();
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (values.Contains(matrix[i, j]))
                    {
                        columnsToRemove.Add(j);
                        break;
                    }
                    values.Add(matrix[i, j]);
                }
            }

            for (int j = columnsToRemove.Count - 1; j >= 0; j--)
            {
                int columnIndex = columnsToRemove[j];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int k = columnIndex; k < matrix.GetLength(1) - 1; k++)
                    {
                        matrix[i, k] = matrix[i, k + 1];
                    }
                }
            }

            int newColumns = matrix.GetLength(1) - columnsToRemove.Count;
            int[,] newMatrix = new int[matrix.GetLength(0), newColumns];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < newColumns; j++)
                {
                    newMatrix[i, j] = matrix[i, j];
                }
            }
        }
        static void Exp15()
        {
            int spaceCount = 0;
            char inputChar;

            do
            {
                inputChar = Console.ReadKey().KeyChar;
                if (inputChar == ' ')
                {
                    spaceCount++;
                }
            } while (inputChar != '.');

            Console.WriteLine("Количество пробелов: " + spaceCount);
        }
        static void Main(string[] args)
        {
            Exp01();
            Exp02();
            Exp03();
            Exp04();
            Exp05();
            Exp06();
            Exp07();
            Exp08();
            Exp09();
            Exp10();
            Exp11();
            Exp12();
            Exp13();
            Exp14();
            Exp15();

            Console.ReadKey();
        }
    }
}