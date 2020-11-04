using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.DAL.Abstract;
using Tez.Entities;

namespace Tez.DAL.Concrete.EntityFramework
{
    public class EfProjeDal:IProjeDal
    {
        TezContext context;

        public EfProjeDal()
        {
            context = new TezContext();
        }
        public EfProjeDal(TezContext tezContext)
        {
            context = tezContext;

        }

        public void Add(dbProje Veri)
        {
            context.dbProjes.Add(Veri);
            context.SaveChanges();
        }

        public void Delete(dbProje Veri)
        {
            context.dbProjes.Remove(Veri);
            context.SaveChanges();

        }

        public dbProje Get(int Id)
        {

            return context.dbProjes.Where(c => c.Id == Id)
                .FirstOrDefault();
        }
        public List<dbProje> GetAll()
        {
            return context.dbProjes.ToList();
        }
    }
}
