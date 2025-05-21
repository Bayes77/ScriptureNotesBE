using  ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Data
{
    public class GroupMemberData
    {
        public static List<GroupMember> GroupMembers = new()

        {
            new() {Id = 10, GroupId = 01, Uid = "one", CreatedAt = DateTime.UtcNow, Joined_At = DateTime.Now},
            new() {Id = 20, GroupId = 01, Uid = "two", CreatedAt = DateTime.UtcNow, Joined_At = DateTime.Now},
            new() {Id = 30, GroupId = 02, Uid = "two", CreatedAt = DateTime.UtcNow, Joined_At = DateTime.Now},
            new() {Id = 40, GroupId = 02, Uid = "one", CreatedAt = DateTime.UtcNow, Joined_At = DateTime.Now},

        };
    }
}
