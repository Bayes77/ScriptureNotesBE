using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Interfaces
{
    public interface IGroupMemberRepository
    {
        Task<List<GroupMember>> GetGroupMemberById(int id);
        Task<List<GroupMember>> GetGroupMembers();
       
        Task<GroupMember> AddGroupMember(GroupMember groupMember);
        Task<GroupMember> UpdateGroupMember(int id,GroupMember groupMember);
        Task<GroupMember> DeleteGroupMember(int id);
    }
}
