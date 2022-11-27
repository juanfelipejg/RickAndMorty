namespace RickAndMorty.Application.Services.Character
{
    using System.Collections.Generic;
    using RickAndMorty.Domain.Models.Character;

    public interface ICharacterService
    {
        IEnumerable<Character> GetAll();
    }
}
