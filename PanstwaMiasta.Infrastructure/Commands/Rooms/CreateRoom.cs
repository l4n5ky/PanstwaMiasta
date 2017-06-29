using System;

namespace PanstwaMiasta.Infrastructure.Commands.Rooms
{
    public class CreateRoom : ICommand
    {
        public Guid RoomCreatorId { get; set; }
    }
}
