using Ros.Maui.Models;
using SQLite;

namespace Ros.Maui.Repositories;

public class AssetSQLiteRepository : IAssetRepository
{
	private readonly SQLiteAsyncConnection _db;
	private readonly int _rowLimit = 10;

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
				x.ParentAsset.Contains(filter) ||
				x.Name.Contains(filter) ||
				x.SAPInventoryNumber.Contains(filter) ||
				x.FirstName.Contains(filter) ||
				x.LastName.Contains(filter) ||
				x.Username.Contains(filter) ||
				x.SerialNumber.Contains(filter) ||
				x.LocationDescription.Contains(filter))
			.Take(_rowLimit)
			.ToListAsync();
	}

	public async Task DropAndRecreateTableAsync()
	{
		await _db.DropTableAsync<Asset>();
		await _db.CreateTableAsync<Asset>();
	}
}
