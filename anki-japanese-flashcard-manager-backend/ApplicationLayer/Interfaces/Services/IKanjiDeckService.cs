using anki_japanese_flashcard_manager_backend.DomainLayer.Entities;

namespace anki_japanese_flashcard_manager_backend.ApplicationLayer.Interfaces.Services
{
	public interface IKanjiDeckService
	{
		IEnumerable<Deck> GetResourceKanjiDecks();
		IEnumerable<Deck> GetNewKanjiDecks();
		IEnumerable<Deck> GetLearningKanjiDecks();
	}
}
