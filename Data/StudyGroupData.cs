using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Data
{
    public class StudyGroupData
    {
        public static List<StudyGroup> StudyGroups = new()
        {
            new() { Id = 11, Name = "Group 1", Description = "This is group 1", CreatedAt = DateTime.UtcNow },
            new() { Id = 12, Name = "Group 2", Description = "This is group 2", CreatedAt = DateTime.UtcNow },
            new() { Id = 13, Name = "Group 3", Description = "This is group 3", CreatedAt = DateTime.UtcNow },
            new() { Id = 14, Name = "Group 4", Description = "This is group 4", CreatedAt = DateTime.UtcNow },
            new() { Id = 15, Name = "Group 5", Description = "This is group 5", CreatedAt = DateTime.UtcNow },

        };
    }
}
