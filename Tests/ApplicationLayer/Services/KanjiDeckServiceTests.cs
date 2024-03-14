﻿using anki_japanese_flashcard_manager_backend.ApplicationLayer.Services;
using anki_japanese_flashcard_manager_backend.DomainLayer.Helpers;
using Tests.TestHelpers;

namespace Tests.ApplicationLayer.Services
{
	public class KanjiDeckServiceTests
	{
		[Theory]
		//Test case: Deck ids found
		[InlineData("empty_kanjiResource_deck.anki2", new long[] { 1706982246215 })]
		[InlineData("empty_kanjiResource_newKanji_decks.anki2", new long[] { 1707160947123 })]
		//Test case: Deck ids not found
		[InlineData("empty_random_decks.anki2", new long[0])]
		public void Get_kanji_resource_decks(string anki2File, long[] expectedDeckIds)
		{
			//Arange
			KanjiDeckService kanjiDeckService = new Anki2TestHelper(anki2File).KanjiDeckService;

			//Act
			var taggedDecks = kanjiDeckService.GetResourceKanjiDecks();

			//Assert
			taggedDecks.GetIds().Should().BeEquivalentTo(expectedDeckIds);
		}

		[Theory]
		//Test case: Deck ids found
		[InlineData("empty_newKanji_deck.anki2", new long[] { 1707160682667 })]
		[InlineData("empty_kanjiResource_newKanji_decks.anki2", new long[] { 1707160682667 })]
		//Test case: Deck ids not found
		[InlineData("empty_random_decks.anki2", new long[0])]
		public void Get_new_kanji_decks(string anki2File, long[] expectedDeckIds)
		{
			//Arange
			KanjiDeckService kanjiDeckService = new Anki2TestHelper(anki2File).KanjiDeckService;

			//Act
			var taggedDecks = kanjiDeckService.GetNewKanjiDecks();

			//Assert
			taggedDecks.GetIds().Should().BeEquivalentTo(expectedDeckIds);
		}

		[Theory]
		//Test case: Deck ids found
		[InlineData("emptyLearningKanji_飲newKanji_食欠人良resourceKanji_decks.anki2", new long[] { 1707525964862 })]
		//Test case: Deck ids not found
		[InlineData("empty_random_decks.anki2", new long[0])]
		public void Get_learning_kanji_decks(string anki2File, long[] expectedDeckIds)
		{
			//Arange
			KanjiDeckService kanjiDeckService = new Anki2TestHelper(anki2File).KanjiDeckService;

			//Act
			var learningKanjiDecks = kanjiDeckService.GetLearningKanjiDecks();

			//Assert
			learningKanjiDecks.GetIds().Should().BeEquivalentTo(expectedDeckIds);
		}
	}
}
