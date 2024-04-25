using System.Text.Json;
using CsharpSB_Project.Practice10.Utils;

namespace CsharpSB_Project.Practice10.Data;
public class Client {
    public FullName FullName { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public string SerialNumber { get; set; }

    public Client() {
        this.FullName = new FullName(ClientsManager.Clients.Count);
        this.PhoneNumber = new PhoneNumber();
        this.SerialNumber = RandomNumberGenerator.GenerateRandomNumber(10);
        ClientsManager.Clients.Add(this);
    }

    public override string ToString() {
        return JsonSerializer.Serialize(this);
    }
}