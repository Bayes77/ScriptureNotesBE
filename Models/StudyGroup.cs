namespace ScriptureNotesBE.Models
{
    public class StudyGroup
    {
        public int Id { get; set; }
        public string? Uid { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<GroupMember>? GroupMembers { get; set; }



    }
}
