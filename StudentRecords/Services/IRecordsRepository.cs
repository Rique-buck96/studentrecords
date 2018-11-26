using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentRecords.Models;

namespace StudentRecords.Services
{
    interface IUserRepository : IDisposable
    {
        IEnumerable<Users> GetUsers();
        Users GetUserById(Guid userId);
        void InsertUser(Users user);
        void DeleteUser(Guid userId);
        void UpdateUser(Users user);
        void Save();
    }
}
