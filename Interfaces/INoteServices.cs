using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Interfaces
{
    public interface INoteServices
    {
        Task<List<Note>> GetNoteById(int id);
        Task<List<Note>> GetNotes();
        Task<List<Note>> GetNotesByUserId(string Uid);
        Task<List<Note>> GetNotesByGroupId(int groupId);
        Task<List<Note>> GetNotesByTagId(int tagId);
        Task<Note> AddNote(Note note);
        Task<Note> UpdateNote(int id, Note note);
        Task<Note> DeleteNote(int id);
    }
}
