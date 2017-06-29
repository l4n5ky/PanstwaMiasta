using Microsoft.AspNetCore.Mvc;
using PanstwaMiasta.Infrastructure.Commands;
using PanstwaMiasta.Infrastructure.Commands.Players;
using PanstwaMiasta.Infrastructure.DTO;
using PanstwaMiasta.Infrastructure.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PanstwaMiasta.Api.Controllers
{
    [Route("[controller]")]
    public class PlayersController : Controller
    {
        private readonly ICommandDispatcher CommandDispatcher;
        private readonly IPlayerService _playerService;

        public PlayersController(ICommandDispatcher dispatcher, IPlayerService playerService)
        {
            CommandDispatcher = dispatcher;
            _playerService = playerService;
        }

        [HttpGet("")]
        public async Task<IEnumerable<PlayerDto>> GetAll()
            => await _playerService.BrowseAsync();

        [HttpGet("{nickname}")]
        public async Task<IActionResult> Get(string nickname)
        {
            var player = await _playerService.GetAsync(nickname);
            if (player == null)
            {
                return NotFound();
            }

            return Json(player);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreatePlayer command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return Created($"players/{command.Nickname}", null);
        }
    }
}
