using PanstwaMiasta.Infrastructure.Commands;
using PanstwaMiasta.Infrastructure.Commands.Accounts;
using PanstwaMiasta.Infrastructure.Services;
using System.Threading.Tasks;

namespace PanstwaMiasta.Infrastructure.Handlers.Accounts
{
    class ChangePasswordHandler : ICommandHandler<ChangePassword>
    {
        private readonly IPlayerService _playerService;

        public ChangePasswordHandler(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public async Task HandleAsync(ChangePassword command)
        {
            await _playerService.UpdateAsync(command.Id, command.Password, command.NewPassword);
        }
    }
}
