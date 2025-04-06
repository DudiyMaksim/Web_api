using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_api.DAL.Entities;

namespace Web_api.DAL.Repositories.Account
{
    public class AccountRepository : GenericRepository<ProductEntity, string>, IAccountRepository
    {
        public AccountRepository(AppDbContext context)
            : base(context) { }
    }
}
