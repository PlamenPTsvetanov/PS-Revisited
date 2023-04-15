using System.Security.Cryptography;

namespace UserLogin
{
    static public class UserData
    {
        static public List<User> TestUsers { 
            get { 
                ResetTestUserData();
                return _testUsers;
                } 
            set { }
        }
        static private List<User> _testUsers;

        //У1 - Задаваме стойност на тестовия потребител, ако такава липсва
        static private void ResetTestUserData()
        {
            if (_testUsers == null)
            {
                _testUsers = new List<User>();

                User TempUser1 = new User();
                TempUser1._username = "placvetanov";
                TempUser1._facultyNumber = "121220013";
                TempUser1._password = "123123";
                TempUser1._role = 1;
                TempUser1._creationDate= DateTime.Now;
                TempUser1._validTo = DateTime.MaxValue;
                _testUsers.Add(TempUser1);

                User TempUser2 = new User();
                TempUser2._username = "ivivanov";
                TempUser2._facultyNumber = "121220014";
                TempUser2._password = "123123";
                TempUser2._role = 4;
                TempUser2._creationDate = DateTime.Now;
                TempUser2._validTo = DateTime.MaxValue;
                _testUsers.Add(TempUser2);

                User TempUser3 = new User();
                TempUser3._username = "geogeoriev";
                TempUser3._facultyNumber = "121220015";
                TempUser3._password = "123123";
                TempUser3._role = 4;
                TempUser3._creationDate = DateTime.Now;
                TempUser3._validTo = DateTime.MaxValue;
                _testUsers.Add(TempUser3);
            }

        }


        static public User IsUserPassCorrect(string username, string password)
        {
            return (from u in TestUsers where u._username.Equals(username) && u._password.Equals(password) select u).First();
        }

        static public void setUserActiveTo(string username, DateTime dateTime)
        {
            foreach(User user in TestUsers)
            {
                if (user._username.Equals(username))
                {
                    user._validTo = dateTime;
                }
            }
        }

        static public void assignUserRole(string username, Int32 role)
        {
            foreach (User user in TestUsers)
            {
                if (user._username.Equals(username))
                {
                    user._role = role;
                }
            }
        }

        static public void listAllUsers()
        {
            foreach (User user in TestUsers)
            {
                Console.WriteLine(user._username);
            }
        }


        static public bool checkIfPresentUsers()
        {
            UserContext context = new UserContext();
            IEnumerable<User> queryUsers = context.Users;

            int count = queryUsers.Count();

            return count == 0 ? true : false;
        }
        static public void copyTestUsers()
        {
            UserContext context = new UserContext();

            foreach (User user in TestUsers)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();
        }
    }
}
