using System;
using WebDriver.Model;

namespace WebDriver.Service
{
    public class UserCreator
    {
        private static readonly string USER_EMAIL = "bobpixelgun@gmail.com";
        private static readonly string USER_PASSWD = "Romashka_01";

        public static User TakeStaticCredentials() => new User(USER_EMAIL, USER_PASSWD);
        public static User TakeUserEmail() => new User(USER_EMAIL, "");
        public static User TakeUserPasswd() => new User("", USER_PASSWD);

    }
}
