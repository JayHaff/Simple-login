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
    public class SignUpViewModel : Screen
    {
        private string _userName = "";
        private string _password;
        private string _passwordCheck;
        private string _lengthColor;
        private string _capColor;
        private string _specialColor;
        private string _matchColor;

        private bool _checkLength;
        private bool _checkCap;
        private bool _checkSpecial;
        private bool _checkMatch;

      
        

        public SignUpViewModel()
        {
            _lengthColor = "Firebrick";
            _capColor = "Firebrick";
            _specialColor = "Firebrick";
            _matchColor = "Firebrick";

            NotifyOfPropertyChange(() => LengthColor);
            NotifyOfPropertyChange(() => CapColor);
            NotifyOfPropertyChange(() => SpecialColor);
            NotifyOfPropertyChange(() => MatchColor);
        }

        public bool CheckLength
        {
            get
            {
                return _checkLength;

            }
            set
            {
                
            }

        }

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
                NotifyOfPropertyChange(() => CanSignUp);

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

                if (_password.Length >= 8)
                {
                    _checkLength = true;
                    _lengthColor = "Green";
                }
                
                else
                {
                    _checkLength = false;
                    _lengthColor = "Firebrick";
                }


                if (_password.Any(char.IsUpper))
                {
                    _checkCap = true;
                    _capColor = "Green";
                }

                else
                {
                    _checkCap = false;
                    _capColor = "Firebrick";
                }
                   
                if (Regex.IsMatch(Password, "[!@#$%^&*?]"))
                {
                    _checkSpecial = true;
                    _specialColor = "Green";
                }

                else
                {
                    _checkSpecial = false;
                    _specialColor = "Firebrick";
                }


                NotifyOfPropertyChange(() => CanSignUp);
                NotifyOfPropertyChange(() => CheckLength);
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CheckCap);
                NotifyOfPropertyChange(() => CheckSpecial);
                NotifyOfPropertyChange(() => LengthColor);
                NotifyOfPropertyChange(() => CapColor);
                NotifyOfPropertyChange(() => SpecialColor);
 
            }
        }

        public bool CanSignUp
        {
          
            get
            {
                return (_checkLength && _checkCap && _checkSpecial && _checkMatch && _userName.Length > 0);
            }

        }

        public void SignUp()
        {
            Conductor conductor = new Conductor();

            if(conductor.AddUser(_userName,_password))
            {
                MessageBox.Show("User Added");
                Password = "";
                UserName = "";
            }
            else
                MessageBox.Show("User Id already exsit");

            


        }

        public bool CheckCap
        {
            get
            {
                return _checkCap;
            }

        }

        public bool CheckSpecial
        {
            get
            {
                return _checkSpecial;
            }

        }

        public string PasswordCheck
        {
            get
            {
                return _passwordCheck;
            }

            set
            {
                _passwordCheck = value;

                if (_password == _passwordCheck)
                {
                    _checkMatch = true;
                    _matchColor = "Green";
                }

                else
                {
                    _checkMatch = false;
                    _matchColor = "Firebrick";
                }

                NotifyOfPropertyChange(() => CanSignUp);
                NotifyOfPropertyChange(() => CheckMatch);
                NotifyOfPropertyChange(() => MatchColor);

            }
        }

        public bool CheckMatch
        {
            get
            {
                return _checkMatch;
            }
        }

        public string LengthColor
        {
            get
            {
                return _lengthColor;
            }
        }

        public string CapColor
        {
            get
            {
                return _capColor;
            }
        }

        public string SpecialColor
        {
            get
            {
                return _specialColor;
            }
        }

        public string MatchColor
        {
            get
            {
                return _matchColor;
            }
        }
  
    }
}
