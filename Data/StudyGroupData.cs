using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Data
{
    public class StudyGroupData
    {
        public static List<StudyGroup> StudyGroups = new()
        {
            new() { Id = 01, Name = "Group 1", Description = "This is group 1", CreatedAt = DateTime.UtcNow },
            new() { Id = 02, Name = "Group 2", Description = "This is group 2", CreatedAt = DateTime.UtcNow },
            new() { Id = 03, Name = "Group 3", Description = "This is group 3", CreatedAt = DateTime.UtcNow },
            new() { Id = 04, Name = "Group 4", Description = "This is group 4", CreatedAt = DateTime.UtcNow },
            new() { Id = 05, Name = "Group 5", Description = "This is group 5", CreatedAt = DateTime.UtcNow },

        };
    }
}
