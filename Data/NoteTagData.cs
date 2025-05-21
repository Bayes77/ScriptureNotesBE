using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Data
{
    public class NoteTagData
    {
        public static List<NoteTag> NoteTags = new()
        {
            new() { Id = 101, NoteId = 1, TagId = 100},
            new() { Id = 202, NoteId = 1, TagId = 200},
            new() { Id = 303, NoteId = 2, TagId = 300, },
            new() { Id = 404, NoteId = 2, TagId = 400},
            new() { Id = 505, NoteId = 3, TagId = 500, },
        };
    }
}
