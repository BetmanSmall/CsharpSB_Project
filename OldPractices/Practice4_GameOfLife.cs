namespace CsharpSB_Project;
public class Practice4_GameOfLife {
    private class LifeSimulation {
        private readonly int _height;
        private readonly int _width;
        private readonly bool[,] _cells;

        public LifeSimulation(int height, int width) {
            _height = height;
            _width = width;
            _cells = new bool[height, width];
            GenerateField();
        }

        private void GenerateField() {
            Random generator = new Random();
            for (int i = 0; i < _height; i++) {
                for (int j = 0; j < _width; j++) {
                    var number = generator.Next(2);
                    _cells[i, j] = (number != 0);
                }
            }
        }

        public void DrawAndGrow() {
            DrawGame();
            Grow();
        }

        private void DrawGame() {
            for (int i = 0; i < _height; i++) {
                for (int j = 0; j < _width; j++) {
                    Console.Write(_cells[i, j] ? "0" : " ");
                    if (j == _width - 1) Console.WriteLine("\r");
                }
            }
            Console.SetCursorPosition(0, Console.WindowTop+1);
        }

        private void Grow() {
            for (int i = 0; i < _height; i++) {
                for (int j = 0; j < _width; j++) {
                    int numOfAliveNeighbors = GetNeighbors(i, j);
                    if (_cells[i, j]) {
                        if (numOfAliveNeighbors <= 1) {
                            _cells[i, j] = false;
                        } else if (numOfAliveNeighbors >= 4) {
                            _cells[i, j] = false;
                        }
                    } else {
                        if (numOfAliveNeighbors == 3) {
                            _cells[i, j] = true;
                        }
                    }
                }
            }
        }

        private int GetNeighbors(int x, int y) {
            int numOfAliveNeighbors = 0;
            for (int i = x - 1; i < x + 2; i++) {
                for (int j = y - 1; j < y + 2; j++) {
                    if (!((i < 0 || j < 0) || (i >= _height || j >= _width))) {
                        if (_cells[i, j]) numOfAliveNeighbors++;
                    }
                }
            }
            return numOfAliveNeighbors;
        }
    }

    public class GameOfLife {
        private const int Heigth = 15;
        private const int Width = 30;
        private const uint MaxRuns = 100;

        public GameOfLife() {
            Console.WriteLine("-Practice4--Task03-GameOfLife-");
            int runs = 0;
            LifeSimulation sim = new LifeSimulation(Heigth, Width);
            while (runs++ < MaxRuns) {
                sim.DrawAndGrow();
                Thread.Sleep(100);
            }
        }
    }
}