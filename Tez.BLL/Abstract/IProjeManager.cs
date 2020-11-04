using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.Entities;

namespace Tez.BLL.Abstract
{
	public interface IProjeManager
	{
		dbProje Get(int Id);
		void Add(dbProje Veri);
		void Delete(dbProje Veri);
		List<dbProje> GetAll();
	}
}
