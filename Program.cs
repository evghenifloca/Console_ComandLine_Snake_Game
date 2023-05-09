using ComandLine_Snake_Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ComandLine_Snake_Game
{
    class Program
    {
        static void Main(string[] args) 
        {
            bool game = true;
            int gameSpeed = 200;
            string playerName;

            //Setting the window and game field size
            Game_Screen game_screen = new Game_Screen(60, 35);
            game_screen.FieldDraw();

            //Creating Snake and Apple objects
            Snake snake = new Snake();
            Apple apple = new Apple();

            while (game == true)
            {
                game_screen.InterfaceSet();

                snake.SnakeMoving();
                apple.AppleRespawn();
                game = Snake.SnakeCollision(game);
                gameSpeed = game_screen.levelChange(gameSpeed);

                Thread.Sleep(gameSpeed);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(26, 15);
            Console.Write($"GAME OVER");
            Console.SetCursorPosition(16, 16);
            Console.Write("PRESS ANY KEY TO CONTINUE...");
            Console.ReadKey();
            Console.Clear();

            SaveScore();
        }

        static void SaveScore()
        {

            using (StreamWriter saves = new StreamWriter("saves.txt", true))
            {
                saves.WriteLine(Game_Screen.snakeSize - 1);
            }

            string[] lines = File.ReadAllLines("saves.txt");
            int[] scores = new int[lines.Length];

            int i = 0, y = 5, k = 0, min;


            foreach (string line in lines)
            {
                scores[i] = Convert.ToInt32(line);
                i++;
            }

            while (k < scores.Length)
            {
                for (int j = 0; j < scores.Length; j++)
                {
                    if (scores[k] > scores[j])
                    {
                        min = scores[k];
                        scores[k] = scores[j];
                        scores[j] = min;
                        
                    }
                }
                k++;
            }

            Console.SetCursorPosition(26, 6);
            Console.Write("TOP SCORES");
            Console.SetCursorPosition(26, 7);
            Console.Write("----------");

            
            if (scores.Length > 10)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.SetCursorPosition(30, 9 + j + j);
                    Console.Write(scores[j] + " ");
                }
            }
            else
            {
                for (int j = 0; j < scores.Length; j++)
                {
                    Console.SetCursorPosition(30, 9 + j + j);
                    Console.Write(scores[j] + " ");
                }
            }


            Console.SetCursorPosition(26, 30);
            Console.Write("----------");
            Console.ReadKey();

        }
    }

}