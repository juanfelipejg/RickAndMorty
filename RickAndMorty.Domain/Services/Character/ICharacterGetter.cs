namespace RickAndMorty.Domain.Services
{
    using Models.Character;

    public interface ICharacterGetter
    {
        IEnumerable<Character> GetAll();
    }
}