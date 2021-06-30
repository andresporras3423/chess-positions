using ConsoleApp1;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestPositions
{
    public class Tests
    {
        private Positions positions;
        [SetUp]
        public void Setup()
        {
            positions = new Positions();
        }

        [Test]
        public void original_white_position_has_20_movements()
        {
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> white_movements = positions.available_white_moves().ToList<string>();
            Assert.AreEqual(20, white_movements.Count());
        }

        [Test]
        public void black_movements_after_e4()
        {
            positions.whitePieces["wp5"] = new Cell(4, 4);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> black_movements = positions.available_black_moves().ToList<string>();
            Assert.AreEqual(20, black_movements.Count());
        }

        [Test]
        public void white_movements_after_e4_e5()
        {
            positions.whitePieces["wp5"] = new Cell(4, 4);
            positions.whitePieces["bp5"] = new Cell(3, 4);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> white_movements = positions.available_white_moves().ToList<string>();
            Assert.AreEqual(29, white_movements.Count());
        }

        [Test]
        public void black_movements_after_e4_e5_nf3()
        {
            positions.whitePieces["wp5"] = new Cell(4, 4);
            positions.blackPieces["bp5"] = new Cell(3, 4);
            positions.whitePieces["wn2"] = new Cell(5, 5);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> black_movements = positions.available_black_moves().ToList<string>();
            Assert.AreEqual(29, black_movements.Count());
        }

        [Test]
        public void white_movements_after_e4_e5_nf3_nc6()
        {
            positions.whitePieces["wp5"] = new Cell(4, 4);
            positions.blackPieces["bp5"] = new Cell(3, 4);
            positions.whitePieces["wn2"] = new Cell(5, 5);
            positions.blackPieces["bn1"] = new Cell(2, 2);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> white_movements = positions.available_white_moves().ToList<string>();
            Assert.AreEqual(27, white_movements.Count());
        }

        [Test]
        public void black_movements_after_e4_e5_nf3_nc6_bb5()
        {
            positions.whitePieces["wp5"] = new Cell(4, 4);
            positions.blackPieces["bp5"] = new Cell(3, 4);
            positions.whitePieces["wn2"] = new Cell(5, 5);
            positions.blackPieces["bn1"] = new Cell(2, 2);
            positions.whitePieces["wb2"] = new Cell(3, 1);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> black_movements = positions.available_black_moves().ToList<string>();
            Assert.AreEqual(30, black_movements.Count());
        }

        [Test]
        public void white_movements_promotion_test1()
        {
            clear_board(positions);
            no_castling(positions);
            positions.whitePieces["wp2"] = new Cell(1, 1);
            positions.whitePieces["wp4"] = new Cell(1, 3);
            positions.whitePieces["wp6"] = new Cell(1, 5);
            positions.whitePieces["wk"] = new Cell(6, 6);
            positions.blackPieces["br1"] = new Cell(0, 0);
            positions.blackPieces["br2"] = new Cell(0, 2);
            positions.blackPieces["bn1"] = new Cell(0, 4);
            positions.blackPieces["bn2"] = new Cell(0, 6);
            positions.blackPieces["bk"] = new Cell(6, 1);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> white_movements = positions.available_white_moves().ToList<string>();
            Assert.AreEqual(44, white_movements.Count());
        }

        [Test]
        public void black_movements_promotion_test1()
        {
            positions.blackPieces["bp8"] = new Cell(6, 7);
            positions.whitePieces.Remove("wp8");
            positions.whitePieces.Remove("wr2");
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> black_movements = positions.available_black_moves().ToList<string>();
            Assert.AreEqual(31, black_movements.Count());
        }

        [Test]
        public void black_with_no_movements_available()
        {
            clear_board(positions);
            no_castling(positions);
            positions.whitePieces["wk"] = new Cell(2, 4);
            positions.whitePieces["wp4"] = new Cell(1, 4);
            positions.blackPieces["bk"] = new Cell(0, 4);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> black_movements = positions.available_black_moves().ToList<string>();
            Assert.AreEqual(0, black_movements.Count());
        }

        [Test]
        public void white_with_no_movements_available()
        {
            clear_board(positions);
            no_castling(positions);
            positions.whitePieces["wk"] = new Cell(7, 7);
            positions.whitePieces["wp1"] = new Cell(5, 0);
            positions.blackPieces["bb2"] = new Cell(7, 6);
            positions.blackPieces["bp8"] = new Cell(6, 7);
            positions.blackPieces["bp7"] = new Cell(5, 7);
            positions.blackPieces["bp1"] = new Cell(4, 0);
            positions.blackPieces["bk"] = new Cell(0, 7);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> white_movements = positions.available_white_moves().ToList<string>();
            Assert.AreEqual(0, white_movements.Count());
        }

        [Test]
        public void white_castling_test1()
        {
            clear_board(positions);
            positions.whitePieces["wk"] = new Cell(7, 4);
            positions.whitePieces["wr1"] = new Cell(7, 0);
            positions.whitePieces["wr2"] = new Cell(7, 7);
            positions.blackPieces["bk"] = new Cell(0, 1);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> white_movements = positions.available_white_moves().ToList<string>();
            Assert.AreEqual(26, white_movements.Count());
        }

        [Test]
        public void white_castling_test2()
        {
            positions.whitePieces.Remove("wn2");
            positions.whitePieces.Remove("wb2");
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> white_movements = positions.available_white_moves().ToList<string>();
            Assert.AreEqual(22, white_movements.Count());
        }

        [Test]
        public void white_castling_test3()
        {
            positions.whitePieces.Remove("wn1");
            positions.whitePieces.Remove("wb1");
            positions.whitePieces.Remove("wq1");
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> white_movements = positions.available_white_moves().ToList<string>();
            Assert.AreEqual(23, white_movements.Count());
        }

        [Test]
        public void white_cant_castling_test1()
        {
            no_white_castling(positions);
            positions.whitePieces.Remove("wn1");
            positions.whitePieces.Remove("wb1");
            positions.whitePieces.Remove("wq1");
            positions.whitePieces.Remove("wn2");
            positions.whitePieces.Remove("wb2");
            positions.blackPieces["bq1"] = new Cell(2, 4);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> white_movements = positions.available_white_moves().ToList<string>();
            Assert.AreEqual(23, white_movements.Count());
        }

        [Test]
        public void white_cant_castling_test2()
        {
            positions.whitePieces.Remove("wp5");
            positions.whitePieces.Remove("wb2");
            positions.whitePieces.Remove("wn2");
            positions.blackPieces["bq1"] = new Cell(2, 4);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> white_movements = positions.available_white_moves().ToList<string>();
            Assert.AreEqual(2, white_movements.Count());
        }

        [Test]
        public void white_cant_castling_test3()
        {
            positions.whitePieces.Remove("wp6");
            positions.whitePieces.Remove("wb1");
            positions.whitePieces.Remove("wn1");
            positions.whitePieces.Remove("wq1");
            positions.blackPieces["bp6"] = new Cell(6, 5);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> white_movements = positions.available_white_moves().ToList<string>();
            Assert.AreEqual(2, white_movements.Count());
        }

        [Test]
        public void black_castling_test1()
        {
            positions.blackPieces.Clear();
            positions.blackPieces["bk"] = new Cell(0, 4);
            positions.blackPieces["br1"] = new Cell(0, 0);
            positions.blackPieces["br2"] = new Cell(0, 7);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> black_movements = positions.available_black_moves().ToList<string>();
            Assert.AreEqual(24, black_movements.Count());
        }

        [Test]
        public void black_castling_test2()
        {
            positions.blackPieces.Clear();
            positions.blackPieces["bk"] = new Cell(0, 4);
            positions.blackPieces["br1"] = new Cell(0, 0);
            positions.blackPieces["br2"] = new Cell(0, 7);
            positions.whitePieces["wq1"] = new Cell(1, 1);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> black_movements = positions.available_black_moves().ToList<string>();
            Assert.AreEqual(20, black_movements.Count());
        }

        [Test]
        public void black_castling_test3()
        {
            positions.blackPieces.Remove("bn1");
            positions.blackPieces.Remove("bb1");
            positions.blackPieces.Remove("bq1");
            positions.blackPieces.Remove("bn2");
            positions.blackPieces.Remove("bb2");
            positions.whitePieces["wb2"] = new Cell(0, 6);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> black_movements = positions.available_black_moves().ToList<string>();
            Assert.AreEqual(23, black_movements.Count());
        }

        [Test]
        public void black_cant_castling_test1()
        {
            no_black_castling(positions);
            positions.blackPieces.Remove("bn1");
            positions.blackPieces.Remove("bb1");
            positions.blackPieces.Remove("bq1");
            positions.blackPieces.Remove("bn2");
            positions.blackPieces.Remove("bb2");
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> black_movements = positions.available_black_moves().ToList<string>();
            Assert.AreEqual(23, black_movements.Count());
        }

        [Test]
        public void black_cant_castling_test2()
        {
            positions.black_long_castling = false;
            positions.blackPieces.Remove("bn1");
            positions.blackPieces.Remove("bb1");
            positions.blackPieces.Remove("bq1");
            positions.blackPieces.Remove("bn2");
            positions.blackPieces.Remove("bb2");
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> black_movements = positions.available_black_moves().ToList<string>();
            Assert.AreEqual(24, black_movements.Count());
        }

        [Test]
        public void black_cant_castling_test3()
        {
            positions.blackPieces.Remove("bn1");
            positions.blackPieces.Remove("bb1");
            positions.blackPieces.Remove("bq1");
            positions.blackPieces.Remove("bn2");
            positions.blackPieces.Remove("bb2");
            positions.blackPieces.Remove("bp5");
            positions.whitePieces["wb1"] = new Cell(4, 7);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> black_movements = positions.available_black_moves().ToList<string>();
            Assert.AreEqual(21, black_movements.Count());
        }


        [Test]
        public void black_en_passant_test1()
        {
            clear_board(positions);
            no_castling(positions);
            positions.last_movement = "wp4,6,4,wp4,4,4,";
            positions.whitePieces["wk"] = new Cell(7, 4);
            positions.whitePieces["wp4"] = new Cell(4, 4);
            positions.blackPieces["bp5"] = new Cell(4, 5);
            positions.blackPieces["bp3"] = new Cell(4, 3);
            positions.blackPieces["bk"] = new Cell(0, 4);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> black_movements = positions.available_black_moves().ToList<string>();
            Assert.AreEqual(9, black_movements.Count());
        }

        [Test]
        public void white_en_passant_test1()
        {
            positions.last_movement = "bp7,1,6,bp7,3,6,";
            positions.blackPieces["bp7"] = new Cell(3, 6);
            positions.whitePieces["wp8"] = new Cell(3, 7);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> white_movements = positions.available_white_moves().ToList<string>();
            Assert.AreEqual(23, white_movements.Count());
        }

        [Test]
        public void black_king_capture()
        {
            clear_board(positions);
            no_black_castling(positions);
            positions.blackPieces["bk"] = new Cell(3, 3);
            positions.whitePieces["wp1"] = new Cell(3, 4);
            positions.whitePieces["wk"] = new Cell(0, 0);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> movements = positions.available_black_moves().ToList<string>();
            Assert.Contains("bk,3,3,bk,3,4,wp1", movements);
        }

        [Test]
        public void white_king_capture()
        {
            clear_board(positions);
            no_white_castling(positions);
            positions.whitePieces["wk"] = new Cell(3, 3);
            positions.blackPieces["bp1"] = new Cell(3, 4);
            positions.blackPieces["bk"] = new Cell(0, 0);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> movements = positions.available_white_moves().ToList<string>();
            Assert.Contains("wk,3,3,wk,3,4,bp1", movements);
        }

        [Test]
        public void black_pawn_capture()
        {
            clear_board(positions);
            no_castling(positions);
            positions.blackPieces["bk"] = new Cell(7, 7);
            positions.blackPieces["bp2"] = new Cell(3, 4);
            positions.whitePieces["wp1"] = new Cell(4, 5);
            positions.whitePieces["wk"] = new Cell(0, 0);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> movements = positions.available_black_moves().ToList<string>();
            Assert.Contains("bp2,3,4,bp2,4,5,wp1", movements);
        }

        [Test]
        public void white_pawn_capture()
        {
            clear_board(positions);
            no_castling(positions);
            positions.blackPieces["bk"] = new Cell(7, 7);
            positions.blackPieces["bp2"] = new Cell(3, 4);
            positions.whitePieces["wp1"] = new Cell(4, 5);
            positions.whitePieces["wk"] = new Cell(0, 0);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> movements = positions.available_white_moves().ToList<string>();
            Assert.Contains("wp1,4,5,wp1,3,4,bp2", movements);
        }

        [Test]
        public void black_knight_capture()
        {
            clear_board(positions);
            no_castling(positions);
            positions.blackPieces["bk"] = new Cell(7, 7);
            positions.blackPieces["bn1"] = new Cell(3, 4);
            positions.whitePieces["wp1"] = new Cell(4, 6);
            positions.whitePieces["wk"] = new Cell(0, 0);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> movements = positions.available_black_moves().ToList<string>();
            Assert.Contains("bn1,3,4,bn1,4,6,wp1", movements);
        }

        [Test]
        public void white_knight_capture()
        {
            clear_board(positions);
            no_castling(positions);
            positions.blackPieces["bk"] = new Cell(7, 7);
            positions.blackPieces["bp1"] = new Cell(3, 4);
            positions.whitePieces["wn1"] = new Cell(4, 6);
            positions.whitePieces["wk"] = new Cell(0, 0);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> movements = positions.available_white_moves().ToList<string>();
            Assert.Contains("wn1,4,6,wn1,3,4,bp1", movements);
        }

        [Test]
        public void black_bishop_capture()
        {
            clear_board(positions);
            no_castling(positions);
            positions.blackPieces["bk"] = new Cell(0, 7);
            positions.blackPieces["bb1"] = new Cell(0, 0);
            positions.whitePieces["wb1"] = new Cell(7, 7);
            positions.whitePieces["wk"] = new Cell(7, 0);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> movements = positions.available_black_moves().ToList<string>();
            Assert.Contains("bb1,0,0,bb1,7,7,wb1", movements);
        }

        [Test]
        public void white_bishop_capture()
        {
            clear_board(positions);
            no_castling(positions);
            positions.blackPieces["bk"] = new Cell(0, 7);
            positions.blackPieces["bb1"] = new Cell(0, 0);
            positions.whitePieces["wb1"] = new Cell(7, 7);
            positions.whitePieces["wk"] = new Cell(7, 0);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> movements = positions.available_white_moves().ToList<string>();
            Assert.Contains("wb1,7,7,wb1,0,0,bb1", movements);
        }

        [Test]
        public void black_rock_capture()
        {
            clear_board(positions);
            no_castling(positions);
            positions.blackPieces["bk"] = new Cell(0, 7);
            positions.blackPieces["br1"] = new Cell(0, 0);
            positions.whitePieces["wq1"] = new Cell(7, 0);
            positions.whitePieces["wk"] = new Cell(7, 7);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> movements = positions.available_black_moves().ToList<string>();
            Assert.Contains("br1,0,0,br1,7,0,wq1", movements);
        }

        [Test]
        public void white_rock_capture()
        {
            clear_board(positions);
            no_castling(positions);
            positions.blackPieces["bk"] = new Cell(0, 7);
            positions.blackPieces["bq1"] = new Cell(0, 0);
            positions.whitePieces["wr1"] = new Cell(7, 0);
            positions.whitePieces["wk"] = new Cell(7, 7);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> movements = positions.available_white_moves().ToList<string>();
            Assert.Contains("wr1,7,0,wr1,0,0,bq1", movements);
        }

        [Test]
        public void black_queen_capture()
        {
            clear_board(positions);
            no_castling(positions);
            positions.blackPieces["bk"] = new Cell(0, 3);
            positions.blackPieces["bq1"] = new Cell(1, 3);
            positions.whitePieces["wq1"] = new Cell(6, 3);
            positions.whitePieces["wk"] = new Cell(7, 3);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> movements = positions.available_black_moves().ToList<string>();
            Assert.Contains("bq1,1,3,bq1,6,3,wq1", movements);
        }

        [Test]
        public void white_queen_capture()
        {
            clear_board(positions);
            no_castling(positions);
            positions.blackPieces["bk"] = new Cell(0, 0);
            positions.blackPieces["bq1"] = new Cell(1, 1);
            positions.whitePieces["wq1"] = new Cell(6, 6);
            positions.whitePieces["wk"] = new Cell(7, 7);
            positions.setInitialBoard();
            positions.tempCells = (string[,])positions.cells.Clone();
            List<string> movements = positions.available_white_moves().ToList<string>();
            Assert.Contains("wq1,6,6,wq1,1,1,bq1", movements);
        }

        public void no_castling(Positions position)
        {
            no_white_castling(position);
            no_black_castling(position);
        }

        public void no_white_castling(Positions position)
        {
            positions.white_long_castling = false;
            positions.white_short_castling = false;
        }

        public void no_black_castling(Positions position)
        {
            positions.black_long_castling = false;
            positions.black_short_castling = false;
        }

        public void clear_board(Positions position)
        {
            positions.whitePieces.Clear();
            positions.blackPieces.Clear();
        }
    }
}