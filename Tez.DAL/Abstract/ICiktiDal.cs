using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.Entities;

namespace Tez.DAL.Abstract
{
	public interface ICiktiDal
	{

		dbCikti Get(int CiktiVeri);
		void Add(dbCikti CiktiVeri);
		void Delete(dbCikti CiktiVeri);
		List<dbCikti> GetAll();
	}
}
