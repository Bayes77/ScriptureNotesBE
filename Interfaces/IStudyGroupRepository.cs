using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Interfaces
{
    public interface IStudyGroupRepository
    {
        Task<List<StudyGroup>> GetStudyGroupById(int id);
        Task<List<StudyGroup>> GetStudyGroups();
        
        
        Task<StudyGroup> AddStudyGroup(StudyGroup studyGroup);
        Task<StudyGroup> UpdateStudyGroup(int id, StudyGroup studyGroup);
        Task<StudyGroup> DeleteStudyGroup(int id);
    }
}
