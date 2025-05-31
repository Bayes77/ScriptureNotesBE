using  ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Data
{
    public class GroupMemberData
    {
        public static List<GroupMember> GroupMembers = new()

        {
            new() {Id = 10, GroupId = 11, UserId = 1111, Uid = "one", CreatedAt = DateTime.UtcNow, Joined_At = DateTime.UtcNow},
            new() {Id = 20, GroupId = 12, UserId = 2222, Uid = "two", CreatedAt = DateTime.UtcNow, Joined_At = DateTime.UtcNow},
            new() {Id = 30, GroupId = 13, UserId = 1111, Uid = "two", CreatedAt = DateTime.UtcNow, Joined_At = DateTime.UtcNow},
            new() {Id = 40, GroupId = 14, UserId = 2222, Uid = "one", CreatedAt = DateTime.UtcNow, Joined_At = DateTime.UtcNow},

        };
    }
}
