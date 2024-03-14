using anki_japanese_flashcard_manager_backend.DomainLayer.Entities;
using anki_japanese_flashcard_manager_backend.DomainLayer.Interfaces.Repositories;

namespace anki_japanese_flashcard_manager_backend.DomainLayer.Helpers
{
	public static class Anki2Extension
	{
		public static IEnumerable<long> GetIds(this IEnumerable<Note> notes)
		{
			return notes.Select(n => n.Id);
		}

		public static IEnumerable<long> GetIds(this IEnumerable<Deck> decks)
		{
			return decks.Select(d => d.Id);
		}

		public static IEnumerable<Note> GetNotes(this IEnumerable<Deck> decks, ICardRepository cardRepository)
		{
			return decks.SelectMany(d => cardRepository.GetDeckNotes(d.Id));
		}
	}
}
