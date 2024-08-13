using SQLite;
using System.ComponentModel.DataAnnotations;

namespace Ros.Maui.Models;

[Table("assets")]
public class Asset
{
	[Required]
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
	public DateTime AssignmentDate { get; set; }
	public string SerialNumber { get; set; } = string.Empty;
	public string LocationDescription { get; set; } = string.Empty;
	public string LowestOrganizationalUnit { get; set; } = string.Empty;
	public string JobTitle { get; set; } = string.Empty;
}
