using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.DAL.Abstract;
using Tez.Entities;

namespace Tez.DAL.Concrete.EntityFramework
{
	public class EfDanismanDal : IDanismanDal
	{
        TezContext context;

        public EfDanismanDal()
        {
            context = new TezContext();
        }
        public EfDanismanDal(TezContext tezContext)
        {
            context = tezContext;

        }

        public void Add(dbDanisman Veri)
        {
            context.dbDanismen.Add(Veri);
            context.SaveChanges();
        }

        public void Delete(dbDanisman Veri)
        {
            context.dbDanismen.Remove(Veri);
            context.SaveChanges();

        }

        public dbDanisman Get(int Id)
        {

            return context.dbDanismen.Where(c => c.Id == Id)
                .FirstOrDefault();
        }

        public dbDanisman Get(string mail)
        {
            return context.dbDanismen.Where(c => c.DanismanMail == mail)
                .FirstOrDefault();
        }

        public List<dbDanisman> GetAll()
        {
            return context.dbDanismen.ToList();
        }

        public void Update(dbDanisman danisman)
        {
            dbDanisman temp = Get(danisman.DanismanMail);
            temp.DanismanSifre = danisman.DanismanSifre;
            temp.DanismanKontenjan = danisman.DanismanKontenjan;
            context.SaveChanges();
        }
    }
}
