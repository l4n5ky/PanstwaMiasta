using PanstwaMiasta.Infrastructure.Commands;
using PanstwaMiasta.Infrastructure.Commands.Rooms;
using PanstwaMiasta.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PanstwaMiasta.Infrastructure.Handlers.Rooms
{
    public class DeleteRoomHandler : ICommandHandler<DeleteRoom>
    {
        private readonly IRoomService _roomService;

        public DeleteRoomHandler(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public async Task HandleAsync(DeleteRoom command)
        {
            await _roomService.DeleteAsync(command.RoomId);
        }
    }
}
