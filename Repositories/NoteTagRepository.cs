using Microsoft.EntityFrameworkCore;
using ScriptureNotesBE.Data;
using ScriptureNotesBE.Models;
using ScriptureNotesBE.Interfaces;
using System.Linq;

namespace ScriptureNotesBE.Repositories
{
    public class NoteTagRepository : INoteTagRepository
    {
        private readonly ScriptureNoteBEDbContext _context;
        public NoteTagRepository(ScriptureNoteBEDbContext context)
        {
            _context = context;
        }
        public async Task<List<NoteTag>> GetNoteTagById(int id)
        {
            return await _context.NoteTags
                .Where(nt => nt.Id == id)
                .ToListAsync();
        }
        public async Task<List<NoteTag>> GetNoteTags()
        {
            return await _context.NoteTags.ToListAsync();
        }
        public async Task<List<NoteTag>> GetNoteTagsByNoteId(int noteId)
        {
            return await _context.NoteTags
                .Where(nt => nt.NoteId == noteId)
                .ToListAsync();
        }
        public async Task<List<NoteTag>> GetNoteTagsByUserId(string Uid)
        {
            return await _context.NoteTags
                .Where(nt => nt.Uid == Uid)
                .ToListAsync();
        }
        public async Task<NoteTag> AddNoteTag(NoteTag noteTag)
        {
            var result = await _context.NoteTags.AddAsync(noteTag);
            await _context.SaveChangesAsync();
            return noteTag;
        }
        public async Task<NoteTag> UpdateNoteTag(int id, NoteTag noteTag)
        {
            var existingNoteTag = await _context.NoteTags.FindAsync(id);
            if (existingNoteTag != null)
            {
                existingNoteTag.Tag = noteTag.Tag;
                existingNoteTag.NoteId = noteTag.NoteId;
                existingNoteTag.Uid = noteTag.Uid;
                await _context.SaveChangesAsync();
            }
            return existingNoteTag;
        }
        public async Task<NoteTag> DeleteNoteTag(int id)
        {
            var noteTag = await _context.NoteTags.FindAsync(id);
            if (noteTag != null) throw new Exception("NoteTag not found");
            {
                _context.NoteTags.Remove(noteTag);
                await _context.SaveChangesAsync();
            }
            return noteTag;
        }
    }
}
