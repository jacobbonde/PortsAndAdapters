using System.Collections.Generic;

namespace Example3.DomainModel
{
	public interface IImbibementRepository
	{
		IEnumerable<Imbibement> Imbibements();
		void Add(Imbibement imbibement);
	}
}
