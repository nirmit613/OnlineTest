namespace OnlineTest.Models.Interfaces
{
    public interface ITestRepository
    {
        IEnumerable<Test> GetTests();
        Test GetTestById(int id);
        IEnumerable<Test> GetTestsPaginatation(int PageNo, int RowsPerPage);
        IEnumerable<Test> GetTestsByTechnologyId(int technologyId);
        Test IsTestExists(Test test);
        int AddTest(Test test);
        bool UpdateTest(Test test);
        bool DeleteTest(Test test);
    }
}

