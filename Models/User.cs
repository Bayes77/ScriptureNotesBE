namespace ScriptureNotesBE.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Uid { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<GroupMember>? GroupMembers { get; set; }
        public List<Note>? Notes { get; set; }
        public List<NoteTag>? NoteTags { get; set; }



    }
}
