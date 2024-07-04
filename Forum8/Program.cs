﻿using System.Text;

namespace Forum8
{
    internal class Program
    {
        private static readonly IDictionary<int, int> pairs = new Dictionary<int, int>();

        static int[] SortArray(int[] array)
        {
            int length = array.Length;
            for (int iterator1 = 1; iterator1 < length; iterator1++)
            { 
                int element = array[iterator1];
                int iterator2 = iterator1 - 1;

                while (iterator2 >= 0 && array[iterator2] > element)
                {
                    array[iterator2+1] = array[iterator2];
                    iterator2--;
                }

                array[iterator2+1] = element;
            }

            return array;
        }

        static void GetUniquePairs(int[] array, int target)
        {
            int length = array.Length; //[ 1 3 0 4 5] target = 4
            for (int iterator = 0; iterator < length; iterator++)//&& array[iterator] <= target
            {
                int difference = target - array[iterator];
                if (difference < array[iterator])
                    continue;

                if (difference == array[iterator])
                {
                    if (array.Count(x => x == difference) >= 2 && !pairs.ContainsKey(array[iterator]))
                    {
                        pairs.Add(array[iterator], difference);
                    }
                }
                else if (array.Contains(difference) && !pairs.ContainsKey(array[iterator]))
                {
                    pairs.Add(array[iterator], difference);
                }
            }
        }

        private static void OutputUniquePairs(IDictionary<int, int> pairs)
        {
            int tempCounter = 0;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('[');
            int count = pairs.Count;
            foreach (var pair in pairs)
            {
                stringBuilder.Append(string.Format($"({pair.Key},{pair.Value})"));
                tempCounter++;

                if (tempCounter != count)
                {
                    stringBuilder.Append(',');
                }
            }

            stringBuilder.Append(']');
            Console.WriteLine(stringBuilder);
        }

        static bool IsInputValid(int[] array, int target)
        {
            if (array == null || array.Length == 0) {
                Console.WriteLine($"Array shall not be empty!");
                return false;
            }

            if (target >= int.MaxValue)
            {
                Console.WriteLine($"Target difference shall not exceed integer maximum difference {int.MaxValue}");
                return false;
            }

            if (array.Any(x => x >= int.MaxValue))
            {
                Console.WriteLine($"Array element difference shall not exceed integer maximum difference {int.MaxValue}!");
                return false;
            }

            return true;
        }

        static void Main()
        {
            int target = 7;// 4;// 5;//7;
            int[] array = { 2, 2, 4, 3, 4, 0, 7, 3, 5, 5 };// { 0,1,2,2,2,5,-2,6};//{ 0,1,2,5};// { 0,1,2,2,2,5};// { 1,3,0,4,5, 5 };// {5,1,2,3,4,1,5,8,-3 };// { 2, 2, 4, 3, 4, 0,10, 7,9, 3, 5, 5, 8 };//{ 1, 3, 0, 4 ,5};//{ 2,2,4,3,4,0,7,3,5, 5};//Scenario where duplicate may occur if sort not applied//{ 2, 4, 3, 7, 8, 5, 9 };
            int size = 0;
            #region Input from Console
            Console.WriteLine("\nPlease enter the array size");
            string arraySize = Console.ReadLine();
            if (!string.IsNullOrEmpty(arraySize))
                size = Convert.ToInt32(arraySize);
            array = new int[size];

            Console.WriteLine("\nPlease enter the array elements space separated");
            string stringArray = Console.ReadLine();
            if (!string.IsNullOrEmpty(stringArray))
                array = Array.ConvertAll(stringArray.Trim().Split(' '), Convert.ToInt32);

            Console.WriteLine("\nPlease enter the target value");
            string targetString = Console.ReadLine();
            if (!string.IsNullOrEmpty(targetString))
                target = Convert.ToInt32(targetString);
            #endregion

            #region Validate Input
            if (!IsInputValid(array, target)) {
                Environment.Exit(0);
            }
            #endregion

            GetUniquePairs(array, target);
            
            OutputUniquePairs(pairs);

            Console.ReadLine();
        }
    }
}