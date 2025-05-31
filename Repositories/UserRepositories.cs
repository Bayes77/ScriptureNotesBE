using Microsoft.EntityFrameworkCore;
using ScriptureNotesBE.Data;
using ScriptureNotesBE.Models;
using ScriptureNotesBE.Interfaces;
using System.Linq;
using Microsoft.AspNetCore.Razor.TagHelpers;


namespace ScriptureNotesBE.Repositories
{
    public class UserRepositories : IUserRepository
    {
        public readonly ScriptureNoteBEDbContext _context;
        public UserRepositories(ScriptureNoteBEDbContext context)
        {
            _context = context;
        }
        public async Task<User> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) 
            {
                return null;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetUserById(int id)
        {
            var user = await _context.Users.Where(x => x.Id == id).ToListAsync();
            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User> UpdateUser(int id, User user)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
            {
                return null;
            }
            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;
            existingUser.CreatedAt = user.CreatedAt;
            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task<User> GetUserByUid(string uid)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Uid == uid);
            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }


        //public async Task<User> DeleteUser(int id)
        //{
        //    var uToDelete = await _context.Users.FindAsync(id);
        //    if (uToDelete == null) throw new Exception("User not found");
        //    _context.Users.Remove(uToDelete);
        //    await _context.SaveChangesAsync();
        //    return uToDelete; 
        //}

        public Task<List<User>> GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        Task<User> IUserRepository.GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(string uid, User user)
        {
            throw new NotImplementedException();
        }
    }
}
