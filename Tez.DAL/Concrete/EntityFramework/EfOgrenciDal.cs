using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.DAL.Abstract;
using Tez.Entities;

namespace Tez.DAL.Concrete.EntityFramework
{
	public class EfOgrenciDal : IOgrenciDal
    {
        TezContext context;

        public EfOgrenciDal()
        {
            context = new TezContext();
        }
        public EfOgrenciDal(TezContext tezContext)
        {
            context = tezContext;

        }

        public void Add(dbOgrenci Veri)
        {
            context.dbOgrencis.Add(Veri);
            context.SaveChanges();
        }

        public void Delete(dbOgrenci Veri)
        {
            context.dbOgrencis.Remove(Veri);
            context.SaveChanges();

        }

        public dbOgrenci Get(string mail)
        {

            return context.dbOgrencis.Where(c => c.OgrenciMail == mail)
                .FirstOrDefault();
        }

        public List<dbOgrenci> GetAll()
        {
            return context.dbOgrencis.ToList();
        }

        public void Update(dbOgrenci ogrenci)
        {
            dbOgrenci temp = Get(ogrenci.OgrenciMail);
            temp.OgrenciSifre = ogrenci.OgrenciSifre;
            context.SaveChanges();
        }
    }
}
