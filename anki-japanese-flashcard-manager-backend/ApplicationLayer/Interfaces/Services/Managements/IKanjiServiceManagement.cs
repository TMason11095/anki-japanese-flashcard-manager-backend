namespace anki_japanese_flashcard_manager_backend.ApplicationLayer.Interfaces.Services.Managements
{
	public interface IKanjiServiceManagement
	{
		bool MoveNewKanjiToLearningKanji();
		bool MoveResourceSubKanjiToNewKanji();
	}
}
