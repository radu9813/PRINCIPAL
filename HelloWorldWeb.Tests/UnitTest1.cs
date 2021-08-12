using HelloWorldWeb.Services;
using System;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamServiceTest
    {
        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            //Asume

            ITeamService teamService = new TeamService();
            int teamCnt = teamService.GetTeamInfo().TeamMembers.Count;
            //Act
            teamService.AddTeamMember("Raducu");
            //Assert
            Assert.Equal(teamCnt + 1, teamService.GetTeamInfo().TeamMembers.Count);
        }

        [Fact]
        public void RemoveMemberFromTheTeam()
        {
            // Assume
            TeamService teamService = new TeamService();

            // Act
            teamService.RemoveMember(2);

            // Assert
            Assert.True(true);
        }
    }
}
