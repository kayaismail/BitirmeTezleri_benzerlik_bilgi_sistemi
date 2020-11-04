
namespace Tez.Entities
{
	public class dbBolum
	{
		public int Id { get; set; }
		public string BolumAd { get; set; }
		public virtual dbFakulte Fakulte { get; set; }

	}
}
