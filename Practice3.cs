namespace CsharpSB_Project;
internal class Practice3 {
    private static void Task01() {
        Console.WriteLine("---Task01");
        Console.Write("Enter number: ");
        int number = int.Parse(Console.ReadLine());
        if (number % 2 == 0) {
            Console.WriteLine($"{number} is even number");
        }
        else {
            Console.WriteLine($"{number} is odd number");
        }
    }

    private static void Task02() {
        Console.WriteLine("---Task02");
        Console.Write("Введите колличество карт: ");
        int cardCount = int.Parse(Console.ReadLine());
        int total = 0;
        for (int k = 0; k < cardCount; k++) {
            Console.WriteLine("Напиши карту, в виде (6,7,8,9,10) или (J,Q,K,T)");
            string enterValue = Console.ReadLine();
            if (int.TryParse(enterValue, out var enterNumber)) {
                switch (enterNumber) {
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                        total += enterNumber;
                        break;
                    default:
                        Console.Write("Вы ввели что-то неправильноe");
                        k--;
                        break;
                }
            }
            else {
                if (enterValue == "J") {
                    total += 2;
                }
                else if (enterValue == "Q") {
                    total += 3;
                }
                else if (enterValue == "K") {
                    total += 4;
                }
                else if (enterValue == "T") {
                    if (total == 20) {
                        total += 1;
                    }
                    else {
                        total += 11;
                    }
                }
                else {
                    Console.Write("Вы ввели что-то неправильноe");
                    k--;
                }
                /*switch (enterValue) {
                    case "J":
                        total += 2;
                        break;
                    case "Q":
                        total += 3;
                        break;
                    case "K":
                        total += 4;
                        break;
                    case "T":
                        if (total == 20) {
                            total += 1;
                        } else {
                            total += 11;
                        }
                        break;
                    default:
                        Console.Write("Что то не то ты ввел.");
                        k--;
                        break;
                }*/
            }
        }
        Console.WriteLine("Total: " + total);
    }

    private static void Task03() {
        Console.WriteLine("---Task03");
        Console.Write("Введите число: ");
        int number = int.Parse(Console.ReadLine());
        bool numberIsSimple = number > 1 ? true : false;
        int k = 2;
        while (k < number - 1) {
            if (number % k == 0) {
                numberIsSimple = false;
                break;
            }
            k++;
        }
        if (numberIsSimple) {
            Console.WriteLine($"{number} простое число!");
        }
        else {
            Console.WriteLine($"{number} не простое число!");
        }
    }

    private static void Task04() {
        Console.WriteLine("---Task04");
        Console.Write("Введите длину последовательности: ");
        int count = int.Parse(Console.ReadLine());
        int minValue = Int32.MaxValue;
        for (int k = 0; k < count; k++) {
            Console.Write("Введите число: ");
            int number = int.Parse(Console.ReadLine());
            if (number < minValue) {
                minValue = number;
            }
        }
        Console.WriteLine($"minValue: {minValue}");
    }

    private static void Task05() {
        Console.WriteLine("---Task05");
        Console.Write("Введите максимальное целое число диапазона: ");
        int maxValue = int.Parse(Console.ReadLine());
        Random random = new Random();
        int generateNumber = random.Next(0, maxValue + 1);
        int tryCount = 0;
        do {
            tryCount++;
            Console.Write("Введите число: ");
            string enterString = Console.ReadLine();
            if (enterString.Length == 0) {
                break;
            }
            int enterNumber = int.Parse(enterString);
            if (generateNumber < enterNumber) {
                Console.WriteLine("Загаданое число меньше!");
            }
            else if (generateNumber > enterNumber) {
                Console.WriteLine("Загаданое число больше!");
            }
            else {
                Console.WriteLine("Ты угадал!");
                break;
            }
        } while (true);
        Console.WriteLine($"Загаданое число: {generateNumber}, число попыток: {tryCount}");
    }
}