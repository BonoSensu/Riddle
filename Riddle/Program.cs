using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riddle
{
    class Program
    {
        static void Main(string[] args)
        {
            string menu = "15-puzzle";
            int x = Console.WindowWidth;
            int y = Console.WindowHeight;
            Console.SetCursorPosition(x / 2 - menu.Length / 2, 1);
            Console.WriteLine(menu);
            Console.CursorVisible = true;

            Console.Write("Enter the size of field: ");
            int size = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Game FieldSize = new Game(size);
            FieldSize.Draw();
            FieldSize.Play();
            Console.ReadKey();
        }

    }

}
