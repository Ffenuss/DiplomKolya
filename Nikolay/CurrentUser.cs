using Nikolay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikolay
{
    public class CurrentUser
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public CurrentUser(int userId, string username)
        {
            UserId = userId;
            Username = username;
        }
    }
}
