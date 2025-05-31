using ScriptureNotesBE.Interfaces;
using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Services
{
    public class ScriptureServices : IScriptureServices
    {
        private readonly IScriptureRepository _scriptureRepository;
        public ScriptureServices(IScriptureRepository scriptureRepository)
        {
            _scriptureRepository = scriptureRepository;
        }
        public async Task<List<Scripture>> GetScriptureById(int id)
        {
            return await _scriptureRepository.GetScriptureById(id);
        }
        public async Task<List<Scripture>> GetScriptures()
        {
            return await _scriptureRepository.GetScriptures();
        }
        public async Task<Scripture> AddScripture(Scripture scripture)
        {
            return await _scriptureRepository.AddScripture(scripture);
        }
        public async Task<Scripture> UpdateScripture(int id, Scripture scripture)
        {
            return await _scriptureRepository.UpdateScripture(id, scripture);
        }
        public async Task<Scripture> DeleteScripture(int id)
        {
            return await _scriptureRepository.DeleteScripture(id);
        }
    }
}
