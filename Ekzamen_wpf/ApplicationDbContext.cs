using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekzamen_wpf
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<Model.Author> authors { get; set; }
        public DbSet<Model.Book> books { get; set; }
        public DbSet<Model.Jenre> jenres { get; set; }

        private string sqlConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\karas\source\repos\Ekzamen_wpf\Ekzamen_wpf\Database1.mdf;Integrated Security=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(sqlConnectionString);
        }
    }
}
