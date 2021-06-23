﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Startup
    {

        static Positions positions = new Positions();
        public static void Main(String[] args)
        {
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> black_movements = positions.available_black_moves().ToList<string>();
            Console.WriteLine(String.Join("\n", black_movements));
            Console.WriteLine($"Total movements: {black_movements.Count()}");
            List<string> white_movements = positions.available_white_moves().ToList<string>();
            Console.WriteLine(String.Join("\n", white_movements));
            Console.WriteLine($"Total movements: {white_movements.Count()}");
            //Console.WriteLine(white_king_attacked());
            //Console.WriteLine(black_king_attacked());
        }

    }
}
