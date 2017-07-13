using System;

namespace PanstwaMiasta.Infrastructure.Commands.Accounts
{
    public class ChangePassword : ICommand
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}
