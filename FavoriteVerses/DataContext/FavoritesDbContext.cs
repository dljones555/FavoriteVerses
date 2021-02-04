using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavoriteVerses.DataContext
{
    public class FavoritesDbContext : DbContext
    {
        public FavoritesDbContext(DbContextOptions<FavoritesDbContext> options)
        : base(options)
        {
        }

        public DbSet<Models.Verse> FavoriteVerses { get; set; }
    }
}
