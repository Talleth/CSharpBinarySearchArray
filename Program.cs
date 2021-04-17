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
            // 1. Create an array with random numbers between 1-1000 (some numbers will be duplicated)
            // 2. Create one random number between 1-1000
            // 3. Pass the array and number to the search function
            // 4. The search function populates a binary search tree with the array
            // 5. The search function does a binary search on the tree with the random number
            // 6. This function will return found or not found based on the results

            int[]   randomNumberArray   = Program.RandomArrayGenerator(1000);
            int     randomNumber        = Program.RandomNumberGenerator(1000);
            bool    result              = Program.FindNumber(randomNumber, randomNumberArray);

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
            int[] result = new int[numberOfNumbers];
            Random random = new Random();

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

        public static bool FindNumber(int numberToFind, int[] listOfNumbers)
        {
            Node        result      = null;
            BinaryTree  binaryTree  = new BinaryTree();

            // Create and populate tree
            foreach (int value in listOfNumbers)
                binaryTree.Add(value);

            // Search tree
            result = binaryTree.Find(numberToFind, binaryTree.Root);

            return result != null;
        }
    }

    public class BinaryTree
    {
        private Node m_root;

        public BinaryTree()
        {
        }

        public Node Root
        {
            get { return this.m_root; }
            set { this.m_root = value; }
        }

        public bool Add(int value)
        {
            Node before = null;
            Node after  = this.Root;

            while (after != null)
            {
                // Check which direction the node would be in
                before = after;
                if (value < after.Data)
                    after = after.Left;
                else if (value > after.Data)
                    after = after.Right;
                else
                {
                    // Same value
                    return false;
                }
            }

            Node newNode = new Node(value);

            if (this.Root == null)
                this.Root = newNode;
            else
            {
                if (value < before.Data)
                    before.Left = newNode;
                else
                    before.Right = newNode;
            }

            return true;
        }

        public Node Find(int value, Node parent)
        {
            // Simple binary tree search traversal
            if (parent != null)
            {
                if (value == parent.Data) return parent;
                if (value < parent.Data)
                    return Find(value, parent.Left);
                else
                    return Find(value, parent.Right);
            }

            return null;
        }
    }

    public class Node
    {
        private Node m_right;
        private Node m_left;
        private int m_data;

        public Node(int data)
        {
            this.m_data = data;
            this.m_right = null;
            this.m_left = null;
        }

        public Node Right
        {
            get { return this.m_right; }
            set { this.m_right = value; }
        }

        public Node Left
        {
            get { return this.m_left; }
            set { this.m_left = value; }
        }

        public int Data
        {
            get { return this.m_data; }
            set { this.m_data = value; }
        }
    }
}
