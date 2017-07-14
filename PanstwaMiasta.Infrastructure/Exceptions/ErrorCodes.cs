namespace PanstwaMiasta.Infrastructure.Exceptions
{
    public static class ErrorCodes
    {
        public static string UserExist => "username_in_use";
        public static string UserNotFound => "user_not_found";
        public static string InvalidCredentials => "invalid_credentials";
    }
}
