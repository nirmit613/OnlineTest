using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.UpdateDTO;

namespace OnlineTest.Services.Interface
{
    public interface ITechnologyService
    {
        ResponseDTO GetTechnology();
        ResponseDTO GetTechnologyPagination(int PageNo, int RowsPerPage);
        ResponseDTO GetTechnologybyId(int id);
        ResponseDTO GetTechnologyByName(string name);
        ResponseDTO AddTechnology(AddTechnologyDTO test);
        ResponseDTO UpdateTechnology(UpdateTechnologyDTO test);
        ResponseDTO DeleteTechnology(int id);
    }
}
