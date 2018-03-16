using System.Collections.Generic;

namespace Example2b.DataAccess
{
	public interface IImbibementRepository
	{
		IEnumerable<Imbibement> Imbibements();
		void Add(Imbibement imbibement);
	}
}
