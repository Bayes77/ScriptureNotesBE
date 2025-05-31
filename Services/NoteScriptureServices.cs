using ScriptureNotesBE.Interfaces;
using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Services
{
    public class NoteScriptureServices : INoteScriptureServices
    {
        private readonly INoteScriptureRepository _noteScriptureRepository;
        public NoteScriptureServices(INoteScriptureRepository noteScriptureRepository)
        {
            _noteScriptureRepository = noteScriptureRepository;
        }
       
      
        public async Task<NoteScripture> AddNoteScripture(NoteScripture noteTag)
        {
            return await _noteScriptureRepository.AddNoteScripture(noteTag);
        }
        public async Task<NoteScripture> UpdateNoteScripture(int id, NoteScripture noteTag)
        {
            return await _noteScriptureRepository.UpdateNoteScripture(id, noteTag);
        }
        public async Task<NoteScripture> DeleteNoteScripture(int id)
        {
            return await _noteScriptureRepository.DeleteNoteScripture(id);
        }

        public async Task<List<NoteScripture>> GetNoteScriptureById(int id)
        {
            return await _noteScriptureRepository.GetNoteScriptureById(id);
        }

        public async Task<List<NoteScripture>> GetNoteScriptures()
        {
            return await _noteScriptureRepository.GetNoteScriptures();
        }
    }
}
