using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace anki_japanese_flashcard_manager_backend.DataAccessLayer.Helpers
{
	public static class DbContextHelper
	{
		public static void ClearSqlitePool(DbContext dbContext)
		{
			SqliteConnection.ClearPool((SqliteConnection)dbContext.Database.GetDbConnection());
		}
	}
}
