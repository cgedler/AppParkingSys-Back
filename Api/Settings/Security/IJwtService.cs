using Core.Entities;

namespace Api.Settings.Security
{
    public interface IJwtService
    {
        string GenerateToken(User user);
        bool validatePassword(string loginPassword, string registeredPassword);
    }
}
