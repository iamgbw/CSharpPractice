using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    internal class NumberPrograms
    {

        public static void areaOfACircle()
        {
            Console.Write("Enter a Radius = ");
            int radius = int.Parse(Console.ReadLine());
            double pi = 3.14;
            double area = 0;

            area = pi * radius * radius;

            Console.WriteLine("Area = " + area);
        }

        public static void fibonacciSeries()
        {
            Console.WriteLine("Fibonacci Series = ");
            int first = 0;
            int second = 1;
            int next;

            for (int i = 0; i < 10; i++)
            {
                Console.Write(first + " ");

                next = first + second;
                first = second;
                second = next;

            }
        }

        public static void factorial()
        {
            Console.Write("Enter a Number = ");
            int num = int.Parse(Console.ReadLine());

            int factorial = 1;
            for (int i = 1; i <= num; i++)
            {
                factorial = factorial * i;
            }
            Console.WriteLine($"Factorial of {num} is {factorial}");

        }

        public static void findSmallestNumberInArray() {

            Console.WriteLine("Find Smallest Number In Array");
            int[] input = { 25, 11, 7, 75, 56 };
            int smallestNum = int.MaxValue;

            //Console.WriteLine()
            for (int i = 0; i < input.Length; i++)
            {
                if (smallestNum >= input[i])
                {
                    smallestNum = input[i];
                }
            }
            Console.WriteLine("Smallest Num = " + smallestNum);
        }


        public static void findLargestNumberInArray()
        {
            int[] array = { 25, 11, 7, 75, 56 };
            int largestNum = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (largestNum <= array[i])
                {
                    largestNum = array[i];
                }
            }
            Console.WriteLine("Largest Num = " + largestNum);

        }
        public static void findGivenNumberIsPrimeOrNonPrime() {

            Console.WriteLine("Find Given Number Is Prime Or NonPrime \n");

            Console.Write("Enter a Number = ");
            int number = int.Parse(Console.ReadLine());

            if (number < 2) {
                Console.WriteLine("Given Number is Not Prime Number");
                return;
            }

            bool isPrime = true;

            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                    break;
                }

            }

            Console.WriteLine((isPrime) ? "Given Number is Prime."
                : "Given Number is NOT Prime.");



        }
        public static void findAllPrimeNumbersUptoTheGivenNumber() {

            Console.WriteLine("Find Prime Number upto the given Numbe \n");

            Console.Write("Enter a Number = ");
            int number = int.Parse(Console.ReadLine());

            for (int i = 2; i <= number; i++)
            {

                bool isPrime = true;

                for (int j = 2; j * j <= i; j++)
                {

                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    Console.Write(i + " ");
                }
            }
        }

        public static void findDuplicateElementInGivenArray() {
            Console.WriteLine("\n find Duplicate Element In Given Array\n");
            int[] input = { 5, 2, 6, 4, 7, 6, 9 };

            IDictionary<int, int> elementCount = new Dictionary<int, int>();

            foreach (int num in input)
            {
                if (elementCount.ContainsKey(num))
                {
                    elementCount[num]++;
                }
                else
                {
                    elementCount[num] = 1;
                }
            }

            foreach (var item in elementCount)
            {
                if (item.Value >= 2)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }


        public static void findSquareOfAlternateNumbers() {

            Console.WriteLine("Find Square Of Alternate Numbers \n");
            int[] input = { 1, 3, 5, 7, 9 };
            List<int> list = new List<int>();



            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 == 0)
                {

                    int temp = input[i] * input[i];
                    list.Add(temp);
                }
            }

            foreach (int num in list)
            {
                Console.Write(num + " ");
            }
        }

        public static void printNumbersWithoutNumber()
        {
            int start = 'A' / 'A';      // 65 / 65 = 1
            int end = 'd';              // ASCII of 'd' = 100

            for (int i = start; i <= end; i++)
            {
                Console.Write(i + " "); 
            }
        }
        public static void findArmStrongNumber() {

            Console.WriteLine("Enter a Number = ");
            int num = int.Parse(Console.ReadLine());
            int originalNumber = num;
            int sum = 0;
            int digits = num.ToString().Length;

            while (num > 0) {

                int digit = num % 10;
                int power = 1;

                for (int i = 0; i < digits; i++) {

                    power = power * digit;
                }

                sum += power;
                num /= 10;

            }

            if (originalNumber == sum)
            {
                Console.WriteLine("Given Number is ArmStrong Number.");
            }
            else {
                Console.WriteLine("Given Number is Not ArmStrong Number.");
            }

        }

        public static void checkGivenNumberIsPrimeOrNonPrime() {
            Console.WriteLine("Check Given Number Is Prime Or NonPrime \n\n");
            Console.Write("Enter Number = ");
            int num = int.Parse(Console.ReadLine());
            int nonPrime = 0;

            if (num < 2) {
                Console.WriteLine("Given Number is Not a Prime Number");
            }

            for (int i = 2; i < num; i++) {
                if (num % i == 0) {
                    nonPrime++;
                }
            }

            Console.WriteLine((nonPrime != 0) ? "Given Number is Not a Prime Number" : "Given Number is a Prime Number");

        }



        public static void reverseNumber()
        {

            Console.Write("Reverse Number  \n\n");
            Console.Write("Enter a Number :- ");
            int input = int.Parse(Console.ReadLine());
            int reversedNumber = 0;

            while (input > 0)
            {
                int digit = input % 10;
                reversedNumber = reversedNumber * 10 + digit;
                input = input / 10;
            }


            Console.Write("Reversed Number = " + reversedNumber + "\n\n");

        }

        public static void digitOrStringPatternStartEndStartEnd()
        {
            string input = "0123456789";
            string output = "";

            int start = 0;
            int end = input.Length - 1;

            while (start <= end)
            {
                if (start == end)
                {
                    output += input[start];
                }
                else
                {
                    output += input[start];
                    output += input[end];
                }

                start++;
                end--;
            }

            Console.WriteLine("Input = " + input);
            Console.WriteLine("Output = " + output);

        }
    }
}
