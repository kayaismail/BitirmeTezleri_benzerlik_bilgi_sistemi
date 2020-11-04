using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.Entities;

namespace Tez.BLL.Abstract
{
	public interface IDanismanManager
	{

		dbDanisman Get(int ProjeId);
		dbDanisman Get(string mail);
		bool Add(dbDanisman proje);
		void Delete(dbDanisman proje);
		List<dbDanisman> GetAll();
		bool GirisKontrolu(string mail, string Sifre);
		void Update(dbDanisman danisman);

	}
}
