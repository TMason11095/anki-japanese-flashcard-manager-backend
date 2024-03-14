using anki_japanese_flashcard_manager_backend.ApplicationLayer.Config;
using anki_japanese_flashcard_manager_backend.ApplicationLayer.Interfaces.Services;
using anki_japanese_flashcard_manager_backend.DomainLayer.Entities;
using anki_japanese_flashcard_manager_backend.DomainLayer.Interfaces.Repositories;

namespace anki_japanese_flashcard_manager_backend.ApplicationLayer.Services
{
	public class DeckService : IDeckService
	{
		private readonly IDeckRepository _deckRepository;

		public DeckService(IDeckRepository deckRepository)
		{
			_deckRepository = deckRepository;
		}

		public IEnumerable<Deck> GetTaggedDecks(string deckTagName)//Deck
		{
			//Get the deck tag (prefix for the full tag)
			string deckTag = AnkiBindingConfig.Bindings.DeckTag;
			//Build the full tag
			string fullDeckTag = deckTag + deckTagName;
			//Return the tagged decks
			return _deckRepository.GetDecksByDescriptionContaining(fullDeckTag);
		}
	}
}
