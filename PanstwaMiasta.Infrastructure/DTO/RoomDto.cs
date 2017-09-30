using System;
using System.Collections.Generic;

namespace PanstwaMiasta.Infrastructure.DTO
{
    public class RoomDto
    {
        public int Number { get; set; }
        public bool IsActive { get; set; }
        public Guid Id { get; set; }
        public IEnumerable<PlayerDto> Players { get; set; }
        public Guid RoomAdminId { get; set; }
    }
}