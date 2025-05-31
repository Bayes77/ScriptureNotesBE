using ScriptureNotesBE.Interfaces;
using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Services
{
    public class NoteServices : INoteServices
    {
        private readonly INoteRepository _noteRepository;
        public NoteServices(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }
        public async Task<List<Note>> GetNotes()
        {
            return await _noteRepository.GetNotes();
        }
        public async Task<List<Note>> GetNoteById(int id)
        {
            return await _noteRepository.GetNoteById(id);
        }
        public async Task<Note> AddNote(Note note)
        {
            return await _noteRepository.AddNote(note);
        }
        public async Task<Note> UpdateNote(int id, Note note)
        {
            return await _noteRepository.UpdateNote(id, note);
        }
        public async Task<Note> DeleteNote(int id)
        {
            return await _noteRepository.DeleteNote(id);
        }
    }
}
