namespace GamesServer.Models.ConnectFour
{
    public class Direction
    {
        public (int, int) FirstModifier { get; private set; }
        public (int, int) SecondModifier { get; private set; }


        public Direction((int, int) firstModifier, (int, int) secondModifier) 
        {
            FirstModifier = firstModifier;
            SecondModifier = secondModifier;
        }

    }
}