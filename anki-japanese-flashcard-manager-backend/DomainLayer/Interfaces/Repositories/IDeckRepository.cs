using anki_japanese_flashcard_manager_backend.DomainLayer.Entities;

namespace anki_japanese_flashcard_manager_backend.DomainLayer.Interfaces.Repositories
{
	public interface IDeckRepository
	{
		IEnumerable<Deck> GetDecksByDescriptionContaining(string descriptionPart);
	}
}
