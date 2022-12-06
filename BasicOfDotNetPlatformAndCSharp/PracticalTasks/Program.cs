namespace PracticalTasks
{
    public class Program
    {
        static void Main(string[] args)
        {
            StartProcess();
        }

        private static void StartProcess()
        {            
            string[] numeralSystem = {"Binary", "Ternary", "Quaternary", "Quinary", "Senary", "Septenary",
                "Octal", "Nonary", "Decimal", "Undecimal", "Duodecimal", "Tridecimal", "Tetradecimal",
                "Pentadecimal", "Hexadecimal", "Heptadecimal", "Octodecimal", "Enneadecimal", "Vigesimal"};
            
            int chosenSystem = 0;

            Console.WriteLine("Please enter any integer number as a decimal: ");

            int getNumber;

            while (!Int32.TryParse(Console.ReadLine(), out getNumber))
            {
                Console.WriteLine("Invalid input. Please enter an integer number and try again.");
            }            

            Console.WriteLine("\n" + "Please choose a new numeral system (by typing 2-20) to convert your number: ");

            for (int i = 0; i < 19; i++)
            {
                Console.WriteLine((i + 2) + ". " + numeralSystem[i]);
            }            

            int getSystem;

            while (!Int32.TryParse(Console.ReadLine(), out getSystem) || getSystem < 2 || getSystem > 20)
            {
                Console.WriteLine("Invalid input. Please enter any integer number from 2 to 20: ");
            }

            chosenSystem = getSystem - 2;    

            Console.WriteLine($"\nOriginal input number: {getNumber}");
            Console.WriteLine($"{getNumber} in {numeralSystem[chosenSystem]} system equals to {ConvertNumber(getNumber, getSystem)}\n");   
            
            StartProcess();
        }

        private static string ConvertNumber(int inputNumber, int newBase)
        {
            string str = "";

            while (inputNumber > 0)
            {
                str += ReturnValue(inputNumber % newBase);
                inputNumber /= newBase;
            }

            char[] result = str.ToCharArray();
            Array.Reverse(result);
            return new string(result);
        }

        private static char ReturnValue(int number)
        {
            if (number >= 0 && number <= 9)
            {
                return (char)(number + 48);
            }
            else
            {
                return (char)(number - 10 + 65);
            }
        }
    }
}