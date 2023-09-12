using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuldkortetServer.Models
{
    public class User
    {
        private string userId;
        private string userName;
        private string userKommun;
        public string UserId { get { return userId; } set { userId = value; } }
        public string UserName { get { return userName; } set { userName = value; } }
        public string UserKommun { get { return userKommun; } set { userKommun = value; } }
        public User(string _id, string _username, string _userkommun)
        { // We set the 3 parameters when we create the object in our code. 
            if (_id != "")
            {
                userId = _id;
                userName = _username;
                userKommun = _userkommun;
            }
            else
            {
                MessageBox.Show("Error: Kunde inte skapa användar data.");
            }
        }
    }
}
