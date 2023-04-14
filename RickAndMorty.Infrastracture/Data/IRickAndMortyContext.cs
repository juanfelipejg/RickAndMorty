namespace RickAndMorty.Infrastracture.Data
{
	using Microsoft.EntityFrameworkCore;
	using RickAndMorty.Domain.Models.Characters;
	using RickAndMorty.Domain.Models.Episodes;

	public interface IRickAndMortyContext
	{
		DbSet<Character> Characters();

		DbSet<Episode> Episodes();

		int SaveChanges();
	}
}
