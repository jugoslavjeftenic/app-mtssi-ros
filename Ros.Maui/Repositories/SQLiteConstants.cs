namespace Ros.Maui.Repositories;

class SQLiteConstants
{
	public const string DatabaseFilename = "RosSQLite.db3";
	public static string DatabasePath =>
		Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
}
