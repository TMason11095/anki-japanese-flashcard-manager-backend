using anki_japanese_flashcard_manager_backend.ApplicationLayer.Interfaces.Services.Managements;
using anki_japanese_flashcard_manager_backend.ApplicationLayer.Interfaces.Services;
using anki_japanese_flashcard_manager_backend.ApplicationLayer.Services.Managements;
using anki_japanese_flashcard_manager_backend.ApplicationLayer.Services;
using anki_japanese_flashcard_manager_backend.DataAccessLayer.Contexts;
using anki_japanese_flashcard_manager_backend.DataAccessLayer.Interfaces.Contexts;
using anki_japanese_flashcard_manager_backend.DataAccessLayer.Repositories;
using anki_japanese_flashcard_manager_backend.DomainLayer.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace anki_japanese_flashcard_manager_backend.Composition
{
	public static class CompositionRoot
	{
		public static void Compose(IServiceCollection services, string dbPath)
		{
			//Register the Data Access Layer
			services.AddScoped<IAnki2Context, Anki2Context>(provider => new Anki2Context(dbPath));
			services.AddScoped<ICardRepository, CardRepository>();
			services.AddScoped<IDeckRepository, DeckRepository>();
			//Register the Application Layer
			services.AddScoped<IDeckService, DeckService>();
			services.AddScoped<IKanjiCardService, KanjiCardService>();
			services.AddScoped<IKanjiDeckService, KanjiDeckService>();
			services.AddScoped<IKanjiNoteService, KanjiNoteService>();
			services.AddScoped<IKanjiServiceManagement, KanjiServiceManagement>();
		}
	}
}
