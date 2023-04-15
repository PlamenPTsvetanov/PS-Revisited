using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin;

public class LoginValidation
{
    string username;
    string password;
    string errorMessage;

    private ActionOnError action;
    public static UserRoles currentUserRole { get; private set; }
    public static string currentUserUsername { get; private set; }

    public LoginValidation(string inUsername, string inPassword, ActionOnError action)
    {
        username = inUsername;
        password = inPassword;
        this.action = action;   
    }

    public bool ValidateUserInput(ref User user)
    {
        currentUserRole = UserRoles.ANONYMOUS;
        if (username.Equals(String.Empty))
        {
            errorMessage = "Wrong username!";

        } else if (password.Equals(String.Empty))
        {
            errorMessage = "Wrong password!";
        } else if (username.Length < 5)
        {
            errorMessage = "Username too short!";
        }

        User retUser = UserData.IsUserPassCorrect(username, password);

        if (retUser != null)
        {
            user = retUser;
        } else
        {
            errorMessage = "No such user exists!";
        }
        if (errorMessage != null)
        {
            action(errorMessage);
            return false;
        }
        currentUserRole = (UserRoles)user._role;
        currentUserUsername = user._username;
        Logger.LogActivity("Успешен Login");
        return true;
    }

    public delegate void ActionOnError(string errorMsg);
  }