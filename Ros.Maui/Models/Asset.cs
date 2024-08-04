namespace Ros.Maui.Models;

public class Asset
{
	public int Id { get; set; }
	public string? SerialNumber { get; set; }
	public string? Name { get; set; }
	public string? ParentAsset { get; set; }
	public string? SAPInventoryNumber { get; set; }

	// TODO
	// public string? Category { get; set; }
	// public int Assignee { get; set; }
	// public string? FirstName { get; set; }
	// public string? LastName { get; set; }
	// public string? Username { get; set; }
	// public DateOnly AssignmentDate { get; set; }
	// public string? LocationDescription { get; set; }
	// public string? LowestOrganizationalUnit { get; set; }
	// public string? ResourceName { get; set; }
}
