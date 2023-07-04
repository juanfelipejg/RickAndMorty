namespace RickAndMorty.Application.Services.Characters
{
    using System.Collections.Generic;
    using RickAndMorty.Domain.Models.Characters;

    public interface ICharacterService
    {
        IEnumerable<Character> GetAll();

        IEnumerable<Character> GetAllFavoriteCharacters();

        Character Create(Character character);

        void Update(string id, Character character);

        void DeleteById(string id);
    }
}
