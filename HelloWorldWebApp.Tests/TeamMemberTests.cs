using HelloWorldWebApp.Models;
using HelloWorldWebApp.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorldWebApp.Tests
{
    public class TeamMemberTests
    {
        private Mock<ITimeService> timeMock;

        public TeamMemberTests()
        {
            InitializeTimeServiceMock();

        }

        private void InitializeTimeServiceMock()
        {
            this.timeMock = new Mock<ITimeService>();
            timeMock.Setup(_ => _.GetCurrentDate()).Returns(new DateTime(2021, 8, 11));
        }

        /*[Fact]
        public void GettingAge()
        {
            InitializeTimeServiceMock();
            //Assume
            var timeService = timeMock.Object;
            TeamMember newMember = new TeamMember();
            newMember.Name = ("Test");
            newMember.Birthday = new DateTime(1990, 9, 30);

            //Act
           // int age = newMember.GetAge();

            //Assert
            timeMock.Verify(_ => _.GetCurrentDate(), Times.Once());
            Assert.Equal(30, 30);
        }*/

       
    }
}
