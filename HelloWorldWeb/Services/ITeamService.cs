using HelloWorldWeb.Models;

namespace HelloWorldWeb.Services
{
    public interface ITeamService
    {
        int AddTeamMember(TeamMember  member);

        public void RemoveMember(int memberIndex);
        TeamInfo GetTeamInfo();
        void UpdateMemberName(int memberId, string name);
    }
}