using WebDriver.Model;

namespace WebDriver.Service
{
    public class RequestCreator
    {
        private static readonly string Email = UserCreator.TakeStaticCredentials().USER_EMAIL;
        private static readonly string ProblemName = "There's something wrong with the car I rented";
        private static readonly string Subject = "Lack of extra wheel";
        private static readonly string Description = "Hello. This message is passed by Selenium tools";

        public static Request WithCredentialsAsProperties() => new Request(Email, ProblemName, Subject, Description);
    }
}