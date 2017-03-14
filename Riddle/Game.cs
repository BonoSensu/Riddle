using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Riddle
{
    class Game
    {
        private int[,] field;
        private int FieldSize;
        private int iter;
        private int CurrentX;
        private int CurrentY;

        public Game(int FieldSize)
        {
            if (FieldSize > 1)
            {
                CurrentX = FieldSize - 1;
                CurrentY = FieldSize - 1;
                this.FieldSize = FieldSize;
                field = new int[FieldSize, FieldSize];
                Random Gen = new Random();
                int[] TempArr = new int[(int)Math.Pow(FieldSize, 2)];
                List<int> TempList = new List<int>();

                iter = 0;
                TempArr[(int)Math.Pow(FieldSize, 2) - 1] = 0;
                while (TempList.Count < (int)Math.Pow(FieldSize, 2) - 1)
                {
                    int TempRand = Gen.Next(0, (int)Math.Pow(FieldSize, 2) - 1) + 1;
                    if (!TempList.Contains(TempRand))
                    {
                        TempList.Add(TempRand);
                        TempArr[iter] = TempRand;
                        iter++;
                    }
                }
                iter = 0;
                for (int i = 0; i < FieldSize; i++)
                {
                    for (int j = 0; j < FieldSize; j++)
                    {

                        field[i, j] = TempArr[iter];
                        iter++;
                    }
                }

            }

        }

        public void Draw()
        {
            iter = 0;
            for (int i = 0; i < FieldSize; i++)
            {
                Console.SetCursorPosition(7, i + 4);

                for (int j = 0; j < FieldSize; j++)
                {
                    if (field[i, j] != 0)
                        Console.Write("{0}\t", field[i, j]);
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("NULL");
                        Console.ResetColor();
                        Console.Write("\t");
                    }
                    iter++;
                }
                Console.WriteLine();
            }
        }

        
        
        

        private void Switch(ref int a, ref int b)
        {
            a = a + b;
            b = b - a;
            b = -b;
            a = a - b;
        }



        public void Down()
        {
            if (!(CurrentY == (FieldSize - 1)))
            {
                Switch(ref field[CurrentY, CurrentX], ref field[CurrentY + 1, CurrentX]);
                CurrentY++;
            }
        }

        public void Right()
        {
            if (!(CurrentX == (FieldSize - 1)))
            {
                Switch(ref field[CurrentY, CurrentX], ref field[CurrentY, CurrentX + 1]);
                CurrentX++;
            }
        }

        public void Left()
        {
            if (!(CurrentX == 0))
            {
                Switch(ref field[CurrentY, CurrentX], ref field[CurrentY, CurrentX - 1]);
                CurrentX--;
            }
        }

        public void Up()
        {
            if (!(CurrentY == 0))
            {
                Switch(ref field[CurrentY, CurrentX], ref field[CurrentY - 1, CurrentX]);
                CurrentY--;
            }
        }

        public void Play()
        {
            while (true)
            {
                var TheKey = Console.ReadKey().Key;
                switch (TheKey)
                {
                    case ConsoleKey.UpArrow:
                        Up();
                        Draw();
                        break;
                    case ConsoleKey.DownArrow:
                        Down();
                        Draw();
                        break;
                    case ConsoleKey.RightArrow:
                        Right();
                        Draw();
                        break;
                    case ConsoleKey.LeftArrow:
                        Left();
                        Draw();
                        break;

                    default:
                        break;
                }
            }
        }



    }
}
