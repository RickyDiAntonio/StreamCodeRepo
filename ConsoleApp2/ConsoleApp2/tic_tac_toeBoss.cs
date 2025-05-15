//using System.Data;
//using System.Numerics;
//using System.Security.Cryptography.X509Certificates;

//new TicTacToeGame().run();
//public class TicTacToeGame
//{
//    public void run()
//    {
//        //board, render,players
//        Board board = new Board();
//        BoardRenderer renderer = new BoardRenderer();
//        int turnNumber = 0;
//        renderer.Render(board);
//        Cell currentPlayer = Cell.X;
//        while (turnNumber < 9)
//        {
//            Console.Clear();
//            Console.WriteLine($"Turn {turnNumber} - Player {currentPlayer}");
//            renderer.Render(board);
//            int cellNumber = Prompt("Choose a cell (1-9): ");
//            int row = (cellNumber - 1) / 3;
//            int col = (cellNumber - 1) % 3;
//            if (board.GetCell(row, col) != Cell.Empty)
//            {
//                Console.WriteLine("Cell already taken. Press Enter to try again.");
//                Console.ReadLine();
//            }
//            else
//            {
//                board.SetCell(row, col, currentPlayer);
//                turnNumber++;
//                if (CheckWinnter(board, currentPlayer))
//                {
//                    Console.Clear();
//                    Console.WriteLine($"Player {currentPlayer} is the winner!!!");
//                    renderer.Render(board);
//                    return;
//                }
//                currentPlayer = currentPlayer == Cell.X ? Cell.O : Cell.X;
//            }
//        }
//        Console.Clear();
//        Console.WriteLine("game over!");
//        renderer.Render(board);
//    }
//    public bool CheckWinnter(Board board, Cell player)
//    {
//        for (int row = 0; row < 3; row++)
//        {
//            if (board.GetCell(row, 0) == player && board.GetCell(row, 1) == player && board.GetCell(row, 2) == player)
//                return true;
//        }
//        // Vertical Check
//        for (int col = 0; col < 3; col++)
//        {
//            if (board.GetCell(0, col) == player && board.GetCell(1, col) == player && board.GetCell(2, col) == player)
//                return true;
//        }
//        if (board.GetCell(0, 0) == player && board.GetCell(1, 1) == player && board.GetCell(2, 2) == player)
//            return true;
//        if (board.GetCell(0, 2) == player && board.GetCell(1, 1) == player && board.GetCell(2, 0) == player)
//            return true;
//        return false; // No winner
//    }
//    private int Prompt(string message)
//    {
//        int value;
//        while (true)
//        {
//            Console.Write(message);
//            string input = Console.ReadLine();
//            if (int.TryParse(input, out value) && value >= 1 && value <= 9)
//                return value;
//            Console.WriteLine("Invalid input. Please enter a number from 1 to 9.");
//        }
//    }
//}
//public class Board
//{
//    private readonly Cell[,] _cells = new Cell[3, 3];
//    public Board()
//    {
//        for (int r = 0; r < 3; r++)
//        {
//            for (int c = 0; c < 3; c++)
//            {
//                _cells[r, c] = Cell.Empty;
//            }
//        }
//    }
//    public Cell GetCell(int x, int y) => _cells[x, y];
//    public void SetCell(int x, int y, Cell cell)
//    {
//        _cells[x, y] = cell;
//    }
//}
//public class BoardRenderer
//{
//    public void Render(Board board)
//    {
//        for (int r = 0; r < 3; r++)
//        {
//            for (int c = 0; c < 3; c++)
//            {
//                Cell cell = board.GetCell(r, c);
//                char display = cell == Cell.Empty ? '.' : cell.ToString()[0];
//                Console.Write(" " + display + " ");
//                if (c < 2) Console.Write("|");
//            }
//            Console.WriteLine();
//            if (r < 2) Console.WriteLine("-----------");
//        }
//    }
//}
//public class Square
//{
//    public int Row { get; }
//    public int Col { get; }
//    public Square(int row, int col)
//    {
//        Row = row; Col = col;
//    }
//}
//public enum Cell { Empty, X, O }