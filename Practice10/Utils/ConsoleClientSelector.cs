using System.Text;
using CsharpSB_Project.Practice10.Data;

namespace CsharpSB_Project.Practice10.Utils;
public static class ConsoleClientSelector {
    public static Client SelectClient() {
        int clientsCountInPage = 10;
        int pageIndex = 0;
        do {
            StringBuilder stringBuilder = new StringBuilder();
            int pagesCount = ClientsManager.Clients.Count / clientsCountInPage;
            int clientsPageIndexMin = pageIndex * clientsCountInPage;
            int clientsPageIndexMax = (pageIndex + 1) * clientsCountInPage;
            // clientsPageIndexMax = clientsPageIndexMax < ClientsManager.Clients.Count ? clientsPageIndexMax : ClientsManager.Clients.Count;
            if (clientsPageIndexMax > ClientsManager.Clients.Count) {
                clientsPageIndexMax = ClientsManager.Clients.Count;
            }
            for (int i = clientsPageIndexMin; i < clientsPageIndexMax; i++) {
                stringBuilder.Append($"  --- {i + 1} - " + ClientsManager.Clients[i].FullName + "\n");
            }
            Console.Out.WriteLine($"\n Pages:({pageIndex+1}/{pagesCount+1})");
            Console.Out.WriteLine(stringBuilder.ToString());
            Console.Out.WriteLine("Менять страницы: -1 = Назад, 0 = Вперед.");
            Console.Out.WriteLine("Выбери клиента:");
            int enterValue = int.Parse(Console.ReadLine());
            if (enterValue <= 0) {
                if (enterValue == 0) {
                    pageIndex++;
                    pageIndex = pageIndex > pagesCount ? pagesCount : pageIndex;
                } else {
                    pageIndex--;
                    pageIndex = pageIndex < 0 ? 0 : pageIndex;
                }
            } else {
                if (enterValue > clientsPageIndexMin && enterValue <= clientsPageIndexMax) {
                    return ClientsManager.Clients[enterValue - 1];
                }
            }
        } while (true);
    }
}