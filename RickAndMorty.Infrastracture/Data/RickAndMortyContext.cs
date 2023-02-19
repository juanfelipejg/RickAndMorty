using Microsoft.EntityFrameworkCore;
using RickAndMorty.Domain.Models.Characters;
using RickAndMorty.Domain.Models.Episodes;

namespace RickAndMorty.Infrastracture.Data
{
    public class RickAndMortyContext: DbContext
    {
        public RickAndMortyContext( DbContextOptions<RickAndMortyContext> options ): base( options )
        {

        }

        public DbSet<Character> Characters => Set<Character>();

        public DbSet<Episode> Episodes => Set<Episode>();
    }
}
