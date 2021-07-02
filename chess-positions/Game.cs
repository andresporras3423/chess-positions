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
            if(is_game_finished(movements.Count()) == true) start_game();
            add_recent_board(movements.Count());
            print_last_board_info();
            Random rnd = new Random();
            int randomMovement = rnd.Next(movements.Count());
            string[] selectedMoveInfo = movements[randomMovement].Split(",");
            if (selectedMoveInfo.Last() != "") // change of position with no capture
            {
                positions.blackPieces.Remove(selectedMoveInfo.Last());
            }
            if (selectedMoveInfo[0] != selectedMoveInfo[3]) //promotion
            {
                positions.whitePieces.Remove(selectedMoveInfo.First());
                positions.whitePieces[selectedMoveInfo[3]] = new Cell(Int32.Parse(selectedMoveInfo[4]), Int32.Parse(selectedMoveInfo[5]));
                updateWhitePromotion(selectedMoveInfo[3]);
            }
            else if (selectedMoveInfo.Last() == "castling")
            {
                if (selectedMoveInfo[5] == "6") positions.whitePieces["wr2"] = new Cell(7, 5);
                else positions.whitePieces["wr1"] = new Cell(7, 3);
                positions.white_short_castling = false;
                positions.white_long_castling = false;
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
            positions.setInitialBoard();
            next_black_move();
        }

        public void next_black_move()
        {
            List<string> movements = positions.available_black_moves().ToList<string>();
            if (is_game_finished(movements.Count()) == true) start_game();
            add_recent_board(movements.Count());
            print_last_board_info();
            Random rnd = new Random();
            int randomMovement = rnd.Next(movements.Count());
            string[] selectedMoveInfo = movements[randomMovement].Split(",");
            if (selectedMoveInfo.Last() != "") // change of position with no capture
            {
                positions.whitePieces.Remove(selectedMoveInfo.Last());
            }
            if (selectedMoveInfo[0] != selectedMoveInfo[3]) //promotion
            {
                positions.blackPieces.Remove(selectedMoveInfo.First());
                positions.blackPieces[selectedMoveInfo[3]] = new Cell(Int32.Parse(selectedMoveInfo[4]), Int32.Parse(selectedMoveInfo[5]));
                updateBlackPromotion(selectedMoveInfo[3]);
            }
            else if (selectedMoveInfo.Last() == "castling") //castling
            {
                if (selectedMoveInfo[5] == "6") positions.whitePieces["br2"] = new Cell(0, 5);
                else positions.whitePieces["br1"] = new Cell(0, 3);
                positions.black_short_castling = false;
                positions.black_long_castling = false;
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
            positions.setInitialBoard();
            next_white_move();
        }

        public void updateWhitePromotion(string whitePromoted)
        {
            if (Regex.Match(whitePromoted, @"^wq").Success) positions.next_white_queen+=1;
            else if (Regex.Match(whitePromoted, @"^wr").Success) positions.next_white_rock += 1;
            else if (Regex.Match(whitePromoted, @"^wb").Success) positions.next_white_bishop += 1;
            else positions.next_white_knight += 1;
        }

        public void updateBlackPromotion(string blackPromoted)
        {
            if (Regex.Match(blackPromoted, @"^bq").Success) positions.next_black_queen += 1;
            else if (Regex.Match(blackPromoted, @"^br").Success) positions.next_black_rock += 1;
            else if (Regex.Match(blackPromoted, @"^bb").Success) positions.next_black_bishop += 1;
            else positions.next_black_knight += 1;
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

        public bool is_game_finished(int total_movements)
        {
            if (total_movements == 0 || positions.blackPieces.Keys.Count + positions.whitePieces.Keys.Count == 2)
            {
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
