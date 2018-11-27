using System;

namespace StudentRecords.Models
{
    public class Users
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }  //0 = Admin, 1 = Event Manager
    }
}
