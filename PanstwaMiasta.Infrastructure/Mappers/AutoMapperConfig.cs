using AutoMapper;
using PanstwaMiasta.Core.Models;
using PanstwaMiasta.Infrastructure.DTO;

namespace PanstwaMiasta.Infrastructure.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Player, PlayerDto>();
            })
            .CreateMapper();
    }
}
