using Moq;
using ScriptureNotesBE.Models;
using Xunit;
using ScriptureNotesBE.Interfaces;
using ScriptureNotesBE.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ScriptureNoteBETest
{
    public class NoteTest
    {

        private readonly Mock<INoteRepository> _noteRepositoryMock;
        private readonly INoteServices _NoteService;

        public NoteTest()
        {
            _noteRepositoryMock = new Mock<INoteRepository>();
            _NoteService = new NoteServices(_noteRepositoryMock.Object);
        }

        [Fact]
        public async Task GetNotesAsync_WhenCalled_ReturnsNotesAsync()
        {
            var note = new List<Note>
            {
                new Note { Id = 111, UserId = 1111, Uid = "one", Content = "This is the first note", CreatedAt = DateTime.Now },
                 new Note { Id = 222, UserId = 2222, Uid = "two", Content = "This is the second note", CreatedAt = DateTime.Now }
            };

            _noteRepositoryMock.Setup(repo => repo.GetNotes()).ReturnsAsync(note);
            var result = await _NoteService.GetNotes();
            Assert.IsNotNull(result);
            Assert.Equals(2, result.Count);
        }

        [Fact]
        public async Task GetNoteByIdAsync_WhenCalled_ReturnsNoteAsync()
        {
            var note = new Note { Id = 111, UserId = 1111, Uid = "one", Content = "This is the first note", CreatedAt = DateTime.Now };
            _noteRepositoryMock.Setup(repo => repo.GetNoteById(111)).ReturnsAsync(new List<Note> { note });
            var result = await _NoteService.GetNoteById(111);
            Assert.IsNotNull(result);
            Assert.ContainsSingle(result);
            Assert.Equals("This is the first note", result[0].Content);

        }

        [Fact]
        public async Task AddNoteAsync_WhenCalled_ReturnsAddedNoteAsync()
        {
            var note = new Note { Id = 111, UserId = 1111, Uid = "one", Content = "This is the first note", CreatedAt = DateTime.Now };
            _noteRepositoryMock.Setup(repo => repo.AddNote(note)).ReturnsAsync(note);
            var result = await _NoteService.AddNote(note);
            Assert.IsNotNull(result);
            Assert.Equals("This is the first note", result.Content);
        }

        [Fact]
        public async Task UpdateNoteAsync_WhenCalled_ReturnsUpdatedNoteAsync()
        {
            var note = new Note { Id = 111, UserId = 1111, Uid = "one", Content = "This is the first note", CreatedAt = DateTime.Now };
            _noteRepositoryMock.Setup(repo => repo.UpdateNote(111, note)).ReturnsAsync(note);
            var result = await _NoteService.UpdateNote(111, note);
            Assert.IsNotNull(result);
            Assert.Equals("This is the first note", result.Content);
        }

        [Fact]
        public async Task DeleteNoteAsync_WhenCalled_ReturnsDeletedNoteAsync()
        {
            var note = new Note { Id = 111, UserId = 1111, Uid = "one", Content = "This is the first note", CreatedAt = DateTime.Now };
            _noteRepositoryMock.Setup(repo => repo.DeleteNote(111)).ReturnsAsync(note);
            var result = await _NoteService.DeleteNote(111);
            Assert.IsNotNull(result);
            Assert.Equals("This is the first note", result.Content);
        }


    }
}
