namespace PracticalTasks
{
    public class Program
    {
        private static int MaxUnequalChar(string userString)
        {
            int stringLength = userString.Length;
            int result = 0;

            for (int i = 0; i < stringLength; i++)
            {
                bool[] checkedChars = new bool[256];

                for (int j = i; j < stringLength; j++)
                {
                    if (checkedChars[userString[j]] == true)
                    {              
                        break;
                    }
                    else
                    {
                        result = Math.Max(result, j - i + 1);    
                        checkedChars[userString[j]] = true;
                    }
                }
                checkedChars[userString[i]] = false;
            }
            return result;
        }

        static void Main(string[] args)
        {         
            Console.WriteLine("Please type a sequence of symbols...");

            var getSequence = Convert.ToString(Console.ReadLine());            

            int maxNumber = MaxUnequalChar(getSequence);

            Console.WriteLine($"The maximum number of unequal consecutive characters is: {maxNumber}");
        }        
    }      
    }
}