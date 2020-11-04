using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.Entities;

namespace Tez.DAL.Abstract
{
	public interface IDanismanDal
	{
		dbDanisman Get(int Id);
		void Add(dbDanisman Veri);
		void Delete(dbDanisman Veri);
		List<dbDanisman> GetAll();
		dbDanisman Get(string mail);
		void Update(dbDanisman danisman);

	}
}
