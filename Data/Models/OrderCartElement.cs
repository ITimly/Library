using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Models
{
    public class OrderCartElement
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public string OrderCartId { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
