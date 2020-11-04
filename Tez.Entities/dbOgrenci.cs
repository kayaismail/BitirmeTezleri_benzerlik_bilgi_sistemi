using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tez.Entities
{
	public class dbOgrenci
	{
		public int Id { get; set; }
		[DataType(DataType.EmailAddress)]
		[Required(AllowEmptyStrings = false)]
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string OgrenciMail { get; set; }
		public string OgrenciSifre { get; set; }
		public virtual System.Collections.Generic.List<dbTezFikir> TezFikirleri { get; set; }

		public virtual dbBolum Bolum { get; set; }
	}
}
