using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tez.Entities;

namespace Tez.WebUI.Models
{
	public class BolumFakulte
	{
		public dbBolum dbBolum { get; set; }
		public List<dbFakulte> dbFakultes { get; set; }
		public string SecilenFakulteId { get; set; }
	}
}