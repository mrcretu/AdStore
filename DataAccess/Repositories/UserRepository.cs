using DataAccess.Abstractions;
using Entities.Entities;

namespace DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        protected UserRepository(ApplicationContext context) : base(context)
        {
        }
    }
}