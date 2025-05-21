namespace ScriptureNotesBE.Models
{
    public class Scripture
    {
        public int Id { get; set; } 
        public string? Ref { get; set; }
        public string? Text { get; set; }
        public List<NoteScripture>? NoteScriptures { get; set; }

    }
}
