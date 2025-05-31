using ScriptureNotesBE.Interfaces;
using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<User>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }
        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }
        public async Task<User> AddUser(User user)
        {
            return await _userRepository.AddUser(user);
        }
        public async Task<User> UpdateUser(string uid, User user)
        {
            return await _userRepository.UpdateUser(uid, user);
        }
        public async Task<User> DeleteUser(int id)
        {
            return await _userRepository.DeleteUser(id);
        }

        public Task<List<User>> GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
