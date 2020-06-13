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




        public MockDatabase()
        {
            this._pathName = pathName();

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

        public string pathName()
        {
            var CurrentDirectory = Directory.GetCurrentDirectory();
           

            int count = 0;
            int index = 0;

            foreach (var letter in CurrentDirectory)
            {
                letter.ToString();
                if (letter.Equals('\\'))
                {
                    Console.WriteLine("here");
                    count += 1;

                }
                index += 1;
                if (count == 3)
                    break;

            }



            var newdirct = CurrentDirectory.Remove(index);

            return newdirct + @"Desktop\MockDataBase";

        }




    }
}
