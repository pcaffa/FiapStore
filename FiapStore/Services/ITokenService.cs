using FiapStore.Entity;

namespace FiapStore.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
