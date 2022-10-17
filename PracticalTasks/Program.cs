namespace PracticalTasks
{
    internal class Program
    {
        static int maxUnequalChar(string str)
        {
            int strLength = str.Length;
            int result = 0;

            for (int i = 0; i < strLength; i++)
            {
                //Array where each index represents symbols in ASCII codes: e.g. checkedChar[97] represents 'a'.
                //True means that symbol was already met in a substring when we check a sequence of chars for a duplicate.
                bool[] checkedChar = new bool[256];

                //checking char by char until it detects a match with one of the previous steps.
                for (int j = i; j < strLength; j++)
                {
                    if (checkedChar[str[j]] == true)
                    {              
                        //Once the duplicated char is found, stop going further
                        //restart checking the sequence with a shift of the starting point.
                        break;
                    }
                    else
                    {
                        //Comparison of the current max number of unique subsequent chars with a number from a new checking round.
                        //Take the largest one as a new record.
                        result = Math.Max(result, j - i + 1);    
                        //Mark the checked char as present for this round and be ready to be triggered by a duplicate of this char.
                        checkedChar[str[j]] = true;
                    }
                }
                //Reset the array for the next round.
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