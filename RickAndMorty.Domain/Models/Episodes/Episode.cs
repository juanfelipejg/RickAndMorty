using RickAndMorty.Domain.Models.Characters;

namespace RickAndMorty.Domain.Models.Episodes
{
    public class Episode
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Character> Characters { get; set; }
    }
}
