using HastaneOtomasyonu.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HastaneOtomasyonu.DataAccess.Concreat.Entityframework
{
    public class HastaneOtomasyonuDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-QGFA3DT; Database=HastaneOtomasyonuDb;integrated security=true;");
            //(localdb)\MSSQLLocalDB;
        }


        public DbSet<Admin> Adminler { get; set; }

        public DbSet<Bolum> Bolumler { get; set; }
        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Hasta> Hastalar { get; set; }
        public DbSet<Hastane> Hastaneler { get; set; }
        public DbSet<Il> Iller { get; set; }
        public DbSet<Randevu> Randevular { get; set; }

        internal Expression<Func<object, object>> GetIncludePaths(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
