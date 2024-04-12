using System.Text;

namespace CsharpSB_Project; 
public class Practice6 {
    public static void TaskLoop() {
        do {
            Console.WriteLine("Выберите действие -- ");
            Console.WriteLine(" - 1. Вывести данные на экран");
            Console.WriteLine(" - 2. Добавить новую запись");
            Console.WriteLine(" - 0. Выйти из программы");
            int enterValue = int.Parse(Console.ReadLine());
            if (enterValue == 0) break;
            else if (enterValue == 1) ReadAndPrintDictionary();
            else if (enterValue == 2) GetFromUserAndWriteDictionary();
        } while (true);
    }

    private static string fileName = "dictionary.csv";

    private static void ReadAndPrintDictionary() {
        if (!File.Exists(fileName)) {
            Console.WriteLine("Справочник отсутствует!");
            return;
        }
        using (StreamReader streamReader = new StreamReader(fileName, Encoding.Unicode)) {
            string line;
            Console.WriteLine($"ID\t DateTime\t FullName\t Age\t Height\t Birthday\t Place of Birth");
            while ((line = streamReader.ReadLine()) != null) {
                string[] strings = line.Split("#");
                foreach (string s in strings) {
                    Console.Write(s + "\t");
                }
                Console.WriteLine();
            }
        }
    }

    private static void GetFromUserAndWriteDictionary() {
        using (StreamWriter streamWriter = new StreamWriter(fileName, true, Encoding.Unicode)) {
            StringBuilder stringBuilder = new StringBuilder();
            Console.Write("\nВвeдите ИД сотрудника:");
            stringBuilder.Append(Console.ReadLine() + "#");
            stringBuilder.Append(DateTime.Now + "#");
            Console.Write("\nВвeдите Ф.И.О сотрудника:");
            stringBuilder.Append(Console.ReadLine() + "#");
            Console.Write("\nВвeдите Возраст сотрудника:");
            stringBuilder.Append(Console.ReadLine() + "#");
            Console.Write("\nВвeдите Рост сотрудника:");
            stringBuilder.Append(Console.ReadLine() + "#");
            Console.Write("\nВвeдите Дату рождения сотрудника:");
            stringBuilder.Append(Console.ReadLine() + "#");
            Console.Write("\nВвeдите Место рождения сотрудника:");
            stringBuilder.Append(Console.ReadLine());
            streamWriter.WriteLine(stringBuilder.ToString());
        }
    }
}