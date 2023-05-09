using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComandLine_Snake_Game
{
    class Apple
    {
        public static int xCoord, yCoord;
        bool firstApple = true; 
     

        public void AppleRespawn()
        {
            Random appleCoordonates = new Random();

            for (int i = 0; i < Snake.snakePartsPositionX.Length; i++)
            {
                if (xCoord != Snake.snakePartsPositionX[i] && yCoord != Snake.snakePartsPositionY[i])
                {
                    if (xCoord == Snake.positionX && yCoord == Snake.positionY)
                    {
                        xCoord = appleCoordonates.Next(Game_Screen.minCoordX + 2, Game_Screen.maxCoordX);
                        yCoord = appleCoordonates.Next(Game_Screen.minCoordY + 1, Game_Screen.maxCoordY);
                        Console.SetCursorPosition(xCoord, yCoord);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("■");
                        Snake.snakeParts++;
                    }
                }
            }


            if (firstApple == true)
            {
                xCoord = appleCoordonates.Next(Game_Screen.minCoordX, Game_Screen.maxCoordX);
                yCoord = appleCoordonates.Next(Game_Screen.minCoordY, Game_Screen.maxCoordY);
                Console.SetCursorPosition(xCoord, yCoord);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("■");
            }

            firstApple = false;
        }
    }
}
