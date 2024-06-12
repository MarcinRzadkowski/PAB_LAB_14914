using WebApi.Core.Entities;

namespace WebApi.Core.Repositories
{
    public interface IMemberService
    {
        Task<Member> GetMemberByIdAsync(int id);
        Task<IEnumerable<Member>> GetAllMembersAsync();
        Task AddMemberAsync(Member member);
        Task UpdateMemberAsync(Member member);
        Task DeleteMemberAsync(int id);
    }
}