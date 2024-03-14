namespace anki_japanese_flashcard_manager_backend.ApplicationLayer.Helpers
{
	public static class NoteHelper
	{
		public static IEnumerable<string> GetIdsFromTagList(IEnumerable<string> tagList, string tag)//Note?
		{
			return tagList.Where(t => t.StartsWith(tag))
						.Select(t => t.Substring(tag.Length));
		}
	}
}
