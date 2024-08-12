using Ros.Maui.Models;
using SQLite;

namespace Ros.Maui.Repositories;

public class AssetSQLiteRepository : IAssetRepository
{
	private readonly SQLiteAsyncConnection _db;
	private int _rowLimit = 10;

	public AssetSQLiteRepository()
	{
		_db = new SQLiteAsyncConnection(SQLiteConstants.DatabasePath);
		_db.CreateTableAsync<Asset>();
	}

	public async Task<List<Asset>> GetAssetsAsync(string filter)
	{
		if (string.IsNullOrWhiteSpace(filter))
		{
			return await _db.Table<Asset>().Take(_rowLimit).ToListAsync();
		}

		return await _db.Table<Asset>()
			.Where(x =>
				x.ParentAsset.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
				x.Name.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
				x.Category.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
				x.SAPInventoryNumber.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
				x.FirstName.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
				x.LastName.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
				x.Username.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
				x.SerialNumber.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
				x.LocationDescription.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
				x.LowestOrganizationalUnit.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
				x.JobTitle.Contains(filter, StringComparison.OrdinalIgnoreCase))
			.Take(_rowLimit)
			.ToListAsync();
	}
}
