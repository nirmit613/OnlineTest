using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.GetDTO;
using OnlineTest.Services.DTO.UpdateDTO;

namespace OnlineTest.Services.Interfaces
{
    public interface IRTokenService
    {
        GetRTokenDTO GetRefreshToken(RefreshDTO user);
        bool AddRefreshToken(AddRTokenDTO rToken);
        bool ExpireRefreshToken(UpdateRTokenDTO rToken);
    }
}