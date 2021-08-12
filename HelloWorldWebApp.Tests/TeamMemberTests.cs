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
        private readonly ITimeService timeService;

        public TeamMemberTests()
        {
            var mock = new Mock<ITimeService>();
            mock.Setup(_ => _.GetCurrentDate()).Returns(new DateTime(2021, 8, 11));
            timeService = mock.Object;
        }

        [Fact]
        public void GettingAge()
        {
            //Assume
            TeamMember newMember = new TeamMember("UnitTests", timeService);
            newMember.Birthday = new DateTime(1990, 9, 30);

            //Act
            int age = newMember.GetAge();

            //Assert
            Assert.Equal(30, age);
        }

       
    }
}
