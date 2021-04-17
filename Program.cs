using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    public class Program
    {
        public static void Main(string[] pArguments)
        {
            // This main function does the following:
            // 1. Create an array with random numbers between 1-1000 and sort
            // 2. Create one random number between 1-1000
            // 3. Pass the sorted array and number to the search function
            // 4. Perform binary search on sorted array
            // 5. This function will return found or not found based on the results

            int[]   randomNumberArray   = Program.RandomArrayGenerator(1000);
            int     randomNumber        = Program.RandomNumberGenerator(1000);
            bool    result              = false;

            Array.Sort(randomNumberArray);

            result  = Program.FindNumber(randomNumber, randomNumberArray);

            Console.WriteLine("Results of Search: ");
            Console.WriteLine();
            Console.WriteLine("Array contains numbers from 1-1000");
            Console.WriteLine();
            Console.WriteLine("Random number generated = " + randomNumber);
            Console.WriteLine();

            if (result)
                Console.WriteLine("Element found");
            else
                Console.WriteLine("Not found");
        }

        public static int[] RandomArrayGenerator(int numberOfNumbers)
        {
            // Initialize output array and random number class
            int[]   result = new int[numberOfNumbers];
            Random  random = new Random();

            // Get each random number and store in array
            for (int i = 0; i < numberOfNumbers; i++)
                result[i] = random.Next(1, numberOfNumbers);

            return result;
        }

        public static int RandomNumberGenerator(int maxNumber)
        {
            // Generate one random number from 1-maxnumber
            Random random = new Random();
            return random.Next(1, maxNumber);
        }

        public static bool FindNumber(int numberToFind, int[] sortedArray)
        {
            int minNum      = 0;
            int maxNum      = sortedArray.Length - 1;
            bool result     = false;

            // Following demonstrates the use of a binary search on a sorted array
            // The steps are:
            // 1. Find the middle, if that matches return true and break
            // 2. If not, divide the array in half (number is greater take top half otherwise bottom half)
            // 3. Repeat steps until there is a match
            // 4. If no match is found return false

            while (minNum <= maxNum)
            {
                int mid = (minNum + maxNum) / 2;

                if (numberToFind == sortedArray[mid])
                {
                    result = true;
                    break;
                }
                else if (numberToFind < sortedArray[mid])
                    maxNum = mid - 1;
                else
                    minNum = mid + 1;
            }
            return result;
        }
    }
}
