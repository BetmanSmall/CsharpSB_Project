using CsharpSB_Project.Practice10.Data;
using CsharpSB_Project.Practice10.Utils;

namespace CsharpSB_Project.Practice10.Employees;
public class Consultant : Employee {
    public void WorkWithClient(Client client) {
        do {
            Console.Out.WriteLine("Что ты хочешь сделать с этим клиентом?" +
                                  "   --- 1. Просмотреть серию и номер паспорта" +
                                  "   --- 2. Просмотреть ФИО" +
                                  "   --- 3. Изменить Номер телефона" +
                                  "   --- 0. Назад" +
                                  "");
            int enterValue = int.Parse(Console.ReadLine());
            if (enterValue == 0) break;
            if (enterValue == 1) {
                Console.Out.WriteLine(GetClientSerialNumber(client));
            } else if (enterValue == 2) {
                Console.Out.WriteLine(GetClientFullName(client));
            } else if (enterValue == 3) {
                try {
                    Console.Out.Write("Введите номер телефона: ");
                    string phoneNumberStr = Console.ReadLine();
                    PhoneNumber newPhoneNumber = new PhoneNumber(phoneNumberStr);
                    SetClientPhoneNumber(client, newPhoneNumber);
                } catch (Exception e) {
                    Console.Error.WriteLine(e);
                    Console.Out.Write("Плохой номер ты ввел!");
                    // throw;
                }
            }
        } while (true);
    }

    public string GetClientSerialNumber(Client client) {
        if (client != null) {
            if (client.SerialNumber != null) {
                if (client.SerialNumber.Length > 0) {
                    return RandomNumberGenerator.GetAsterisksMask(client.SerialNumber.Length);
                }
            }
        }
        return String.Empty;
    }

    public string GetClientFullName(Client client) {
        return client.FullName.ToString();
    }

    public void SetClientPhoneNumber(Client client, PhoneNumber phoneNumber) {
        client.PhoneNumber = phoneNumber;
        Console.Out.WriteLine("Успешно! Новый номер:" + phoneNumber);
        // Console.Out.WriteLine("Успешно! Новый номер:" + GetClientPhoneNumber(client));
    }

    // public string GetClientPhoneNumber(Client client) {
    // return client.PhoneNumber.ToString();
    // }
}