namespace CsharpSB_Project;
public static class MainClass {
    private static void Main(string[] args) {
        Practice4.Task01();
        Practice4.Task02();
        Console.ReadKey();
        Console.Clear();
        var gameOfLife = new Practice4_GameOfLife.GameOfLife();
    }
}