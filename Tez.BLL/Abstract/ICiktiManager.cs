using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.Entities;

namespace Tez.BLL.Abstract
{
	public interface ICiktiManager
	{
		dbCikti Get(int ProjeId);
		void Add(dbCikti proje);
		void Delete(dbCikti proje);
		List<dbCikti> GetAll();

	}
}
