using Microsoft.AspNetCore.Mvc;
using RickAndMorty.Application.Services;
using RickAndMorty.Domain.Models.Episodes;

namespace RickAndMorty.Api.Controllers
{
    [ApiController]
    [Route("api/episodes")]
    public class EpisodeController: ControllerBase
    {
        private IEpisodeService episodeService;

        public EpisodeController(IEpisodeService episodeService)
        {
            this.episodeService = episodeService;
        }

        [HttpGet]
        public List<Episode> GetAll()
        {
            return this.episodeService.GetAll();
        }

        [HttpPost]
        public Episode Create( Episode episode ) { return this.episodeService.Create( episode ); }
    }
}
