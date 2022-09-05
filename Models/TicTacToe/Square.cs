namespace GamesServer.Models.TicTacToe
{
    public class Square 
    {
        private readonly int _Number;
        public MarkEnum? Mark {get;set;}

        public Square(int number)
        {
            _Number = number;
        }
    }
}