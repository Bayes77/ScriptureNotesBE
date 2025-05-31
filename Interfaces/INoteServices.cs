using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Interfaces
{
    public interface INoteServices
    {
        Task<List<Note>> GetNoteById(int id);
        Task<List<Note>> GetNotes();
        
        Task<Note> AddNote(Note note);
        Task<Note> UpdateNote(int id, Note note);
        Task<Note> DeleteNote(int id);
    }
}
