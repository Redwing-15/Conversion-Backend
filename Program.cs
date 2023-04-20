namespace Conversion_Backend;
class Program
{
    static int binaryToDecimal(string input)
    {
        int answer = 0;
        int power = 1; // Used to store the current power, as using Math.Pow will produce rounding errors
        for (int n = input.Length - 1; n >= 0; n--) // Iterates over each character in input string, starting from the end of the string
        {
            int binary = Int32.Parse(input[n].ToString()); // Gets the value of the int
            answer += binary * power; // Uses the formula to get answer
            power *= 2; // Increases the power by factor of 1
        }
        return answer;
    }
    static int hexToDecimal(string input)
    {
        int answer = 0;
        int power = 1; // Used to store the current power, as using Math.Pow will produce rounding errors
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
            answer += number * power; // Uses the formula to get answer
            power *= 16; // Increases the power by factor of 1
        }
        return answer;
    }
    static int octalToDecimal(string input)
    {
        int answer = 0;
        int power = 1; // Used to store the current power, as using Math.Pow will produce rounding errors
        for (int n = input.Length - 1; n >= 0; n--) // Iterates over each character in input string, starting from the end of the string
        {
            int octal = input[n] - '0';
            answer += octal * power; // Uses the formula to get answer
            power *= 8; // Increases the power by factor of 1
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
    static string decimalToText(List<int> input)
    {
        string answer = "";
        foreach (int num in input)
        {
            answer += ((char)num).ToString(); // This very simply uses the built in function to convert decimal into ascii.
        }
        return answer;
    }
    static string binaryToText(List<string> input)
    {
        List<int> numbers = new List<int>();
        foreach (string binary in input) // Loops over each binary number
        {
            numbers.Add(binaryToDecimal(binary)); // Converts and adds to list of decimal numbers to perform decimal to text calculation
        }
        return decimalToText(numbers);
    }
    static string hexToText(List<string> input)
    {
        List<int> numbers = new List<int>();
        foreach (string hex in input) // Loops over each hex number
        {
            numbers.Add(hexToDecimal(hex)); // Converts and adds to list of decimal numbers to perform decimal to text calculation
        }
        return decimalToText(numbers);
    }
    static string octalToText(List<string> input)
    {
        List<int> numbers = new List<int>();
        foreach (string octal in input) // Loops over each octal number
        {
            numbers.Add(octalToDecimal(octal)); // Converts and adds to list of decimal numbers to perform decimal to text calculation
        }
        return decimalToText(numbers);
    }
    static string decimalToOctal(int input)
    {
        string answer = "";
        int remainder;

        while (input != 0)
        {
            remainder = input % 8; // Gets the remainder of the input divided by 8
            input = input / 8; // Divides the number by 8
            answer = remainder.ToString() + answer; // Adds the number to the start of the answer
        }
        return answer;
    }
    static string binaryToOctal(string input)
    {
        // To convert binary to octal, you must convert to decimal, then to octal
        // As these functions have already been created, this simply uses those functions to acquire the answer.
        int number = binaryToDecimal(input);
        string answer = decimalToOctal(number);
        return answer;
    }
    static string hexToOctal(string input)
    {
        // To convert hex to octal, you must convert to decimal, then to octal
        // As these functions have already been created, this simply uses those functions to acquire the answer.
        int number = hexToDecimal(input);
        string answer = decimalToOctal(number);
        return answer;
    }
    static string[] textToOctal(string input)
    {
        // To convert text to octal, you need to convert each individual char into decimal, then into octal
        // Thus we will use the function textToDecimal, and then convert each individual decimal into octal
        string[] answer = new string[input.Length];
        int[] numbers = textToDecimal(input); // Converts string into list of decimal numbers
        for (int n = 0; n <= numbers.Length-1; n++) // Iterates over each number in list
        {
            answer[n] = decimalToOctal(numbers[n]);
        }
        return answer;
    }
    static string hexToRGB(string input)
    {
        string answer = "";
        answer += $"{hexToDecimal(input.Substring(0, 2))}, ";
        answer += $"{hexToDecimal(input.Substring(2, 2))}, ";
        answer += hexToDecimal(input.Substring(4, 2));
        // Console.WriteLine($"{r}, {g}, {b}");
        return answer;
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
        Console.WriteLine("14)   Decimal to Text");
        Console.WriteLine("15)   Binary to Text");
        Console.WriteLine("16)   Hexadecimal to Text");
        Console.WriteLine("17)   Octal to Text");
        Console.WriteLine("18)   Decimal to Octal");
        Console.WriteLine("19)   Binary to Octal");
        Console.WriteLine("20)   Hexadecimal to Octal");
        Console.WriteLine("21)   Text to Octal");
        Console.WriteLine("22)   Hexadecimal to RGB");
        int Option = Convert.ToInt32(Console.ReadLine());
        if (Option == 1)
        {
            Console.Write("Enter Binary Number: ");
            string input = Console.ReadLine();
            Console.WriteLine($"Answer: {binaryToDecimal(input)}");
        }
        else if (Option == 2)
        {
            Console.Write("Enter Hexadecimal Number: ");
            string input = Console.ReadLine();
            Console.WriteLine($"Answer: {hexToDecimal(input)}");
        }
        else if (Option == 3)
        {
            Console.Write("Enter Octal Number: ");
            string input = Console.ReadLine();
            Console.WriteLine($"Answer: {octalToDecimal(input)}");
        }
        else if (Option == 4)
        {
            Console.Write("Enter Text: ");
            string input = Console.ReadLine();
            string outputString = "";
            foreach (int n in textToDecimal(input))
            {
                outputString += $"{n} ";
            }
            Console.WriteLine($"Answer: {outputString.Remove(outputString.Length - 1)}");
        }
        else if (Option == 5)
        {
            Console.Write("Enter Decimal Number: ");
            string input = Console.ReadLine();
            Console.WriteLine($"Answer: {decimalToHex(Int32.Parse(input))}");
        }
        else if (Option == 6)
        {
            Console.Write("Enter Binary Number: ");
            string input = Console.ReadLine();
            Console.WriteLine($"Answer: {binaryToHex(input)}");
        }
        else if (Option == 7)
        {
            Console.Write("Enter Octal Number: ");
            string input = Console.ReadLine();
            Console.WriteLine($"Answer: {octalToHex(input)}");
        }
        else if (Option == 8)
        {
            Console.Write("Enter Text: ");
            string input = Console.ReadLine();
            string outputString = "";
            foreach (string n in textToHex(input))
            {
                outputString += $"{n} ";
            }
            Console.WriteLine($"Answer: {outputString.Remove(outputString.Length - 1)}");
        }
        else if (Option == 9)
        {
            Console.Write("Enter RGB Code (255, 255, 255): ");
            string input = Console.ReadLine();
            Console.WriteLine($"Answer: {rgbToHex(input)}");
        }
        else if (Option == 10)
        {
            Console.Write("Enter Decimal Number: ");
            string input = Console.ReadLine();
            Console.WriteLine($"Answer: {decimalToBinary(Convert.ToInt32(input))}");
        }
        else if (Option == 11)
        {
            Console.Write("Enter Hexadecimal Number: ");
            string input = Console.ReadLine();
            Console.WriteLine($"Answer: {hexToBinary(input)}");
        }
        else if (Option == 12)
        {
            Console.Write("Enter Octal Number: ");
            string input = Console.ReadLine();
            Console.WriteLine($"Answer: {octalToBinary(input)}");
        }
        else if (Option == 13)
        {
            Console.Write("Enter Text: ");
            string input = Console.ReadLine();
            Console.WriteLine($"Answer: {textToBinary(input)}");
        }
        else if (Option == 14)
        {
            Console.Write("Enter Number: ");
            string input = Console.ReadLine();
            List<int> numbers = new List<int>();
            if (input.Contains(' ')) // Checks if there is a single number or multiple numbers to convert
            {
                string[] Numbers = input.Split(" "); // Splits string into separate numbers
                foreach (string num in Numbers)
                {
                    numbers.Add(Int32.Parse(num)); // Converts each into an int
                }
            }
            else
            {
                numbers.Add(Int32.Parse(input)); // If no spaces detected, adds the whole input as 1 number
            }
            Console.WriteLine($"Answer: {decimalToText(numbers)}");
        }
        else if (Option == 15)
        {
            Console.Write("Enter Binary Number: ");
            string input = Console.ReadLine();
            List<string> numbers = new List<string>();
            if (input.Contains(' '))
            {
                string[] Numbers = input.Split(" ");
                foreach (string num in Numbers)
                {
                    numbers.Add(num);
                }
            }
            else if (input.Length > 8)
            {
                Console.WriteLine("This method of input not supported. Please space the numbers");
            }
            else
            {
                numbers.Add(input);
            }
            Console.WriteLine($"Answer: {binaryToText(numbers)}");
        }
        else if (Option == 16)
        {
            Console.Write("Enter Hexadecimal Number: ");
            string input = Console.ReadLine();
            List<string> numbers = new List<string>();
            if (input.Contains(' '))
            {
                string[] Numbers = input.Split(" ");
                foreach (string num in Numbers)
                {
                    numbers.Add(num);
                }
            }
            else if (input.Length > 8)
            {
                Console.WriteLine("This method of input not supported. Please space the numbers");
            }
            else
            {
                numbers.Add(input);
            }
            Console.WriteLine($"Answer: {hexToText(numbers)}");
        }
        else if (Option == 17)
        {
            Console.Write("Enter Octal Number: ");
            string input = Console.ReadLine();
            List<string> numbers = new List<string>();
            if (input.Contains(' '))
            {
                string[] Numbers = input.Split(" ");
                foreach (string num in Numbers)
                {
                    numbers.Add(num);
                }
            }
            else if (input.Length > 8)
            {
                Console.WriteLine("This method of input not supported. Please space the numbers");
            }
            else
            {
                numbers.Add(input);
            }
            Console.WriteLine($"Answer: {octalToText(numbers)}");
        }
        else if (Option == 18)
        {
            Console.Write("Enter Number: ");
            string input = Console.ReadLine();
            Console.WriteLine($"Answer: {decimalToOctal(Int32.Parse(input))}");
        }
        else if (Option == 19)
        {
            Console.Write("Enter Binary Number: ");
            string input = Console.ReadLine();
            Console.WriteLine($"Answer: {binaryToOctal(input)}");
        }
        else if (Option == 20)
        {
            Console.Write("Enter Hexadecimal Number: ");
            string input = Console.ReadLine();
            Console.WriteLine($"Answer: {hexToOctal(input)}");
        }
        else if (Option == 21)
        {
            Console.Write("Enter Text: ");
            string input = Console.ReadLine();
            string outputString = "";
            foreach (string n in textToOctal(input))
            {
                outputString += $"{n} ";
            }
            Console.WriteLine($"Answer: {outputString.Remove(outputString.Length - 1)}");
        }
        if (Option == 22)
        {
            Console.Write("Enter Hexadecimal Number: #");
            string input = Console.ReadLine();
            Console.WriteLine($"Answer: {hexToRGB(input)}");
        }
    }
}