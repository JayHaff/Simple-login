using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using login.Models;
using login.Views;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using login.Utils;

namespace login.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {

        public void SignUp()
        {
            
            ActivateItem(new SignUpViewModel());
        }

        public void SignIn()
        {
            ActivateItem(new SignInViewModel());
        }
    }
}
