using HelloWorldWebApp.Models;
using HelloWorldWebApp.Services;
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
            timeService = new FakeTimeService();
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

        private class FakeTimeService : ITimeService
        {
            public DateTime GetCurrentDate()
            {
                return new DateTime(2021, 8, 11);
            }
        }
    }
}
