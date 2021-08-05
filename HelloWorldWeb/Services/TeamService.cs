using HelloWorldWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamInfo teamInfo;

        public TeamService()
        {
            this.teamInfo = new TeamInfo
            {
                Name = "Team 3",
                TeamMembers = new List<TeamMember>(),
            };

            this.teamInfo.TeamMembers.Add(new TeamMember("Teona"));
            this.teamInfo.TeamMembers.Add(new TeamMember("Radu"));
            this.teamInfo.TeamMembers.Add(new TeamMember("George"));
            this.teamInfo.TeamMembers.Add(new TeamMember("Dragos"));
            this.teamInfo.TeamMembers.Add(new TeamMember("Claudia"));
            this.teamInfo.TeamMembers.Add(new TeamMember("Leon"));
        }

        public TeamInfo GetTeamInfo()
        {
            return this.teamInfo;
        }

        public int AddTeamMember(string name)
        {
            TeamMember teamMember = new TeamMember(name);
           
            teamInfo.TeamMembers.Add(teamMember);
            return teamMember.ID;
        }

        public void RemoveMember(int memberIndex)
        {
            teamInfo.TeamMembers.RemoveAt(memberIndex);
        }

    }
}
