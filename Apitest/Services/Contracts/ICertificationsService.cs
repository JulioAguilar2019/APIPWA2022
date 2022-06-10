using Apitest.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apitest.Services.Contracts
{
    public interface ICertificationsService
    {
        public Task<List<certifications>> GetCertificationsAsync();

        public Task<certifications> GetCertificationsByIdAsync(int id);

        public Task<certifications> CreateCertificationsAsync(certifications cert);

        public Task<certifications> UpdateAsync(certifications cert);

        public Task DestroyAsync(int id);
    }
}
