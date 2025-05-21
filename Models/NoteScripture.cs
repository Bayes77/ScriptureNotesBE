namespace ScriptureNotesBE.Models
{
    public class NoteScripture
    {
        public int Id { get; set; }
        public string? Uid { get; set; }
        public int NoteId { get; set; }
        public int ScriptureId { get; set; }
        public DateTime CreatedAt { get; set; }

        public  Note? Note { get; set; }
        public  Scripture? Scripture { get; set; }
    }
}
