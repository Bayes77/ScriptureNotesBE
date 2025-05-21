namespace ScriptureNotesBE.Models
{
    public class Note
    {
        int Id { get; set; }
        string? Uid { get; set; }
        string? Title { get; set; }

        string? Content { get; set; }
        DateTime CreatedAt { get; set; }
        public NoteScripture? NoteScripture { get; set; }
        public List<Tag>? Tags { get; set; }
        public List<NoteTag>? NoteTags { get; set; }

    }
}
