using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveNewWorld
{
    class BraveNewWorld
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Random rand = new Random();
            int playerPosX = 0, playerPosY = 0;
            int playerDX = 0, playerDY = 0;
            bool isPlaying = true;

            char[,] randomWorld = new char[rand.Next(20, 30), rand.Next(20, 30)];
            FillTheWorld(randomWorld);
            SetTreasurePosition(randomWorld);
            PrintTheWorld(randomWorld);

            SetPlayerPosition(randomWorld, ref playerPosX, ref playerPosY);
            Console.SetCursorPosition(playerPosX, playerPosY);
            Console.Write('@');

            while (isPlaying)
            {
                Move(randomWorld, ref playerPosX, ref playerPosY, ref playerDX, ref playerDY);

                if (randomWorld[playerPosY, playerPosX] == 'X')
                {
                    isPlaying = false;
                    Console.Clear();
                    Console.SetCursorPosition(0,0);
                    Console.WriteLine("Вы победили!!!");
                    Console.ReadKey();
                }
            }
        }

        static void SetTreasurePosition(char[,] world)
        {
            bool findEmpty = true;

            for (int i = world.GetLength(0) - 1; i > 0 && findEmpty; i--)
            {
                for (int j = world.GetLength(1) - 1; j > 0 && findEmpty; j--)
                {
                    if (world[i, j] == ' ')
                    {
                        world[i, j] = 'X';
                        findEmpty = false;
                    }
                }
            }
        }
        static void Move(char[,] map, ref int playerPosX, ref int playerPosY, ref int playerDX, ref int playerDY) 
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        playerDX = -1; playerDY = 0;
                        break;
                    case ConsoleKey.UpArrow:
                        playerDX = 0; playerDY = -1;
                        break;
                    case ConsoleKey.RightArrow:
                        playerDX = 1; playerDY = 0;
                        break;
                    case ConsoleKey.DownArrow:
                        playerDX = 0; playerDY = 1;
                        break;
                }

                if (map[playerPosY + playerDY, playerPosX + playerDX] != '#')
                {
                    Console.SetCursorPosition(playerPosX, playerPosY);
                    Console.Write(' ');

                    playerPosX += playerDX;
                    playerPosY += playerDY;

                    Console.SetCursorPosition(playerPosX, playerPosY);
                    Console.Write('@');
                }
            }
        }
        static void SetPlayerPosition(char[,] world ,ref int playerPosX, ref int playerPosY)
        {
            bool findEmpty = true;

            for (int i = 0; i < world.GetLength(0) && findEmpty; i++)
            {
                for (int j = 0; j < world.GetLength(1) && findEmpty; j++)
                {
                    if (world[i,j] == ' ')
                    {
                        playerPosX = i;
                        playerPosY = j;
                        findEmpty = false;
                    }
                }
            }
        }

        static void PrintTheWorld(char[,] array) 
        {
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void FillTheWorld(char[,] array) 
        {
            Random rand = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i == 0 || i == array.GetLength(0) - 1 || j == 0 || j == array.GetLength(1) - 1 )
                    {
                        array[i, j] = '#';
                    }
                    else
                    {
                        switch (rand.Next(1,5))
                        {
                            case 1:
                                array[i, j] = '#';
                                break;
                            default:
                                array[i, j] = ' ';
                                break;
                        }
                    }
                }
            }
        }
    }
}
