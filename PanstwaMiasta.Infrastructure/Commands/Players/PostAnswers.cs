using PanstwaMiasta.Core.Models;
using System.Collections.Generic;

namespace PanstwaMiasta.Infrastructure.Commands.Players
{
    public class PostAnswers : ICommand
    {
        public IEnumerable<Answer> Answers { get; set; }
    }
}
