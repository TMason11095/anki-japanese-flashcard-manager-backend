using anki_japanese_flashcard_manager_backend.DomainLayer.Entities;

namespace anki_japanese_flashcard_manager_backend.DomainLayer.Interfaces.Repositories
{
	public interface ICardRepository
	{
		IEnumerable<Note> GetDeckNotes(long deckId);
		bool MoveNotesBetweenDecks(IEnumerable<long> noteIds, long newDeckId);
		IEnumerable<long> GetNoteIdsWithAtLeastInterval(IEnumerable<long> noteIds, int interval);
	}
}
