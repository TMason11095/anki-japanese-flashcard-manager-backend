using anki_japanese_flashcard_manager_backend.DomainLayer.Entities;

namespace anki_japanese_flashcard_manager_backend.ApplicationLayer.Interfaces.Services
{
	public interface IDeckService
	{
		IEnumerable<Deck> GetTaggedDecks(string deckTagName);
	}
}
