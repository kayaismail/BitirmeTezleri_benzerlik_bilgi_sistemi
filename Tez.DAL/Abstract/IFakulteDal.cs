using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.Entities;

namespace Tez.DAL.Abstract
{
	public interface IFakulteDal
	{
		dbFakulte Get(int Id);
		void Add(dbFakulte Veri);
		void Delete(dbFakulte Veri);
		List<dbFakulte> GetAll();
	}
}
