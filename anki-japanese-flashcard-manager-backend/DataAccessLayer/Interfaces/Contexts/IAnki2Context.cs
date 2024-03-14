using anki_japanese_flashcard_manager_backend.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace anki_japanese_flashcard_manager_backend.DataAccessLayer.Interfaces.Contexts
{
	public interface IAnki2Context : IDisposable
	{
		public DbSet<Card> Cards { get; }
		public DbSet<Deck> Decks { get; }
		public DbSet<Note> Notes { get; }

		public int SaveChanges();
	}
}
