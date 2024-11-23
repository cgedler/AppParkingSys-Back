using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParkingSys_Back.Infrastructure.Data.Repositories
{
    public class UserRepository : BaseRepository<Core.Entities.User>, Core.Interfaces.Repositories.IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {

        }
    }
}
