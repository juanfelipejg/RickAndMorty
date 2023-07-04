namespace RickAndMorty.Application.Services.Characters
{
	using Domain.Models.Characters;
	using Domain.Services;
	using Infrastracture.Data;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Logging;

	public class CharacterService: ICharacterService
	{
		private readonly ICharacterGetter characterGetter;
		private readonly RickAndMortyContext rickAndMortyContext;
		private readonly ILogger<CharacterService> logger;

		public CharacterService( ICharacterGetter characterGetter, RickAndMortyContext rickAndMortyContext, ILogger<CharacterService> logger )
		{
			this.characterGetter = characterGetter;
			this.rickAndMortyContext = rickAndMortyContext;
			this.logger = logger;
		}

		public IEnumerable<Character> GetAll()
		{
			return this.characterGetter.GetAll();
		}

		public IEnumerable<Character> GetAllFavoriteCharacters()
		{
			return this.rickAndMortyContext.Characters.AsNoTracking().ToList();
		}

		public Character Create( Character character )
		{
			this.rickAndMortyContext.Characters.Add( character );
			this.logger.LogInformation( $"Se esta ingresando el character: {character}" );
			this.rickAndMortyContext.SaveChanges();

			return character;
		}

		public void Update( string id, Character character )
		{
			Character? characterToUpdate = this.rickAndMortyContext.Characters.Find( id );

			if( characterToUpdate is null )
			{
				throw new InvalidOperationException( "Character does not exist" );
			}

			characterToUpdate = character;

			this.rickAndMortyContext.SaveChanges();
		}

		public void DeleteById( string id )
		{
			var characterToDelete = this.rickAndMortyContext.Characters.Find( id );

			if( characterToDelete is not null )
			{
				this.rickAndMortyContext.Characters.Remove( characterToDelete );
				this.rickAndMortyContext.SaveChanges();
			}
		}
	}
}