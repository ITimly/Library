using Library.Data.Interfaces;
using Library.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data.Repository
{
    public class GenreRepository : IAllGenres
    {
        private readonly AppDBContent appDBContent;
        public GenreRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Genre> AllGenres => appDBContent.Genres;
    }
}
