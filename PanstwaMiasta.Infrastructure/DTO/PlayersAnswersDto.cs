using PanstwaMiasta.Core.Models;
using System.Collections.Generic;

namespace PanstwaMiasta.Infrastructure.DTO
{
    // 7
    public class PlayersAnswersDto : PlayerDto
    {
        public IEnumerable<Answer> Answers { get; set; }
    }
}
