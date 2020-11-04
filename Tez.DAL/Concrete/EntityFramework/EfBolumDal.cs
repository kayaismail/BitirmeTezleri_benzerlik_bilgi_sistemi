using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.DAL.Abstract;
using Tez.Entities;

namespace Tez.DAL.Concrete.EntityFramework
{
	public class EfBolumDal:IBolumDal
    {
        TezContext context;

        public EfBolumDal()
        {
            context = new TezContext();
        }
        public EfBolumDal(TezContext tezContext)
        {
            context = tezContext;

        }

        public void Add(dbBolum Veri)
        {
            context.dbBolums.Add(Veri);
            context.SaveChanges();
        }

        public void Delete(dbBolum Veri)
        {
            context.dbBolums.Remove(Veri);
            context.SaveChanges(); 

        }

        public dbBolum Get(string BolumAd)
        {

            return context.dbBolums.Where(c => c.BolumAd == BolumAd)
                .FirstOrDefault();
        }

        public dbBolum Get(int Id)
        {
            return context.dbBolums.Where(c => c.Id == Id)
                   .FirstOrDefault();
        }

        public List<dbBolum> GetAll()
        {
            return context.dbBolums.ToList();
        }
    }
}
