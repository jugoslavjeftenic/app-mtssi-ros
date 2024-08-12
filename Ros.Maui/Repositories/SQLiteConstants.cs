namespace Ros.Maui.Repositories;

public class SQLiteConstants
{
	public const string DatabaseFilename = "RosSQLite.db3";
	public static string DatabasePath =>
		Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
}
