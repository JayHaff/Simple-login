using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.Windows;
using login.Models;

namespace login.ViewModels
{
     public class SignInViewModel : Screen
    {
        private string _userName;
        private string _password;

        public string UserName
        {
            get
            {
                return _userName;
            }

            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);



            }

        }


        public string Password
        {
            get
            {
                return _password;
            }
            set
            {

                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }


        public void SignIn()
        {
            

            Conductor conductor = new Conductor();

            if(conductor.LogIn(_userName,_password))
            {
                MessageBox.Show("Login Sucessfull!");
                Password = "";
                UserName = "";
            }
            else
            {
                MessageBox.Show("wrong User name or Password");
            }
        }




     }
}
