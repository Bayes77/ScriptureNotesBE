using Microsoft.EntityFrameworkCore;
using ScriptureNotesBE.Data;
using ScriptureNotesBE.Models;
using ScriptureNotesBE.Interfaces;
using System.Linq;


namespace ScriptureNotesBE.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly ScriptureNoteBEDbContext _context;
        public TagRepository(ScriptureNoteBEDbContext context)
        {
            _context = context;
        }
        public async Task<List<Tag>> GetTags()
        {
            return await _context.Tags.ToListAsync();
        }
        public async Task<Tag> GetTagById(int id)
        {
            return await _context.Tags.FindAsync(id);
        }
        public async Task<Tag> AddTag(Tag tag)
        {
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();
            return tag;
        }
        public async Task<Tag> UpdateTag(int id, Tag tag)
        {
            var existingTag = await _context.Tags.FindAsync(id);
            if (existingTag == null)
            {
                return null;
            }
            existingTag.Name = tag.Name;
            existingTag.CreatedAt = tag.CreatedAt;
            await _context.SaveChangesAsync();
            return existingTag;
        }
        public async Task<Tag> DeleteTag(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag == null) throw new Exception("Tag not found");
            {
                return null;
            }
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        Task<List<Tag>> ITagRepository.GetTagById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Tag>> GetTagsByUserId(string Uid)
        {
            return await _context.Tags.Where(t => t.Uid == Uid).ToListAsync();
        }
    }
}
