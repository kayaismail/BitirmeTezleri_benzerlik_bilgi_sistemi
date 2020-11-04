using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.DAL.Abstract;
using Tez.Entities;

namespace Tez.DAL.Concrete.EntityFramework
{
    public class EfTezDal:ITezDal
    {
        TezContext context;

        public EfTezDal()
        {
            context = new TezContext();
        }
        public EfTezDal(TezContext tezContext)
        {
            context = tezContext;

        }

        public void Add(dbTez Veri)
        {
            context.Tez.Add(Veri);
            context.SaveChanges();
        }

        public void Delete(dbTez Veri)
        {
            context.Tez.Remove(Veri);
            context.SaveChanges();

        }

        public dbTez Get(int ProjeId)
        {
            return context.Tez.Where(c => c.Id == ProjeId)
                .FirstOrDefault();
        }

        public List<dbTez> GetAll()
        {
            return context.Tez.ToList();
        }
        public void Update(dbTez bitirmeProjesi)
        {
            dbTez productUpdate = context.Tez
                                    .FirstOrDefault(p => p.Id == bitirmeProjesi.Id);

            productUpdate.TezAdi = bitirmeProjesi.TezAdi;
            productUpdate.TezOzet = bitirmeProjesi.TezOzet;
            productUpdate.TezGerceklestirenler = bitirmeProjesi.TezGerceklestirenler;
            productUpdate.OzetKelime = bitirmeProjesi.OzetKelime;
            productUpdate.Keywords = bitirmeProjesi.Keywords;
            productUpdate.KeywordsKelime = bitirmeProjesi.KeywordsKelime;
            productUpdate.YilDonem = bitirmeProjesi.YilDonem;
            productUpdate.BaslikKelime = bitirmeProjesi.BaslikKelime;
            productUpdate.Danisman = bitirmeProjesi.Danisman;
            context.SaveChanges();

        }
    }
}
