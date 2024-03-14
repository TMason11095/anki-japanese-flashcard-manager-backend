﻿using anki_japanese_flashcard_manager_backend.ApplicationLayer.Services;
using anki_japanese_flashcard_manager_backend.DataAccessLayer.Repositories;
using anki_japanese_flashcard_manager_backend.DomainLayer.Entities;
using anki_japanese_flashcard_manager_backend.DomainLayer.Helpers;
using Tests.TestHelpers;

namespace Tests.ApplicationLayer.Services
{
	public class KanjiNoteServiceTests
	{
		[Theory]
		//Test Case: Note ids found
		[InlineData("飲newKanji_食欠人良resourceKanji_decks.anki2", 1707160947123, new[] { 1707169497960, 1707169570657, 1707169983389, 1707170000793 })]
		[InlineData("飲newKanji_食欠人良resourceKanji_decks.anki2", 1707160682667, new[] { 1707169522144 })]
		//Test Case: Note ids not found
		[InlineData("deck_with_different_card_types.anki2", 1707263514556, new long[0])]
		public void Get_kanji_notes(string anki2File, long deckId, long[] expectedNoteIds)
		{
			//Arrange
			Anki2TestHelper helper = new Anki2TestHelper(anki2File);
			CardRepository cardRepo = helper.CardRepository;
			IEnumerable<Note> notes = cardRepo.GetDeckNotes(deckId);
			KanjiNoteService kanjiNoteService = helper.KanjiNoteService;

			//Act
			var taggedNotes = kanjiNoteService.GetKanjiNotes(notes);

			//Assert
			taggedNotes.GetIds().Should().BeEquivalentTo(expectedNoteIds);
		}

		[Theory]
		//Test case: Sub kanji ids found
		[InlineData("飲newKanji_食欠人良resourceKanji_decks.anki2", 1707160682667, new[] { "1472", "466" })]
		//Test case: Sub kanji ids not found
		[InlineData("deck_with_different_card_types.anki2", 1707263514556, new string[0])]
		//Test case: Duplicate sub kanji ids found is a distinct list
		[InlineData("飲newKanji_食欠人良resourceKanji_decks.anki2", 1707160947123, new[] { "1468", "951" })]
		public void Get_sub_kanji_ids_from_notes(string anki2File, long deckId, string[] expectedSubKanjiIds)
		{
			//Arrange
			Anki2TestHelper helper = new Anki2TestHelper(anki2File);
			CardRepository cardRepo = helper.CardRepository;
			IEnumerable<Note> notes = cardRepo.GetDeckNotes(deckId);
			KanjiNoteService kanjiNoteService = helper.KanjiNoteService;
			IEnumerable<Note> kanjiNotes = kanjiNoteService.GetKanjiNotes(notes);

			//Act
			IEnumerable<string> subKanjiIds = kanjiNoteService.GetSubKanjiIds(kanjiNotes);

			//Assert
			subKanjiIds.Should().BeEquivalentTo(expectedSubKanjiIds);
		}

		[Theory]
		//Test Case: Note ids pulled
		[InlineData("飲newKanji_食欠人良resourceKanji_decks.anki2", 1707160947123, 1707160682667, new[] { 1707169497960, 1707169570657, 1707169983389, 1707170000793 })]
		//Test Case: Note ids not pulled
		[InlineData("飲newKanji_食欠人良resourceKanji_decks.anki2", 1706982318565, 1707160682667, new long[0])]
		public void Pull_all_sub_kanji_notes_from_note_list(string anki2File, long sourceDeckId, long originalKanjiDeckId, long[] expectedKanjiNoteIds)
		{
			//Arrange
			Anki2TestHelper helper = new Anki2TestHelper(anki2File);
			KanjiNoteService kanjiNoteService = helper.KanjiNoteService;
			CardRepository cardRepo = helper.CardRepository;
			List<Note> sourceNotes = cardRepo.GetDeckNotes(sourceDeckId).ToList();
			int sourceNotesOriginalCount = sourceNotes.Count;
			List<Note> originalKanjiNotes = cardRepo.GetDeckNotes(originalKanjiDeckId).ToList();

			//Act
			var subKanjiNotes = kanjiNoteService.PullAllSubKanjiNotesFromNoteList(ref sourceNotes, originalKanjiNotes);

			//Assert
			sourceNotes.Count.Should().Be(sourceNotesOriginalCount - subKanjiNotes.Count);//Should have removed all the found kanji notes
			subKanjiNotes.GetIds().Should().BeEquivalentTo(expectedKanjiNoteIds);
		}

		[Theory]
		//Test case: Note ids found
		[InlineData("飲newKanji_食欠人良resourceKanji_decks.anki2", 1707160947123, "kid:", new[] { 1707169497960, 1707169570657, 1707169983389, 1707170000793 })]
		[InlineData("飲newKanji_食欠人良resourceKanji_decks.anki2", 1707160682667, "kid:", new[] { 1707169522144 })]
		//Test case: Note ids not found
		[InlineData("deck_with_different_card_types.anki2", 1707263514556, "kid:", new long[0])]
		[InlineData("飲newKanji_食欠人良resourceKanji_decks.anki2", 1707160947123, "nonExistentTag:", new long[0])]
		public void Get_notes_by_note_tag(string anki2File, long deckId, string noteTagName, long[] expectedNoteIds)
		{
			//Arrange
			Anki2TestHelper helper = new Anki2TestHelper(anki2File);
			KanjiNoteService kanjiNoteService = helper.KanjiNoteService;
			CardRepository cardRepo = helper.CardRepository;
			IEnumerable<Note> notes = cardRepo.GetDeckNotes(deckId);

			//Act
			var taggedNotes = kanjiNoteService.GetTaggedNotes(notes, noteTagName);

			//Assert
			taggedNotes.GetIds().Should().BeEquivalentTo(expectedNoteIds);
		}

		[Theory]
		//Test case: Note ids found
		[InlineData("飲newKanji_食欠人良resourceKanji_decks.anki2", 1707160682667, new[] { "1474" }, new[] { 1707169522144 })]
		[InlineData("飲newKanji_食欠人良resourceKanji_decks.anki2", 1707160947123, new[] { "1472", "466", "951", "1468" }, new[] { 1707169497960, 1707169570657, 1707169983389, 1707170000793 })]
		//Test case: Note ids not found
		[InlineData("飲newKanji_食欠人良resourceKanji_decks.anki2", 1707160682667, new[] { "0", "nonExistentId" }, new long[0])]
		public void Get_notes_by_kanji_ids(string anki2File, long deckId, string[] kanjiIds, long[] expectedNoteIds)
		{
			//Arrange
			Anki2TestHelper helper = new Anki2TestHelper(anki2File);
			KanjiNoteService kanjiNoteService = helper.KanjiNoteService;
			CardRepository cardRepo = helper.CardRepository;
			IEnumerable<Note> notes = cardRepo.GetDeckNotes(deckId);

			//Redundant? (Filter for "kid:" but then instantly filter again to grab the ids)
			//(Only care about using GetKanjiNotes() when trying to access data that isn't "kid")
			//List<Note> kanjiNotes = anki2Controller.GetKanjiNotes(notes);

			//Act
			var kanjiNotes = kanjiNoteService.GetNotesByKanjiIds(notes, kanjiIds);

			//Assert
			kanjiNotes.GetIds().Should().BeEquivalentTo(expectedNoteIds);
		}
	}
}
