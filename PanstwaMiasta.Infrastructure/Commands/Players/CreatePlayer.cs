namespace PanstwaMiasta.Infrastructure.Commands.Players
{
    public class CreatePlayer : ICommand
    {
        public string Nickname { get; set; }
        public string Password { get; set; }
    }
}
