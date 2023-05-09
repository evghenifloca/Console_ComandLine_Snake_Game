using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandLine_Snake_Game
{
    internal class Game_Screen
    {
        public int fieldX, fieldY;
        public static int snakeSize, snakeLevel = 1;
        public static int maxCoordX, minCoordX, maxCoordY, minCoordY;
        public static int levelRequirements = 3;
        bool speedChanged = false;

        public Game_Screen(int x, int y)
        {
            fieldX = x;
            fieldY = y;
        }


        public int levelChange(int gameSpeed)
        {
            if (snakeSize == levelRequirements)
            {
                snakeLevel++;
                levelRequirements += levelRequirements;
                gameSpeed -= Convert.ToInt32(gameSpeed * 0.20);
            }

            return gameSpeed;
        }

        public void FieldDraw()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(fieldX, fieldY);
            Console.ForegroundColor = ConsoleColor.DarkGray;


            for (int i = 0; i < fieldX; i++) 
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("▒");

                Console.SetCursorPosition(i, fieldY - 4);
                Console.Write("▒");
            }

            for (int i = 0; i < fieldY - 4; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("▒▒");

                Console.SetCursorPosition(fieldX - 2, i);
                Console.Write("▒▒"); 
            }

            maxCoordX = fieldX - 2;
            minCoordX = 1;
            maxCoordY = fieldY - 4;
            minCoordY = 0;
        }

        public void InterfaceSet()
        {
            snakeSize = Snake.snakeParts;

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.SetCursorPosition(2, fieldY - 2);
            Console.Write($"Snake Size: {snakeSize - 1} ({levelRequirements - 1})");

            Console.SetCursorPosition(fieldX - 11, fieldY - 2);
            Console.Write($"Level: {(snakeLevel < 10 ? "0" : "")}{snakeLevel}");
        }

    }
}
