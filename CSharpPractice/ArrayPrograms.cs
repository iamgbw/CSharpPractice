using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    internal class ArrayPrograms
    {
        public static void findSecondLargestNumberInGivenArray()
        {

            Console.WriteLine("Second Largest Number in Array :- \n\n\n\n");

            int[] array = { 5, 1, 0, 4, 0, 6, 0, 0, 9, 0, 8, 0, 7, 6 };

            int largest = int.MinValue;
            int secondLargest = int.MinValue;

            foreach (int num in array)
            {
                if (num > largest)
                {
                    secondLargest = largest;
                    largest = num;
                }
                else if (num > secondLargest && num < largest)
                {
                    secondLargest = num;
                }
            }

            Console.WriteLine("Second Largest = " + secondLargest);
            Console.WriteLine("Largest = " + largest);

        }

        public static void moveZerosToLeftInGivenArray()
        {
            int[] array = { 5, 7, 0, 4, 0, 6, 0, 0, 9, 0, 8, 0, 7, 6 };

            List<int> list = new List<int>();

            foreach (int num in array)
            {
                if (num == 0)
                {
                    list.Add(num);
                }
            }

            foreach (int num in array)
            {
                if (num != 0)
                {
                    list.Add(num);
                }
            }

            foreach (int num in list)
            {
                Console.Write(num + "   ");
            }
        }
        
        
        public static void sortAscendingArray()
        {

            int[] array = { 2, 5, 8, 4, 1, 0, 9, 7, 3, 6 };

            for (int i = 0; i < array.Length - 1; i++)
            {

                for (int j = 0; j < array.Length - i - 1; j++)
                {

                    if (array[j] > array[j + 1])
                    {

                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            foreach (int num in array)
            {

                Console.Write(num + "   ");
            }
        }
        public static void sortDescendingArray() 
        {

            int[] array = {2, 5, 8, 4, 1, 0, 9, 7, 3, 6 };

            for (int i = 0; i < array.Length - 1; i++)
            {

                for (int j = 0; j < array.Length - i - 1; j++)
                {

                    if (array[j] < array[j + 1])
                    { 
                    
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            foreach (int num in array)
            { 
            
                Console.Write(num + "   ");
            }
        }

        public static void reverseArray()
        {
            int[] array = { 2, 5, 8, 4, 1, 0, 9, 7, 3, 6 };
            int length = array.Length;

            Console.WriteLine(length);
            for (int i = 0; i < array.Length / 2; i++)
            {
                int temp = array[i];
                array[i] = array[length - i - 1];
                array[length - i - 1] = temp;

            }

            foreach (int num in array)
            { 
            
                Console.Write(num + ",   ");
            }
        }
    }
}
