using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Interfaces
{
    public interface INoteScriptureRepository
    {
        Task<List<NoteScripture>> GetNoteScriptureById(int id);
        Task<List<NoteScripture>> GetNoteScriptures();
       
        Task<NoteScripture> AddNoteScripture(NoteScripture noteScripture);
        Task<NoteScripture> UpdateNoteScripture(int id,NoteScripture noteScripture);
        Task<NoteScripture> DeleteNoteScripture(int id);
    }
}
