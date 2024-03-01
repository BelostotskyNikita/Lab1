using Lab1_4.Entities;

namespace Lab1_4.Services
{
    public interface IDbService
    {
        IEnumerable<Team> GetAllTeams();
        IEnumerable<Member> GetMembers(int id);
        void Init();
    }
}
