using Microsoft.Extensions.Caching.Memory;
using PanstwaMiasta.Infrastructure.Commands;
using PanstwaMiasta.Infrastructure.Commands.Accounts;
using PanstwaMiasta.Infrastructure.Extensions;
using PanstwaMiasta.Infrastructure.Services;
using System.Threading.Tasks;

namespace PanstwaMiasta.Infrastructure.Handlers.Players
{
    public class LoginHandler : ICommandHandler<Login>
    {
        private readonly IPlayerService _playerService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _cache;

        public LoginHandler(IPlayerService playerService, IJwtHandler jwtHandler,
            IMemoryCache cache)
        {
            _playerService = playerService;
            _jwtHandler = jwtHandler;
            _cache = cache;
        }

        public async Task HandleAsync(Login command)
        {
            await _playerService.LoginAsync(command.Nickname, command.Password, command.DeviceId);
            var player = await _playerService.GetAsync(command.Nickname);
            var jwt = _jwtHandler.CreateToken(player.Id);
            _cache.SetJwt(command.TokenId, jwt);
        }
    }
}
