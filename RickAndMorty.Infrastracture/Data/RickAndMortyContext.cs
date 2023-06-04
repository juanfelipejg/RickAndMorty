namespace RickAndMorty.Infrastracture.Data
{
	using Microsoft.EntityFrameworkCore;
	using Domain.Models.Characters;
	using Domain.Models.Episodes;

	public class RickAndMortyContext: DbContext
	{
		public RickAndMortyContext( DbContextOptions<RickAndMortyContext> options ) : base( options )
		{

		}

		public DbSet<Character> Characters  { get; set; }

        public DbSet<Episode> Episodes { get; set; }

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

		protected override void OnModelCreating( ModelBuilder modelBuilder )
		{
			modelBuilder.Entity<Character>()
				.HasMany( c => c.Episodes )
				.WithMany( e => e.Characters );
		}
	}
}
