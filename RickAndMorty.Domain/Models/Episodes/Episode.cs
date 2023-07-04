namespace RickAndMorty.Domain.Models.Episodes
{
	public class Episode
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<EpisodeCharacter> Characters { get; set; }
    }
}
