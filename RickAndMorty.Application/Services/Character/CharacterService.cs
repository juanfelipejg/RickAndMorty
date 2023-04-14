namespace RickAndMorty.Application.Services.Character
{
	using RickAndMorty.Domain.Models.Characters;
	using RickAndMorty.Domain.Services;
	using RickAndMorty.Infrastracture.Data;
	using Microsoft.EntityFrameworkCore;

	public class CharacterService: ICharacterService
	{
		private readonly ICharacterGetter characterGetter;
		private readonly IRickAndMortyContext rickAndMortyContext;

		public CharacterService( ICharacterGetter characterGetter, IRickAndMortyContext rickAndMortyContext )
		{
			this.characterGetter = characterGetter;
			this.rickAndMortyContext = rickAndMortyContext;
		}

		public IEnumerable<Character> GetAll()
		{
			return this.characterGetter.GetAll();
		}

		public IEnumerable<Character> GetAllFavoriteCharacters()
		{
			return this.rickAndMortyContext.Characters().AsNoTracking().ToList();
		}

		public Character Create( Character character )
		{
			this.rickAndMortyContext.Characters().Add( character );
			this.rickAndMortyContext.SaveChanges();

			return character;
		}

		public void Update( string id, Character character )
		{
			Character? characterToUpdate = this.rickAndMortyContext.Characters().Find( id );

			if( characterToUpdate is null )
			{
				throw new InvalidOperationException( "Character does not exist" );
			}

			characterToUpdate = character;

			this.rickAndMortyContext.SaveChanges();
		}

		public void DeleteById( string id )
		{
			var characterToDelete = this.rickAndMortyContext.Characters().Find( id );

			if( characterToDelete is not null )
			{
				this.rickAndMortyContext.Characters().Remove( characterToDelete );
				this.rickAndMortyContext.SaveChanges();
			}
		}
	}
}