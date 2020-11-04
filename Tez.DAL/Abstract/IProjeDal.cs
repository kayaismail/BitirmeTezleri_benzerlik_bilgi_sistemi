using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.Entities;

namespace Tez.DAL.Abstract
{
	public interface IProjeDal
	{
		dbProje Get(int Id);
		void Add(dbProje Veri);
		void Delete(dbProje Veri);
		List<dbProje> GetAll();

	}
}
