using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntExamples.Types;

namespace IntExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SelectionMenu();
        }

        private static void SelectionMenu()
        {
            Console.WriteLine("---Code Examples---\n\n");

            Console.WriteLine("1. MergeSort\n");
            Console.WriteLine("1. QuickSort\n");

            bool valid = false;
            while (!valid)
            {
                Console.Write("\nSelect example number: ");

                string input = Console.ReadLine();
                int option;

                if (int.TryParse(input, out option))
                    switch (option)
                    {
                        case 1:
                            MergeSortEx.Start();
                            valid = true;
                            break;
                        default:
                            Console.WriteLine("Invalid Selection\n");
                            break;
                    }
                else
                    Console.WriteLine("Invalid Selection\n");
            }

        }
    }
}
