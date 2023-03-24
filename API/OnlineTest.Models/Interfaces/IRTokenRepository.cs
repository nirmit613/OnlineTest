using OnlineTest.Model;

namespace OnlineTest.Models.Interfaces
{
    public interface IRTokenRepository
    {
        RToken GetRefreshToken(int id, string refreshToken);
        bool AddRefreshToken(RToken token);
        bool ExpireRefreshToken(RToken token);
    }
}