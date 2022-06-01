using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntExamples.Types
{
    public static class MergeSortEx
    {
        internal static void Start()
        {
            Console.Clear();
            Console.WriteLine("---MergeSort---\n\n");
            Console.WriteLine("Enter numbers to add to array, enter any letter when finished:");

            List<int> values = new List<int>();
            bool cont = true;

            while(cont)
            {
                int input;
                cont = int.TryParse(Console.ReadLine(), out input);
                if(cont) values.Add(input);
            }

            int[] array = values.ToArray();
            int[] result = MergeSort(array);

            Console.Write("\nSorted Array: ");
            PrintArray(result);
            Console.ReadLine();
        }

        internal static int[] MergeSort(int[] array)
        {
            int[] left;
            int[] right;
            int[] result = new int[array.Length];

            if (array.Length <= 1)
                return array;

            //find midpoint
            int midPoint = array.Length / 2;

            //split array into 2 arrays
            left = new int[midPoint];

            if (array.Length % 2 == 0)
                right = new int[midPoint];
            else right = new int[midPoint + 1];


            //populate left
            for(int i =0; i < midPoint; i++)
                left[i] = array[i];

            //populate right
            int x = 0;
            for(int i = midPoint; i < array.Length; i++)
            {
                right[x] = array[i];
                x++;
            }

            left = MergeSort(left);
            right = MergeSort(right);

            result = Merge(left, right);
            return result;
        }

        internal static int[] Merge(int[] left, int[] right)
        {
            int resultLength = left.Length + right.Length;
            int[] result = new int[resultLength];

            int leftIndex = 0;
            int rightIndex = 0;
            int resultIndex = 0;

            while(leftIndex < left.Length || rightIndex < right.Length)
            {
                if(leftIndex < left.Length && rightIndex < right.Length)
                {
                    if(left[leftIndex] <= right[rightIndex])
                    {
                        result[resultIndex] = left[leftIndex];
                        leftIndex++;
                        resultIndex++;
                    }
                    else
                    {
                        result[resultIndex] = right[rightIndex];
                        rightIndex++;
                        resultIndex++;
                    }
                }
                else if(leftIndex < left.Length)
                {
                    result[resultIndex] = left[leftIndex];
                    leftIndex++;
                    resultIndex++;
                }
                else if(rightIndex < right.Length)
                {
                    result[resultIndex] = right[rightIndex];
                    rightIndex++;
                    resultIndex++;
                }
            }
            return result;
        }

        internal static void PrintArray(int[] input)
        {
            foreach (int i in input)
                Console.Write(i + " ");
        }

    }
}
