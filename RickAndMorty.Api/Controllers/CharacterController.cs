namespace RickAndMorty.Api.Controllers
{
	using Application.Services.Characters;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using RickAndMorty.Domain.Models.Characters;

	[ApiController]
    [Route( "api/characters" )]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService characterService;

        public CharacterController( ICharacterService characterService )
        {
            this.characterService = characterService;
        }

		[HttpGet]		
		public IEnumerable<Character> Get()
        {
            return this.characterService.GetAll();
        }

        [HttpPost]
		[Authorize]
		public Character AddFavoriteCharacter(Character character)
        {
            return this.characterService.Create(character);
        }
    }
}