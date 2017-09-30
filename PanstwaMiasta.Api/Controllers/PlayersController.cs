using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PanstwaMiasta.Infrastructure.Commands;
using PanstwaMiasta.Infrastructure.DTO;
using PanstwaMiasta.Infrastructure.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PanstwaMiasta.Api.Controllers
{
    public class PlayersController : BaseController
    {
        private readonly IPlayerService _playerService;

        public PlayersController(ICommandDispatcher commandDispatcher,
                IPlayerService playerService, IMemoryCache cache) : base(commandDispatcher)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IEnumerable<PlayerDto>> GetAll()
        {
            var players = await _playerService.BrowseAsync();

            return players;
        }

        [HttpGet("{nickname}")]
        public async Task<IActionResult> Get(string nickname)
        {
            var player = await _playerService.GetAsync(nickname);

            if(player == null)
            {
                return NotFound();
            }

            return Json(player);
        }
    }
}
