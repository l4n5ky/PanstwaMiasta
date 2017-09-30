using System;

namespace PanstwaMiasta.Infrastructure.Commands.Rooms
{
    public class StartGame : ICommand
    {
        public Guid RoomId { get; set; }
    }
}
