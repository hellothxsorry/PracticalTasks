namespace PracticalTasks
{
    public class Program
    {
        public static int MaxUnequalChars(string str)
        {
            str = str.Replace(" ", "");
            int strLength = str.Length;
            int result = 0;

            for (int i = 0; i < strLength; i++)
            {
                bool[] checkedChar = new bool[256];

                for (int j = i; j < strLength; j++)
                {
                    if (checkedChar[str[j]] == true)
                    {              
                        break;
                    }
                    else
                    {
                        result = Math.Max(result, j - i + 1);    
                        checkedChar[str[j]] = true;
                    }
                }
                checkedChar[str[i]] = false;
            }
            return result;
        }

        public static int MaxIdenticalLetters(string str)
        {
            str = str.ToLower();
            int strLength = str.Length;
            int result = 0;

            for (int i = 0; i < strLength; i++)
            {
                int currentCount = 1;
                if (str[i] < 65 || str[i] > 90 && str[i] < 97 || str[i] > 122) continue;

                for (int j = i + 1; j < strLength; j++)
                {
                    if (str[i] != str[j]) break;
                    currentCount++;
                }

                if (currentCount > result)
                {
                    result = currentCount;
                }
            }

            return result;
        }

        public static int MaxIdenticalDigits(string str)
        {
            int strLength = str.Length;
            int result = 0;

            for (int i = 0; i < strLength; i++)
            {
                int currentCount = 1;
                if (str[i] < 48 || str[i] > 57) continue;

                for (int j = i + 1; j < strLength; j++)
                {
                    if (str[i] != str[j]) break;
                    currentCount++;
                }

                if (currentCount > result)
                {
                    result = currentCount;
                }
            }

            return result;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Please type a sequence of symbols...");

            var getSequence = Convert.ToString(Console.ReadLine());

            int maxNumUnequalChars = MaxUnequalChars(getSequence);
            int maxNumIdenticalLetters = MaxIdenticalLetters(getSequence);
            int maxNumIdenticalDigits = MaxIdenticalDigits(getSequence);

            Console.WriteLine($"Original sequence: {getSequence}" +
                $"\nThe maximum number of unequal consecutive characters is: {maxNumUnequalChars}" +
                $"\nThe maximum number of identical consecutive Latin letters in line is: {maxNumIdenticalLetters}" +
                $"\nThe maximum number of identical consecutive digits is: {maxNumIdenticalDigits}");
        }        
    }
}
