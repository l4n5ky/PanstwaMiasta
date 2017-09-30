using PanstwaMiasta.Infrastructure.Commands;
using PanstwaMiasta.Infrastructure.Commands.Rooms;
using PanstwaMiasta.Infrastructure.Services;
using System.Threading.Tasks;

namespace PanstwaMiasta.Infrastructure.Handlers.Rooms
{
    public class CreateRoomHandler : ICommandHandler<CreateRoom>
    {
        private readonly IRoomService _roomService;

        public CreateRoomHandler(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public async Task HandleAsync(CreateRoom command)
        {
            await _roomService.CreateAsync(command.RoomAdminId);
        }
    }
}
