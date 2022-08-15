using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Interfaces
{
    public interface IAllGenres
    {
        IEnumerable<Genre> AllGenres { get; }
    }
}
