using ScriptureNotesBE.Interfaces;
using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Services
{
    public class GroupMemberServices : IGroupMemberServices
    {
        private readonly IGroupMemberRepository _groupMemberRepository;
        public GroupMemberServices(IGroupMemberRepository groupMemberRepository)
        {
            _groupMemberRepository = groupMemberRepository;
        }
        public async Task<List<GroupMember>> GetGroupMemberById(int id)
        {
            return await _groupMemberRepository.GetGroupMemberById(id);
        }
        public async Task<List<GroupMember>> GetGroupMembers()
        {
            return await _groupMemberRepository.GetGroupMembers();
        }
        
     
        public async Task<GroupMember> AddGroupMember(GroupMember groupMember)
        {
            return await _groupMemberRepository.AddGroupMember(groupMember);
        }
        public async Task<GroupMember> UpdateGroupMember(int id, GroupMember groupMember)
        {
            return await _groupMemberRepository.UpdateGroupMember(id, groupMember);
        }
        public async Task<GroupMember> DeleteGroupMember(int id)
        {
            return await _groupMemberRepository.DeleteGroupMember(id);
        }
    }
}
