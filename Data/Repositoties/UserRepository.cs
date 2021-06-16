using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositoties
{
    public class UserRepository : IUserRepository
    {
        TestDbContext db;
        public UserRepository(TestDbContext context)
        {
            db = context;
        }

        public async Task AddAsync(User entity)
        {
            await db.Users.AddAsync(entity);
        }

        public void Delete(User entity)
        {
            db.Users.Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            User user = await this.GetByIdAsync(id);
            if (user != null)
                db.Users.Remove(user);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await db.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetByUsernameAndPasswordAsync(string username, string password)
        {
            return await db.Users.Include(u => u.Profile).FirstOrDefaultAsync(u => u.Profile.Username == username && 
                    u.Profile.Password == password);
        }

        public void Update(User entity)
        {
            db.Users.Update(entity);
        }
    }
}
