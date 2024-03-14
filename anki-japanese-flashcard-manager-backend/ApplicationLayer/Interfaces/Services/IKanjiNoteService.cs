using anki_japanese_flashcard_manager_backend.DomainLayer.Entities;

namespace anki_japanese_flashcard_manager_backend.ApplicationLayer.Interfaces.Services
{
	public interface IKanjiNoteService
	{
		List<Note> PullAllSubKanjiNotesFromNoteList(ref List<Note> noteList, List<Note> originalKanjiNotes);
	}
}
