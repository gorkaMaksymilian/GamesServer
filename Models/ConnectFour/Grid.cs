namespace GamesServer.Models.ConnectFour
{
    public class Grid
    {
        const int COLUMNS = 7;
        const int ROWS = 6;
        public PieceEnum?[,] Pieces { get; private set; }
        public PieceEnum NextTurn { get; private set; }
        public PieceEnum? WinnerColor {get; private set; }

        // To check neighbours in pairs (right+left / up+down etc.)
        public List<Direction> Directions = new List<Direction> {
            new Direction((0,1),(0,-1)),        // up + down
            new Direction((1,0),(-1,0)),        // right + left
            new Direction((1,1),(-1,-1)),       // up-right + down-left
            new Direction((-1,1),(1,-1))        // up-left + down-right
        };

        public Grid()
        {
            Pieces = new PieceEnum?[COLUMNS,ROWS];
            NextTurn = PieceEnum.Red;
        }

        public void SetNextTurn()
        {
            NextTurn = (NextTurn == PieceEnum.Red)? PieceEnum.Yellow : PieceEnum.Red;
        }


        public void IsWinningMove(int column, int row)
        {
            int firstDirectionNeighboursCounter, secondDirectionNeighboursCounter;
            int neighbourColumn, neighbourRow;

            
            foreach (var direction in Directions)
            {
                neighbourColumn = direction.FirstModifier.Item1 + column;
                neighbourRow = direction.FirstModifier.Item2 + row;
                firstDirectionNeighboursCounter = GetNeighbours(neighbourRow,neighbourColumn,column,row,direction.FirstModifier.Item1,direction.FirstModifier.Item2);


                neighbourColumn = direction.SecondModifier.Item1 + column;
                neighbourRow = direction.SecondModifier.Item2 + row;
                secondDirectionNeighboursCounter = GetNeighbours(neighbourRow,neighbourColumn,column,row,direction.SecondModifier.Item1,direction.SecondModifier.Item2);
                

                if (firstDirectionNeighboursCounter + secondDirectionNeighboursCounter >= 3) 
                {
                    if (Pieces is not null && Pieces[column,row].HasValue) {
                        WinnerColor = Pieces![column,row]!.Value;
                        break;
                    }
                    
                }
            }
            

            
        }

        public int GetNeighbours(int neighbourRow, int neighbourColumn, int column, int row, int firstItem, int secondItem)
        {
            int neighboursCounter = 0;
            while (neighbourRow >= 0 && neighbourRow < ROWS && neighbourColumn >= 0 && neighbourColumn < COLUMNS) 
            {
                if (Pieces is not null && Pieces![neighbourColumn, neighbourRow].HasValue && Pieces![column,row].HasValue) 
                {
                    if (Pieces![neighbourColumn, neighbourRow]!.Value == Pieces![column,row]!.Value)
                        neighboursCounter++;
                    else
                        break;


                    neighbourColumn += firstItem;
                    neighbourRow += secondItem;
                }
                else 
                    break;
            }
            return neighboursCounter;
        }

        public void ResetGame()
        {
            Pieces = new PieceEnum?[COLUMNS,ROWS];
            WinnerColor = null;

        }
    }
}