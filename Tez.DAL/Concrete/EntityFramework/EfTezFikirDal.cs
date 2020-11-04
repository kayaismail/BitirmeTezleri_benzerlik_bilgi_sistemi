using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.DAL.Abstract;
using Tez.Entities;

namespace Tez.DAL.Concrete.EntityFramework
{
    public class EfTezFikirDal : ITezFikirDal
    {
        TezContext context;

        public EfTezFikirDal()
        {
            context = new TezContext();
        }
        public EfTezFikirDal(TezContext tezContext)
        {
            context = tezContext;

        }

        public void Add(dbTezFikir Veri)
        {
            context.dbTezFikirs.Add(Veri);
            context.SaveChanges();
        }

        public void Delete(dbTezFikir Veri)
        {
            context.dbTezFikirs.Remove(Veri);
            context.SaveChanges();

        }

        public dbTezFikir Get(int Id)
        {

            return context.dbTezFikirs.Where(c => c.Id == Id)
                .FirstOrDefault();
        }

        public List<dbTezFikir> GetAll()
        {
            return context.dbTezFikirs.ToList();
        }

        public void Update(dbTezFikir tezFikir)
        {
            dbTezFikir tezFikirUpdate = context.dbTezFikirs
                                   .FirstOrDefault(p => p.Id == tezFikir.Id);
            tezFikirUpdate.FikirYorum = tezFikir.FikirYorum;
            tezFikirUpdate.TezFikirDurumu = tezFikir.TezFikirDurumu;
            context.SaveChanges();
        }
    }
}
