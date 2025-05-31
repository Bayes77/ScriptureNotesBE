using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Data
{
    public class NoteData
    {
        public static List<Note> Notes = new()
        {
            new() { Id = 111, UserId = 1111, Uid = "one", Title = "Note 1", Content = "This is the first note.", CreatedAt = DateTime.UtcNow },
            new() { Id = 222, UserId = 2222, Uid = "two", Title = "Note 2", Content = "This is the second note.", CreatedAt = DateTime.UtcNow },
            new() { Id = 333, UserId = 1111, Uid = "one", Title = "Note 3", Content = "This is the third note.", CreatedAt = DateTime.UtcNow },
        };
    }
}
