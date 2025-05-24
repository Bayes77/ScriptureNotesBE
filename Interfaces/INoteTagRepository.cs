using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Interfaces
{
    public interface INoteTagRepository
    {
        Task<List<NoteTag>> GetNoteTagById(int id);
        Task<List<NoteTag>> GetNoteTags();
        Task<List<NoteTag>> GetNoteTagsByNoteId(int noteId);
        Task<List<NoteTag>> GetNoteTagsByUserId(string Uid);
        Task<NoteTag> AddNoteTag(NoteTag noteTag);
        Task<NoteTag> UpdateNoteTag(int id, NoteTag noteTag);
        Task<NoteTag> DeleteNoteTag(int id);
    }
}
