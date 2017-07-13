namespace PanstwaMiasta.Infrastructure.Commands.Accounts
{
    public class Register : ICommand
    {
        public string Nickname { get; set; }
        public string Password { get; set; }
    }
}
