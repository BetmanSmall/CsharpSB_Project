using System.Text.Json;
using CsharpSB_Project.Practice10.Data;

namespace CsharpSB_Project.Practice10.Utils;
public static class ClientsManager {
    private static string JsonFileName = "clients.json";

    public static List<Client> Clients = new List<Client>();

    public static void Load() {
        var task = DeserializeFromFile(JsonFileName);
        task.Wait();
    }

    public static void UnLoad() {
        SerializeToFile(JsonFileName);
    }

    public static async Task SerializeToFile(string fileName) {
        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate)) {
            var options = new JsonSerializerOptions { WriteIndented = true };
            await JsonSerializer.SerializeAsync(fs, Clients, options);
            Console.WriteLine("Data has been saved to file");
        }
    }

    public static async Task DeserializeFromFile(string fileName) {
        if (!File.Exists(fileName)) return;
        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate)) {
            Clients = (await JsonSerializer.DeserializeAsync<List<Client>>(fs))!;
            Console.WriteLine($"Clients loaded:" + Clients);
        }
    }
}