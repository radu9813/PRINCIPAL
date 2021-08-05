using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Models
{
    public class TeamMember
    {
        private static int idCount = 0;
        public TeamMember(string name)
        {
            this.Name = name;
            this.ID = idCount;
            idCount++;
        }

        public int ID { get; set; }
        public string Name { get; set; }
    }
}
