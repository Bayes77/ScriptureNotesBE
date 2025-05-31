using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Data
{
    public class NoteTagData
    {
        public static List<NoteTag> NoteTags = new()
        {
            new() { Id = 101, NoteId = 111, TagId = 100},
            new() { Id = 202, NoteId = 111, TagId = 200},
            new() { Id = 303, NoteId = 222, TagId = 300, },
            new() { Id = 404, NoteId = 222, TagId = 400},
            new() { Id = 505, NoteId = 333, TagId = 500, },
        };
    }
}
