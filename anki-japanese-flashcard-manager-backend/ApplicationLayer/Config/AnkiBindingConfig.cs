using anki_japanese_flashcard_manager_backend.ApplicationLayer.DTOs.Config;
using Newtonsoft.Json;

namespace anki_japanese_flashcard_manager_backend.ApplicationLayer.Config
{
	public static class AnkiBindingConfig
	{
		public static readonly AnkiBindingTagsDTO Bindings;

		static AnkiBindingConfig()
		{
			//Get the bindings JSON data (search all subdirectories as it'll move if used as a submodule)
			string jsonFilePath = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "ankiBindingTags.json", SearchOption.AllDirectories).FirstOrDefault();
			string json = File.ReadAllText(jsonFilePath);
			//Setup the settings to ignore any extra properties
			JsonSerializerSettings settings = new JsonSerializerSettings
			{
				MissingMemberHandling = MissingMemberHandling.Ignore
			};
			//Set the bindings
			Bindings = JsonConvert.DeserializeObject<AnkiBindingTagsDTO>(json, settings);
		}
	}
}
