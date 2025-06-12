using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice
{
    internal class StringPrograms
    {
        public static void CountOccurrencesOf01SubstringInABinaryString()
        {

                Console.WriteLine("Count Occurrences of '01' Substring in a Binary String :- \n\n\n");
                string input = "0110010010101001";
                int count = 0;

                for (int i = 0; i < input.Length - 1; i++)
                {
                    char c = input[i];
                    char a = input[i + 1];

                    if (c == '0' && a == '1')
                    {
                        count++;
                    }
                }

                Console.WriteLine($"Character sequence occurres {count} times.");
            
        }
        
    
    

        public static void partialReverseString()
        {

            string input = "ABCD ABCD";
            string output = "";

            string[] words = input.Split(" ");
     

            for (int i = 1; i < words.Length; i++)
            { 
                string reversedWord = "";
                
                for (int j = 0; j < words[i].Length; j++)
                {

                    reversedWord = words[i][j] + reversedWord;
                }
                
                words[i] = reversedWord;
            
            }
            
            output = output + string.Join(" ", words);
            output = output.Trim();
            Console.WriteLine(output);

        }


        public static void wiproThirdProgram2ndWay()
        {

            string input = "I work with abc because I Love ababc.";
            string result = "";

            string[] words = input.Split(' ');
           
            for (int i = 0; i < words.Length; i++)
            {

                for (int j = 0; j < words[i].Length; j++)
                {

                    if (words[i].Contains("abc"))
                    {
                        words[i] = words[i].Replace("abc", "Nihilent");
                    }
                    
                }

                

            }
            result = result + string.Join(" ", words);
            result = result.Trim();
            Console.WriteLine(result);
        }





        public static void sortString() 
        {
            Console.WriteLine("Sort String");
            Console.Write("Enter a String :- ");
            string input = Console.ReadLine();

            char[] charArray = input.ToCharArray();

            for (int i = 0; i < input.Length - 1; i++)
            {
                for (int j = 0; j < input.Length - i - 1; j++)
                {
                    if (charArray[j] > charArray[j + 1])
                    {
                        char temp = charArray[j];
                        charArray[j] = charArray[j + 1];
                        charArray[j + 1] = temp;
                    }
                }
            }

            string result = new string(charArray); ;
            Console.WriteLine(result);
        }

        public static void reverseString() {
            Console.WriteLine("Reverse String \n\n");
            Console.Write("Enter a String :- ");
            string input = Console.ReadLine();
            string reversedString = "";

            for (int i = 0; i < input.Length; i++) {
                reversedString = input[i] + reversedString;
            }
            
            Console.WriteLine("Reversed String = " + reversedString);
        }

        public static void reverseEachWordOfString() {

            Console.Write("Reverse Each Word Of String \n\n");
            Console.Write("Enter a String = ");
            string input = Console.ReadLine();
            string result = "";

            string[] words = input.Split(" ");

            foreach (string word in words) {
                string reversedWord = "";


                for (int i = 0; i < word.Length  ; i++) {

                    reversedWord =  word[i] + reversedWord ;
                }

                result = result + reversedWord + " ";

            }
            

            Console.WriteLine("Reverse Each Word Of String = " + result.Trim());
        }


        public static void reverseWordOrderInGivenStringWithoutReversingWords() {

            Console.WriteLine("Reverse Word Order In Given String Without Reversing Words \n\n\n");

            Console.Write("Enter a String = ");
            string input = Console.ReadLine();
            string reversedString = "";


            string[] words = input.Split(" ");

            for (int i = words.Length - 1; i >= 0; i--)
            {


                Console.Write(words[i] + " ");
            }
        }

        public static void reverseWordOrderInGivenStringWithoutReversingWordsAndWithoutAnyStringMethodArrowInternationalProgram()
        {

           
            string input = "My Name is Ganesh";
            //Output = "Ganesh is Name My"

            IList<string> list = new List<string>();
            string currentWord = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ')
                {
                    currentWord = currentWord + input[i];
                }
                else
                {
                    list.Add(currentWord);
                    currentWord = "";   // Reset for next word
                }    
            }

            if (currentWord != "")         // Add the last word (since it won't be followed by space)
            {
                list.Add(currentWord);
            }

            for (int i = list.Count - 1; i >= 0; i--) // Print List Collection in reverse
            {
                Console.Write(list[i] + ' ');
            }
        }

        public static void findHighestValueInDictionaryWithAllDetailsForThatValue()
        {
                 // Step 1: Create and initialize the dictionary with animal counts
                 IDictionary<string, int> animalCount = new Dictionary<string, int>
                 {
                        { "cat", 3 },
                        { "dog", 7 },
                        { "monkey", 5 },
                        { "giraffe", 9 },
                        { "elephant", 2 }
                 };

                // Step 2: Prepare variables to track highest value, corresponding key, and index
                int highestValue = int.MinValue;  // Initially set to smallest possible integer
                string highestKey = "";           // To store the key with the highest value
                int index = 0;                    // To track current index in the loop
                int highestIndex = -1;            // To store the index of the highest value found

                // Step 3: Loop through the dictionary to find the highest value and its key/index
                foreach (var item in animalCount)
                {
                    // Check if current item's value is greater than the highest found so far
                    if (item.Value > highestValue)
                    {
                        highestValue = item.Value;   // Update highest value
                        highestKey = item.Key;       // Update corresponding key
                        highestIndex = index;        // Update index where it was found
                    }
                    index++;  // Move to the next index
                }

                // Step 4: Print the result in desired format
                Console.WriteLine($"Output: [{highestValue}, \"{highestKey}\", {highestIndex}]");
        }


        public static void seperateAlphabatesDigitsAndSpecialCharactersFromString() { 
        
            Console.WriteLine("Seperate Alphabates, Digits And Special Characters From String \n\n");

            Console.WriteLine("Enter a String which include Alphabates, Digits And Special Characters \n\n");
            string input = Console.ReadLine();

            string alphabates = "";
            string digits = "";
            string specialCharacters = "";

            for (int i = 0; i < input.Length; i++) { 
            
                char c = input[i];

                if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {

                    alphabates += c;
                }
                else if (c >= '0' && c <= '9')
                {
                    digits += c;
                }
                else { 
                
                    specialCharacters = specialCharacters + c;
                }
            }

            Console.WriteLine("Alphabates = " + alphabates);
            Console.WriteLine("Digits = " + digits);
            Console.WriteLine("SpecialCharacters = " + specialCharacters);
        }


        public static void checkStringAnagram() {

            Stopwatch stopwatch = Stopwatch.StartNew();



            Console.WriteLine("Try programiz.pro");
            Console.WriteLine("Check String Anagram \n\n");
            Console.WriteLine("Enter First String = ");
            string input1 = Console.ReadLine();
            Console.WriteLine("\nEnter Second String = ");
            string input2 = Console.ReadLine();

            input1 = input1.Replace(" ", "").ToLower();
            input2 = input2.Replace(" ", "").ToLower();

            if (input1.Length != input2.Length)
            {

                Console.WriteLine("Given Strings are not Anagram");
                return;
            }

            // create char[] of size = input.Length
            int[] charCount1 = new int[26];
            int[] charCount2 = new int[26];

            for (int i = 0; i < input1.Length; i++)
            {

                char c1 = input1[i];
                int index1 = c1 - 'a';
                charCount1[index1]++;


                char c2 = input2[i];
                int index2 = c2 - 'a';
                charCount2[index2]++;

            }

            bool isAnagram = true;
            for (int i = 0; i < 26; i++)
            {

                if (charCount1[i] != charCount2[i])
                {
                    isAnagram = false;
                    break;
                }
            }

            Console.WriteLine((isAnagram)?
             "Given Strings are Anagram"
                    : "Given Strings are NOT Anagram");


            stopwatch.Stop();
           
            Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
        }


        public static void wiproThirdProgram() {
            Console.WriteLine("Wipro Third Program replace abc with wipro \n");
            string input = "I wrok with abc because I love ababc";
            string find = "abc";
            string replace = "wipro";

            int inputLength = input.Length;
            int findLength = find.Length;
            string output = "";

            for (int i = 0; i < inputLength; i++)
            {
                // Check if the substring matches 'find'
                //
                if (i <= inputLength - findLength && input.Substring(i, findLength) == find)
                {
                    output += replace; // Append replacement string
                    //i += findLength - 1; // Skip matched characters
                    i = i + findLength - 1;
                }
                else
                {
                    //output += input[i]; // Append original character
                    output = output + input[i];
                }
            }
            Console.WriteLine(output);

        }

        public static void wiproSecondProgram() {
            Console.WriteLine("Make a String like I am Good Ganesh");
            string s1 = "I am Ganesh waghamare from vairag";
            string s2 = "Good";
            string result = "";
            string[] words = s1.Split(" ");

            List<string> list = new List<string>();
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == "Ganesh")
                {
                    list.Add(s2);
                    list.Add(words[i]);
                }
                else
                {
                    list.Add(words[i]);
                }
            }
            foreach (string s in list)
            {
                Console.Write(s +" ");
            }
        }



        public static void numberOfOccurrenceCharactersInString()
        {

            Console.WriteLine("Number Of Occurrence Characters In String Without Dictionary \n");

            String str = "Shree Ganesh Bhimrao Waghmare";

            for (int i = 0; i < str.Length; i++)
            {

                int count = 0;

                for (int j = 0; j < str.Length; j++)
                {

                    if (str[i] == str[j])
                    {
                        count++;
                    }
                }

                if (i == str.IndexOf(str[i]))
                {
                    Console.WriteLine($"Char '{str[i]}' occures {count} times.");
                }


            }
        }


        public static void numberOfOccurrenceCharactersUsingDirectoryInString()
        {
            Console.Write("Number Of Character Occurrence Using Directory In String \n");
            Console.Write("Enter a string: ");
            string str = Console.ReadLine();

            

            Dictionary<char, int> charCount = new Dictionary<char, int>();

            foreach (char c in str)
            {
                if (charCount.ContainsKey(c))
                {
                    charCount[c]++;
                }
                else
                {
                    charCount[c] = 1;
                }

            }


            foreach (var pair in charCount)
            {
                Console.WriteLine($"{pair.Key} occurres {pair.Value} times.");
            }


        }
    }
}
