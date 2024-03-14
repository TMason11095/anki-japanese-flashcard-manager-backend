﻿using anki_japanese_flashcard_manager_backend.ApplicationLayer.Services;
using Tests.TestHelpers;

namespace Tests.ApplicationLayer.Services
{
	public class KanjiCardServiceTests
	{
		[Theory]
		//Test case: Note ids found
		[InlineData("emptyLearningKanji_1ivl飲12ivl良monthsIvl食欠人newKanji_decks.anki2", new[] { 1548988102030, 1552619440878, 1559353225229, 1559353240186, 1559353264106 }, new[] { 1548988102030, 1552619440878, 1559353225229, 1559353240186 })]
		//Test case: No note ids found
		[InlineData("emptyLearningKanji_0ivl飲1ivl食欠良5ivl人newKanji_decks.anki2", new[] { 1707169522144, 1707169497960, 1707169570657, 1707170000793, 1707169983389 }, new long[0])]
		public void Get_note_ids_with_at_least_the_kanji_interval(string anki2File, long[] noteIds, long[] expectedNoteIds)
		{
			//Arrange
			KanjiCardService kanjiCardService = new Anki2TestHelper(anki2File).KanjiCardService;

			//Act
			var noteIdsWithKanjiInterval = kanjiCardService.GetNoteIdsWithAtLeastKanjiInterval(noteIds);

			//Assert
			noteIdsWithKanjiInterval.Should().BeEquivalentTo(expectedNoteIds);
		}
	}
}
