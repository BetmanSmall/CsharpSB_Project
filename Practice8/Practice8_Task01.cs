namespace CsharpSB_Project.Practice8;
public class Practice8_Task01 {
    private static List<int> _list = new List<int>();

    public static void Task01() {
        FillList();
        PrintList();
        Console.ReadKey();
        RemoveNumberRange();
        PrintList();
    }

    private static void FillList() {
        _list.Clear();
        Random random = new Random();
        for (int i = 0; i < 100; i++) {
            _list.Add(random.Next(0, 101));
        }
    }

    private static void PrintList() {
        Console.Out.WriteLine($"_list:{string.Join(",", _list)}");
    }

    private static void RemoveNumberRange(int min = 25, int max = 50) {
        if (min < max) {
            int removeValues = _list.RemoveAll(number => (number > min && number < max));
            Console.Out.WriteLine("Сколько удалили:" + removeValues);
        }
    }
}