using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public class Positions {

        public Positions()
        {
            
        }

        public List<Cell> knightMovements = new List<Cell>{new Cell(1,2),
            new Cell(1, -2),
            new Cell(2, 1),
            new Cell(2, -1),
            new Cell(-1, 2),
            new Cell(-1, -2),
            new Cell(-2, 1),
            new Cell(-2, -1) };

        public List<Cell> kingMovements = new List<Cell>{new Cell(1,1),
            new Cell(1, 0),
            new Cell(1, -1),
            new Cell(0, 1),
            new Cell(0, -1),
            new Cell(-1, 1),
            new Cell(-1, 0),
            new Cell(-1, -1) };

        public List<Cell> bishopMovements = new List<Cell>{new Cell(1,1),
            new Cell(1, -1),
            new Cell(-1, 1),
            new Cell(-1, -1)};

        public List<Cell> rockMovements = new List<Cell>{new Cell(0,1),
            new Cell(0, -1),
            new Cell(1, 0),
            new Cell(-1, 0)};

        public string last_movement = ",,,,,";
        public bool black_king_move = false;
        public bool black_rock1_move = false;
        public bool black_rock2_move = false;
        public bool white_king_move = false;
        public bool white_rock1_move = false;
        public bool white_rock2_move = false;

        public int next_black_queen = 2;
        public int next_black_rock = 3;
        public int next_black_bishop = 3;
        public int next_black_knight = 3;
        public int next_white_queen = 2;
        public int next_white_rock = 3;
        public int next_white_bishop = 3;
        public int next_white_knight = 3;


        public string[,] cells = {
            {"","","","","","","",""},
            {"","","","","","","",""},
            {"","","","","","","",""},
            {"","","","","","","",""},
            {"","","","","","","",""},
            {"","","","","","","",""},
            {"","","","","","","",""},
            {"","","","","","","",""}
        };

        public string[,] tempCells;



        public Dictionary<string, Cell> blackPieces = new Dictionary<string, Cell>
        {
            {  "br1", new Cell(0,0) },
            {  "bn1", new Cell(0,1) },
            {  "bb1", new  Cell(0,2)},
            {  "bq1", new  Cell(0,3) },
            {  "bk", new Cell(0,4) },
            {  "bb2", new Cell(0,5) },
            {  "bn2", new Cell(0,6) },
            {  "br2", new Cell(0,7) },
            {  "bp1", new Cell(1,0) },
            {  "bp2", new Cell(1,1) },
            {  "bp3", new Cell(1,2) },
            {  "bp4", new Cell(1,3) },
            {  "bp5", new Cell(1,4) },
            {  "bp6", new Cell(1,5) },
            {  "bp7", new Cell(1,6) },
            {  "bp8", new Cell(1,7) },
        };

        public Dictionary<string, Cell> whitePieces = new Dictionary<string, Cell>
        {
            {  "wp1", new Cell(6,0) },
            {  "wp2", new Cell(6,1) },
            {  "wp3", new Cell(6,2) },
            {  "wp4", new Cell(6,3) },
            {  "wp5", new Cell(6,4) },
            {  "wp6", new Cell(6,5) },
            {  "wp7", new Cell(6,6) },
            {  "wp8", new Cell(6,7) },
            {  "wr1", new Cell(7,0) },
            {  "wn1", new Cell(7,1)  },
            {  "wb1", new Cell(7,2)  },
            {  "wq1", new Cell(7,3)  },
            {  "wk", new Cell(7,4)  },
            {  "wb2", new Cell(7,5)  },
            {  "wn2", new Cell(7,6)  },
            {  "wr2", new Cell(7,7)  },
        };



        public bool white_king_attacked(Cell king)
        {
            if (attacked_by_black_pawn(king.y, king.x)) return true;
            if (attacked_by_black_knight(king.y, king.x)) return true;
            if (attacked_by_black_king(king.y, king.x)) return true;
            if (attacked_by_black_in_diagonals(king.y, king.x)) return true;
            if (attacked_by_black_in_rowcolumns(king.y, king.x)) return true;
            return false;
        }

        public bool black_king_attacked(Cell king)
        {
            if (attacked_by_white_pawn(king.y, king.x)) return true;
            if (attacked_by_white_knight(king.y, king.x)) return true;
            if (attacked_by_white_king(king.y, king.x)) return true;
            if (attacked_by_white_in_diagonals(king.y, king.x)) return true;
            if (attacked_by_white_in_rowcolumns(king.y, king.x)) return true;
            return false;
        }

        public HashSet<string> available_black_moves()
        {
            HashSet<string> moves = new HashSet<string>();
            foreach (var item in available_black_king_moves())
            {
                moves.Add(item);
            }
            foreach (var piece in blackPieces)
            {
                if (Regex.Match(piece.Key, @"^(bn)").Success)
                {
                    foreach (var item in available_black_knight_moves(piece.Key, new Cell(piece.Value.y, piece.Value.x)))
                    {
                        moves.Add(item);
                    }
                }
                else if (Regex.Match(piece.Key, @"^(bb)").Success)
                {
                    foreach (var item in available_black_bishop_moves(piece.Key, new Cell(piece.Value.y, piece.Value.x)))
                    {
                        moves.Add(item);
                    }
                }
                else if (Regex.Match(piece.Key, @"^(br)").Success)
                {
                    foreach (var item in available_black_rock_moves(piece.Key, new Cell(piece.Value.y, piece.Value.x)))
                    {
                        moves.Add(item);
                    }
                }
                else if (Regex.Match(piece.Key, @"^(bq)").Success)
                {
                    foreach (var item in available_black_queen_moves(piece.Key, new Cell(piece.Value.y, piece.Value.x)))
                    {
                        moves.Add(item);
                    }
                }
                else if (Regex.Match(piece.Key, @"^(bp)").Success)
                {
                    foreach (var item in available_black_pawn_moves(piece.Key, new Cell(piece.Value.y, piece.Value.x)))
                    {
                        moves.Add(item);
                    }
                }
            }
            return moves;
        }

        public HashSet<string> available_black_king_moves()
        {
            Cell king = blackPieces["bk"];
            HashSet<string> availableMovements = new HashSet<string>();
            foreach (var kingMovement in kingMovements)
            {
                string nCell = valid_position(king.y + kingMovement.y, king.x + kingMovement.x);
                if (nCell == "" || Regex.Match(nCell, @"^w").Success)
                {
                    tempCells = (string[,])cells.Clone();
                    tempCells[king.y, king.x] = "";
                    tempCells[king.y + kingMovement.y, king.x + kingMovement.x] = "bk";
                    if (!black_king_attacked(new Cell(king.y + kingMovement.y, king.x + kingMovement.x)))
                    {
                        availableMovements.Add($"bk,{king.y},{king.x},bk,{king.y + kingMovement.y},{king.x + kingMovement.x}");
                    }
                }
            }
            tempCells = (string[,])cells.Clone();
            if (!black_king_move && !black_rock1_move && cells[0, 1] == "" && cells[0, 2] == "" && cells[0, 3] == "" && !black_king_attacked(new Cell(king.y, king.x)) && !black_king_attacked(new Cell(king.y, king.x - 1)) && !black_king_attacked(new Cell(king.y, king.x - 2)))
            {
                availableMovements.Add($"bk,{king.y},{king.x},bk,{king.y},{king.x - 2}");
            }
            if (!black_king_move && !black_rock2_move && cells[0, 5] == "" && cells[0, 6] == "" && !black_king_attacked(new Cell(king.y, king.x)) && !black_king_attacked(new Cell(king.y, king.x + 1)) && !black_king_attacked(new Cell(king.y, king.x + 2)))
            {
                availableMovements.Add($"bk,{king.y},{king.x},bk,{king.y},{king.x + 2}");
            }
            return availableMovements;
        }





        public HashSet<string> available_black_knight_moves(string piece, Cell knight)
        {
            Cell king = blackPieces["bk"];
            HashSet<string> availableMovements = new HashSet<string>();
            foreach (var knightMovement in knightMovements)
            {
                string nCell = valid_position(knight.y + knightMovement.y, knight.x + knightMovement.x);
                if (nCell == "" || Regex.Match(nCell, @"^w").Success)
                {
                    tempCells = (string[,])cells.Clone();
                    tempCells[knight.y, knight.x] = "";
                    tempCells[knight.y + knightMovement.y, knight.x + knightMovement.x] = "bn";
                    if (!black_king_attacked(new Cell(king.y, king.x)))
                    {
                        availableMovements.Add($"{piece},{knight.y},{knight.x},{piece},{knight.y + knightMovement.y},{knight.x + knightMovement.x}");
                    }
                }

            }
            return availableMovements;
        }

        public HashSet<string> available_black_pawn_moves(string piece, Cell pawn)
        {
            Cell king = blackPieces["bk"];
            HashSet<string> availableMovements = new HashSet<string>();
            string nCell = valid_position(pawn.y + 1, pawn.x);
            if (nCell == "")
            {
                tempCells = (string[,])cells.Clone();
                tempCells[pawn.y, pawn.x] = "";
                tempCells[pawn.y + 1, pawn.x] = "bp";
                if (!black_king_attacked(new Cell(king.y, king.x)))
                {
                    if (pawn.y + 1 < 7) availableMovements.Add($"{piece},{pawn.y},{pawn.x},{piece},{pawn.y + 1},{pawn.x}");
                    else available_promotion_moves(piece, pawn.y, pawn.x, pawn.y + 1, pawn.x, availableMovements);
                }
            }
            if (pawn.y == 1)
            {
                nCell = valid_position(pawn.y + 1, pawn.x);
                string nCell2 = valid_position(pawn.y + 2, pawn.x);
                if (nCell == "" && nCell2 == "")
                {
                    tempCells = (string[,])cells.Clone();
                    tempCells[pawn.y, pawn.x] = "";
                    tempCells[pawn.y + 2, pawn.x] = "bp";
                    if (!black_king_attacked(new Cell(king.y, king.x))) availableMovements.Add($"{piece},{pawn.y},{pawn.x},{piece},{pawn.y + 2},{pawn.x}");
                }
            }
            nCell = valid_position(pawn.y + 1, pawn.x + 1);
            if (Regex.Match(nCell, @"^w").Success)
            {
                tempCells = (string[,])cells.Clone();
                tempCells[pawn.y, pawn.x] = "";
                tempCells[pawn.y + 1, pawn.x + 1] = "bp";
                if (!black_king_attacked(new Cell(king.y, king.x)))
                {
                    if (pawn.y + 1 < 7) availableMovements.Add($"{piece},{pawn.y},{pawn.x},{piece},{pawn.y + 1},{pawn.x + 1}");
                    else available_promotion_moves(piece, pawn.y, pawn.x, pawn.y + 1, pawn.x + 1, availableMovements);
                }
            }
            nCell = valid_position(pawn.y + 1, pawn.x - 1);
            if (Regex.Match(nCell, @"^w").Success)
            {
                tempCells = (string[,])cells.Clone();
                tempCells[pawn.y, pawn.x] = "";
                tempCells[pawn.y + 1, pawn.x - 1] = "bp";
                if (!black_king_attacked(new Cell(king.y, king.x)))
                {
                    if (pawn.y + 1 < 7) availableMovements.Add($"{piece},{pawn.y},{pawn.x},{piece},{pawn.y + 1},{pawn.x - 1}");
                    else available_promotion_moves(piece, pawn.y, pawn.x, pawn.y + 1, pawn.x - 1, availableMovements);
                }
            }
            if (last_movement == $"wp,{pawn.y + 2},{pawn.x + 1},wp,{pawn.y},{pawn.x + 1}")
            {
                tempCells = (string[,])cells.Clone();
                tempCells[pawn.y, pawn.x] = "";
                tempCells[pawn.y, pawn.x + 1] = "";
                tempCells[pawn.y + 1, pawn.x + 1] = "bp";
                if (!black_king_attacked(new Cell(king.y, king.x))) availableMovements.Add($"{piece},{pawn.y},{pawn.x},{piece},{pawn.y + 1},{pawn.x + 1}");
            }
            if (last_movement == $"wp,{pawn.y + 2},{pawn.x - 1},wp,{pawn.y},{pawn.x - 1}")
            {
                tempCells = (string[,])cells.Clone();
                tempCells[pawn.y, pawn.x] = "";
                tempCells[pawn.y, pawn.x - 1] = "";
                tempCells[pawn.y + 1, pawn.x - 1] = "bp";
                if (!black_king_attacked(new Cell(king.y, king.x))) availableMovements.Add($"{piece},{pawn.y},{pawn.x},{piece},{pawn.y + 1},{pawn.x - 1}");
            }
            return availableMovements;
        }



        public HashSet<string> available_black_bishop_moves(string piece, Cell bishop)
        {
            Cell king = blackPieces["bk"];
            HashSet<string> availableMovements = new HashSet<string>();
            foreach (var bishopMovement in bishopMovements)
            {
                Cell nPosition = new Cell(bishop.y, bishop.x);
                while (true)
                {
                    nPosition.x += bishopMovement.x;
                    nPosition.y += bishopMovement.y;
                    string nCell = valid_position(nPosition.y, nPosition.x);
                    if (nCell == "" || Regex.Match(nCell, @"^w").Success)
                    {
                        tempCells = (string[,])cells.Clone();
                        tempCells[bishop.y, bishop.x] = "";
                        tempCells[nPosition.y, nPosition.x] = "bb";
                        if (!black_king_attacked(new Cell(king.y, king.x)))
                        {
                            availableMovements.Add($"{piece},{bishop.y},{bishop.x},{piece},{nPosition.y},{nPosition.x}");
                        }
                    }
                    if (nCell != "") break;
                }
            }
            return availableMovements;
        }

        public HashSet<string> available_black_rock_moves(string piece, Cell rock)
        {
            Cell king = blackPieces["bk"];
            HashSet<string> availableMovements = new HashSet<string>();
            foreach (var rockMovement in rockMovements)
            {
                Cell nPosition = new Cell(rock.y, rock.x);
                while (true)
                {
                    nPosition.x += rockMovement.x;
                    nPosition.y += rockMovement.y;
                    string nCell = valid_position(nPosition.y, nPosition.x);
                    if (nCell == "" || Regex.Match(nCell, @"^w").Success)
                    {
                        tempCells = (string[,])cells.Clone();
                        tempCells[rock.y, rock.x] = "";
                        tempCells[nPosition.y, nPosition.x] = "br";
                        if (!black_king_attacked(new Cell(king.y, king.x)))
                        {
                            availableMovements.Add($"{piece},{rock.y},{rock.x},{piece},{nPosition.y},{nPosition.x}");
                        }
                    }
                    if (nCell != "") break;
                }
            }
            return availableMovements;
        }

        public HashSet<string> available_black_queen_moves(string piece, Cell queen)
        {
            Cell king = blackPieces["bk"];
            HashSet<string> availableMovements = new HashSet<string>();
            foreach (var rockMovement in rockMovements)
            {
                Cell nPosition = new Cell(queen.y, queen.x);
                while (true)
                {
                    nPosition.x += rockMovement.x;
                    nPosition.y += rockMovement.y;
                    string nCell = valid_position(nPosition.y, nPosition.x);
                    if (nCell == "" || Regex.Match(nCell, @"^w").Success)
                    {
                        tempCells = (string[,])cells.Clone();
                        tempCells[queen.y, queen.x] = "";
                        tempCells[nPosition.y, nPosition.x] = "bq";
                        if (!black_king_attacked(new Cell(king.y, king.x)))
                        {
                            availableMovements.Add($"{piece},{queen.y},{queen.x},{piece},{nPosition.y},{nPosition.x}");
                        }
                    }
                    if (nCell != "") break;
                }
            }
            foreach (var bishopMovement in bishopMovements)
            {
                Cell nPosition = new Cell(queen.y, queen.x);
                while (true)
                {
                    nPosition.x += bishopMovement.x;
                    nPosition.y += bishopMovement.y;
                    string nCell = valid_position(nPosition.y, nPosition.x);
                    if (nCell == "" || Regex.Match(nCell, @"^w").Success)
                    {
                        tempCells = (string[,])cells.Clone();
                        tempCells[queen.y, queen.x] = "";
                        tempCells[nPosition.y, nPosition.x] = "bq";
                        if (!black_king_attacked(new Cell(king.y, king.x)))
                        {
                            availableMovements.Add($"{piece},{queen.y},{queen.x},{piece},{nPosition.y},{nPosition.x}");
                        }
                    }
                    if (nCell != "") break;
                }
            }
            return availableMovements;
        }

        public HashSet<string> available_white_moves()
        {
            HashSet<string> moves = new HashSet<string>();
            foreach (var item in available_white_king_moves())
            {
                moves.Add(item);
            }
            foreach (var piece in whitePieces)
            {
                if (Regex.Match(piece.Key, @"^(wn)").Success)
                {
                    foreach (var item in available_white_knight_moves(piece.Key, new Cell(piece.Value.y, piece.Value.x)))
                    {
                        moves.Add(item);
                    }
                }
                else if (Regex.Match(piece.Key, @"^(wb)").Success)
                {
                    foreach (var item in available_white_bishop_moves(piece.Key, new Cell(piece.Value.y, piece.Value.x)))
                    {
                        moves.Add(item);
                    }
                }
                else if (Regex.Match(piece.Key, @"^(wr)").Success)
                {
                    foreach (var item in available_white_rock_moves(piece.Key, new Cell(piece.Value.y, piece.Value.x)))
                    {
                        moves.Add(item);
                    }
                }
                else if (Regex.Match(piece.Key, @"^(wq)").Success)
                {
                    foreach (var item in available_white_queen_moves(piece.Key, new Cell(piece.Value.y, piece.Value.x)))
                    {
                        moves.Add(item);
                    }
                }
                else if (Regex.Match(piece.Key, @"^(wp)").Success)
                {
                    foreach (var item in available_white_pawn_moves(piece.Key, new Cell(piece.Value.y, piece.Value.x)))
                    {
                        moves.Add(item);
                    }
                }
            }
            return moves;
        }

        public HashSet<string> available_white_king_moves()
        {
            Cell king = whitePieces["wk"];
            HashSet<string> availableMovements = new HashSet<string>();
            foreach (var kingMovement in kingMovements)
            {
                string nCell = valid_position(king.y + kingMovement.y, king.x + kingMovement.x);
                if (nCell == "" || Regex.Match(nCell, @"^b").Success)
                {
                    tempCells = (string[,])cells.Clone();
                    tempCells[king.y, king.x] = "";
                    tempCells[king.y + kingMovement.y, king.x + kingMovement.x] = "wk";
                    if (!white_king_attacked(new Cell(king.y + kingMovement.y, king.x + kingMovement.x)))
                    {
                        availableMovements.Add($"wk,{king.y},{king.x},wk,{king.y + kingMovement.y},{king.x + kingMovement.x}");
                    }
                }
            }
            tempCells = (string[,])cells.Clone();
            if (!white_king_move && !white_rock1_move && cells[7, 1] == "" && cells[7, 2] == "" && cells[7, 3] == "" && !white_king_attacked(new Cell(king.y, king.x)) && !white_king_attacked(new Cell(king.y, king.x - 1)) && !white_king_attacked(new Cell(king.y, king.x - 2)))
            {
                availableMovements.Add($"wk,{king.y},{king.x},wk,{king.y},{king.x - 2}");
            }
            if (!white_king_move && !white_rock2_move && cells[7, 5] == "" && cells[7, 6] == "" && !white_king_attacked(new Cell(king.y, king.x)) && !white_king_attacked(new Cell(king.y, king.x + 1)) && !white_king_attacked(new Cell(king.y, king.x + 2)))
            {
                availableMovements.Add($"wk,{king.y},{king.x},wk,{king.y},{king.x + 2}");
            }
            return availableMovements;
        }


        public HashSet<string> available_white_knight_moves(string piece, Cell knight)
        {
            Cell king = whitePieces["wk"];
            HashSet<string> availableMovements = new HashSet<string>();
            foreach (var knightMovement in knightMovements)
            {
                string nCell = valid_position(knight.y + knightMovement.y, knight.x + knightMovement.x);
                if (nCell == "" || Regex.Match(nCell, @"^b").Success)
                {
                    tempCells = (string[,])cells.Clone();
                    tempCells[knight.y, knight.x] = "";
                    tempCells[knight.y + knightMovement.y, knight.x + knightMovement.x] = "wn";

                    if (!white_king_attacked(new Cell(king.y, king.x)))
                    {
                        availableMovements.Add($"{piece},{knight.y},{knight.x},{piece},{knight.y + knightMovement.y},{knight.x + knightMovement.x}");
                    }
                }

            }
            return availableMovements;
        }

        public HashSet<string> available_white_pawn_moves(string piece, Cell pawn)
        {
            Cell king = whitePieces["wk"];
            HashSet<string> availableMovements = new HashSet<string>();
            string nCell = valid_position(pawn.y - 1, pawn.x);
            if (nCell == "")
            {
                tempCells = (string[,])cells.Clone();
                tempCells[pawn.y, pawn.x] = "";
                tempCells[pawn.y - 1, pawn.x] = "wp";
                if (!white_king_attacked(new Cell(king.y, king.x)))
                {
                    if (pawn.y - 1 > 0) availableMovements.Add($"{piece},{pawn.y},{pawn.x},{piece},{pawn.y - 1},{pawn.x}");
                    else available_promotion_moves(piece, pawn.y, pawn.x, pawn.y - 1, pawn.x, availableMovements);
                }
            }
            if (pawn.y == 6)
            {
                nCell = valid_position(pawn.y - 1, pawn.x);
                string nCell2 = valid_position(pawn.y  - 2, pawn.x);
                if (nCell == "" && nCell2 == "")
                {
                    tempCells = (string[,])cells.Clone();
                    tempCells[pawn.y, pawn.x] = "";
                    tempCells[pawn.y - 2, pawn.x] = "wp";
                    if (!white_king_attacked(new Cell(king.y, king.x))) availableMovements.Add($"{piece},{pawn.y},{pawn.x},{piece},{pawn.y - 2},{pawn.x}");
                }
            }
            nCell = valid_position(pawn.y - 1, pawn.x + 1);
            if (Regex.Match(nCell, @"^b").Success)
            {
                tempCells = (string[,])cells.Clone();
                tempCells[pawn.y, pawn.x] = "";
                tempCells[pawn.y - 1, pawn.x + 1] = "wp";
                if (!white_king_attacked(new Cell(king.y, king.x)))
                {
                    if (pawn.y - 1 > 0) availableMovements.Add($"{piece},{pawn.y},{pawn.x},{piece},{pawn.y - 1},{pawn.x + 1}");
                    else available_promotion_moves(piece, pawn.y, pawn.x, pawn.y - 1, pawn.x + 1, availableMovements);
                }
            }
            nCell = valid_position(pawn.y - 1, pawn.x - 1);
            if (Regex.Match(nCell, @"^b").Success)
            {
                tempCells = (string[,])cells.Clone();
                tempCells[pawn.y, pawn.x] = "";
                tempCells[pawn.y - 1, pawn.x - 1] = "wp";
                if (!white_king_attacked(new Cell(king.y, king.x)))
                {
                    if (pawn.y - 1 > 0) availableMovements.Add($"{piece},{pawn.y},{pawn.x},{piece},{pawn.y - 1},{pawn.x - 1}");
                    else available_promotion_moves(piece, pawn.y, pawn.x, pawn.y - 1, pawn.x - 1, availableMovements);
                }
            }
            if (last_movement == $"bp,{pawn.y - 2},{pawn.x + 1},bp,{pawn.y},{pawn.x + 1}")
            {
                tempCells = (string[,])cells.Clone();
                tempCells[pawn.y, pawn.x] = "";
                tempCells[pawn.y, pawn.x + 1] = "";
                tempCells[pawn.y - 1, pawn.x + 1] = "wp";
                if (!white_king_attacked(new Cell(king.y, king.x))) availableMovements.Add($"{piece},{pawn.y},{pawn.x},{piece},{pawn.y - 1},{pawn.x + 1}");
            }
            if (last_movement == $"bp,{pawn.y - 2},{pawn.x - 1},bp,{pawn.y},{pawn.x - 1}")
            {
                tempCells = (string[,])cells.Clone();
                tempCells[pawn.y, pawn.x] = "";
                tempCells[pawn.y, pawn.x - 1] = "";
                tempCells[pawn.y - 1, pawn.x - 1] = "wp";
                if (!white_king_attacked(new Cell(king.y, king.x))) availableMovements.Add($"{piece},{pawn.y},{pawn.x},{piece},{pawn.y - 1},{pawn.x - 1}");
            }
            return availableMovements;
        }

        public void available_promotion_moves(string piece, int y0, int x0, int y, int x, HashSet<string> availableMovements)
        {
            if (y == 0)
            {
                availableMovements.Add($"{piece},{y0},{x0},wq{next_white_queen},{y},{x}");
                availableMovements.Add($"{piece},{y0},{x0},wr{next_white_rock},{y},{x}");
                availableMovements.Add($"{piece},{y0},{x0},wb{next_white_bishop},{y},{x}");
                availableMovements.Add($"{piece},{y0},{x0},wn{next_white_knight},{y},{x}");
            }
            else if (y == 7)
            {
                availableMovements.Add($"{piece},{y0},{x0},bq{next_black_queen},{y},{x}");
                availableMovements.Add($"{piece},{y0},{x0},br{next_black_rock},{y},{x}");
                availableMovements.Add($"{piece},{y0},{x0},bb{next_black_bishop},{y},{x}");
                availableMovements.Add($"{piece},{y0},{x0},bn{next_black_knight},{y},{x}");
            }
        }

        public HashSet<string> available_white_bishop_moves(string piece, Cell bishop)
        {
            Cell king = whitePieces["wk"];
            HashSet<string> availableMovements = new HashSet<string>();
            foreach (var bishopMovement in bishopMovements)
            {
                Cell nPosition = new Cell(bishop.y, bishop.x);
                while (true)
                {
                    nPosition.x += bishopMovement.x;
                    nPosition.y += bishopMovement.y;
                    string nCell = valid_position(nPosition.y, nPosition.x);
                    if (nCell == "" || Regex.Match(nCell, @"^b").Success)
                    {
                        tempCells = (string[,])cells.Clone();
                        tempCells[bishop.y, bishop.x] = "";
                        tempCells[nPosition.y, nPosition.x] = "wb";
                        if (!white_king_attacked(new Cell(king.y, king.x)))
                        {
                            availableMovements.Add($"{piece},{bishop.y},{bishop.x},{piece},{nPosition.y},{nPosition.x}");
                        }
                    }
                    if (nCell != "") break;
                }
            }
            return availableMovements;
        }

        public HashSet<string> available_white_rock_moves(string piece, Cell rock)
        {
            Cell king = whitePieces["wk"];
            HashSet<string> availableMovements = new HashSet<string>();
            foreach (var rockMovement in rockMovements)
            {
                Cell nPosition = new Cell(rock.y, rock.x);
                while (true)
                {
                    nPosition.x += rockMovement.x;
                    nPosition.y += rockMovement.y;
                    string nCell = valid_position(nPosition.y, nPosition.x);
                    if (nCell == "" || Regex.Match(nCell, @"^b").Success)
                    {
                        tempCells = (string[,])cells.Clone();
                        tempCells[rock.y, rock.x] = "";
                        tempCells[nPosition.y, nPosition.x] = "wr";
                        if (!white_king_attacked(new Cell(king.y, king.x)))
                        {
                            availableMovements.Add($"{piece},{rock.y},{rock.x},{piece},{nPosition.y},{nPosition.x}");
                        }
                    }
                    if (nCell != "") break;
                }
            }
            return availableMovements;
        }

        public HashSet<string> available_white_queen_moves(string piece, Cell queen)
        {
            Cell king = whitePieces["wk"];
            HashSet<string> availableMovements = new HashSet<string>();
            foreach (var rockMovement in rockMovements)
            {
                Cell nPosition = new Cell(queen.y, queen.x);
                while (true)
                {
                    nPosition.x += rockMovement.x;
                    nPosition.y += rockMovement.y;
                    string nCell = valid_position(nPosition.y, nPosition.x);
                    if (nCell == "" || Regex.Match(nCell, @"^b").Success)
                    {
                        tempCells = (string[,])cells.Clone();
                        tempCells[queen.y, queen.x] = "";
                        tempCells[nPosition.y, nPosition.x] = "wq";
                        if (!black_king_attacked(new Cell(king.y, king.x)))
                        {
                            availableMovements.Add($"{piece},{queen.y},{queen.x},{piece},{nPosition.y},{nPosition.x}");
                        }
                    }
                    if (nCell != "") break;
                }
            }
            foreach (var bishopMovement in bishopMovements)
            {
                Cell nPosition = new Cell(queen.y, queen.x);
                while (true)
                {
                    nPosition.x += bishopMovement.x;
                    nPosition.y += bishopMovement.y;
                    string nCell = valid_position(nPosition.y, nPosition.x);
                    if (nCell == "" || Regex.Match(nCell, @"^b").Success)
                    {
                        tempCells = (string[,])cells.Clone();
                        tempCells[queen.y, queen.x] = "";
                        tempCells[nPosition.y, nPosition.x] = "wq";
                        if (!white_king_attacked(new Cell(king.y, king.x)))
                        {
                            availableMovements.Add($"{piece},{queen.y},{queen.x},{piece},{nPosition.y},{nPosition.x}");
                        }
                    }
                    if (nCell != "") break;
                }
            }
            return availableMovements;
        }

        public bool attacked_by_black_pawn(int y, int x)
        {
            if (valid_temp_position(y - 1, x + 1) == "bp" || valid_temp_position(y - 1, x - 1) == "bp") return true;
            return false;
        }

        public bool attacked_by_black_knight(int y, int x)
        {
            if (valid_temp_position(y - 2, x + 1) == "bn" || valid_temp_position(y - 2, x - 1) == "bn" || valid_temp_position(y + 2, x - 1) == "bn" || valid_temp_position(y + 2, x - 1) == "bn" || valid_temp_position(y - 1, x + 2) == "bn" || valid_temp_position(y - 1, x - 2) == "bn" || valid_temp_position(y + 1, x + 2) == "bn" || valid_temp_position(y + 1, x - 2) == "bn") return true;
            return false;
        }

        public bool attacked_by_black_king(int y, int x)
        {
            if (valid_temp_position(y - 1, x - 1) == "bk" || valid_temp_position(y - 1, x) == "bk" || valid_temp_position(y - 1, x + 1) == "bk" || valid_temp_position(y, x - 1) == "bk" || valid_temp_position(y, x + 1) == "bk" || valid_temp_position(y + 1, x - 1) == "bk" || valid_temp_position(y + 1, x) == "bk" || valid_temp_position(y + 1, x + 1) == "bk") return true;
            return false;
        }

        public bool attacked_by_black_in_diagonals(int y, int x)
        {
            List<Dictionary<string, int>> diagonals = new List<Dictionary<string, int>>();
            diagonals.Add(new Dictionary<string, int> { { "x", 1 }, { "y", 1 } });
            diagonals.Add(new Dictionary<string, int> { { "x", 1 }, { "y", -1 } });
            diagonals.Add(new Dictionary<string, int> { { "x", -1 }, { "y", 1 } });
            diagonals.Add(new Dictionary<string, int> { { "x", -1 }, { "y", -1 } });
            foreach (Dictionary<string, int> diagonal in diagonals)
            {
                int new_y = y;
                int new_x = x;
                while (true)
                {
                    new_y += diagonal["y"];
                    new_x += diagonal["x"];
                    if (valid_temp_position(new_y, new_x) == "bq" || valid_temp_position(new_y, new_x) == "bb") return true;
                    else if (valid_temp_position(new_y, new_x) == "v" || valid_temp_position(new_y, new_x) != "") break;
                }
            }
            return false;
        }

        public bool attacked_by_black_in_rowcolumns(int y, int x)
        {
            List<Dictionary<string, int>> rowcolumns = new List<Dictionary<string, int>>();
            rowcolumns.Add(new Dictionary<string, int> { { "x", 0 }, { "y", 1 } });
            rowcolumns.Add(new Dictionary<string, int> { { "x", 0 }, { "y", -1 } });
            rowcolumns.Add(new Dictionary<string, int> { { "x", -1 }, { "y", 0 } });
            rowcolumns.Add(new Dictionary<string, int> { { "x", 1 }, { "y", 0 } });
            foreach (Dictionary<string, int> rowcolumn in rowcolumns)
            {
                int new_y = y;
                int new_x = x;
                while (true)
                {
                    new_y += rowcolumn["y"];
                    new_x += rowcolumn["x"];
                    if (valid_temp_position(new_y, new_x) == "bq" || valid_temp_position(new_y, new_x) == "br") return true;
                    else if (valid_temp_position(new_y, new_x) == "v" || valid_temp_position(new_y, new_x) != "") break;
                }
            }
            return false;
        }

        public bool attacked_by_white_pawn(int y, int x)
        {
            if (valid_temp_position(y + 1, x + 1) == "wp" || valid_temp_position(y + 1, x - 1) == "wp") return true;
            return false;
        }

        public bool attacked_by_white_knight(int y, int x)
        {
            if (valid_temp_position(y - 2, x + 1) == "wn" || valid_temp_position(y - 2, x - 1) == "wn" || valid_temp_position(y + 2, x - 1) == "wn" || valid_temp_position(y + 2, x - 1) == "wn" || valid_temp_position(y - 1, x + 2) == "wn" || valid_temp_position(y - 1, x - 2) == "wn" || valid_temp_position(y + 1, x + 2) == "wn" || valid_temp_position(y + 1, x - 2) == "wn") return true;
            return false;
        }

        public bool attacked_by_white_king(int y, int x)
        {
            if (valid_temp_position(y - 1, x - 1) == "wk" || valid_temp_position(y - 1, x) == "wk" || valid_temp_position(y - 1, x + 1) == "wk" || valid_temp_position(y, x - 1) == "wk" || valid_temp_position(y, x + 1) == "wk" || valid_temp_position(y + 1, x - 1) == "wk" || valid_temp_position(y + 1, x) == "wk" || valid_temp_position(y + 1, x + 1) == "wk") return true;
            return false;
        }

        public bool attacked_by_white_in_diagonals(int y, int x)
        {
            List<Dictionary<string, int>> diagonals = new List<Dictionary<string, int>>();
            diagonals.Add(new Dictionary<string, int> { { "x", 1 }, { "y", 1 } });
            diagonals.Add(new Dictionary<string, int> { { "x", 1 }, { "y", -1 } });
            diagonals.Add(new Dictionary<string, int> { { "x", -1 }, { "y", 1 } });
            diagonals.Add(new Dictionary<string, int> { { "x", -1 }, { "y", -1 } });
            foreach (Dictionary<string, int> diagonal in diagonals)
            {
                int new_y = y;
                int new_x = x;
                while (true)
                {
                    new_y += diagonal["y"];
                    new_x += diagonal["x"];
                    if (valid_temp_position(new_y, new_x) == "wq" || valid_temp_position(new_y, new_x) == "wb") return true;
                    else if (valid_temp_position(new_y, new_x) == "v" || valid_temp_position(new_y, new_x) != "") break;
                }
            }
            return false;
        }

        public bool attacked_by_white_in_rowcolumns(int y, int x)
        {
            List<Dictionary<string, int>> rowcolumns = new List<Dictionary<string, int>>();
            rowcolumns.Add(new Dictionary<string, int> { { "x", 0 }, { "y", 1 } });
            rowcolumns.Add(new Dictionary<string, int> { { "x", 0 }, { "y", -1 } });
            rowcolumns.Add(new Dictionary<string, int> { { "x", -1 }, { "y", 0 } });
            rowcolumns.Add(new Dictionary<string, int> { { "x", 1 }, { "y", 0 } });
            foreach (Dictionary<string, int> rowcolumn in rowcolumns)
            {
                int new_y = y;
                int new_x = x;
                while (true)
                {
                    new_y += rowcolumn["y"];
                    new_x += rowcolumn["x"];
                    if (valid_temp_position(new_y, new_x) == "wq" || valid_temp_position(new_y, new_x) == "wr") return true;
                    else if (valid_temp_position(new_y, new_x) == "v" || valid_temp_position(new_y, new_x) != "") break;
                }
            }
            return false;
        }

        public string valid_temp_position(int y, int x)
        {
            try
            {
                return tempCells[y, x];
            }
            catch
            {
                return "v";
            }
        }

        public string valid_position(int y, int x)
        {
            try
            {
                return cells[y, x];
            }
            catch
            {
                return "v";
            }
        }

        public void setInitialBoard()
        {
            foreach (var blackPiece in blackPieces)
            {
                cells[blackPiece.Value.y, blackPiece.Value.x] = String.Join("", blackPiece.Key.ToCharArray().Where((bp, i) => i < 2));
            }
            foreach (var whitePiece in whitePieces)
            {
                cells[whitePiece.Value.y, whitePiece.Value.x] = String.Join("", whitePiece.Key.ToCharArray().Where((wp, i) => i < 2));
            }
        }
    }
}
