
using System;
using System.IO;
using System.Text.Json;

namespace CSharpFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
           // TimeService timeService = new TimeService();
            TeamMember teamMember = new TeamMember();
            teamMember.Name = "Radu";
            string jsonString = JsonSerializer.Serialize(teamMember);
            Console.WriteLine(jsonString);
            File.WriteAllText("TeamMember.json", jsonString);

            var teamMember2 = JsonSerializer.Deserialize<TeamMember>(jsonString);
        }
    }
}
