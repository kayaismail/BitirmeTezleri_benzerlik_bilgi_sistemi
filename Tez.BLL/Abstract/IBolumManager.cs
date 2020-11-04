using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.Entities;

namespace Tez.BLL.Abstract
{
	public interface IBolumManager
	{
		dbBolum Get(string Veri);
		void Add(dbBolum proje);
		void Delete(dbBolum proje);
		List<dbBolum> GetAll();
		dbBolum Get(int Id);
	}
}
