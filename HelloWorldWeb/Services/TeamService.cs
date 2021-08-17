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

            this.AddTeamMember("Teona");
            this.AddTeamMember("Radu");
            this.AddTeamMember("George");
            this.AddTeamMember("Dragos");
            this.AddTeamMember("Claudia");
            this.AddTeamMember("Leon");
        }

        public TeamInfo GetTeamInfo()
        {
            return this.teamInfo;
        }

        public TeamMember GetTeamMemberByID(int id)
        {
            foreach (TeamMember teamMember in this.teamInfo.TeamMembers) {
                    if (id == teamMember.Id)
                    {
                        return teamMember;
                    }
            }

            return null;
        }

        public void UpdateMemberName(int memberId, string name)
        {
            int index = teamInfo.TeamMembers.FindIndex(element => element.Id == memberId);
            teamInfo.TeamMembers[index].Name = name;
        }
        public int AddTeamMember(string name)
        {
            TeamMember teamMember = new TeamMember();
            teamMember.Name = name;
            this.teamInfo.TeamMembers.Add(teamMember);
            return teamMember.Id;
        }

        public void RemoveMember(int memberIndex)
        {
            this.teamInfo.TeamMembers.Remove(GetTeamMemberByID(memberIndex));
        }

    }
}
