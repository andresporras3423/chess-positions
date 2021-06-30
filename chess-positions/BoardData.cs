using System;
using System.Collections.Generic;
using System.Text;

namespace chess
{
    // INFO FOR THE DATABASE. A position has:
    // 1) the pieces and their positions
    // 2) total number of pieces
    // 3) 4 variables for available castlings
    // 4) last movement
    // 5) how many movements available it has
    public class BoardData
    {
        public string pieces_position;
        public int total_pieces;
        public bool black_long_castling;
        public bool black_short_castling;
        public bool white_long_castling;
        public bool white_short_castling;
        public string last_movement;
        public int movements_available;

        public BoardData(string npieces_position,
        int ntotal_pieces,
        bool nblack_long_castling,
        bool nblack_short_castling,
        bool nwhite_long_castling,
        bool nwhite_short_castling,
        string nlast_movement,
        int nmovements_available)
        {
            pieces_position= npieces_position;
            total_pieces=ntotal_pieces;
            black_long_castling= nblack_long_castling;
            black_short_castling= nblack_short_castling;
            white_long_castling= nwhite_long_castling;
            white_short_castling= nwhite_short_castling;
            last_movement= nlast_movement;
            movements_available= nmovements_available;
        }
        public string print_info()
        {
            string print = "";
            print += $"" +
                $"current board: {pieces_position}\n" +
                $"pieces: {total_pieces}\n" +
                $"black long castling: {black_long_castling}\n" +
                $"black short castling: {black_short_castling}\n" +
                $"white long castling: {white_long_castling}\n" +
                $"white short castling: {white_short_castling}\n" +
                $"most recent movement: {last_movement}\n" +
                $"total movements available: {movements_available}\n";
            return print;
        }
    }
}
