using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.GetDTO;
using OnlineTest.Services.DTO.UpdateDTO;

namespace OnlineTest.Services.Interface
{
    public interface IUserService
    {
        ResponseDTO GetUsers();
        ResponseDTO GetUserPagination(int PageNo, int RowsPerPage);
        ResponseDTO GetUserbyId(int id);
        ResponseDTO GetUserbyEmail(string email);
        ResponseDTO AddUser(AddUserDTO user);
        ResponseDTO UpdateUser(UpdateUserDTO user);
        ResponseDTO DeleteUser(int id);
        GetUserDTO IsUserExists(TokenDTO user);
    }
}

