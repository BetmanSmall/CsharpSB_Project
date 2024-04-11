using System.Text;

namespace CsharpSB_Project; 
public class Practice5 {
    public static void Task01() {
        Console.WriteLine("-Practice5--Task01-");
        string text = Console.ReadLine();
        string[] strings = SplitText(text, ' ');
        PrintArray(strings);
    }

    private static string[] SplitText(string text, char separator) {
        // string[] arrayStrings = text.Split(separator);
        int whiteSpaceCount = 0;
        foreach (char c in text) {
            if (c.Equals(separator)) whiteSpaceCount++;
        }
        string[] arrayStrings = new string[whiteSpaceCount+1];
        int wordIndex = 0;
        StringBuilder stringBuilder = new StringBuilder();
        for (int j = 0; j < text.Length; j++) {
            char c = text[j];
            if (c != separator) {
                stringBuilder.Append(c);
            } else {
                arrayStrings[wordIndex++] = stringBuilder.ToString();
                stringBuilder.Clear();
            }
        }
        if (stringBuilder.Length > 0) {
            arrayStrings[wordIndex] = stringBuilder.ToString();
        }
        return arrayStrings;
    }

    private static void PrintArray(string[] arrayStrings) {
        foreach (string arrayString in arrayStrings) {
            Console.WriteLine(arrayString);
        }
    }

    public static void Task02() {
        Console.WriteLine("-Practice5--Task02-");
        string enterText = Console.ReadLine();
        Console.WriteLine($"enterText: {enterText}");
        string reversString = ReversWords(enterText);
        Console.WriteLine($"reversString: {reversString}");
    }

    private static string ReversWords(string inputPhrase) {
        string[] strings = SplitText(inputPhrase, ' ');
        string ResultString = String.Empty; 
        for (int i = 0; i < strings.Length; i++) {
            ResultString += strings[strings.Length - 1 - i];
            ResultString += " ";
        }
        return ResultString;
    }
}