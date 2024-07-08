using System.Diagnostics;
using System.Text;

namespace Forum8
{
    public struct ArraySum
    {
        public int Key;
        public int Element;  
    };

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

        static void Test()
        { 

            var watch1 = System.Diagnostics.Stopwatch.StartNew();
            int[] array = { 1, 3, 0, 4 };
            int length = array.Length;
            int counter1 = 0;
            int counter2 = 0;

            int target = 7;

            for (int index = 0; index <= length; index++)
            {
                for (int jindex = index + 1; jindex < length; jindex++)
                {
                    if ((array[index] + array[jindex]) == target && !pairs.ContainsKey(array[index]))
                    {
                        pairs.Add(array[index], array[jindex]);
                    }
                    counter1++;
                }
            }
            watch1.Stop();
            var elapsedMs = watch1.Elapsed.TotalMilliseconds;
            Console.WriteLine(elapsedMs);
            Console.WriteLine($"Counter 1 is : {counter1}");

            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            for (int iterator = 0; iterator < length; iterator++)
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

                counter2++;
            }
            watch2.Stop();
            var elapsedMs2 = watch2.Elapsed.TotalMilliseconds;
            Console.WriteLine(elapsedMs2);
            Console.WriteLine($"COunter 2 is : {counter2}");
        }

        static void GetUniquePairs(int[] array, int target)
        {
            int length = array.Length; //[ 1 3 0 4 5] target = 4
            
            #region Approach 1 
            var watch1 = System.Diagnostics.Stopwatch.StartNew();
            for (int index = 0; index <= length; index++)
            {
                for (int jindex = index + 1; jindex < length; jindex++)
                {
                    if ((array[index] + array[jindex]) == target && !pairs.ContainsKey(array[index]))
                    {
                        pairs.Add(array[index], array[jindex]);
                    }
                }
            }
            watch1.Stop();
            var elapsedMs1 = watch1.Elapsed.TotalMilliseconds;
            Console.WriteLine($"Old appraoch :- {elapsedMs1}");
            OutputUniquePairs(pairs);
            pairs.Clear();
            #endregion

            #region Approach 2
            IDictionary<int,int> keyValues = new Dictionary<int,int>();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            foreach (var element in array)
            { 
                if(keyValues.ContainsKey(element))
                    keyValues[element] +=1;
                else
                    keyValues.Add(element, 1);
            }
            for (int iterator = 0; iterator < length; iterator++)//&& array[iterator] <= target
            {
                int difference = target - array[iterator];
                if (difference < array[iterator])
                    continue;

                if (difference == array[iterator])
                {
                    if (keyValues[difference] >= 2 && !pairs.ContainsKey(array[iterator]))
                    {
                        pairs.Add(array[iterator], difference);
                    }
                }
                else if (keyValues.ContainsKey(difference) && !pairs.ContainsKey(array[iterator]))
                {
                    pairs.Add(array[iterator], difference);
                }
            }
            watch.Stop();
            var elapsedMs = watch.Elapsed.TotalMilliseconds;
            Console.WriteLine(elapsedMs);
            OutputUniquePairs(pairs);

            pairs.Clear();
            #endregion

            #region Approach 3
            var watch2 = System.Diagnostics.Stopwatch.StartNew();
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
            watch2.Stop();
            var elapsedMs2 = watch.Elapsed.TotalMilliseconds;
            Console.WriteLine(elapsedMs2);
            OutputUniquePairs(pairs);
            pairs.Clear();
            #endregion 
            #region Approach 4
            
            var watch4 = System.Diagnostics.Stopwatch.StartNew();
            Dictionary<int,ArraySum> keys = new Dictionary<int,ArraySum>();
            ArraySum sum = new ArraySum();

            foreach (var element in array)
            {
                
                if (keys.TryGetValue(element, out sum) == false)
                    keys.Add(element, new ArraySum { Key = element, Element = 1 });
                else
                    keys[element] = new ArraySum {Key = element, Element = keys[element].Element + 1 };
            }

            for (int iterator = 0; iterator < length; iterator++)//&& array[iterator] <= target
            {
                int difference = target - array[iterator];
                if (difference < array[iterator])
                    continue;

                if (difference == array[iterator])
                {
                    if (keys[difference].Element >= 2 && !pairs.TryGetValue(array[iterator], out _))
                    {
                        pairs.Add(array[iterator], difference);
                    }
                }
                else if (keys[difference].Key == difference && !pairs.TryGetValue(array[iterator], out _))
                {
                    pairs.Add(array[iterator], difference);
                }
            }
            watch4.Stop();
            var elapsedMs4 = watch4.Elapsed.TotalMilliseconds;
            Console.WriteLine(elapsedMs4);
            OutputUniquePairs(pairs);
            pairs.Clear();
            #endregion

            #region Approach 5

            var watch5 = System.Diagnostics.Stopwatch.StartNew();
            int max = 0;
            for (int iterator = 0; iterator < length; iterator++)
            {
                if (array[iterator] > max)
                     max = array[iterator];
            }

            int[] tempArray = new int[max + 1];
            for (int iterator = 0; iterator < length; iterator++)
            { 
                int temp = array[iterator];
                tempArray[array[iterator]] = temp;
            }

            ArraySum[] pairs2 = new ArraySum[max + 1];
            for (int iterator = 0; iterator < length; iterator++)
            {
                int difference = target - array[iterator];
                if (tempArray[difference] == difference && array[iterator] < difference)
                {
                    pairs2[array[iterator]] = new ArraySum { Key = array[iterator], Element = difference };
                }
            }

            //OutputPairsFromArraySum(pairs2);
            watch5.Stop();
            var elapsedMs5 = watch5.Elapsed.TotalMilliseconds;
            Console.WriteLine(elapsedMs5);
            OutputPairsFromArraySum(pairs2);
            #endregion
        }

        private static void OutputPairsFromArraySum(ArraySum[] pairs)
        {
            int length = pairs.Length;
            StringBuilder stringBuilder= new StringBuilder();
            stringBuilder.Append('{');
            
            for (int iterator = 0; iterator < length; iterator++)
            {
                if ((pairs[iterator].Key == 0 && pairs[iterator].Element == 0))
                {

                    continue;
                }
                else
                {
                    stringBuilder.Append($"({pairs[iterator].Key},{pairs[iterator].Element})");    
                }
                stringBuilder.Append(',');                
            }

            if (stringBuilder[stringBuilder.Length-1] == ',')
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            stringBuilder.Append('}');
            Console.WriteLine(stringBuilder);
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
            //Console.WriteLine("\nPlease enter the array size");
            //string arraySize = Console.ReadLine();
            //if (!string.IsNullOrEmpty(arraySize))
            //    size = Convert.ToInt32(arraySize);
            //array = new int[size];

            //Console.WriteLine("\nPlease enter the array elements space separated");
            //string stringArray = Console.ReadLine();
            //if (!string.IsNullOrEmpty(stringArray))
            //    array = Array.ConvertAll(stringArray.Trim().Split(' '), Convert.ToInt32);

            //Console.WriteLine("\nPlease enter the target value");
            //string targetString = Console.ReadLine();
            //if (!string.IsNullOrEmpty(targetString))
            //    target = Convert.ToInt32(targetString);
            #endregion

            #region Validate Input
            if (!IsInputValid(array, target)) {
                Environment.Exit(0);
            }
            #endregion

            //Test();

            GetUniquePairs(array, target);
            
            

            Console.ReadLine();
        }
    }
}