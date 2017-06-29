using PanstwaMiasta.Infrastructure.Commands;
using PanstwaMiasta.Infrastructure.Commands.Players;
using PanstwaMiasta.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PanstwaMiasta.Infrastructure.Handlers.Players
{
    public class CreatePlayerHandler : ICommandHandler<CreatePlayer>
    {
        private readonly IPlayerService _playerService;

        public CreatePlayerHandler(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public async Task HandleAsync(CreatePlayer command)
        {
            await _playerService.RegisterAsync(Guid.NewGuid(), command.Nickname, command.Password);
        }
    }
}
