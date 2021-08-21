using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace chess
{
    public class Game
    {
        public List<BoardData> boards = new List<BoardData>();
        public Positions positions;
        public bool save_in_database;

        public Game(bool nsave)
        {
            save_in_database = nsave;
        }

        public void start_game()
        {
            positions = new Positions();
            positions.setInitialBoard();
            boards.Clear();
            next_white_move();
        }

        public void next_white_move()
        {
            List<string> movements = positions.available_white_moves().ToList<string>();
            if (is_it_game_over(movements.Count()) == true) return;
            add_recent_board(movements.Count());
            print_last_board_info();
            Random rnd = new Random();
            int randomMovement = rnd.Next(movements.Count());
            string lastMovement = movements[randomMovement];
            positions.updateBoardDetailsAfterWhiteMovement(lastMovement);
            positions.setInitialBoard();
            next_black_move();
        }

        public void next_black_move()
        {
            List<string> movements = positions.available_black_moves().ToList<string>();
            if (is_it_game_over(movements.Count()) == true) return;
            add_recent_board(movements.Count());
            print_last_board_info();
            Random rnd = new Random();
            int randomMovement = rnd.Next(movements.Count());
            string lastMovement = movements[randomMovement];
            positions.updateBoardDetailsAfterBlackMovement(lastMovement);
            positions.setInitialBoard();
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
                    if(positions.cells[i, j]!="") current_board += positions.cells[i, j].Substring(0,2);
                    if (j < size_level_1) current_board += ",";
                }
                if (i < size_level_0) current_board += "*";
            }
            return current_board;
        }

        public bool is_it_game_over(int total_movements)
        {
            if (total_movements == 0)
            {
                add_recent_board(total_movements);
                //start_game();
                return true;
            }
            if (positions.blackPieces.Keys.Count + positions.whitePieces.Keys.Count == 2)
            {
                //start_game();
                return true;
            }
            return false;
        }

        public void add_recent_board(int total_movements)
        {
            
            BoardData bd = new BoardData(
                give_current_board(),
                positions.blackPieces.Keys.Count,
                positions.whitePieces.Keys.Count,
                positions.black_long_castling,
                positions.black_short_castling,
                positions.white_long_castling,
                positions.black_short_castling,
                last_movement_reduced(),
                total_movements);
            if(save_in_database) SavePositions.savePosition(bd);
            boards.Add(bd);
        }

        public string last_movement_reduced()
        {
            string[] move_info = positions.last_movement.Split(",");
            if (move_info[0].Length > 2) move_info[0] = move_info[0].Substring(0, 2);
            if (move_info[3].Length > 2) move_info[3] = move_info[3].Substring(0, 2);
            if (move_info[6].Length > 2) move_info[6] = move_info[6].Substring(0, 2);
            return String.Join(",", move_info);
        }

        public void print_last_board_info()
        {
            Console.WriteLine($"turn: {(boards.Count()+1)/2}");
            Console.WriteLine($"turn: {boards.Last().print_info()}");
        }
    }
}
