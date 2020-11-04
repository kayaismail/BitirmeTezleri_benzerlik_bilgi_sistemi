using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.Entities;

namespace Tez.BLL.Abstract
{
	public interface IOgrenciManager
	{
		dbOgrenci Get(string mail);
		bool Add(dbOgrenci Veri);
		void Delete(dbOgrenci Veri);
		List<dbOgrenci> GetAll();
		bool GirisKontrolu(string mail, string Sifre);
		void Update(dbOgrenci ogrenci);
	}
}
