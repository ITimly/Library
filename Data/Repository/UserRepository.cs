using Library.Data.Interfaces;
using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Repository
{
    public class UserRepository : IAllUsers
    {
        private readonly AppDBContent appDBContent;
        public UserRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<User> Users => appDBContent.Users;
        public void UpdateUser(User user)
        {
            User accaunt = appDBContent.Users.FirstOrDefault(a => a.Email == user.Email);
            if(accaunt != null)
            {
                accaunt.Name = user.Name;
                accaunt.Password = user.Password;
                accaunt.Level = user.Level;
                appDBContent.Users.Update(accaunt);
                appDBContent.SaveChanges();
            }
        }
        public bool ValidUser(User user)
        {
            User people = appDBContent.Users.FirstOrDefault(i => i.Email == user.Email);
            return people == null ? false : true;
        }
        public bool ValidNewUser(User user)
        {
            User people = appDBContent.Users.FirstOrDefault(i => i.Email == user.Email);
            return people == null ? true : false;
        }
        public void UserDelete(int id)
        {
            appDBContent.Users.Remove(appDBContent.Users.FirstOrDefault(c => c.Id == id));
            appDBContent.SaveChanges();
        }
        public List<User> GetUsers(int id)
        {
            return appDBContent.Users.Where(u => u.Id == id).ToList();
        }
    }
}
