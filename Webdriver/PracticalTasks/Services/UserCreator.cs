using PracticalTasks.Models;

namespace PracticalTasks.Services
{
    public class UserCreator
    {
        public static readonly string emailAddressOne = "user.emailAddressOne";
        public static readonly string emailAddressTwo = "user.emailAddressTwo";
        public static readonly string password = "user.password";
        public static readonly string wrongEmailAddress = "user.wrongEmailAddress";
        public static readonly string wrongPassword = "user.wrongPassword";

        public static User CreateUserOne()
        {
            return new User(TestDataReader.GetTestData(emailAddressOne), TestDataReader.GetTestData(password));
        }

        public static User CreateUserTwo()
        {
            return new User(TestDataReader.GetTestData(emailAddressTwo), TestDataReader.GetTestData(password));
        }

        public static User CreateIncorrectUser()
        {
            return new User(TestDataReader.GetTestData(wrongEmailAddress), TestDataReader.GetTestData(wrongPassword));
        }
    }
}