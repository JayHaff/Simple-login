using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace login.Models
{
    public class MockDatabase
    { 
  
        private string _pathName;




        public MockDatabase(string _pathName = @"C:\Users\Jay\Desktop\MockDataBase")
        {
            this._pathName = _pathName;

            if (!File.Exists(_pathName))
            {
               var myfile =  File.Create(_pathName);
                myfile.Close();
            }

            
            
        }

        public string PathName
        {
            get
            {
                return _pathName;
            }

            set
            {
                _pathName = value;
                if (!File.Exists(_pathName))
                {
                    File.Create(_pathName);
                }

            }
        }

        public List<UserInfo> GetData()
        {
            
            List<UserInfo> UserList = new List<UserInfo>();

            List<string> lines = File.ReadAllLines(_pathName).ToList();



            foreach (var line in lines)
            {
                string[] entries = line.Split(',');
                if (entries.Length == 2)
                {
                    UserInfo user = new UserInfo();

                    user.UserID = entries[0];
                    user.Password = entries[1];

                    UserList.Add(user);
                }
                else
                    continue;
            }
                return UserList;
   
        }

        public void SetData(List<UserInfo> User)
        {
         

            List<string> output = new List<string>();

            foreach(var x in User)
            {
                output.Add($"{x.UserID},{x.Password}");
            }

            File.WriteAllLines(_pathName, output);

       
        }
            
         


    }
}
