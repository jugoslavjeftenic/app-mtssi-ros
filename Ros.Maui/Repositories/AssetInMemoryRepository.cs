using Ros.Maui.Models;

namespace Ros.Maui.Repositories;

public class AssetInMemoryRepository : IAssetRepository
{
	private readonly static List<Asset> _assets = [
		new Asset
		{
			Id = 1,
			SerialNumber = "XY123",
			Name = "Računar",
			ParentAsset = "10001",
			SAPInventoryNumber = "20000001"
		},
		new Asset
		{
			Id = 2,
			SerialNumber = "AB123",
			Name = "Računar neki drugi",
			ParentAsset = "10002",
			SAPInventoryNumber = "20000002"
		},
		new Asset
		{
			Id = 3,
			SerialNumber = "XY123AB",
			Name = "Lapatop",
			ParentAsset = "10003",
			SAPInventoryNumber = "20000003"
		},
		new Asset
		{
			Id = 4,
			SerialNumber = "123XAB",
			Name = "Desktop",
			ParentAsset = "10004",
			SAPInventoryNumber = "20000004"
		},
		new Asset
		{
			Id = 5,
			SerialNumber = "DE456",
			Name = "Monitor",
			ParentAsset = "10005",
			SAPInventoryNumber = "20000005"
		},
		new Asset
		{
			Id = 6,
			SerialNumber = "FG789",
			Name = "Printer",
			ParentAsset = "10006",
			SAPInventoryNumber = "20000006"
		},
		new Asset
		{
			Id = 7,
			SerialNumber = "HI012",
			Name = "Skener",
			ParentAsset = "10007",
			SAPInventoryNumber = "20000007"
		},
		new Asset
		{
			Id = 8,
			SerialNumber = "JK345",
			Name = "Server",
			ParentAsset = "10008",
			SAPInventoryNumber = "20000008"
		},
		new Asset
		{
			Id = 9,
			SerialNumber = "LM678",
			Name = "Projektor",
			ParentAsset = "10009",
			SAPInventoryNumber = "20000009"
		},
		new Asset
		{
			Id = 10,
			SerialNumber = "NO901",
			Name = "Tablet",
			ParentAsset = "10010",
			SAPInventoryNumber = "20000010"
		}
	];

	public async Task<List<Asset>> GetAssetsAsync(string filter = "")
	{
		if (string.IsNullOrWhiteSpace(filter))
		{
			return await Task.FromResult(_assets);
		}

		var assets = _assets
			.Where(x =>
				(x.SerialNumber?
					.Contains(filter, StringComparison.OrdinalIgnoreCase) ?? false) ||
				(x.Name?
					.Contains(filter, StringComparison.OrdinalIgnoreCase) ?? false) ||
				(x.ParentAsset?
					.Contains(filter, StringComparison.OrdinalIgnoreCase) ?? false) ||
				(x.SAPInventoryNumber?
					.Contains(filter, StringComparison.OrdinalIgnoreCase) ?? false)
			)
			.ToList();

		return await Task.FromResult(assets);
	}
}
