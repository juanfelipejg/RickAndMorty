namespace RickAndMorty.Application.Services
{
	using System.Collections.Generic;
	using Microsoft.EntityFrameworkCore;
	using Domain.Models.Episodes;
	using Infrastracture.Data;

	public class EpisodeService: IEpisodeService
	{
		private readonly RickAndMortyContext rickAndMortyContext;

		public EpisodeService( RickAndMortyContext rickAndMortyContext )
		{
			this.rickAndMortyContext = rickAndMortyContext;
		}

		public Episode Create( Episode episode )
		{
			var newEpisode = new Episode
			{
				Name = episode.Name,
				Characters = this.GetCharacters( episode.Characters ),
			};

			Episode episodeCreated = this.rickAndMortyContext.Episodes.Add( newEpisode ).Entity;
			this.rickAndMortyContext.SaveChanges();

			return episodeCreated;
		}

		private ICollection<EpisodeCharacter> GetCharacters( ICollection<EpisodeCharacter> characters )
		{
			var newCharacters = new List<EpisodeCharacter>();

			foreach ( var character in characters )
			{
				newCharacters.Add( new EpisodeCharacter
				{
					CharacterId = character.CharacterId
				} );
			}

			return newCharacters;
		}

		public void Delete( int id )
		{
			Episode? episode = this.rickAndMortyContext.Episodes.Find( id );

			if( episode is not null )
			{
				this.rickAndMortyContext.Episodes.Remove( episode );
				this.rickAndMortyContext.SaveChanges();
			}
		}

		public List<Episode> GetAll()
		{
			return this.rickAndMortyContext.Episodes.AsNoTracking().ToList();
		}

		public Episode GetById( int id )
		{
			return this.rickAndMortyContext.Episodes.Find( id );
		}

		public Episode Update( Episode episode )
		{
			throw new NotImplementedException();
		}
	}
}
