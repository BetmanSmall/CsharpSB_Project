using System.Xml.Linq;

namespace CsharpSB_Project.Practice8;
public class Practice8_Task04 {
    // <Person name=”ФИО человека” >
    // <Address>
    // <Street>Название улицы</Street>
    // <HouseNumber>Номер дома</HouseNumber>
    // <FlatNumber>Номер квартиры</FlatNumber>
    // </Address>
    // <Phones>
    // <MobilePhone>89999999999999</MobilePhone>
    // <FlatPhone>123-45-67<FlatPhone>
    // </Phones>
    // </Person>
    public static void Task04() {
        XDocument xmlDocument = new XDocument();
        XElement persons = new XElement("Persons");
        do {
            Console.Write("Введите ФИО или пустую строку что бы закончить:");
            string fullName = Console.ReadLine();
            if (fullName == String.Empty) break;
            XElement person = new XElement("Person", new XAttribute("name", fullName));
            // XAttribute xAttribute = new XAttribute("name", fullName);
            // person.Add(xAttribute);
            XElement address = new XElement("Address");

            Console.Write("Название улицы:");
            string streetStr = Console.ReadLine();
            XElement street = new XElement("Street", streetStr);
            address.Add(street);

            Console.Write("Номер дома:");
            string houseNumberStr = Console.ReadLine();
            XElement houseNumber = new XElement("HouseNumber", houseNumberStr);
            address.Add(houseNumber);

            Console.Write("Номер квартиры:");
            string flatNumberStr = Console.ReadLine();
            XElement flatNumber = new XElement("FlatNumber", flatNumberStr);
            address.Add(flatNumber);

            XElement phones = new XElement("Phones");

            Console.Write("Мобильный телефон:");
            string mobilePhoneStr = Console.ReadLine();
            XElement mobilePhone = new XElement("MobilePhone", mobilePhoneStr);
            phones.Add(mobilePhone);

            Console.Write("Плоский телефон:");
            string flatPhoneStr = Console.ReadLine();
            XElement flatPhone = new XElement("FlatPhone", flatPhoneStr);
            phones.Add(flatPhone);

            person.Add(address);
            person.Add(phones);
            persons.Add(person);
        } while (true);
        xmlDocument.Add(persons);
        xmlDocument.Save("persons.xml");
        Console.WriteLine("Data saved");
    }
}