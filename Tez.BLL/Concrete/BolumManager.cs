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
	public class BolumManager : IBolumManager
	{
        private IBolumDal bolumDal;
        public BolumManager(IBolumDal bolumDal)
        {
            this.bolumDal = bolumDal;
        }

        public void Add(dbBolum Veri)
        {
            this.bolumDal.Add(Veri);
        }

        public void Delete(dbBolum Veri)
        {
            this.bolumDal.Delete(Veri);
        }

        public dbBolum Get(string Veri)
        {
            return this.bolumDal.Get(Veri);
        }

        public dbBolum Get(int Id)
        {
            return this.bolumDal.Get(Id);
        }
        public List<dbBolum> GetAll()
        {
            return this.bolumDal.GetAll();
        }
    }
}