using Ros.Maui.Models;

namespace Ros.Maui.Repositories;

public interface IAssetsRepository
{
    Task<List<Asset>> GetAssetsAsync(string filter);
}
