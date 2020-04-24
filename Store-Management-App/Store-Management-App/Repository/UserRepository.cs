using Store_Management_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management_App.Repository
{
    public class UserRepository
    {
        private List<User> users = new List<User>
        {
            new User(1, "diana", "password", "diana@gmail.com", EUserType.ADMIN),
            new User(2, "estera", "password", "estera@gmail.com", EUserType.ADMIN),
            new User(3, "dana", "password", "dana@gmail.com", EUserType.CLIENT)
        };


        private static UserRepository instance = null;
        private static readonly object padlock = new object();

        private UserRepository()
        {

        }

        public static UserRepository Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new UserRepository();
                    }
                    return instance;
                }
            }
        }

        public bool FindUser(string username, string password) {
           return users.Exists(user => user.Username == username && user.Password == password);
        }
    }
}
