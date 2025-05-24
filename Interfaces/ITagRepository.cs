using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Interfaces
{
    public interface ITagRepository
    {
        Task<List<Tag>> GetTagById(int id);
        Task<List<Tag>> GetTags();
        Task<List<Tag>> GetTagsByUserId(string Uid);
        
        Task<Tag> AddTag(Tag tag);
        Task<Tag> UpdateTag(int id, Tag tag);
        Task<Tag> DeleteTag(int id);
    }
}
