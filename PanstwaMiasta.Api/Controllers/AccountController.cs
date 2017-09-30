using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PanstwaMiasta.Infrastructure.Commands;
using PanstwaMiasta.Infrastructure.Commands.Accounts;
using PanstwaMiasta.Infrastructure.Extensions;
using System;
using System.Threading.Tasks;

namespace PanstwaMiasta.Api.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IMemoryCache _cache;

        public AccountController(ICommandDispatcher commandDispatcher,
            IMemoryCache cache) : base(commandDispatcher)
        {
            _cache = cache;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody]Register command)
        {
            await DispatchAsync(command);

            return Created($"account/{command.Nickname}", null);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]Login command)
        {
            command.TokenId = Guid.NewGuid();
            await DispatchAsync(command);
            var jwt = _cache.GetJwt(command.TokenId);

            return Json(jwt);
        }

        [Authorize]
        [HttpPut("update")]
        public async Task<IActionResult> Put([FromBody]ChangePassword command)
        {
            await DispatchAsync(command);

            return Ok();
        }
    }
}
