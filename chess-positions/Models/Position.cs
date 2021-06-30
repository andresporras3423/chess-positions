using System;
using System.Collections.Generic;

#nullable disable

namespace chess.Models
{
    public partial class Position
    {
        public int Id { get; set; }
        public string Board { get; set; }
        public int TotalPieces { get; set; }
        public bool BlackLongCastling { get; set; }
        public bool BlackShortCastling { get; set; }
        public bool WhiteLongCastling { get; set; }
        public bool WhiteShortCastling { get; set; }
        public string LastMove { get; set; }
        public int AvailableMoves { get; set; }

        //public Position(string nBoard, 
        //    int nTotalPieces, 
        //    bool nBlackLongCastling,
        //    bool nBlackShortCastling,
        //    bool nWhiteLongCastling,
        //    bool nWhiteShortCastling,
        //    string nLastMove,
        //    int nAvailableMoves)
        //{
        //    Board = nBoard;
        //    TotalPieces = nTotalPieces;
        //    BlackLongCastling = nBlackLongCastling;
        //    BlackShortCastling = nBlackShortCastling;
        //    WhiteLongCastling = nWhiteLongCastling;
        //    WhiteShortCastling = nWhiteShortCastling;
        //    LastMove = nLastMove;
        //    AvailableMoves = nAvailableMoves;
        //}
    }
}
