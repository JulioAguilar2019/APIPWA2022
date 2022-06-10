using Apitest.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apitest.Services.Contracts
{
    public interface IBriefCaseService
    {

        public Task<List<briefcase>> GetBriefcaseAsync();

        public Task<briefcase> GetbriefcaseByIdAsync(int id);

        public Task<briefcase> CreatebriefcaseAsync(briefcase brief);

        public Task<briefcase> UpdateAsync(briefcase brief);

        public Task DestroyAsync(int id);
      
    }
}
