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

		protected override void OnModelCreating( ModelBuilder modelBuilder )
		{
			modelBuilder.Entity<EpisodeCharacter>().HasKey( x => new { x.EpisodeId, x.CharacterId } );

			modelBuilder.Entity<EpisodeCharacter>()
				.HasOne( po => po.Episode )
				.WithMany( p => p.Characters )
				.HasForeignKey( po => po.EpisodeId );

			modelBuilder.Entity<EpisodeCharacter>()
				.HasOne( po => po.Character )
				.WithMany( o => o.Episodes )
				.HasForeignKey( po => po.CharacterId );
		}
	}
}
