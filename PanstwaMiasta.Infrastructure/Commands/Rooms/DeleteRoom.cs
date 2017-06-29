using System;

namespace PanstwaMiasta.Infrastructure.Commands.Rooms
{
    public class DeleteRoom : ICommand
    {
        public Guid RoomId { get; set; }
    }
}
