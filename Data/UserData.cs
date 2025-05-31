using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Data
{
    public class UserData
    {
        public static List<User> Users = new()
        {
            new() { Id = 1111, Uid = "one", UserName = "user1", Email = "user1@gmail.com", CreatedAt = DateTime.UtcNow },
            new() { Id = 2222, Uid = "two", UserName = "user2", Email = "user2@gmail.com", CreatedAt = DateTime.UtcNow },
        };
    }
}
