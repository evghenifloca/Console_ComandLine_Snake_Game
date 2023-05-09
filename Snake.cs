using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace ComandLine_Snake_Game
{
    public class Snake
    {
        public static int snakeParts = 1;
        public static int positionX = 30, positionY = 20;
        public static int frame = snakeParts - 1;
        public static bool speedConverter = false;
        
        public static int[] snakePartsPositionX = new int[2888];
        public static int[] snakePartsPositionY = new int[2888];


        public enum Direction
        {
            Up,
            Down,
            Right,
            Left
        }

        public static Direction snakeDirection = Direction.Right;


        public static bool SnakeCollision(bool game)
        {
            if (positionX == Game_Screen.minCoordX || positionX == Game_Screen.maxCoordX ||
                positionY == Game_Screen.minCoordY || positionY == Game_Screen.maxCoordY)
                game = false;
            
            for (int i = 0; i < snakePartsPositionX.Length; i++)
            {
                if (positionX == snakePartsPositionX[i] && positionY == snakePartsPositionY[i])
                {
                    game = false;
                }
            }


            return game;
        }

        public void HeadPositionScan(int frame)
        {
            snakePartsPositionX[frame] = positionX;
            snakePartsPositionY[frame] = positionY;
        }

        public void SnakeMoving()
        {
            //Draw the body part by scanning the head previous position
            HeadPositionScan(frame);
            Console.SetCursorPosition(snakePartsPositionX[frame], snakePartsPositionY[frame]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("O");

            if (frame > 0) 
                frame--;
            else
            {
                frame = snakeParts - 1;
            }

            //The Snake receives the direction command
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo move = Console.ReadKey(true);

                switch (move.Key)
                {
                    case ConsoleKey.RightArrow:
                        if (snakeDirection != Direction.Left)
                            snakeDirection = Direction.Right;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (snakeDirection != Direction.Right)
                            snakeDirection = Direction.Left;
                        break;
                    case ConsoleKey.UpArrow:
                        if (snakeDirection != Direction.Down)
                            snakeDirection = Direction.Up;
                        break;
                    case ConsoleKey.DownArrow:
                        if (snakeDirection != Direction.Up)
                            snakeDirection = Direction.Down;
                        break;
                }
            }


            //The Snake moves to the received direction
            switch (snakeDirection)
            {
                case Direction.Right:
                    positionX += 1;
                    break;
                case Direction.Left:
                    positionX -= 1;
                    break;
                case Direction.Up:
                    positionY -= 1;
                    break;
                case Direction.Down:
                    positionY += 1;
                    break;
            }
            

            //Drawing the Snake Head to the new position
            Console.SetCursorPosition(positionX, positionY);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("0");

            //Deleting the previous position of the last part of the snake
            //except for the 1st iteration when the snake head is alone to prevent delettin (0, 0)
            if (snakePartsPositionX[frame] != 0)
            {
                Console.SetCursorPosition(snakePartsPositionX[frame], snakePartsPositionY[frame]);
                Console.Write(" ");
            }
            
        }

    }
}
