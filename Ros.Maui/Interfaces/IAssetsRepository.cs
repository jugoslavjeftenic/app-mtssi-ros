using Ros.Maui.Models;

namespace Ros.Maui.Interfaces;

public interface IAssetsRepository
{
	Task<List<Asset>> GetAssetsAsync(string filter);
}
