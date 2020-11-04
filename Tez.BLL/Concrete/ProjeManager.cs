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
	public class ProjeManager : IProjeManager
	{
        private IProjeDal projeDal;
        public ProjeManager(IProjeDal projeDal)
        {
            this.projeDal = projeDal;
        }

        public void Add(dbProje Veri)
        {
            this.projeDal.Add(Veri);
        }

        public void Delete(dbProje Veri)
        {
            this.projeDal.Delete(Veri);
        }

        public dbProje Get(int Id)
        {
            return this.projeDal.Get(Id);
        }

        public List<dbProje> GetAll()
        {
            return this.projeDal.GetAll();
        }
    }
}
