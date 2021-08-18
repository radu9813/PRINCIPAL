using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class StartupTests
    {
        [Fact]
        public void ConvertHerokuStringToASPNETString()
        {
            //Assume
            string herokuConnectionString = "postgres://gdpwhqjwnjynmj:b1a04484b373eb434580e479482d55af380e7ee9a0520815f01f2b906dcf28bd@ec2-34-251-245-108.eu-west-1.compute.amazonaws.com:5432/dfq8nb3bfovsg4";

            //Act
            string aspNetConnectionString = Startup.ConvertHerokuConnectionToASPNET(herokuConnectionString);
            
            //Assert
            Assert.Equal("Host=ec2-34-251-245-108.eu-west-1.compute.amazonaws.com;Port=5432;Username=gdpwhqjwnjynmj;Password=b1a04484b373eb434580e479482d55af380e7ee9a0520815f01f2b906dcf28bd;Database=dfq8nb3bfovsg4;Pooling=true;SSL Mode=Require;TrustServerCertificate=True;", aspNetConnectionString);
        }
    }
}
