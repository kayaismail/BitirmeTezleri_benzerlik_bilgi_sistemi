using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tez.Entities;

namespace Tez.WebUI.Models
{
	public class ProjeDanisman
	{
		public dbProje dbProje { get; set; }
		public List<dbDanisman> dbDanismen { get; set; }
		public string SecilenDanismanId { get; set; }

	}
}