using System;

namespace PanstwaMiasta.Infrastructure.Commands.Players
{
    public class ConnectToRoom : ICommand
    {
        public Guid RoomId { get; set; }
    }
}
