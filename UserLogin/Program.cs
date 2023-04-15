namespace UserLogin
{
    class Program
    {
      
        static void Main(string[] args)
        {
            //У1 - Инициализиране на потребител като администратор
            User user = null;

            //У1 - Логване на потребител
            Console.WriteLine("Enter username");
            String tempUsername = Console.ReadLine();
            Console.WriteLine("Enter password");
            String tempPass = Console.ReadLine();

            
            //У1 - Извеждане на данните на администратор, ако е регистриран
            LoginValidation validation = new LoginValidation(tempUsername, tempPass, printError); 
            if (validation.ValidateUserInput(ref user))
            {
                Console.WriteLine("Username: " + user._username);
                Console.WriteLine("Faculty number: " + user._facultyNumber);
                Console.WriteLine("Password: " + user._password);
           

                Console.Write("Welcome! You are ");
                switch (user._role)
                {
                    case (Int32) UserRoles.ANONYMOUS:
                        Console.WriteLine("not found in our system!");
                    break;

                    case (Int32)UserRoles.STUDENT:
                        Console.WriteLine("a student in our university!");
                    break;

                    case (Int32)UserRoles.ADMIN:
                        Console.WriteLine("an administrator of our university system!");
                        adminMenu();
                    break;

                    case (Int32)UserRoles.INSPECTOR:
                        Console.WriteLine("an inspector in our university!");
                    break;

                    case (Int32)UserRoles.PROFESSOR:
                        Console.WriteLine("a professor in our university!");
                    break;
                }
            }
        }

        public static void printError(string errorMsg)
        {
            Console.WriteLine("!!! " + errorMsg + " !!!");
            Logger.LogActivity("errorMsg");
        }


        private static void adminMenu()
        {
            Int32 command = -1;
            Console.WriteLine("Chose an option:\n0:Exit\n1:Change user role\n2:Change user valid date\n3:List all users\n4.View log");
            command = Int32.Parse(Console.ReadLine());
            string tempUsername = String.Empty;
            Int32 tempRole = -1;
            DateTime date = DateTime.Now;

            switch (command)
            {
                case 1:
                    
                    Console.WriteLine("Username: ");
                    tempUsername = Console.ReadLine();
                    Console.WriteLine("New Role: ");
                    tempRole = Int32.Parse(Console.ReadLine());
                    UserData.assignUserRole(tempUsername, tempRole);
                    break;
                case 2:
                    Console.WriteLine("Username: ");
                    tempUsername = Console.ReadLine();
                    Console.WriteLine("New Datetime: ");
                    date = DateTime.Parse(Console.ReadLine());
                    UserData.setUserActiveTo(tempUsername, date);
                    break;
                case 3:
                    UserData.listAllUsers();
                    break;
                case 4:
                    IEnumerable<string> enumerable = Logger.GetAllActivities();
                    foreach (string activity in enumerable)
                    {
                        Console.WriteLine($"{activity}");
                    }
                    break;
            }
        }
    }

}