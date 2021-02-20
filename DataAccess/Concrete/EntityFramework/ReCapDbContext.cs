using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocaldb;Database=ReCapDb;Trusted_Connection=true");
        }
        public DbSet<Car> Cars { get; set; } // Projenin Car sınıfı, Cars Tablosu ile bağlıdır.
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }

        /* EntityFrameworkCore.SqlServer Nuget paketi indirildi,
         * Context sınıfı oluşturulup, projenin kullanacağı Db belirtildi.
         * Projedeki sınıflar, entityler ile Db'deki tablolar bağlandı.
         */
    }
}
