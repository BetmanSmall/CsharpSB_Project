namespace CsharpSB_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fullName = "Иванов Иван Иванович";
            Console.WriteLine($"fullName: {fullName}");
            int age = 99;
            Console.WriteLine($"age: {age}");
            string email = "email@test.ru";
            Console.WriteLine($"email: {email}");
            float programmingPoints = 98;
            Console.WriteLine($"programmingPoints: {programmingPoints}");
            float mathScores = 89;
            Console.WriteLine($"mathScores: {mathScores}");
            float physicsPoints = 76;
            Console.WriteLine($"physicsPoints: {physicsPoints}");

            Console.WriteLine("\n" + "Press any key to continue...");
            Console.ReadKey();

            float totalPoint = programmingPoints + mathScores + physicsPoints;
            Console.WriteLine($"totalPoint: {totalPoint}");
            float averagePoint = totalPoint / 3f;
            Console.WriteLine($"averagePoint: {averagePoint}");
        }
    }
}
