using System;

namespace PanstwaMiasta.Infrastructure.Commands.Rooms
{
    public class LeaveRoom : ICommand
    {
        public Guid RoomId { get; set; }
        public Guid PlayerId { get; set; }
    }
}
