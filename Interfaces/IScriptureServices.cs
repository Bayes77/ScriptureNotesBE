using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Interfaces
{
    public interface IScriptureServices
    {
        Task<List<Scripture>> GetScriptureById(int id);
        Task<List<Scripture>> GetScriptures();
      
       
        Task<Scripture> AddScripture(Scripture scripture);
        Task<Scripture> UpdateScripture(int id, Scripture scripture);
        Task<Scripture> DeleteScripture(int id);
    }
}
