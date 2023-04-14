namespace RickAndMorty.Infrastracture.Data
{
	using Microsoft.EntityFrameworkCore;
	using Domain.Models.Characters;
	using Domain.Models.Episodes;

    public class RickAndMortyContext: DbContext, IRickAndMortyContext
    {
        public RickAndMortyContext( DbContextOptions<RickAndMortyContext> options ): base( options )
        {

        }

        public virtual DbSet<Character> Characters() => this.Set<Character>();

        public virtual DbSet<Episode> Episodes() => this.Set<Episode>();

		public int SaveChanges()
		{
			try
			{
				int result = base.SaveChanges();
				
				return result;
			}
			catch( DbUpdateException ex )
			{
				throw new Exception( "Ocurrió un error al guardar los cambios en la base de datos.", ex );
			}
		}
	}
}
