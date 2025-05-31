using Moq;
using ScriptureNotesBE.Models;
using Xunit;
using ScriptureNotesBE.Interfaces;
using ScriptureNotesBE.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ScriptureNoteBETest
{
    public class SGTest
    {
        private readonly Mock<IStudyGroupRepository> _studyGroupRepositoryMock;
        private readonly IStudyGroupServices _studyGroupService;

        public SGTest()
        {
            _studyGroupRepositoryMock = new Mock<IStudyGroupRepository>();
            _studyGroupService = new StudyGroupServices(_studyGroupRepositoryMock.Object);
        }

        [Fact]
        public async Task GetStudyGroups_ShouldReturnListOfStudyGroups()
        {
            // Arrange
            var studyGroups = new List<StudyGroup>
            {
                new StudyGroup { Id = 1, Name = "Group 1", Description = "Description 1" },
                new StudyGroup { Id = 2, Name = "Group 2", Description = "Description 2" }
            };

            _studyGroupRepositoryMock.Setup(repo => repo.GetStudyGroups()).ReturnsAsync(studyGroups);
            // Act
            var result = await _studyGroupService.GetStudyGroups();
            // Assert
            Assert.IsNotNull(result);
            Assert.Equals(2, result.Count);
        }

        [Fact]
        public async Task AddStudyGroup_ShouldReturnAddedStudyGroup()
        {
            // Arrange
            var newStudyGroup = new StudyGroup { Id = 3, Name = "Group 3", Description = "Description 3" };
            _studyGroupRepositoryMock.Setup(repo => repo.AddStudyGroup(It.IsAny<StudyGroup>())).ReturnsAsync(newStudyGroup);
            // Act
            var result = await _studyGroupService.AddStudyGroup(newStudyGroup);
            // Assert
            Assert.IsNotNull(result);
            Assert.Equals("Group 3", result.Name);
        }

        [Fact]
        public async Task UpdateStudyGroup_ShouldReturnUpdatedStudyGroup()
        {
            // Arrange
            var updatedStudyGroup = new StudyGroup { Id = 1, Name = "Updated Group", Description = "Updated Description" };
            _studyGroupRepositoryMock.Setup(repo => repo.UpdateStudyGroup(1, It.IsAny<StudyGroup>())).ReturnsAsync(updatedStudyGroup);
            // Act
            var result = await _studyGroupService.UpdateStudyGroup(1, updatedStudyGroup);
            // Assert
            Assert.IsNotNull(result);
            Assert.Equals("Updated Group", result.Name);
        }

        [Fact]
        public async Task DeleteStudyGroup_ShouldReturnDeletedStudyGroup()
        {
            // Arrange
            var deletedStudyGroup = new StudyGroup { Id = 1, Name = "Deleted Group", Description = "Deleted Description" };
            _studyGroupRepositoryMock.Setup(repo => repo.DeleteStudyGroup(1)).ReturnsAsync(deletedStudyGroup);
            // Act
            var result = await _studyGroupService.DeleteStudyGroup(1);
            // Assert
            Assert.IsNotNull(result);
            Assert.Equals("Deleted Group", result.Name);
        }

        [Fact]
        public async Task GetStudyGroupById_ShouldReturnStudyGroup()
        {
            // Arrange
            var studyGroup = new StudyGroup { Id = 1, Name = "Group 1", Description = "Description 1" };
            _studyGroupRepositoryMock.Setup(repo => repo.GetStudyGroupById(1)).ReturnsAsync(new List<StudyGroup> { studyGroup });
            // Act
            var result = await _studyGroupService.GetStudyGroupById(1);
            // Assert
            Assert.IsNotNull(result);
            Assert.ContainsSingle(result);
            Assert.Equals("Group 1", result[0].Name);
        }

    }
}
