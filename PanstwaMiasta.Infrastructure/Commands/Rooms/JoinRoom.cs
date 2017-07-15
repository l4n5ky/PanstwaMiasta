using System;

namespace PanstwaMiasta.Infrastructure.Commands.Rooms
{
    public class JoinRoom : ICommand
    { 
        public Guid RoomId { get; set; }
        public Guid PlayerId { get; set; }
    }
}