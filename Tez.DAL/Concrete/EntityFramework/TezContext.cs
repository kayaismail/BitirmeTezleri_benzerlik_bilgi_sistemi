using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.Entities;

namespace Tez.DAL.Concrete.EntityFramework
{
    public class TezContext:DbContext
    {
        public DbSet<dbTez> Tez { get; set; }
        public DbSet<dbCikti> dbCikti { get; set; }
        public DbSet<dbBolum> dbBolums { get; set; }
        public DbSet<dbFakulte> dbFakultes { get; set; }
        public DbSet<dbProje> dbProjes { get; set; }
        public DbSet<dbTezFikir> dbTezFikirs { get; set; }
        public DbSet<dbDanisman> dbDanismen { get; set; }
        

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<TezContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<Tez.Entities.dbOgrenci> dbOgrencis { get; set; }
    }
}
