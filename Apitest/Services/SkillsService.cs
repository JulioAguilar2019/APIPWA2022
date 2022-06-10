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
    public class SkillsService : ISkillsService
    {
        private readonly UsersdbContext _context;
        public SkillsService(UsersdbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<List<skills>> GetSkillsAsync()
        {
            try
            {
                var skillss = await _context.skills.ToListAsync();
                return skillss;

            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public async Task<skills> CreateSkillsAsync(skills Skills)
        {
            try
            {
                await _context.skills.AddAsync(Skills);
                await _context.SaveChangesAsync();
                return Skills;
            }
            catch (System.Exception)
            {

                throw;
            }
        }


        public async Task<skills> GetSkillsByIdAsync(int id)
        {
            try
            {
                var skills = await _context.skills.Where(u => u.skill_id == id).FirstOrDefaultAsync();
                return skills;
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
                var skills = await GetSkillsByIdAsync(id);
                if (skills != null)
                {
                    _context.skills.Remove(skills);
                    await _context.SaveChangesAsync();
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

    

        public async Task<skills> UpdateAsync(skills Skills)
        {
            try
            {
                if (Skills.skill_id > 0)
                {
                    _context.Entry(Skills).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Skills;
                }

                throw new Exception("Las habilidades no se encuentra");
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
