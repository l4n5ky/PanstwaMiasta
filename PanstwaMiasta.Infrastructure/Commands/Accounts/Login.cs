using System;

namespace PanstwaMiasta.Infrastructure.Commands.Accounts
{
    public class Login : ICommand
    {
        public Guid TokenId { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
    }
}
