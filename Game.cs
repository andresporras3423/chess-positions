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

        public void start_game()
        {
            next_white_move();

        }

        public void next_white_move()
        {
            List<string> movements = positions.available_white_moves().ToList<string>();
            add_recent_board(movements.Count());
            print_last_board_info();
            if (movements.Count() == 0) return;
            Random rnd = new Random();
            int randomMovement = rnd.Next(movements.Count());
            string[] selectedMoveInfo = movements[randomMovement].Split(",");
            if(selectedMoveInfo.Last() == "castling")
            {
                if (selectedMoveInfo[5] == "6") positions.whitePieces["wr2"] = new Cell(7, 5);
                else positions.whitePieces["wr1"] = new Cell(7, 3);
                positions.white_short_castling = false;
                positions.white_long_castling = false;
            }
            else if(selectedMoveInfo.Last() != "")
            {
                positions.whitePieces.Remove(selectedMoveInfo.Last());
            }
            if (selectedMoveInfo.First() == "wk")
            {
                positions.white_short_castling = false;
                positions.white_long_castling = false;
            }
            else if (selectedMoveInfo.First() == "wr1") positions.white_long_castling = false;
            else if (selectedMoveInfo.First() == "wr2") positions.white_short_castling = false;
            positions.whitePieces[selectedMoveInfo[3]] = new Cell(Int32.Parse(selectedMoveInfo[4]), Int32.Parse(selectedMoveInfo[5]));
            positions.last_movement = movements[randomMovement];
            next_black_move();
        }

        public void next_black_move()
        {
            List<string> movements = positions.available_black_moves().ToList<string>();
            add_recent_board(movements.Count());
            print_last_board_info();
            if (movements.Count() == 0) return;
            Random rnd = new Random();
            int randomMovement = rnd.Next(movements.Count());
            string[] selectedMoveInfo = movements[randomMovement].Split(",");
            if (selectedMoveInfo.Last() == "castling")
            {
                if (selectedMoveInfo[5] == "6") positions.whitePieces["br2"] = new Cell(0, 5);
                else positions.whitePieces["br1"] = new Cell(0, 3);
                positions.black_short_castling = false;
                positions.black_long_castling = false;
            }
            else if (selectedMoveInfo.Last() != "")
            {
                positions.blackPieces.Remove(selectedMoveInfo.Last());
            }
            if (selectedMoveInfo.First() == "bk")
            {
                positions.black_short_castling = false;
                positions.black_long_castling = false;
            }
            else if (selectedMoveInfo.First() == "br1") positions.black_long_castling = false;
            else if (selectedMoveInfo.First() == "br2") positions.black_short_castling = false;
            positions.blackPieces[selectedMoveInfo[3]] = new Cell(Int32.Parse(selectedMoveInfo[4]), Int32.Parse(selectedMoveInfo[5]));
            positions.last_movement = movements[randomMovement];
            next_white_move();
        }

        public string give_current_board()
        {
            int size_level_0 = positions.cells.GetUpperBound(0);
            int size_level_1 = positions.cells.GetUpperBound(1);
            string current_board = "";
            for (int i=0; i<= size_level_0; i++)
            {
                for (int j = 0; j <= size_level_1; j++)
                {
                    current_board += positions.cells[i, j];
                    if (i < size_level_1) current_board += ",";
                }
                if (i < size_level_0) current_board += "*";
            }
            return current_board;
        }

        public void add_recent_board(int total_movements)
        {
            BoardData bd = new BoardData(
                give_current_board(),
                positions.blackPieces.Keys.Count + positions.whitePieces.Keys.Count,
                positions.black_long_castling,
                positions.black_short_castling,
                positions.white_long_castling,
                positions.black_short_castling,
                positions.last_movement,
                total_movements);
            boards.Add(bd);
        }

        public void print_last_board_info()
        {
            Console.WriteLine($"turn: {(boards.Count()+1)/2}");
            Console.WriteLine($"turn: {boards.Last().print_info()}");
        }
    }
}
