﻿namespace PanstwaMiasta.Infrastructure.DTO
{
    public class JwtDto
    {
        public string Token { get; set; }
        public long Expiry { get; set; }
    }
}
