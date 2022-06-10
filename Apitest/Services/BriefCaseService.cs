using Apitest.Models;
using Apitest.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using Apitest.dbContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace Apitest.Services
{
    public class BriefCaseService : IBriefCaseService
    {

        private readonly UsersdbContext _context;

        public BriefCaseService(UsersdbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<briefcase>> GetBriefcaseAsync()
        {
            try
            {
                var briefcases = await _context.briefcase.ToListAsync();
                return briefcases;

            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public async Task<briefcase> CreatebriefcaseAsync(briefcase brief)
        {
            try
            {
                await _context.briefcase.AddAsync(brief);
                await _context.SaveChangesAsync();
                return brief;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<briefcase> GetbriefcaseByIdAsync(int id)
        {
            try
            {
                var briefcase = await _context.briefcase.Where(u => u.bc_id == id).FirstOrDefaultAsync();
                return briefcase;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task DestroyAsync(int id)
        {
            try
            {
                var briefcase = await GetbriefcaseByIdAsync(id);
                if (briefcase != null)
                {
                    _context.briefcase.Remove(briefcase);
                    await _context.SaveChangesAsync();
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

     

       

        public async Task<briefcase> UpdateAsync(briefcase brief)
        {
            try
            {
                if (brief.bc_id > 0)
                {
                    _context.Entry(brief).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return brief;
                }

                throw new Exception("El portafolio no se encuentra");
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
