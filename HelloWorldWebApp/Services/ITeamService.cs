using HelloWorldWebApp.Models;

namespace HelloWorldWebApp.Services
{
    public interface ITeamService
    {
        int AddTeamMember(string name);

        public void RemoveMember(int memberId);

        public void UpdateMemberName(int memberId, string name);

        TeamInfo GetTeamInfo();

        TeamMember GetMemberById(int memberId);
    }
}