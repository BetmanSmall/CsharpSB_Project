using CsharpSB_Project.Practice10.Data;

namespace CsharpSB_Project.Practice10.Utils;
public static class ClientsManager {
    private static string JsonFileName = "clients.json";

    public static List<Client> Clients = Client.Clients; // new List<Client>();

    public static void Load() {
        var task = Client.DeserializeFromFile(JsonFileName);
        task.Wait();
    }

    public static void UnLoad() {
        Client.SerializeToFile(JsonFileName);
    }
}