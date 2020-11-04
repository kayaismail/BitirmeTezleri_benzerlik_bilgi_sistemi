using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.Entities;

namespace Tez.BLL.Abstract
{
	public interface ITezFikirManager
	{
		dbTezFikir Get(int Id);
		void Add(dbTezFikir Veri);
		void Delete(dbTezFikir Veri);
		List<dbTezFikir> GetAll();
		void Update(dbTezFikir tezFikir);
		
	}
}
