using System.ComponentModel.DataAnnotations.Schema;

namespace anki_japanese_flashcard_manager_backend.DomainLayer.Entities
{
	public class Deck
	{
		public long Id { get; protected set; }
		public string Name { get; protected set; }
		[Column("mtime_secs")]
		public int MtimeSecs { get; protected set; }
		public byte[] Common { get; protected set; }
		public byte[] Kind { get; protected set; }
	}
}
