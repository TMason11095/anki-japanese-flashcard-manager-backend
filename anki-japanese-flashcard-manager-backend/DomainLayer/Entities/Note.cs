using System.ComponentModel.DataAnnotations.Schema;

namespace anki_japanese_flashcard_manager_backend.DomainLayer.Entities
{
	public class Note
	{
		public long Id { get; protected set; }
		public string Tags { get; protected set; }
		[NotMapped] //Convert space delimited Tags field to list
		public List<string> TagsList { get { return Tags.Split(' ').ToList(); } }
		[Column("flds")]
		public string Fields { get; protected set; }
		[Column("sfld")]
		public string SortField { get; protected set; }
	}
}
