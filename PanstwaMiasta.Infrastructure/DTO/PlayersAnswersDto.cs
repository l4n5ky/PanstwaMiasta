using System.Collections.Generic;

namespace PanstwaMiasta.Infrastructure.DTO
{
    public class PlayersAnswersDto : PlayerDto
    {
        public IDictionary<string, string> Answers { get; set; }
    }
}
