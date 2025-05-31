using Moq;
using ScriptureNotesBE.Models;
using Xunit;
using ScriptureNotesBE.Interfaces;
using ScriptureNotesBE.Services;


using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ScriptureNoteBETest
{
    public class GroupMemberTest
    {
        private readonly Mock<IGroupMemberRepository> _groupMemberRepositoryMock;
        private readonly IGroupMemberServices _GroupMemberService;

        public GroupMemberTest()
        {
            _groupMemberRepositoryMock = new Mock<IGroupMemberRepository>();
            _GroupMemberService = new GroupMemberServices(_groupMemberRepositoryMock.Object);
        }

        [Fact]
        public async Task GetGroupMembersAsync_WhenCalled_ReturnsGroupMembersAsync()
        {
            var groupMembers = new List<GroupMember>
            {
                new GroupMember { Id = 10, UserId = 1111, GroupId = 11 },
                new GroupMember { Id = 20, UserId = 2222, GroupId = 12 }
            };

            _groupMemberRepositoryMock.Setup(repo => repo.GetGroupMembers()).ReturnsAsync(groupMembers);
            var result = await _GroupMemberService.GetGroupMembers();
            Assert.IsNotNull(result);
            Assert.Equals(2, result.Count);
        }

        [Fact]
        public async Task GetGroupMemberByIdAsync_WhenCalledWithValidId_ReturnsGroupMemberAsync()
        {
            var groupMemberId = 10;
            var groupMembers = new List<GroupMember>
            {
                new GroupMember { Id = 10, UserId = 1111, GroupId = 11 }
            };


            // If your service expects a list, wrap in a list:
            _groupMemberRepositoryMock.Setup(x => x.GetGroupMemberByIdAsync(groupMemberId))
       .ReturnsAsync(groupMembers);
            var result = await _GroupMemberService.GetGroupMemberById(10);

            Assert.IsNotNull(result);
            Assert.ContainsSingle(result);
            Assert.Equals(10, result[0].Id);
        }

        [Fact]
        public async Task AddGroupMemberAsync_WhenCalledWithValidGroupMember_ReturnsAddedGroupMemberAsync()
        {
            var groupMember = new GroupMember { Id = 10, UserId = 1111, GroupId = 11 };
            _groupMemberRepositoryMock.Setup(repo => repo.AddGroupMember(groupMember)).ReturnsAsync(groupMember);
            var result = await _GroupMemberService.AddGroupMember(groupMember);
            Assert.IsNotNull(result);
            Assert.Equals(10, result.Id);
        }

        [Fact]
        public async Task UpdateGroupMemberAsync_WhenCalledWithValidIdAndGroupMember_ReturnsUpdatedGroupMemberAsync()
        {
            var groupMember = new GroupMember { Id = 10, UserId = 1111, GroupId = 11 };
            _groupMemberRepositoryMock.Setup(repo => repo.UpdateGroupMember(10, groupMember)).ReturnsAsync(groupMember);
            var result = await _GroupMemberService.UpdateGroupMember(10, groupMember);
            Assert.IsNotNull(result);
            Assert.Equals(10, result.Id);
        }

        [Fact]
        public async Task DeleteGroupMemberAsync_WhenCalledWithValidId_ReturnsDeletedGroupMemberAsync()
        {
            var groupMember = new GroupMember { Id = 10, UserId = 1111, GroupId = 11 };
            _groupMemberRepositoryMock.Setup(repo => repo.DeleteGroupMember(10)).ReturnsAsync(groupMember);
            var result = await _GroupMemberService.DeleteGroupMember(10);
            Assert.IsNotNull(result);
            Assert.Equals(10, result.Id);
        }
    }
}
