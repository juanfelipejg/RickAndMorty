using Microsoft.EntityFrameworkCore;
using RickAndMorty.Domain.Models.Episodes;
using RickAndMorty.Infrastracture.Data;

namespace RickAndMorty.Application.Services
{
	public class EpisodeService: IEpisodeService
	{
		private readonly RickAndMortyContext rickAndMortyContext;

		public EpisodeService( RickAndMortyContext rickAndMortyContext )
		{
			this.rickAndMortyContext = rickAndMortyContext;
		}

		public Episode Create( Episode episode )
		{
			this.rickAndMortyContext.Episodes.Add( episode );
			this.rickAndMortyContext.SaveChanges();
			return episode;
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
