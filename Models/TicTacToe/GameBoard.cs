namespace GamesServer.Models.TicTacToe
{
    public class GameBoard
    {
        public List<Square> Squares { get; private set; }


        public MarkEnum NextTurn { get; set; }
        public int OWinns { get; set; }
        public int XWinns { get; set; }
        public MarkEnum? Winner { get; set; }


        public List<WinCondition> WinConditions = new List<WinCondition> {
            new WinCondition(1,2,3),
            new WinCondition(4,5,6),
            new WinCondition(7,8,9),
            new WinCondition(1,4,7),
            new WinCondition(2,5,8),
            new WinCondition(3,6,9),
            new WinCondition(1,5,9),
            new WinCondition(3,5,7)
        };

        public GameBoard()
        {
            Squares = new List<Square>();
            ResetGame();
        }

        public void ResetGame()
        {
            Squares.Clear();
            NextTurn = (Winner.HasValue ? Winner.Value : MarkEnum.O);
            Winner = null;

            for (int i = 1; i <= 9; i++)
                Squares.Add(new Square(i));
        }

        public void Next()
        {
            foreach (var winningCombination in WinConditions)
            {
                if (Squares[winningCombination.FirstSquare - 1].Mark == MarkEnum.O && Squares[winningCombination.SecondSquare - 1].Mark == MarkEnum.O && 
                    Squares[winningCombination.ThirdSquare - 1].Mark == MarkEnum.O)
                {
                    Winner = MarkEnum.O;
                }

                else if(Squares[winningCombination.FirstSquare - 1].Mark == MarkEnum.X && Squares[winningCombination.SecondSquare - 1].Mark == MarkEnum.X && 
                        Squares[winningCombination.ThirdSquare - 1].Mark == MarkEnum.X)
                {
                    Winner = MarkEnum.X;
                }
            }

            if (Winner.HasValue)
            {
                if (Winner == MarkEnum.O)
                    OWinns += 1;
                else
                    XWinns += 1;

                NextTurn = Winner.Value;
            }
            else 
            {
                if (NextTurn == MarkEnum.O)
                    NextTurn = MarkEnum.X;
                else
                    NextTurn = MarkEnum.O;
            }
        }

        
    }
}