using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management_App.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public EUserType Type { get; set; }

        public User(int id, string username, string password, string email, EUserType type)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
            Type = type;
        }
    }
}
