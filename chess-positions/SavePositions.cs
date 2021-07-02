using chess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace chess
{
    public static class SavePositions
    {
        public static void savePosition(BoardData nboard)
        {
            try
            {
                using (var context = new chessmemoContext())
                {
                    Position nPosition = new Position{Board=nboard.pieces_position,
                        TotalBlackPieces=nboard.total_black_pieces,
                        TotalWhitePieces = nboard.total_white_pieces,
                        BlackLongCastling =nboard.black_long_castling,
                        BlackShortCastling=nboard.black_short_castling,
                        WhiteLongCastling=nboard.white_long_castling,
                        WhiteShortCastling=nboard.white_short_castling,
                        LastMove=nboard.last_movement,
                        AvailableMoves=nboard.movements_available };
                        context.Add(nPosition);
                        context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occurred in the database: ");
                Console.WriteLine(ex);
            }
        }
    }
}
