namespace Conversion_Backend;
class Program
{
    static int binaryToDecimal(string input)
    {
        int answer = 0;
        for (int n = input.Length - 1; n >= 0; n--) // Iterates over each character in input string, starting from the end of the string
        {
            int binary = Int32.Parse(input[n].ToString()); // Gets the value of the int
            answer += (Convert.ToInt32(Math.Pow(2, n)) * binary); // Uses the formula to get answer
        }
        return answer;
    }
    static int hexToDecimal(string input)
    {
        int answer = 0;
        for (int n = input.Length - 1; n >= 0; n--) // Iterates over each character in input string, starting from the end of the string
        {
            char hex = input[n]; // Gets the value of the int
            int number = 0;

            if (hex >= '0' && hex <= '9') // Gets the value of the number from the hex conversion table
            {
                number = hex - '0';
            }
            else if (hex >= 'A' && hex <= 'F')
            {
                number = hex - 'A' + 10;
            }
            answer += (Convert.ToInt32(Math.Pow(16, n)) * number); // Uses the formula to get answer
        }
        return answer;
    }
    static int octalToDecimal(string input)
    {
        int answer = 0;
        int powerOfEight = 1; // Used to store the current power of eight, as the usual Math.Pow method will produce rounding errors
        for (int n = input.Length - 1; n >= 0; n--) // Iterates over each character in input string, starting from the end of the string
        {
            int octal = input[n] - '0';
            answer += octal * powerOfEight; // Uses the formula to get answer
            powerOfEight *= 8; // Increases the power by 1 e.g 8*8 + *8
        }
        return answer;
    }
    static int[] textToDecimal(string input)
    {
        int[] answer = new int[input.Length];
        for (int n = 0; n <= input.Length-1; n++) // Iterates over each character in input string
        {
            int Char = input[n]; // Gets the value of the int
            answer[n] = Convert.ToInt32(Char); // Uses the formula to get the answer
        }
        return answer;
    }
    static string decimalToHex(int input)
    {
        string answer = "";
        while (input > 0)
        {
            int remainder = input % 16; // Gets the remainder of the input number divided by 16, will be between 0 and 15
            char hex;
            if (remainder < 10)  // Converts the rnumber into the hex digit using the conversion table
            {
                hex = (char)(remainder + '0');
            }
            else
            {
                hex = (char)(remainder - 10 + 'A');
            }
            answer = hex + answer; // Adds the hex digit to the answer string, inserting it at the start of the string
            input /= 16;
        }
        return answer;
    }
    static string binaryToHex(string input)
    {
        // To convert binary to hex, you must convert to decimal, then to hex
        // As these functions have already been created, this simply uses those functions to acquire the answer.
        int number = binaryToDecimal(input);
        string answer = decimalToHex(number);
        return answer;
    }
    static string octalToHex(string input)
    {
        // Like binary to hex, with octal to hex you must convert to decimal, then to hex
        // As these functions have already been created, this simply uses those functions to acquire the answer.
        int number = octalToDecimal(input);
        string answer = decimalToHex(number);
        return answer;
    }
    static string[] textToHex(string input)
    {
        // To convert text to hex, you need to convert each individual char into decimal, then into hex
        // Thus we will use the function textToDecimal, and then convert each individual decimal into hex
        string[] answer = new string[input.Length];
        int[] numbers = textToDecimal(input); // Converts string into list of decimal numbers
        for (int n = 0; n <= numbers.Length-1; n++) // Iterates over each number in list
        {
            answer[n] = decimalToHex(numbers[n]);
        }
        return answer;
    }
    static string rgbToHex(string input)
    {
        string answer = "";
        string[] numbers = input.Split(", "); // Splits the string into list of numbers
        foreach (string num in numbers) // Iterates over each number into list
        {
            int number = Int32.Parse(num);
            answer += decimalToHex(number); // Convers decimal number into hex and adds to the string
        }
        answer = $"#{answer}";
        return answer;
    }
    static string decimalToBinary(int input)
    {
        string answer = "";
        while (input > 0)
        {
            int remainder = input % 2; // Gets the remainder of the input number divided by 2. Will only give 1 or 0
            answer = remainder.ToString() + answer; // Adds remainder to the binary number
            input /= 2; // Divides the number by 2
        }
        return answer;
    }
    static string hexToBinary(string input)
    {
        // To convert hex to binary, you need to convert each individual char into decimal, then into binary
        // As these functions have already been created, this simply uses those functions to acquire the answer.
        string binary = "";
        foreach (char Char in input) // Iterates over each hex character in the string
        {
            int number = hexToDecimal(Char.ToString());
            string nibble = "";
            for (int i = 0; i < 4; i++) // Uses loop to create the nibble, as regular binary conversion would not give the correct form
            {
                nibble = (number % 2) + nibble; // Does decimal to binary calculation
                number /= 2;
            }
            binary += nibble;
            }
        return binary;
    }
    static string octalToBinary(string input)
    {
        // To convert octal to binary, you need to convert each individual char into decimal, then into binary
        // As these functions have already been created, this simply uses those functions to acquire the answer.
        string answer = "";
        foreach (char Char in input) // Iterates over each hex character in the string
        {
            int number = octalToDecimal(Char.ToString());
            string binary = "";
            for (int i = 0; i < 3; i++) // Uses loop to create the binary, as regular binary conversion would not give the correct form
            {
                binary = (number % 2) + binary; // Does decimal to binary calculation
                number /= 2;
            }
            answer += binary;
            }
        return answer.TrimStart('0'); // Removes the zeros at the start of the binary number as they are not needed
    }
    static string textToBinary(string input)
    {
        string answer = "";
        for (int n = 0; n <= input.Length-1; n++) // Iterates over each character in input string
        {
            int Char = input[n]; // Gets the value of the int
            answer += decimalToBinary(Char) + " ";
        }
        return answer.Remove(answer.Length - 1); // Removes final space from string
    }
    static void Main(string[] args)
    {
        Console.WriteLine("1)    Binary to Decimal");
        Console.WriteLine("2)    Hexadecimal to Decimal");
        Console.WriteLine("3)    Octal to Decimal");
        Console.WriteLine("4)    Text to Decimal");
        Console.WriteLine("5)    Decimal to Hexadecimal");
        Console.WriteLine("6)    Binary to Hexadecimal");
        Console.WriteLine("7)    Octal to Hexadecimal");
        Console.WriteLine("8)    Text to Hexadecimal");
        Console.WriteLine("9)    RGB to Hexadecimal");
        Console.WriteLine("10)   Decimal to Binary");
        Console.WriteLine("11)   Hexadecimal to Binary");
        Console.WriteLine("12)   Octal to Binary");
        Console.WriteLine("13)   Text to Binary");
        int Option = Convert.ToInt32(Console.ReadLine());
        string input;
        string outputString = "";
        switch (Option)
        {
        case 1:
            Console.Write("Enter Binary Number: ");
            input = Console.ReadLine();
            Console.WriteLine($"Answer: {binaryToDecimal(input)}");
            break;
        case 2:
            Console.Write("Enter Hexadecimal Number: ");
            input = Console.ReadLine();
            Console.WriteLine($"Answer: {hexToDecimal(input)}");
            break;
        case 3:
            Console.Write("Enter Octal Number: ");
            input = Console.ReadLine();
            Console.WriteLine($"Answer: {octalToDecimal(input)}");
            break;
        case 4:
            Console.Write("Enter Text: ");
            input = Console.ReadLine();
            foreach (int n in textToDecimal(input))
            {
                outputString += $"{n} ";
            }
            Console.WriteLine($"Answer: {outputString.Remove(outputString.Length -1)}");
            break;
        case 5:
            Console.Write("Enter Decimal Number: ");
            input = Console.ReadLine();
            Console.WriteLine($"Answer: {decimalToHex(Int32.Parse(input))}");
            break;
        case 6:
            Console.Write("Enter Binary Number: ");
            input = Console.ReadLine();
            Console.WriteLine($"Answer: {binaryToHex(input)}");
            break;
        case 7:
            Console.Write("Enter Octal Number: ");
            input = Console.ReadLine();
            Console.WriteLine($"Answer: {octalToHex(input)}");
            break;
        case 8:
            Console.Write("Enter Text: ");
            input = Console.ReadLine();
            foreach (string n in textToHex(input))
            {
                outputString += $"{n} ";
            }
            Console.WriteLine($"Answer: {outputString.Remove(outputString.Length -1)}");
            break;
        case 9:
            Console.Write("Enter RGB Code (255, 255, 255): ");
            input = Console.ReadLine();
            Console.WriteLine($"Answer: {rgbToHex(input)}");
            break;
        case 10:
            Console.Write("Enter Decimal Number: ");
            input = Console.ReadLine();
            Console.WriteLine($"Answer: {decimalToBinary(Convert.ToInt32(input))}");
            break;
        case 11:
            Console.Write("Enter Hexadecimal Number: ");
            input = Console.ReadLine();
            Console.WriteLine($"Answer: {hexToBinary(input)}");
            break;
        case 12:
            Console.Write("Enter Octal Number: ");
            input = Console.ReadLine();
            Console.WriteLine($"Answer: {octalToBinary(input)}");
            break;
        case 13:
            Console.Write("Enter Text: ");
            input = Console.ReadLine();
            Console.WriteLine($"Answer: {textToBinary(input)}");
            break;
        }
    }
}
