using Apitest.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Apitest.dbContexts;

namespace Apitest.Services.Contracts
{
    public interface IUserService
    {
        public Task<List<users>> GetUsersAsync();

        public Task<users> GetUserByIdAsync(int id);

        public Task<users> CreateUserAsync(users user);

        public Task<users> UpdateAsync(users user);

        public Task DestroyAsync(int id);

    }
}
