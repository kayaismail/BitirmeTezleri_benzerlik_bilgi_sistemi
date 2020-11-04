using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.BLL.Abstract;
using Tez.DAL.Abstract;
using Tez.Entities;

namespace Tez.BLL.Concrete
{
	public class TezFikirManager : ITezFikirManager
	{
        private ITezFikirDal tezFikirDal;
        public TezFikirManager(ITezFikirDal tezFikirDal)
        {
            this.tezFikirDal = tezFikirDal;
        }

        public void Add(dbTezFikir Veri)
        {
            this.tezFikirDal.Add(Veri);
        }

        public void Delete(dbTezFikir Veri)
        {
            this.tezFikirDal.Delete(Veri);
        }

        public dbTezFikir Get(int Id)
        {
            return this.tezFikirDal.Get(Id);
        }

        public List<dbTezFikir> GetAll()
        {
            return this.tezFikirDal.GetAll();
        }
        public void Update(dbTezFikir proje)
        {
            this.tezFikirDal.Update(proje);
        }
    }
}
