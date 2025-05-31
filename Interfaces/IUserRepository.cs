using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUserById(string id);
        Task<List<User>> GetUsers();
        Task<User> AddUser(User user);
        Task<User> UpdateUser(int id, User user);
        Task<User> DeleteUser(int id);
        Task<User> GetUserById(int id);
        Task<User> UpdateUser(string uid, User user);
    }
}
