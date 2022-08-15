using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.ViewModels
{
    public class AdminViewModel
    {
        public IEnumerable<User> Users { get; set; }
    }
}
