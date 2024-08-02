namespace Ros.CoreBusiness;

public class Sredstvo
{
	public int Id { get; set; }
	public string? SerijskiBroj { get; set; }
	public string? Naziv { get; set; }
	public string? NadredjenoSredstvo { get; set; }
	public string? SAPInventarniBroj { get; set; }

	// TODO
	// public string? Kategorija { get; set; }
	// public int Zaduzilac { get; set; }
	// public string? Ime { get; set; }
	// public string? Prezime { get; set; }
	// public string? Username { get; set; }
	// public DateOnly DatumZaduzenja { get; set; }
	// public string? OpisLokacije { get; set; }
	// public string? NajnizaOJ { get; set; }
	// public string? NazivRM { get; set; }
}
