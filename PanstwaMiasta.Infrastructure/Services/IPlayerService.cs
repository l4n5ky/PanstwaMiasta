using PanstwaMiasta.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PanstwaMiasta.Infrastructure.Services
{
    public interface IPlayerService : IService
    {
        Task<PlayerDto> GetAsync(Guid id);
        Task<PlayerDto> GetAsync(string nickname);
        Task<IEnumerable<PlayerDto>> BrowseAsync();
        Task RegisterAsync(Guid id, string nickname, string password);
        Task LoginAsync(string nickname, string password);
        Task UpdateAsync(Guid id, string password, string newPassword);
    }
}
