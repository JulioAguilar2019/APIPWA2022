using Apitest.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Apitest.Services.Contracts
{
    public interface ISkillsService
    {

        public Task<List<skills>> GetSkillsAsync();

        public Task<skills> GetSkillsByIdAsync(int id);

        public Task<skills> CreateSkillsAsync(skills Skills);

        public Task<skills> UpdateAsync(skills Skills);

        public Task DestroyAsync(int id);

    }
}
