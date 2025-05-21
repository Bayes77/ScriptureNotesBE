using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Data
{
    public class TagData
    {
        public static List<Tag> Tags = new()
        {
            new() { Id = 100, Name = "Faith", CreatedAt = DateTime.UtcNow },
            new() { Id = 200, Name = "Doctrine", CreatedAt = DateTime.UtcNow },
            new() { Id = 300, Name = "Love", CreatedAt = DateTime.UtcNow },
            new() { Id = 400, Name = "Repentence", CreatedAt = DateTime.UtcNow },
            new() { Id = 500, Name = "Peace", CreatedAt = DateTime.UtcNow },
        };
    }
}
