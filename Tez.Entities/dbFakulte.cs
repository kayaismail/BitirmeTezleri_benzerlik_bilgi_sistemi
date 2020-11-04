
namespace Tez.Entities
{
	public class dbFakulte
	{
		public int Id { get; set; }
		public string FakulteAd { get; set; }
		
		public virtual System.Collections.Generic.List<dbBolum> Bolumler { get; set; }

	}
}