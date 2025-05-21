using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Data
{
    public class NoteScriptureData
    {
        public static List<NoteScripture> NoteScriptures = new()
        {
            new() { Id = 1, NoteId = 111, ScriptureId = 1 },
            new() { Id = 2, NoteId = 222, ScriptureId = 2 },
            new() { Id = 3, NoteId = 333, ScriptureId = 3 },
        };
    }
}
