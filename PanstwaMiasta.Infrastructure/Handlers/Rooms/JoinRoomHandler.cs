using PanstwaMiasta.Infrastructure.Commands;
using PanstwaMiasta.Infrastructure.Commands.Rooms;
using PanstwaMiasta.Infrastructure.Services;
using System.Threading.Tasks;

namespace PanstwaMiasta.Infrastructure.Handlers.Rooms
{
    public class JoinRoomHandler : ICommandHandler<JoinRoom>
    {
        private readonly IRoomService _roomService;

        public JoinRoomHandler(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public async Task HandleAsync(JoinRoom command)
        {
            await _roomService.AddMemberAsync(command.PlayerId, command.RoomId);
        }
    }
}
