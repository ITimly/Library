using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Interfaces
{
    public interface IAllUsers
    {
        IEnumerable<User> Users { get; }
        void UpdateUser(User user);
        bool ValidUser(User user);
        bool ValidNewUser(User user);
        void UserDelete(int id);
        List<User> GetUsers(int id);
    }
}
