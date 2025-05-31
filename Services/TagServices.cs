using ScriptureNotesBE.Interfaces;
using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Services
{
    public class TagServices : ITagServices
    {
        private readonly ITagRepository _tagRepository;
        public TagServices(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public async Task<List<Tag>> GetTagById(int id)
        {
            return await _tagRepository.GetTagById(id);
        }
        public async Task<List<Tag>> GetTags()
        {
            return await _tagRepository.GetTags();
        }
        public async Task<Tag> AddTag(Tag tag)
        {
            return await _tagRepository.AddTag(tag);
        }
        public async Task<Tag> UpdateTag(int id, Tag tag)
        {
            return await _tagRepository.UpdateTag(id, tag);
        }
        public async Task<Tag> DeleteTag(int id)
        {
            return await _tagRepository.DeleteTag(id);
        }

    }
}
