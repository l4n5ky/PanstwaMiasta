using System;
using System.Collections.Generic;

namespace PanstwaMiasta.Infrastructure.DTO
{
    // 8
    public class RoomDto
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<PlayerDto> Players { get; set; }
    }
}
