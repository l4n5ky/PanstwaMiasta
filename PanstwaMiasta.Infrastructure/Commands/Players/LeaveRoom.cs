using System;

namespace PanstwaMiasta.Infrastructure.Commands.Players
{
    public class LeaveRoom : ICommand
    {
        public Guid RoomId { get; set; }
    }
}
