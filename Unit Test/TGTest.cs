using Moq;
using ScriptureNotesBE.Models;
using Xunit;
using ScriptureNotesBE.Interfaces;
using ScriptureNotesBE.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ScriptureNoteBETest;

public class TGTest
{
    private readonly Mock<ITagRepository> _tagRepositoryMock;
    private readonly TagServices _tagServices;


    public TGTest()
    {
        _tagRepositoryMock = new Mock<ITagRepository>();
        _tagServices = new TagServices(_tagRepositoryMock.Object);
    }

    [Fact]
    public async Task GetTags_ShouldReturnListOfTags()
    {
        // Arrange
        var tags = new List<Tag>
        {
            new Tag { Id = 1, Name = "Tag1", CreatedAt = DateTime.Now },
            new Tag { Id = 2, Name = "Tag2", CreatedAt = DateTime.Now }
        };
        _tagRepositoryMock.Setup(repo => repo.GetTags()).ReturnsAsync(tags);
        // Act
        var result = await _tagServices.GetTags();
        // Assert
        Assert.IsNotNull(result);
        Assert.Equals(2, result.Count);
        Assert.Equals("Tag1", result[0].Name);
    }

    [Fact]
    public async Task AddTag_ShouldReturnAddedTag()
    {
        // Arrange
        var newTag = new Tag { Id = 3, Name = "Tag3", CreatedAt = DateTime.Now };
        _tagRepositoryMock.Setup(repo => repo.AddTag(It.IsAny<Tag>())).ReturnsAsync(newTag);
        // Act
        var result = await _tagServices.AddTag(newTag);
        // Assert
        Assert.IsNotNull(result);
        Assert.Equals("Tag3", result.Name);
    }

    [Fact]
    public async Task UpdateTag_ShouldReturnUpdatedTag()
    {
        // Arrange
        var existingTag = new Tag { Id = 1, Name = "Tag1", CreatedAt = DateTime.Now };
        var updatedTag = new Tag { Id = 1, Name = "UpdatedTag1", CreatedAt = DateTime.Now };
        _tagRepositoryMock.Setup(repo => repo.UpdateTag(1, It.IsAny<Tag>())).ReturnsAsync(updatedTag);
        // Act
        var result = await _tagServices.UpdateTag(1, updatedTag);
        // Assert
        Assert.IsNotNull(result);
        Assert.Equals("UpdatedTag1", result.Name);
    }

    [Fact]
    public async Task DeleteTag_ShouldReturnDeletedTag()
    {
        // Arrange
        var tagToDelete = new Tag { Id = 1, Name = "Tag1", CreatedAt = DateTime.Now };
        _tagRepositoryMock.Setup(repo => repo.DeleteTag(1)).ReturnsAsync(tagToDelete);
        // Act
        var result = await _tagServices.DeleteTag(1);
        // Assert
        Assert.IsNotNull(result);
        Assert.Equals("Tag1", result.Name);
    }

    [Fact]
    public async Task GetTagById_ShouldReturnTag()
    {
        // Arrange
        var tag = new Tag { Id = 1, Name = "Tag1", CreatedAt = DateTime.Now };
        _tagRepositoryMock.Setup(repo => repo.GetTagById(1)).ReturnsAsync(new List<Tag> { tag });
        // Act
        var result = await _tagServices.GetTagById(1);
        // Assert
        Assert.IsNotNull(result);
        Assert.ContainsSingle(result);
        Assert.Equals("Tag1", result[0].Name);
    }
}
