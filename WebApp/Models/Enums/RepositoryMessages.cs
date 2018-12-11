namespace WebApp.Models
{
    public enum RepositoryResponses : byte
    {
        Success,
        UsernameAlreadyTaken,
        EmailAlreadyRegistered,
        PhoneAlreadyRegistered,
        UnknownError
    }
}
