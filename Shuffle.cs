using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shuffle
{
    class Shuffle
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] array = new int[rand.Next(20,30)];

            FillArray(array);
            Print(array);

            ShuffleArray(array);
            Console.WriteLine();
            Print(array);
        }

        static void Print(int[] array) 
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        static void FillArray(int[] array) 
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i + i;
            }
        }

        private static void ShuffleArray(int[] array)
        {
            Random rand = new Random();

            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                int temp = array[j];
                array[j] = array[i];
                array[i] = temp;
            }
        }
    }
}
