
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
            Console.Write("What would you like: ");
            var input = Console.ReadLine();
            Func<string, string, string, string, Coffee> recipe = (input=="FlatWhite") ? FlatWhite : Espresso;
        
            Coffee coffee = MakeCoffee("grains", "cow", "2 cups", "2 tablespoons", recipe);

            if (coffee != null)
            {
                Console.WriteLine($"Here is your coffee {coffee}");
            }
            else
            {
                Console.WriteLine("We are sorry that we could not deliver your coffee.");
            }
            
        }

        static Coffee MakeCoffee(string grains, string milk, string water, string sugar, Func<string, string, string, string, Coffee> recipe)
        {
            try
            {
                Console.WriteLine("Start preparing coffee.");

                var coffee = recipe(grains, milk, water, sugar);
                return coffee;
            }
            catch (Exception)
            {
                Console.WriteLine("Sorry your order could not be completed");
                return null;
                
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
       

        }

        static Coffee Espresso(string grains, string milk, string water, string sugar)
        {
            throw new RecipeUnavailableException();
        }

        static Coffee FlatWhite(string grains, string milk, string water, string sugar)
        {
            return new Coffee("FlatWhite");
        }
    }
}
