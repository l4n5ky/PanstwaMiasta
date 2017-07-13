using PanstwaMiasta.Infrastructure.Commands;
using PanstwaMiasta.Infrastructure.Commands.Accounts;
using PanstwaMiasta.Infrastructure.Services;
using System;
using System.Threading.Tasks;

namespace PanstwaMiasta.Infrastructure.Handlers.Players
{
    public class RegisterHandler : ICommandHandler<Register>
    {
        private readonly IPlayerService _playerService;

        public RegisterHandler(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public async Task HandleAsync(Register command)
        {
            await _playerService.RegisterAsync(Guid.NewGuid(), command.Nickname, command.Password);
        }
    }
}
