﻿using System;

namespace PanstwaMiasta.Infrastructure.DTO
{
    public class PlayerDto
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
