using Ros.CoreBusiness;

namespace Ros.DataStore.InMemory;

public class RosInMemoryRepository
{
	List<Sredstvo> _sredstva = [];

	public async Task<List<Sredstvo>> GetSredstva()
	{
		return _sredstva;
	}
}
