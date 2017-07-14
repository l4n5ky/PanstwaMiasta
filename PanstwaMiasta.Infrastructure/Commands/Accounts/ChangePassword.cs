namespace PanstwaMiasta.Infrastructure.Commands.Accounts
{
    public class ChangePassword : AuthenticatedCommandBase
    {
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}
