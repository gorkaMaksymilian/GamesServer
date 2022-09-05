namespace GamesServer.Models.TicTacToe
{
    public class WinCondition
    {
        public int FirstSquare { get; private set; }
        public int SecondSquare { get; private set; }
        public int ThirdSquare { get; private set; }


        public WinCondition(int firstSquare, int secondSquare, int thirdSquare)
        {
            FirstSquare = firstSquare;
            SecondSquare = secondSquare;
            ThirdSquare = thirdSquare;
        }

    }
}