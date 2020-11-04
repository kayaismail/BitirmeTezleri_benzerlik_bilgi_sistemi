using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.Entities;

namespace Tez.DAL.Abstract
{
	public interface IBolumDal
	{

		dbBolum Get(string BolumAd);
		void Add(dbBolum Veri);
		void Delete(dbBolum Veri);
		List<dbBolum> GetAll();
		dbBolum Get(int Id);

	}
}
