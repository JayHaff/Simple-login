using login.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login.Models
{
    public class Conductor
    {
        private List<UserInfo> userList;
        private MockDatabase mockDB;
        private  string hiddenPass;

        public bool  CheckIfUserExsit(string userName)
        {
            if (userList != null)
            {
                userList.Clear();
            }
            mockDB = new MockDatabase();
            userList = mockDB.GetData();

            foreach (var user in userList)
            {
                if (user.UserID == userName)
                return true;
            }
            return false;
            
        }
        public bool FindUser(string userName)
        {
            if(userList != null)
            {
                userList.Clear();
            }
            
            mockDB = new MockDatabase();
            userList = mockDB.GetData();

            foreach (var user in userList)
            {
                if (user.UserID == userName)
                {
                    hiddenPass = user.Password;
                    return true;

                }
                    

                
            }
            return false;

        }

        public bool AddUser(string userName, string password)
        {
            if(CheckIfUserExsit(userName))
            {
                return false;
            }
            else
            {
                string hashedPass = BcryptHash.HashPassword(password);
                Console.WriteLine(hashedPass + "Here");

                Aes aes = new Aes();

                Console.WriteLine($" key {aes.GetKey()}");
                string cryptPass = aes.EncryptToBase64String(hashedPass);
                Console.WriteLine($" key {aes.GetKey()}");
                Console.WriteLine(aes.DecryptFromBase64String(cryptPass));

                userList.Add(new UserInfo { UserID = userName, Password = cryptPass });

                mockDB.SetData(userList);

                return true;
            }
        }

        public bool LogIn(string user, string pass)
        {
           
            if (FindUser(user))
            {
                Console.WriteLine(hiddenPass);
                Aes aes = new Aes();

                string decryptPass = aes.DecryptFromBase64String(hiddenPass);

                if (BcryptHash.ValidatePassword(pass, decryptPass))
                {
                     return true;
                }

                else
                return false;
            }

            return false;
        }
    }
}
