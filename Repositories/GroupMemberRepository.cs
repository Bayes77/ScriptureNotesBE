using Microsoft.EntityFrameworkCore;
using ScriptureNotesBE.Data;
using ScriptureNotesBE.Models;
using ScriptureNotesBE.Interfaces;
using System.Linq;



namespace ScriptureNotesBE.Repositories
{
    public class GroupMemberRepository : IGroupMemberRepository
    {
        private readonly ScriptureNoteBEDbContext _context;
        public GroupMemberRepository(ScriptureNoteBEDbContext context)
        {
            _context = context;
        }
        public async Task<List<GroupMember>> GetGroupMemberById(int id)
        {
            return await _context.GroupMembers.Where(g => g.Id == id).ToListAsync();
        }
        public async Task<List<GroupMember>> GetGroupMembers()
        {
            return await _context.GroupMembers.ToListAsync();
        }
        public async Task<List<GroupMember>> GetGroupMembersByUserId(string Uid)
        {
            return await _context.GroupMembers.Where(g => g.Uid == Uid).ToListAsync();
        }
        public async Task<List<GroupMember>> GetGroupMembersByGroupId(int groupId)
        {
            return await _context.GroupMembers.Where(g => g.GroupId == groupId).ToListAsync();
        }
        public async Task<GroupMember> AddGroupMember(GroupMember groupMember)
        {
            var result = await _context.GroupMembers.AddAsync(groupMember);
            await _context.SaveChangesAsync();
            return groupMember;
        }
        public async Task<GroupMember> UpdateGroupMember(int id,GroupMember groupMember)
        {
            var existingGroupMember = await _context.GroupMembers.FindAsync(id);
            if (existingGroupMember == null)
            {
                return null;
            }
            existingGroupMember.GroupId = groupMember.GroupId;
            existingGroupMember.Uid = groupMember.Uid;
            existingGroupMember.CreatedAt = groupMember.CreatedAt;
            existingGroupMember.Joined_At = groupMember.Joined_At;
            await _context.SaveChangesAsync();
            return groupMember;
        }
        public async Task<GroupMember> DeleteGroupMember(int id)
        {
            var gmToDelete = await _context.GroupMembers.FindAsync(id);
            if (gmToDelete != null) throw new Exception("GroupMember not found");
            {
                _context.GroupMembers.Remove(gmToDelete);
                await _context.SaveChangesAsync();
                return gmToDelete;
            }
        
        }
    }
}
