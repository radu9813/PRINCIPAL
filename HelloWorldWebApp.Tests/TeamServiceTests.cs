using HelloWorldWebApp.Services;
using Microsoft.AspNetCore.SignalR;
using Moq;
using System;
using Xunit;

namespace HelloWorldWebApp.Tests
{
    public class TeamServiceTests
    {   
        private Mock<IHubContext<MessageHub>> messageHub = null;

        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            //Assume
            Mock<IBroadcastService> broadcastServiceMock = new Mock<IBroadcastService>(); 
            var teamService = new TeamService(broadcastServiceMock.Object);
            //Act
            int initialCount = teamService.GetTeamInfo().TeamMembers.Count;
            teamService.AddTeamMember("George");

            //Assert
            Assert.Equal(initialCount + 1, teamService.GetTeamInfo().TeamMembers.Count);
            broadcastServiceMock.Verify(_ => _.NewTeamMemberAdded("George", It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void RemoveMemberFromTheTeam()
        {
            // Assume
            Mock<IBroadcastService> broadcastServiceMock = new Mock<IBroadcastService>();
            var teamService = new TeamService(broadcastServiceMock.Object);
            int initialCount = teamService.GetTeamInfo().TeamMembers.Count;
            var id = teamService.GetTeamInfo().TeamMembers[0].Id;

            // Act
            teamService.RemoveMember(id);

            // Assert
            Assert.Equal(initialCount - 1, teamService.GetTeamInfo().TeamMembers.Count);
        }

        [Fact]
        public void UpdateMemberName()
        {
            // Assume
            Mock<IBroadcastService> broadcastServiceMock = new Mock<IBroadcastService>();
            var teamService = new TeamService(broadcastServiceMock.Object);
            var id = teamService.GetTeamInfo().TeamMembers[0].Id;

            // Act
            teamService.UpdateMemberName(id, "UnitTest");

            // Assert
            var member = teamService.GetMemberById(id);
            Assert.Equal("UnitTest", member.Name);
        }

      /*  [Fact]
        public void CheckIdProblem()
        {
            // Assume
            Mock<IBroadcastService> broadcastServiceMock = new Mock<IBroadcastService>();
            var teamService = new TeamService(broadcastServiceMock.Object);
            var id = teamService.GetTeamInfo().TeamMembers[0].Id;

            // Act
            teamService.RemoveMember(id);
            int memberId = teamService.AddTeamMember("Test");
            teamService.RemoveMember(memberId);

            // Assert
            int lastIndex = teamService.GetTeamInfo().TeamMembers.Count;
            Assert.NotEqual("Test", teamService.GetTeamInfo().TeamMembers[lastIndex - 1].Name);
        }*/

        private void InitializeMessageHubMock()
        {
            // https://www.codeproject.com/Articles/1266538/Testing-SignalR-Hubs-in-ASP-NET-Core-2-1
            Mock<IClientProxy> hubAllClients = new Mock<IClientProxy>();
            Mock<IHubClients> hubClients = new Mock<IHubClients>();
            hubClients.Setup(_ => _.All).Returns(hubAllClients.Object);
            messageHub = new Mock<IHubContext<MessageHub>>();



            messageHub.SetupGet(_ => _.Clients).Returns(hubClients.Object);
        }

        IHubContext<MessageHub> GetMockedMessageHub()
        {
            if (messageHub == null)
            {
                InitializeMessageHubMock();
            }



            return messageHub.Object;
        }
    }
}
