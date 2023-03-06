using PracticalTasks.Models;

namespace PracticalTasks.Services
{
    public class EmailCreator
    {        
        public static readonly string subjectOne = "email.subjectOne";
        public static readonly string subjectTwo = "email.subjectTwo";
        public static readonly string bodyOne = "email.bodyOne";
        public static readonly string bodyTwo = "email.bodyTwo";

        public static Email CreateEmailOne()
        {
            return new Email(TestDataReader.GetTestData(subjectOne), TestDataReader.GetTestData(bodyOne));
        }

        public static Email CreateEmailTwo()
        {
            return new Email(TestDataReader.GetTestData(subjectTwo), TestDataReader.GetTestData(bodyTwo));
        }
    }
}