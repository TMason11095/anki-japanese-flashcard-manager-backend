﻿using anki_japanese_flashcard_manager_backend.DataAccessLayer.Interfaces.Contexts;
using anki_japanese_flashcard_manager_backend.DomainLayer.Entities;
using anki_japanese_flashcard_manager_backend.DomainLayer.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anki_japanese_flashcard_manager_backend.DataAccessLayer.Repositories
{
	public class DeckRepository : IDeckRepository
	{
		private readonly IAnki2Context _context;

		public DeckRepository(IAnki2Context context)
		{
			_context = context;
		}

		public IEnumerable<Deck> GetDecksByDescriptionContaining(string descriptionPart)
		{
			//Get all the decks
			var decks = _context.Decks;
			//Remap to decode the description field (Kind) (Convert to List as the following .Where() tries calling DecodeBlob() and fails if you don't)
			var deckDescs = decks.Select(d => new
			{
				deck = d,
				description = DecodeBlob(d.Kind)
			}).ToList();
			//Filter to find the decks with the tag in its description
			var DecksContaining = deckDescs
				.Where(d => d.description.Contains(descriptionPart, StringComparison.OrdinalIgnoreCase))
				.Select(d => d.deck);
			//Return
			return DecksContaining;
		}

		private static string DecodeBlob(byte[] blob)
		{
			return System.Text.Encoding.UTF8.GetString(blob);
		}
	}
}
