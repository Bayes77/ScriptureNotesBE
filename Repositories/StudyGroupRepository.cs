using Microsoft.EntityFrameworkCore;
using ScriptureNotesBE.Data;
using ScriptureNotesBE.Models;
using ScriptureNotesBE.Interfaces;
using System.Linq;


namespace ScriptureNotesBE.Repositories
{
    public class StudyGroupRepository : IStudyGroupRepository
    {
        private readonly ScriptureNoteBEDbContext _context;
        public StudyGroupRepository(ScriptureNoteBEDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudyGroup>> GetStudyGroups()
        {
            return await _context.StudyGroups.ToListAsync();
        }

        public async Task<List<StudyGroup>> GetStudyGroupById(int id)
        {
            return await _context.StudyGroups.Where(sg => sg.Id == id).ToListAsync();
        }

        public async Task<StudyGroup> AddStudyGroup(StudyGroup studyGroup)
        {
            _context.StudyGroups.Add(studyGroup);
            await _context.SaveChangesAsync();
            return studyGroup;
        }

        public async Task<StudyGroup> UpdateStudyGroup(int id, StudyGroup studyGroup)
        {
            var existingStudyGroup = await _context.StudyGroups.FindAsync(id);
            if (existingStudyGroup == null)
            {
                return null;
            }
            existingStudyGroup.Name = studyGroup.Name;
            existingStudyGroup.Description = studyGroup.Description;
            existingStudyGroup.CreatedAt = studyGroup.CreatedAt;
            await _context.SaveChangesAsync();
            return existingStudyGroup;
        }

        public async Task<StudyGroup> DeleteStudyGroup(int id)
        {
            var studyGroup = await _context.StudyGroups.FindAsync(id);
            if (studyGroup == null) 
            {
                return null;
            }
            _context.StudyGroups.Remove(studyGroup);
            await _context.SaveChangesAsync();
            return studyGroup;
        }

       

        public async Task<List<StudyGroup>> GetStudyGroupsByName(string name)
        {
            return await _context.StudyGroups
                .Where(sg => sg.Name.Contains(name))
                .ToListAsync();
        }

        
    }
}
