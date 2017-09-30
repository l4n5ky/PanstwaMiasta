using PanstwaMiasta.Infrastructure.Commands;
using PanstwaMiasta.Infrastructure.Commands.Rooms;
using PanstwaMiasta.Infrastructure.Services;
using System.Threading.Tasks;

namespace PanstwaMiasta.Infrastructure.Handlers.Rooms
{
    public class LeaveRoomHandler : ICommandHandler<LeaveRoom>
    {
        private readonly IRoomService _roomService;

        public LeaveRoomHandler(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public async Task HandleAsync(LeaveRoom command)
        {
            await _roomService.RemoveMemberAsync(command.PlayerId, command.RoomId);
        }
    }
}
