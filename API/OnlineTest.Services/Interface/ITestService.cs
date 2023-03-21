using OnlineTest.Services.DTO;
using OnlineTest.Services.DTO.AddDTO;
using OnlineTest.Services.DTO.UpdateDTO;

namespace OnlineTest.Services.Interface
{
    public interface ITestService
    {
        ResponseDTO GetTests();
        ResponseDTO GetTestById(int id);
        ResponseDTO GetTestsPagination(int PageNo, int RowsPerPage);
        ResponseDTO GetTestsByTechnologyId(int technologyId);
        ResponseDTO AddTest(AddTestDTO test);
        ResponseDTO UpdateTest(UpdateTestDTO test);
        ResponseDTO DeleteTest(int id);
    }
}
