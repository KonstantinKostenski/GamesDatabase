namespace GameDatabase.Services
{
    public interface IUtilityService
    {
        string EncodePassword(string password);

        string DecodePassword(string password);
        
    }
}