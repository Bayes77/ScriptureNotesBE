using Microsoft.EntityFrameworkCore;
using ScriptureNotesBE.Data;
using ScriptureNotesBE.Models;
using ScriptureNotesBE.Interfaces;
using System.Linq;

namespace ScriptureNotesBE.Repositories
{
    public class ScriptureRepository : IScriptureRepository
    {
        private readonly ScriptureNoteBEDbContext _context;
        public ScriptureRepository(ScriptureNoteBEDbContext context)
        {
            _context = context;
        }
        public async Task<List<Scripture>> GetScriptureById(int id)
        {
            return await _context.Scriptures
                .Where(s => s.Id == id)
                .ToListAsync();
        }
        public async Task<List<Scripture>> GetScriptures()
        {
            return await _context.Scriptures.ToListAsync();
        }
        
        public async Task<Scripture> AddScripture(Scripture scripture)
        {
             var result = await _context.Scriptures.AddAsync(scripture);
            await _context.SaveChangesAsync();
            return scripture;
        }
        public async Task<Scripture> UpdateScripture(int id, Scripture scripture)
        {
            var existingScripture = await _context.Scriptures.FindAsync(id);
            if (existingScripture != null)
            {
                existingScripture.Text = scripture.Text;
                existingScripture.Ref = scripture.Ref;
                await _context.SaveChangesAsync();
            }
            return existingScripture;
        }
        public async Task<Scripture> DeleteScripture(int id)
        {
            var scripture = await _context.Scriptures.FindAsync(id);
            if (scripture != null) 
            {
                _context.Scriptures.Remove(scripture);
                await _context.SaveChangesAsync();
            }
            return scripture;
        }
    }
}
