using Entities.Entities;

namespace BussinessLogic.Abstractions
{
    public interface IUserLogic : ILogic<User>
    {
        User Authenticate(string username, string password);   
    }
}