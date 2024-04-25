using CsharpSB_Project.Practice10.Data;

namespace CsharpSB_Project.Practice10.Employees;
public class Manager : Consultant {
    public override void WorkWithClient(Client client) {
        do {
            Console.Out.WriteLine("Client: " + ClientToString(client));
            Console.Out.WriteLine("Менеджер что ты хочешь сделать с этим клиентом?" +
                                  "   --- 1. Повзаимодействовать с клиентом как консультант" +
                                  "   --- 2. Изменить ФИО" +
                                  "   --- 3. Изменить Номер телефона" +
                                  "   --- 4. Изменить Серию, номер паспорта" +
                                  "   --- 5. Создать нового клиента" +
                                  "   --- 0. Назад" +
                                  "");
            int enterValue = int.Parse(Console.ReadLine());
            if (enterValue == 0) break;
            if (enterValue == 1) {
                base.WorkWithClient(client);
            } else if (enterValue == 2) {
                ChangeClientFullName(client);
            } else if (enterValue == 3) {
                ChangeClientPhoneNumber(client);
            } else if (enterValue == 4) {
                ChangeClientSerialNumber(client);
            } else if (enterValue == 5) {
                client = CreateNewClient();
            }
        } while (true);
    }

    public override string GetClientSerialNumber(Client client) {
        if (client != null) {
            if (client.SerialNumber != null) {
                return client.SerialNumber;
            }
        }
        return String.Empty;
    }

    public void ChangeClientFullName(Client client) {
        Console.Out.Write("Введите фамилию: ");
        string lastName = Console.ReadLine();
        client.FullName.LastName = lastName;
        Console.Out.Write("Введите имя: ");
        string firstName = Console.ReadLine();
        client.FullName.FirstName = firstName;
        Console.Out.Write("Введите отчество: ");
        string surName = Console.ReadLine();
        client.FullName.SurName = surName;
    }

    public void ChangeClientSerialNumber(Client client) {
        do {
            Console.Out.Write("Введите серию и номер паспорта: ");
            string serialNumber = Console.ReadLine();
            var isNumeric = int.TryParse(serialNumber, out _);
            if (isNumeric && serialNumber.Length == 10) {
                client.SerialNumber = serialNumber;
                break;
            } else {
                Console.Out.WriteLine("Ввел что то не то!");
            }
        } while (true);
    }

    public Client CreateNewClient() {
        Client newClient = new Client();
        ChangeClientFullName(newClient);
        ChangeClientPhoneNumber(newClient);
        ChangeClientSerialNumber(newClient);
        return newClient;
    }
}