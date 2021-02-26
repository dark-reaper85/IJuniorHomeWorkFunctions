using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIElement
{
    class UIElement
    {
        static void Main(string[] args)
        {
            int barLength = 10;
            int percent = 70;
            int positionX = 0;
            int positionY = 0;

            PrintBar(barLength, percent, positionX, positionY);
        }

        private static void PrintBar(int barLength, int percent, int positionX, int positionY)
        {
            Console.SetCursorPosition(positionX, positionY);
            
            if (percent < 0)
                percent = 0;
            else if (percent > 100)
                percent = 100;

            int filledBar = barLength * percent / 100;

            Console.Write('[');
            for (int i = 0; i < filledBar; i++)
            {
                Console.Write('#');
            }
            for (int i = filledBar; i < barLength; i++)
            {
                Console.Write('_');
            }
            Console.Write(']');
        }
    }
}
