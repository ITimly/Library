using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public virtual Order Order { get; set; }
        public User User { get; set; }
        public string Status { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
