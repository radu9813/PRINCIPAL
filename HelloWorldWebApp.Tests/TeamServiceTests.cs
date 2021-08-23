using HelloWorldWebApp.Services;
using Microsoft.AspNetCore.SignalR;
using Moq;
using System;
using System.Threading;
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
            var teamService = new TeamService(GetMockedMessageHub());
            //Act
            int initialCount = teamService.GetTeamInfo().TeamMembers.Count;
            teamService.AddTeamMember("George");

            //Assert
            Assert.Equal(initialCount + 1, teamService.GetTeamInfo().TeamMembers.Count);
        }

        [Fact]
        public void RemoveMemberFromTheTeam()
        {
            // Assume
            ITeamService teamService = new TeamService(GetMockedMessageHub());
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
            ITeamService teamService = new TeamService(GetMockedMessageHub());
            var id = teamService.GetTeamInfo().TeamMembers[0].Id;

            // Act
            teamService.UpdateMemberName(id, "UnitTest");

            // Assert
            var member = teamService.GetMemberById(id);
            Assert.Equal("UnitTest", member.Name);
        }

        [Fact]
        public void CheckIdProblem()
        {
            // Assume
            ITeamService teamService = new TeamService(GetMockedMessageHub());
            var id = teamService.GetTeamInfo().TeamMembers[0].Id;

            // Act
            teamService.RemoveMember(id);
            int memberId = teamService.AddTeamMember("Test");
            teamService.RemoveMember(memberId);

            // Assert
            int lastIndex = teamService.GetTeamInfo().TeamMembers.Count;
            Assert.NotEqual("Test", teamService.GetTeamInfo().TeamMembers[lastIndex - 1].Name);
        }
        [Fact]
        public void CheckLine60()
        {   //Assume
            InitializeMessageHubMock();
            var messageHubMock = this.messageHub.Object;

            //Act
            messageHubMock.Clients.All.SendAsync("NewTeamMemberAdded", "Raducu", 2);

            //Assert
            hubAllClients.Verify(hubAllClients => hubAllClients.SendAsync("NewTeamMemberAdded", "Raducu", 2, It.IsAny<CancellationToken>()),Times.Once(),);
                
        }
        private Mock<IHubClients> hubClientsMock;
        private Mock<IClientProxy> hubAllClients;

        private void InitializeMessageHubMock()
        {
            // https://www.codeproject.com/Articles/1266538/Testing-SignalR-Hubs-in-ASP-NET-Core-2-1
            hubAllClients = new Mock<IClientProxy>();
            hubClientsMock = new Mock<IHubClients>();
            hubClientsMock.Setup(_ => _.All).Returns(hubAllClients.Object);
            messageHub = new Mock<IHubContext<MessageHub>>();



            messageHub.SetupGet(_ => _.Clients).Returns(hubClientsMock.Object);
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
