namespace CsharpSB_Project {
    internal class Practice4 {
        public static int[,] Task01() {
            Console.WriteLine("-Practice4--Task01-");
            Console.Write("Введите количество строк: ");
            int rowsCount = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов: ");
            int columnsCount = int.Parse(Console.ReadLine());
            Console.Write("Введите минимальное число для генерации: ");
            int randomMin = int.Parse(Console.ReadLine());
            Console.Write("Введите максимальное число для генерации: ");
            int randomMax = int.Parse(Console.ReadLine());
            Random random = new Random();
            int totalSum = 0;
            int[,] matrix = new int[rowsCount, columnsCount];
            for (int r = 0; r < rowsCount; r++) {
                for (int c = 0; c < columnsCount; c++) {
                    int randomValue = matrix[r, c] = random.Next(randomMin, randomMax);
                    totalSum += randomValue;
                    Console.Write($"{randomValue} \t");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"totalSum: {totalSum}");
            return matrix;
        }

        public static void Task02() {
            Console.WriteLine("-Practice4--Task02-");
            int[,] matrix1 = Task01();
            int[,] matrix2 = Task01();
            if ((matrix1.Rank == matrix2.Rank) && matrix1.Rank == 2 &&
                (matrix1.GetLength(0) == matrix2.GetLength(0) &&
                (matrix1.GetLength(1) == matrix2.GetLength(1)))) {
                int rowsCount = matrix1.GetLength(0);
                int columnsCount = matrix1.GetLength(1);
                int[,] matrix3 = new int[rowsCount, columnsCount];
                for (int r = 0; r < rowsCount; r++) {
                    for (int c = 0; c < columnsCount; c++) {
                        int value1 = matrix1[r, c];
                        int value2 = matrix2[r, c];
                        int value3 = matrix3[r, c] = value1 + value2;
                        Console.Write($"{value3} \t");
                    }
                    Console.WriteLine();
                }
            } else {
                Console.WriteLine("Размеры матриц не равны!");
            }
        }
    }
}