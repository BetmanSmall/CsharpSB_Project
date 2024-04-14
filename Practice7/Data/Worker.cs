using System.Text;

namespace CsharpSB_Project.Practice7.Data; 
public class Worker {
    public string Id { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }
    public int Height { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PlaceOfBirth { get; set; }

    public Worker() {
        this.Id = Guid.NewGuid().ToString();
        this.CreatedDateTime = DateTime.Now;
        this.FullName = Id;
        this.Age = 99;
        this.Height = 999;
        this.DateOfBirth = CreatedDateTime;
        this.PlaceOfBirth = "gorod " + Id;
    }

    public Worker(string[] strings) { // todo Need simple json deserialize!
        if (strings.Length == 7) {
            this.Id = strings[0];
            this.CreatedDateTime = DateTime.Parse(strings[1]);
            this.FullName = strings[2];
            this.Age = int.Parse(strings[3]);
            this.Height = int.Parse(strings[4]);
            this.DateOfBirth = DateTime.Parse(strings[5]);
            this.PlaceOfBirth = strings[6];
        } else {
            throw new Exception($"strings lenght not 7");
        }
    }

    public string GetLineWriteToFile() {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(Id + "#");
        stringBuilder.Append(CreatedDateTime + "#");
        stringBuilder.Append(FullName + "#");
        stringBuilder.Append(Age + "#");
        stringBuilder.Append(Height + "#");
        stringBuilder.Append(DateOfBirth + "#");
        stringBuilder.Append(PlaceOfBirth);
        return stringBuilder.ToString();
    }

    public override string ToString() {
        return $"{nameof(Id)}: {Id}, {nameof(CreatedDateTime)}: {CreatedDateTime}, {nameof(FullName)}: {FullName}, {nameof(Age)}: {Age}, {nameof(Height)}: {Height}, {nameof(DateOfBirth)}: {DateOfBirth}, {nameof(PlaceOfBirth)}: {PlaceOfBirth}";
    }
}