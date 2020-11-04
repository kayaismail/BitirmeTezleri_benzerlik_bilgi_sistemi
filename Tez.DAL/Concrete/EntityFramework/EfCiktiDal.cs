using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.DAL.Abstract;
using Tez.Entities;

namespace Tez.DAL.Concrete.EntityFramework
{
	public class EfCiktiDal : ICiktiDal
    {
        TezContext context;

        public EfCiktiDal()
        {
            context = new TezContext();
        }
        public EfCiktiDal(TezContext tezContext)
        {
            context = tezContext;

        }

        public void Add(dbCikti CiktiVeri)
        {
            context.dbCikti.Add(CiktiVeri);
            context.SaveChanges();
        }

        public void Delete(dbCikti CiktiVeri)
        {
            context.dbCikti.Remove(CiktiVeri);
            context.SaveChanges();

        }

        public dbCikti Get(int CiktiId)
        {
            
            return context.dbCikti.Where(c => c.Bolum.Id == CiktiId)
                .FirstOrDefault();
        }

        public List<dbCikti> GetAll()
        {
            return context.dbCikti.ToList();
        }
    }
}
