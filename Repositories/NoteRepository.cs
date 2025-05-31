using Microsoft.EntityFrameworkCore;
using ScriptureNotesBE.Data;
using ScriptureNotesBE.Models;
using ScriptureNotesBE.Interfaces;
using System.Linq;


namespace ScriptureNotesBE.Repositories 
{
    public class NoteRepository : INoteRepository
    {
        private readonly ScriptureNoteBEDbContext _context;
        public NoteRepository(ScriptureNoteBEDbContext context)
        {
            _context = context;
        }
        public async Task<List<Note>> GetNoteById(int id)
        {
            return await _context.Notes.Where(n => n.Id == id).ToListAsync();
        }
        public async Task<List<Note>> GetNotes()
        {
            return await _context.Notes.ToListAsync();
        }
        public async Task<List<Note>> GetNotesByUserId(string Uid)
        {
            return await _context.Notes.Where(n => n.Uid == Uid).ToListAsync();
        }
        public async Task<Note> AddNote(Note note)
        {
            var result = await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();
            return note;
        }
        public async Task<Note> UpdateNote(int id,Note note)
        {
            var existingNote = await _context.Notes.FindAsync(id);
            if (existingNote == null)
            {
                return null;
            }existingNote.Title = note.Title;
            existingNote.Content = note.Content;
            existingNote.CreatedAt = note.CreatedAt;
            existingNote.Uid = note.Uid;
            await _context.SaveChangesAsync();
            return note;
        }
        public async Task<Note> DeleteNote(int id)
        {
            var nToDelete = await _context.Notes.FindAsync(id);
            if (nToDelete != null)
            {
                _context.Notes.Remove(nToDelete);
                await _context.SaveChangesAsync();
                return nToDelete;
            }
            return null; 
        }

       
    }
}
