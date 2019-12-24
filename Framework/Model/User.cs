using System;

namespace WebDriver.Model
{
    public class User
    {
        public string USER_EMAIL { get; set; }
        public string USER_PASSWD { get; set; }
        
        public User(string email, string passwd)
        {
            USER_EMAIL = email;
            USER_PASSWD = passwd;
        }

        //        public override bool Equals(object obj)
//        {
//            return base.Equals(obj);
//        }
//
//        public override int GetHashCode()
//        {
//            return base.GetHashCode();
//        }
//
//        public override string ToString()
//        {
//            return base.ToString();
//        }
    }
}
