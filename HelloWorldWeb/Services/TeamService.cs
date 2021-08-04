﻿using HelloWorldWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamInfo teamInfo;

        public TeamService()
        {
            this.teamInfo = new TeamInfo
            {
                Name = "Team 3",
                TeamMembers = new List<string>(new string[] { "Teona", "Radu", "Dragos", "Claudia", "Leon", "George" }),
            };
        }

        public TeamInfo GetTeamInfo()
        {
            return this.teamInfo;
        }

        public string AddTeamMember(string name)
        {
            teamInfo.TeamMembers.Add(name);
            return name;
        }

    }
}
