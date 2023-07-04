using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using RickAndMorty.Domain.Models.Characters;

namespace RickAndMorty.Domain.Models.Episodes
{
	public class EpisodeCharacter
	{
		public int EpisodeId { get; set; }

		[IgnoreDataMember]
		[JsonIgnore]
		public Episode? Episode { get; set; }

		public int CharacterId { get; set; }

		[IgnoreDataMember]
		public Character? Character  { get; set; }
	}
}
