namespace CsharpSB_Project.Practice8;
public class Practice8_Task02 {
    private static Dictionary<int, string> telephoneFullNames = new Dictionary<int, string>();

    public static void Task02() {
        FillDictionary();
        FindAndPrintNumber();
    }

    private static void FillDictionary() {
        do {
            Console.WriteLine("Введите ФИО или пустую строку что бы закончить:");
            string fullName = Console.ReadLine();
            if (fullName == String.Empty) break;
            Console.WriteLine("Введите номер телефона (формат только цифры):");
            int number = int.Parse(Console.ReadLine());
            if (!telephoneFullNames.TryAdd(number, fullName)) {
                Console.WriteLine("Такой номер телефон уже есть!");
            }
        } while (true);
    }

    private static void FindAndPrintNumber() {
        Console.WriteLine("Введите номер телефона (формат только цифры):");
        int number = int.Parse(Console.ReadLine());
        if (telephoneFullNames.TryGetValue(number, out string fullName)) {
            Console.WriteLine($"Найден пользователь:{fullName}, номер телефона:{number}");
        }
        else {
            Console.WriteLine($"Пользователь с таким телефоном:{number} не найден");
        }
    }
}