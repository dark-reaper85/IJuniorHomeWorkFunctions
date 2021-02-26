using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadInt
{
    class ReadInt
    {
        static void Main(string[] args)
        {
            string userInput = null;
            Console.WriteLine("Ваше число: " + ReadIntInput(userInput)); 
        }

        static int ReadIntInput(string userInput)
        {
            int value;

            while (int.TryParse(userInput, out value) == false)
            {
                Console.WriteLine("Введите число");
                userInput = Console.ReadLine();
            }

            return value;
        }
    }
}
