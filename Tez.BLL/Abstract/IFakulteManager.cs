using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.Entities;

namespace Tez.BLL.Abstract
{
	public interface IFakulteManager
	{
		dbFakulte Get(int Ad);
		void Add(dbFakulte Veri);
		void Delete(dbFakulte Veri);
		List<dbFakulte> GetAll();
	}
}
