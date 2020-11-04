using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.Entities;

namespace Tez.DAL.Abstract
{
	public interface IOgrenciDal
	{
		dbOgrenci Get(string mail);
		void Add(dbOgrenci Veri);
		void Delete(dbOgrenci Veri);
		List<dbOgrenci> GetAll();
		void Update(dbOgrenci danisman);
	}
}
