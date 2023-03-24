namespace OnlineTest.Services.Interface
{
    public interface IUserRoleService
    {
        List<string> GetRoles(int userId);
    }
}
