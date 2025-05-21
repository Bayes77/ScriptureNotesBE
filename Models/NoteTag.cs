namespace ScriptureNotesBE.Models
{
    public class NoteTag
    {
        public int Id { get; set; }
        public string? Uid { get; set; }
        public int NoteId { get; set; }
        public int TagId { get; set; }
       
        public virtual Note? Note { get; set; }
        public virtual Tag? Tag { get; set; }
    }
}
