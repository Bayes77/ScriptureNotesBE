using ScriptureNotesBE.Interfaces;
using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Services
{
    public class NoteTagServices : INoteTagServices
    {
        private readonly INoteTagRepository _noteTagRepository;
        public NoteTagServices(INoteTagRepository noteTagRepository)
        {
            _noteTagRepository = noteTagRepository;
        }
        public async Task<List<NoteTag>> GetNoteTagById(int id)
        {
            return await _noteTagRepository.GetNoteTagById(id);
        }
        public async Task<List<NoteTag>> GetNoteTags()
        {
            return await _noteTagRepository.GetNoteTags();
        }
        
        public async Task<NoteTag> AddNoteTag(NoteTag noteTag)
        {
            return await _noteTagRepository.AddNoteTag(noteTag);
        }
        public async Task<NoteTag> UpdateNoteTag(int id, NoteTag noteTag)
        {
            return await _noteTagRepository.UpdateNoteTag(id, noteTag);
        }
        public async Task<NoteTag> DeleteNoteTag(int id)
        {
            return await _noteTagRepository.DeleteNoteTag(id);
        }
    }
}
