namespace WebApplication2.Models
{
    public class GameOfLife
    {
        private const int BoardSize = 30;
        private bool[,] _board;

        public GameOfLife()
        {
            _board = new bool[BoardSize, BoardSize];
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            var random = new Random();

            for (var row = 0; row < BoardSize; row++)
            {
                for (var col = 0; col < BoardSize; col++)
                {
                    // Рандомно устанавливаем состояние клетки (живая или мертвая)
                    _board[row, col] = random.Next(2) == 0;
                }
            }
        }

        public void UpdateBoard()
        {
            var newBoard = new bool[BoardSize, BoardSize];

            for (var row = 0; row < BoardSize; row++)
            {
                for (var col = 0; col < BoardSize; col++)
                {
                    var liveNeighbors = CountLiveNeighbors(row, col);

                    switch (_board[row, col])
                    {
                        case false when liveNeighbors == 3:
                            // Клетка мертва и имеет ровно 3 живых соседей, она оживает
                            newBoard[row, col] = true;
                            break;
                        case true when liveNeighbors is < 2 or > 3:
                            // Клетка жива и имеет менее 2 или более 3 живых соседей, она умирает
                            newBoard[row, col] = false;
                            break;
                        default:
                            // Во всех остальных случаях клетка остается в своем текущем состоянии
                            newBoard[row, col] = _board[row, col];
                            break;
                    }
                }
            }

            _board = newBoard;
        }

        private int CountLiveNeighbors(int row, int col)
        {
            var liveNeighbors = 0;

            // Определяем 9 окружающих клеток
            int[] neighborRows = { -1, -1, -1, 0, 0, 0, 1, 1, 1 };
            int[] neighborCols = { -1, 0, 1, -1, 0, 1, -1, 0, 1 };

            for (var i = 0; i < neighborRows.Length; i++)
            {
                var neighborRow = row + neighborRows[i];
                var neighborCol = col + neighborCols[i];

                // Проверяем, находится ли соседняя клетка в пределах игрового поля
                if (neighborRow is < 0 or >= BoardSize || neighborCol is < 0 or >= BoardSize) continue;
                if (_board[neighborRow, neighborCol])
                {
                    liveNeighbors++;
                }
            }

            return liveNeighbors;
        }

        public bool[,] GetBoard()
        {
            return _board;
        }
    }
}