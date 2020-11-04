using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tez.Entities;

namespace Tez.DAL.Abstract
{
	public interface ITezFikirDal
	{
		dbTezFikir Get(int Id);
		void Add(dbTezFikir Veri);
		void Delete(dbTezFikir Veri);
		List<dbTezFikir> GetAll(); 
		void Update(dbTezFikir tezFikir);
	}
}
