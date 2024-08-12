using SQLite;

namespace Ros.Maui.Models;

public class Asset
{
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public string ParentAsset { get; set; } = string.Empty;
	public string Name { get; set; } = string.Empty;
	public string Category { get; set; } = string.Empty;
	public string SAPInventoryNumber { get; set; } = string.Empty;
	public int Assignee { get; set; }
	public string FirstName { get; set; } = string.Empty;
	public string LastName { get; set; } = string.Empty;
	public string Username { get; set; } = string.Empty;
	public DateOnly AssignmentDate { get; set; }
	public string SerialNumber { get; set; } = string.Empty;
	public string LocationDescription { get; set; } = string.Empty;
	public string LowestOrganizationalUnit { get; set; } = string.Empty;
	public string JobTitle { get; set; } = string.Empty;
}
