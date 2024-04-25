using CsharpSB_Project.Practice10.Data;
using CsharpSB_Project.Practice10.Employees;
using CsharpSB_Project.Practice10.Utils;

namespace CsharpSB_Project.Practice10;
public class Practice10 {
    public static void MainLoop() {
        ClientsManager.Load();
        // new Client();
        // new Client();
        do {
            Console.Out.WriteLine(string.Join(",", ClientsManager.Clients));
            Console.Out.Write("Кто ты войн?" +
                                  "\n  --- 1. Консультант!" +
                                  "\n  --- 2. Менеджер!" +
                                  "\n  --- 0. Ахиллес, сын Пелея! | Выход!" +
                                  "\nЯ:");
            int enterValue = int.Parse(Console.In.ReadLine());
            if (enterValue == 0) break;
            Employee employee = null;
            if (enterValue == 1) {
                employee = new Consultant();
            } else if (enterValue == 2) {
                employee = new Manager();
            }
            if (employee != null) {
                employee.WorkWithClients();
            }
        } while (true);
        Console.Out.WriteLine(string.Join(",", ClientsManager.Clients));
        ClientsManager.UnLoad();
    }
}