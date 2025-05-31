namespace ScriptureNotesBE.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string? Uid { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<NoteTag>? NoteTag { get; set; }


    }
}
