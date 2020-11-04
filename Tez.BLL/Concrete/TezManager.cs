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
    public class TezManager : ITezManager
    {
        private ITezDal projeDAL;
        public TezManager(ITezDal projeDal)
        {
            this.projeDAL = projeDal;
        }

        public void Add(Entities.dbTez proje)
        {
            this.projeDAL.Add(proje);
        }


        public void Delete(Entities.dbTez proje)
        {
            this.projeDAL.Delete(proje);
        }

        public Entities.dbTez Get(int ProjeId)
        {
            return this.projeDAL.Get(ProjeId);
        }

        public List<Entities.dbTez> GetAll()
        {
            return this.projeDAL.GetAll();
        }
        public void Update(dbTez proje)
        {
            this.projeDAL.Update(proje);
        }
    }
}
