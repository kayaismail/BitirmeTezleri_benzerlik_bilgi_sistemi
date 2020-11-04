using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Tez.Entities;

namespace Tez.WebUI.Models
{
	public class OgrenciBolum
	{
		
		public dbOgrenci dbOgrenci { get; set; }
		[Required(AllowEmptyStrings = false)]
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public List<dbBolum> dbBolums { get; set; }
		public string SecilenBolumId { get; set; }

	}
}