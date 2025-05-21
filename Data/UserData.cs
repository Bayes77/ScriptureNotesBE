using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Data
{
    public class UserData
    {
        public static List<User> Users = new()
        {
            new() { Id = 001, Uid = "one", UserName = "user1", Email = "user1@gmail.com", CreatedAt = DateTime.UtcNow },
            new() { Id = 002, Uid = "two", UserName = "user2", Email = "user2@gmail.com", CreatedAt = DateTime.UtcNow },
        };
    }
}
