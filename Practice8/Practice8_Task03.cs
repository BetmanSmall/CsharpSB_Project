namespace CsharpSB_Project.Practice8;
public class Practice8_Task03 {
    private static HashSet<int> _hashSet = new HashSet<int>();

    public static void Task03() {
        do {
            Console.Out.Write("Введите число:");
            string enterString = Console.ReadLine();
            if (enterString == String.Empty) break;
            int enterValue = int.Parse(enterString);
            if (_hashSet.Add(enterValue)) {
                Console.Out.WriteLine("Число добавлено!");
            }
            else {
                Console.Out.WriteLine("Число не добавлено!");
            }
        } while (true);
    }
}