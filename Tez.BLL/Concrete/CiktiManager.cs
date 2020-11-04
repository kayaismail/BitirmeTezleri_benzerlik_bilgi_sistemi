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
	public class CiktiManager : ICiktiManager
	{
		private ICiktiDal ciktiDal;
		public CiktiManager(ICiktiDal ciktiDal)
		{
			this.ciktiDal = ciktiDal;
		}

        public void Add(dbCikti CiktiVeri)
        {
            this.ciktiDal.Add(CiktiVeri);
        }

        public void Delete(dbCikti CiktiVeri)
        {
            this.ciktiDal.Delete(CiktiVeri);
        }

        public dbCikti Get(int CiktiId)
        {
            return this.ciktiDal.Get(CiktiId);
        }
        public List<dbCikti> GetAll()
        {
            return this.ciktiDal.GetAll();
        }

    }
}
