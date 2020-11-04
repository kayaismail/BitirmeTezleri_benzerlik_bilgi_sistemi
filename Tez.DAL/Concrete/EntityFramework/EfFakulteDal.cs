using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.DAL.Abstract;
using Tez.Entities;

namespace Tez.DAL.Concrete.EntityFramework
{
	public class EfFakulteDal : IFakulteDal
	{
        TezContext context;

        public EfFakulteDal()
        {
            context = new TezContext();
        }
        public EfFakulteDal(TezContext tezContext)
        {
           context = tezContext;

        }

        public void Add(dbFakulte Veri)
        {
            context.dbFakultes.Add(Veri);
            context.SaveChanges();
        }

        public void Delete(dbFakulte Veri)
        {
            context.dbFakultes.Remove(Veri);
            context.SaveChanges();

        }

        public dbFakulte Get(int Id)
        {

            return context.dbFakultes.Where(c => c.Id == Id)
                .FirstOrDefault();
        }

        public List<dbFakulte> GetAll()
        {
            return context.dbFakultes.ToList();
        }
    }
}
