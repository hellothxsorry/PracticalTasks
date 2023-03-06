namespace PracticalTasks.Models
{
    public class Email
    {
        public string Subject { get; set; }
        public string Message { get; set; }

        public Email(string subject, string message)
        {
            Subject = subject;
            Message = message;
        }
    }
}