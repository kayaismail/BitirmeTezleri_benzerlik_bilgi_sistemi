using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.Entities;

namespace Tez.BLL.Abstract
{
    public interface ITezManager
    {
        List<Entities.dbTez> GetAll();
		Entities.dbTez Get(int ProjeId);
        void Add(Entities.dbTez proje);
        void Delete(Entities.dbTez proje);
        void Update(dbTez proje);
    }
}
