namespace WebDriver.Model
{
    public class Request
    {
        public string Email { get; set; }
        public string ProblemName { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        
        public Request(string email, string problemName, string subject, string description)
        {
            Email = email;
            ProblemName = problemName;
            Subject = subject;
            Description = description;
        }
        
        
    }
}