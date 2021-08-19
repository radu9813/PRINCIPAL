
using System;
using System.IO;
using System.Text.Json;

namespace CSharpFeatures
{
    class Program
    {
        static  void Main(string[] args)
        {
           // TimeService timeService = new TimeService();
            TeamMember teamMember = new TeamMember();
            teamMember.Name = "Radu";
            string jsonString = JsonSerializer.Serialize(teamMember);
            Console.WriteLine(jsonString);
            File.WriteAllText("TeamMember.json", jsonString);
            var readText = File.ReadAllTextAsync("TeamMember.json");
            readText.Wait();
            var json = readText.Result;
            var teamMember2 = JsonSerializer.Deserialize<TeamMember>(json);

            Console.WriteLine(teamMember2.ToString());
        }
    }
}
