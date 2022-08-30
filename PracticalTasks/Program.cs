namespace PracticalTasks
{
    //Create a program that takes an integer in decimal, and a new base number system (from 2 to 20) from the command line.
    //Print the original number converted to this system to the console.

    internal class Program
    {
        static void Main(string[] args)
        {
            startProc();
        }

        private static void startProc()
        {            
            string[] numeralSys = {"Binary", "Ternary", "Quaternary", "Quinary", "Senary", "Septenary",
                "Octal", "Nonary", "Decimal", "Undecimal", "Duodecimal", "Tridecimal", "Tetradecimal",
                "Pentadecimal", "Hexadecimal", "Heptadecimal", "Octodecimal", "Enneadecimal", "Vigesimal"};

            string finalOutput = "";
            int chosenSys = 0;

            Console.WriteLine("Please enter any integer number as a decimal: ");

            int getNum;

            while (!Int32.TryParse(Console.ReadLine(), out getNum))
            {
                Console.WriteLine("Invalid input. Please enter an integer number and try again.");
            }            

            Console.WriteLine("\n" + "Please choose a new numeral system (by typing 2-20) to convert your number: ");

            for (int i = 0; i < 19; i++)
            {
                Console.WriteLine((i + 2) + ". " + numeralSys[i]);
            }            

            int getSys;

            while (!Int32.TryParse(Console.ReadLine(), out getSys) || getSys < 2 || getSys > 20)
            {
                Console.WriteLine("Invalid input. Please enter any integer number from 2 to 20: ");
            }

            chosenSys = getSys - 2;    

            Console.WriteLine(Environment.NewLine + "Original input number: " + getNum);
            Console.WriteLine(getNum + " in " + numeralSys[chosenSys] + " system equals to " + convertNum(getNum, getSys) + Environment.NewLine);   
            
            startProc();
        }

        private static string convertNum(int inputNum, int newBase)
        {
            string str = "";

            while (inputNum > 0)
            {
                str += returnValue(inputNum % newBase);
                inputNum /= newBase;
            }

            char[] result = str.ToCharArray();
            Array.Reverse(result);
            return new string(result);
        }

        private static char returnValue(int num)
        {
            if (num >= 0 && num <= 9)
            {
                return (char)(num + 48);
            }
            else
            {
                return (char)(num - 10 + 65);
            }
        }
    }
}