using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach_client.model.dto
{
    public class UserResponse
    {
        public long Id { get; set; } 
        public string Name { get; set; }
        public string Username { get; set; }
        public string Position { get; set; }
        public String Role { get; set; }
        public DateTime CreateUserDate { get; set; } 
    }
}
