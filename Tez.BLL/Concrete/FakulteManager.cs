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
	public class FakulteManager : IFakulteManager
	{
        private IFakulteDal fakulteDal;
        public FakulteManager(IFakulteDal fakulteDal)
        {
            this.fakulteDal = fakulteDal;
        }

        public void Add(dbFakulte Veri)
        {
            this.fakulteDal.Add(Veri);
        }

        public void Delete(dbFakulte Veri)
        {
            this.fakulteDal.Delete(Veri);
        }

        public dbFakulte Get(int Veri)
        {
            return this.fakulteDal.Get(Veri);
        }

        public List<dbFakulte> GetAll()
        {
            return this.fakulteDal.GetAll();
        }
    }
}
