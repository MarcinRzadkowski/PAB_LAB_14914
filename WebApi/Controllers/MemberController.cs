using Microsoft.AspNetCore.Mvc;
using WebApi.Core.Entities;
using WebApi.Core.Repositories;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberRepository;

        public MemberController(IMemberService memberRepository)
        {
            _memberRepository = memberRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Member>> GetMembers()
        {
            return await _memberRepository.GetAllMembersAsync();
        }

        [HttpGet("{id}")]
        public async Task<Member> GetMember(int id)
        {
            return await _memberRepository.GetMemberByIdAsync(id);
        }

        [HttpPost]
        public async Task AddMember([FromBody] Member member)
        {
            await _memberRepository.AddMemberAsync(member);
        }

        [HttpPut("{id}")]
        public async Task UpdateMember(int id, [FromBody] Member member)
        {
            member.Id = id;
            await _memberRepository.UpdateMemberAsync(member);
        }

        [HttpDelete("{id}")]
        public async Task DeleteMember(int id)
        {
            await _memberRepository.DeleteMemberAsync(id);
        }
    }
}