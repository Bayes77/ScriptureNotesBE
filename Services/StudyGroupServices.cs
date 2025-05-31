using ScriptureNotesBE.Interfaces;
using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Services
{
    public class StudyGroupServices : IStudyGroupServices
    {
        private readonly IStudyGroupRepository _studyGroupRepository;
        public StudyGroupServices(IStudyGroupRepository studyGroupRepository)
        {
            _studyGroupRepository = studyGroupRepository;
        }
        public async Task<List<StudyGroup>> GetStudyGroups()
        {
            return await _studyGroupRepository.GetStudyGroups();
        }
        
        public async Task<StudyGroup> AddStudyGroup(StudyGroup studyGroup)
        {
            return await _studyGroupRepository.AddStudyGroup(studyGroup);
        }
        public async Task<StudyGroup> UpdateStudyGroup(int id, StudyGroup studyGroup)
        {
            return await _studyGroupRepository.UpdateStudyGroup(id, studyGroup);
        }
        public async Task<StudyGroup> DeleteStudyGroup(int id)
        {
            return await _studyGroupRepository.DeleteStudyGroup(id);
        }

        public async Task<List<StudyGroup>> GetStudyGroupById(int id)
        {
            return await _studyGroupRepository.GetStudyGroupById(id);
        }

        
    }
}
