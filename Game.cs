using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class Game
    {
        public List<BoardData> boards = new List<BoardData>();
        public Positions positions = new Positions();

        public Game()
        {
            positions.setInitialBoard();
        }

        public void next_movement()
        {
            List<string> movements = new List<string>();
            if (positions.last_movement.Split("")[0] != "b")
            {
                movements = positions.available_white_moves().ToList<string>();
            }
            else
            {
                movements = positions.available_black_moves().ToList<string>();
            }
            if (movements.Count() == 0) return;
            Random rnd = new Random();
            int randomMovement = rnd.Next(movements.Count());
            string selectedMove = movements[randomMovement];
            //if (selectedMove.Substring(0,2)=="wp" && selectedMove.Substring(2, 1) == "wp")
            //{
            //    //type of move:
            //    //change position
            //    //capture
            //    //en passant
            //    //castling
            //    //promotion
            //}
        }
    }
}
