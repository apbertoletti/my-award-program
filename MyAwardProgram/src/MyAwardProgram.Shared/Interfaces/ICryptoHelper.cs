namespace MyAwardProgram.Shared.Interfaces
{
    public interface ICryptoHelper
    {
        string GenerateHash(string password);
        bool VerifyHash(string typedPassword, string registeredPassword);
    }
}
