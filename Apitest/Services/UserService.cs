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
    public class UserService : IUserService
    {

        private readonly UsersdbContext _context;

        public UserService(UsersdbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<users>> GetUsersAsync()
        {
            try
            {
                var users = await _context.users.ToListAsync();
                return users;

            }
            catch (System.Exception)
            {

                throw;
            }
        }


        public async Task<users> CreateUserAsync(users user)
        {
            try
            {
                await _context.users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public async Task<users> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _context.users.Where(u => u.user_id == id).FirstOrDefaultAsync();
                return user;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public  async Task<users> UpdateAsync(users user)
        {
            try
            {
                if (user.user_id > 0 )
                {
                    _context.Entry(user).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return user;
                }

                throw new Exception("El usuario no se encuentra");
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
                var user = await GetUserByIdAsync(id);
                if (user != null)
                {
                    _context.users.Remove(user);
                    await _context.SaveChangesAsync();
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public IEnumerable<users> getAll()
        {
            var users = (from us in _context.users.ToList()
                         join bc in _context.briefcase.ToList() on us.user_id equals bc.user_id
                         join cer in _context.certifications.ToList() on us.user_id equals cer.user_id
                         join skills in _context.skills.ToList() on us.user_id equals skills.user_id
                         join work in _context.work_experience.ToList() on us.user_id equals work.user_id
                         select new users()
                         {
                             certifications = us.certifications,
                             work_experience = us.work_experience,
                             skills = us.skills,
                             briefcase = us.briefcase,
                             
                         }).ToList();

            return users;
        }
       
    }
}
