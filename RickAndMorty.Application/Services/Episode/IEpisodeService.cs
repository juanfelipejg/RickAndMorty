using RickAndMorty.Domain.Models.Episodes;

namespace RickAndMorty.Application.Services
{
    public interface IEpisodeService
    {
        List<Episode> GetAll();

        Episode GetById(int id);

        Episode Create(Episode episode);

        Episode Update(Episode episode);

        void Delete(int id);
    }
}
