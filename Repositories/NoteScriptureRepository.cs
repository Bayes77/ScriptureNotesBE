using Microsoft.EntityFrameworkCore;
using ScriptureNotesBE.Data;
using ScriptureNotesBE.Models;
using ScriptureNotesBE.Interfaces;
using System.Linq;

namespace ScriptureNotesBE.Repositories
{
    public class NoteScriptureRepository : INoteScriptureRepository
    {
        private readonly ScriptureNoteBEDbContext _context;
        public NoteScriptureRepository(ScriptureNoteBEDbContext context)
        {
            _context = context;
        }
        public async Task<List<NoteScripture>> GetNoteScripturesByNoteId(int noteId)
        {
            return await _context.NoteScriptures
                .Where(ns => ns.NoteId == noteId)
                .ToListAsync();
        }
        public async Task<List<NoteScripture>> GetNoteScripturesByUserId(string uid)
        {
            return await _context.NoteScriptures
                .Where(ns => ns.Uid == uid)
                .ToListAsync();
        }
        public async Task<NoteScripture> AddNoteScripture(NoteScripture noteScripture)
        {
            var result = await _context.NoteScriptures.AddAsync(noteScripture);
            await _context.SaveChangesAsync();
            return noteScripture;
        }
        public async Task<NoteScripture> UpdateNoteScripture(int id, NoteScripture noteScripture)
        {
            var existingNoteScripture = await _context.NoteScriptures.FindAsync(id);
            if (existingNoteScripture != null) throw new Exception("NoteScripture not found");
            {
                existingNoteScripture.Scripture = noteScripture.Scripture;
                existingNoteScripture.NoteId = noteScripture.NoteId;
                existingNoteScripture.Uid = noteScripture.Uid;
                await _context.SaveChangesAsync();
                return existingNoteScripture;
            }
            
        }
        public async Task<NoteScripture> DeleteNoteScripture(int id)
        {
            var noteScripture = await _context.NoteScriptures.FindAsync(id);
            if (noteScripture != null)
            {
                _context.NoteScriptures.Remove(noteScripture);
                await _context.SaveChangesAsync();
                return noteScripture;
            }
            return null;
        }

        public async Task<List<NoteScripture>> GetNoteScriptureById(int id)
        {
            return await _context.NoteScriptures
                 .Where(ns => ns.Id == id)
                 .ToListAsync();
        }

        public async Task<List<NoteScripture>> GetNoteScriptures()
        {
            return await _context.NoteScriptures.ToListAsync();
        }
    }
}
