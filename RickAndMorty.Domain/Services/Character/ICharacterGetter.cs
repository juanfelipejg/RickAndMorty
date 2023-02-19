namespace RickAndMorty.Domain.Services
{
    using Models.Characters;

    public interface ICharacterGetter
    {
        IEnumerable<Character> GetAll();
    }
}