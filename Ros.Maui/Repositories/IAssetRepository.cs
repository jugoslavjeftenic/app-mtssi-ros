using Ros.Maui.Models;

namespace Ros.Maui.Repositories;

public interface IAssetRepository
{
	Task<List<Asset>> GetAssetsAsync(string filter);
}
