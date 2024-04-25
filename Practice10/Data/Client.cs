using System.Text.Json;
using CsharpSB_Project.Practice10.Utils;

namespace CsharpSB_Project.Practice10.Data;
public class Client {
    public FullName FullName { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public string SerialNumber { get; set; }

    public static List<Client> Clients = new List<Client>(); // todo возможно это нужно отсюда убрать в ClientsManager

    public Client() {
        this.FullName = new FullName(Clients.Count);
        this.PhoneNumber = new PhoneNumber();
        this.SerialNumber = RandomNumberGenerator.GenerateRandomNumber(10);
        Clients.Add(this);
    }

    public static async Task SerializeToFile(string fileName) { // todo возможно это нужно отсюда убрать в ClientsManager
        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate)) {
            await JsonSerializer.SerializeAsync(fs, Clients);
            Console.WriteLine("Data has been saved to file");
        }
    }

    public static async Task DeserializeFromFile(string fileName) { // todo возможно это нужно отсюда убрать в ClientsManager
        if (!File.Exists(fileName)) return;
        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate)) {
            Clients = (await JsonSerializer.DeserializeAsync<List<Client>>(fs))!;
            Console.WriteLine($"Clients loaded:" + Clients);
        }
    }

    public override string ToString() {
        return JsonSerializer.Serialize(this);
    }
}