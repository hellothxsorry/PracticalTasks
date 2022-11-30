namespace PracticalTasks
{
    public class Program
    {
        static int maxUnequalChar(string str)
        {
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

        static void Main(string[] args)
        {
            Console.WriteLine("Please type a sequence of symbols...");

            var getSequence = Convert.ToString(Console.ReadLine());

            int maxNum = maxUnequalChar(getSequence);

            Console.WriteLine("The maximum number of unequal consecutive characters is: " + maxNum);
        }        
    }
}
