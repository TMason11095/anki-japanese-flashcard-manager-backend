namespace anki_japanese_flashcard_manager_backend.ApplicationLayer.Interfaces.Services
{
	public interface IKanjiCardService
	{
		IEnumerable<long> GetNoteIdsWithAtLeastKanjiInterval(IEnumerable<long> noteIds);
	}
}
