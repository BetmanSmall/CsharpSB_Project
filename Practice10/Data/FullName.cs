using System.Text.Json;
using System.Text.Json.Serialization;

namespace CsharpSB_Project.Practice10.Data;
public class FullName {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SurName { get; set; }

    [JsonConstructor]
    public FullName() {
    }

    public FullName(int index) {
        FirstName = "FirstName_" + index;
        LastName = "LastName_" + index;
        SurName = "SurName_" + index;
    }

    public override string ToString() {
        return JsonSerializer.Serialize(this);
    }
}