using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnknownWorld.Maker.Game;
using UnknownWorld.Maker.World;

namespace UnknownWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            while (true)
            {
                Console.WriteLine(Cell.CellSymbol[Int32.Parse(Console.ReadLine())]);
            }
        }
    }
}
