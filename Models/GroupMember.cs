namespace ScriptureNotesBE.Models
{
    public class GroupMember
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public string? Uid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Joined_At { get; set; }
        public StudyGroup? StudyGroup { get; set; }
        public User? User { get; set; }


    }
}
