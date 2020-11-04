using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.Entities;

namespace Tez.DAL.Abstract
{
    public interface ITezDal
    {
        List<Entities.dbTez> GetAll();
		Entities.dbTez Get(int BitirmeId);
        void Add(Entities.dbTez bitirmeProjesi);
        void Delete(Entities.dbTez bitirmeProjesi);
        void Update(dbTez product);
    }
}
