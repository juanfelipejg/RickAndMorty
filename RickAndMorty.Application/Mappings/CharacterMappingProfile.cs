namespace RickAndMorty.Application.Mappings
{
    using AutoMapper;
    using RickAndMorty.Domain.Models.Character;

    public class CharacterMappingProfile: Profile
    {
        public CharacterMappingProfile()
        {
            this.CreateMap<Infrastracture.Dtos.Character.Character, Character>();
        }        
    }
}
