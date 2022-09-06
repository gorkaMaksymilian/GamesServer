namespace GamesServer.Models.ConnectFour
{
    public class Space
    {
        public PieceEnum Piece { get; private set; }

        public Space(PieceEnum piece)
        {
            Piece = piece;
        }

    }
}