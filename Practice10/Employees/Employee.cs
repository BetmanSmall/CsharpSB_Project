using CsharpSB_Project.Practice10.Data;
using CsharpSB_Project.Practice10.Utils;

namespace CsharpSB_Project.Practice10.Employees;
public interface Employee {
    public void WorkWithClients() {
        WorkWithClient(ConsoleClientSelector.SelectClient());
    }

    public abstract void WorkWithClient(Client client);
}