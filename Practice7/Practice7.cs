using CsharpSB_Project.Practice7.Data;

namespace CsharpSB_Project.Practice7; 
public class Practice7 {
    private static Repository repository;
    public static void TaskLoop() {
        repository = new Repository();
        do {
            Console.WriteLine("Выберите действие -- ");
            Console.WriteLine(" - 1. Вывести данные на экран || GetAllWorkers");
            Console.WriteLine(" - 2. Получить запись по ИД");
            Console.WriteLine(" - 3. Удалить запись по ИД");
            Console.WriteLine(" - 4. Добавить запись");
            Console.WriteLine(" - 0. Выйти из программы");
            int enterValue = int.Parse(Console.ReadLine());
            if (enterValue == 0) break;
            else if (enterValue == 1) PrintAllWorkers();
            else if (enterValue == 2) GetWorkerById();
            else if (enterValue == 3) DeleteWorkerById();
            else if (enterValue == 4) AddWorker();
        } while (true);
    }

    private static void PrintAllWorkers() {
        // Console.WriteLine($"ID\t DateTime\t FullName\t Age\t Height\t Birthday\t Place of Birth");
        Worker[] workers = repository.GetAllWorkers();
        foreach (Worker worker in workers) {
            Console.Out.WriteLine(worker);
        }
    }

    private static void GetWorkerById() {
        Console.Write("Введите ID:");
        string enterId = Console.ReadLine();
        Worker worker = repository.GetWorkerById(enterId);
        Console.Out.WriteLine($"worker:{worker}");
    }

    private static void DeleteWorkerById() {
        Console.Write("Введите ID:");
        string enterId = Console.ReadLine();
        if (repository.DeleteWorker(enterId)) {
            Console.Out.WriteLine("Удалили!");
        } else {
            Console.Out.WriteLine("Не удалили!");
        }
    }

    private static void AddWorker() {
        Worker worker = new Worker();
        // Console.Write("\nВвeдите ИД сотрудника:");
        // worker.Id = Console.ReadLine();
        Console.Write("\nВвeдите Ф.И.О сотрудника:");
        worker.FullName = Console.ReadLine();
        Console.Write("\nВвeдите Возраст сотрудника:");
        worker.Age = int.Parse(Console.ReadLine());
        Console.Write("\nВвeдите Рост сотрудника:");
        worker.Height = int.Parse(Console.ReadLine());
        Console.Write("\nВвeдите Дату рождения сотрудника:");
        worker.DateOfBirth = DateTime.Parse(Console.ReadLine());
        Console.Write("\nВвeдите Место рождения сотрудника:");
        worker.PlaceOfBirth = Console.ReadLine();
        repository.AddWorker(worker);
    }
}