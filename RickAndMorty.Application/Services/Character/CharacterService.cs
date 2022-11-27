namespace RickAndMorty.Application.Services.Character
{
    using RickAndMorty.Domain.Models.Character;
    using RickAndMorty.Domain.Services;

    public class CharacterService : ICharacterService
    {
        private readonly ICharacterGetter characterGetter;

        public CharacterService( ICharacterGetter characterGetter )
        {
            this.characterGetter = characterGetter;
        }

        public IEnumerable<Character> GetAll()
        {
            return this.characterGetter.GetAll();
        }
    }
}