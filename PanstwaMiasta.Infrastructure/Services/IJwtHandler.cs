using PanstwaMiasta.Infrastructure.DTO;
using System;

namespace PanstwaMiasta.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(Guid playerId); 
    }
}
