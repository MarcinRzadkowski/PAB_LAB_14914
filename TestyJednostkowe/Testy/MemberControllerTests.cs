using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;
using WebApi.Core.Entities;
using WebApi.Core.Repositories;

namespace TestyJednostkowe.Testy
{
    public class MemberControllerTests
    {
        private readonly MemberController _controller;
        private readonly Mock<IMemberService> _mockMemberService;

        public MemberControllerTests()
        {
            _mockMemberService = new Mock<IMemberService>();
            _controller = new MemberController(_mockMemberService.Object);
        }

        [Fact]
        public async Task GetMembers_ReturnsAllMembers()
        {
            var members = new List<Member>
            {
                new Member { Id = 1, FullName = "Member 1" },
                new Member { Id = 2, FullName = "Member 2" }
            };

            _mockMemberService.Setup(service => service.GetAllMembersAsync()).ReturnsAsync(members);

            var result = await _controller.GetMembers();

            Assert.Equal(members, result);
        }

        [Fact]
        public async Task GetMember_ReturnsMember()
        {
            var member = new Member { Id = 1, FullName = "Member 1" };

            _mockMemberService.Setup(service => service.GetMemberByIdAsync(1)).ReturnsAsync(member);

            var result = await _controller.GetMember(1);

            Assert.Equal(member, result);
        }

        [Fact]
        public async Task AddMember_CallsServiceWithMember()
        {
            var member = new Member { FullName = "New Member" };

            _mockMemberService.Setup(service => service.AddMemberAsync(member)).Returns(Task.CompletedTask).Verifiable();

            await _controller.AddMember(member);

            _mockMemberService.Verify(service => service.AddMemberAsync(member), Times.Once);
        }

        [Fact]
        public async Task UpdateMember_CallsServiceWithUpdatedMember()
        {
            var member = new Member { Id = 1, FullName = "Updated Member" };

            _mockMemberService.Setup(service => service.UpdateMemberAsync(member)).Returns(Task.CompletedTask).Verifiable();

            await _controller.UpdateMember(1, member);

            _mockMemberService.Verify(service => service.UpdateMemberAsync(member), Times.Once);
        }

        [Fact]
        public async Task DeleteMember_CallsServiceWithId()
        {
            var memberId = 1;

            _mockMemberService.Setup(service => service.DeleteMemberAsync(memberId)).Returns(Task.CompletedTask).Verifiable();

            await _controller.DeleteMember(memberId);

            _mockMemberService.Verify(service => service.DeleteMemberAsync(memberId), Times.Once);
        }
    }
}