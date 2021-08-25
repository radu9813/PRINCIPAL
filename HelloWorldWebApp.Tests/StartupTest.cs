using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorldWebApp.Tests
{
    public class StartupTest
    {
        [Fact]
        public void ConvertHerokuStringToASPString()
        {
            //Assume
            string herokuConnectionString = "postgres://yjuypjyrjdpooz:918c09f6796c6703255413f0a3ebab76dded049668183f4dd6706b6be71c2a97@ec2-52-208-221-89.eu-west-1.compute.amazonaws.com:5432/d3uekhlv2aejk1";
            //Act
            string aspConnectionString = Startup.ConvertHerokuStringToASPString(herokuConnectionString);

            //Assert
            string expectedResult = "Host=ec2-52-208-221-89.eu-west-1.compute.amazonaws.com;Port=5432;Database=d3uekhlv2aejk1;User Id=yjuypjyrjdpooz;Password=918c09f6796c6703255413f0a3ebab76dded049668183f4dd6706b6be71c2a97;Pooling=true;SSL Mode=Require;TrustServerCertificate=True;Include Error Detail=True";
            Assert.Equal(expectedResult, aspConnectionString);

        }
    }
}
