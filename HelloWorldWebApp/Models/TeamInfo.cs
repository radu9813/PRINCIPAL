// <copyright file="TeamInfo.cs" company="Principal 33">
// Copyright (c) Principal 33. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace HelloWorldWebApp.Models
{
    public class TeamInfo
    {

        public TeamInfo()
        {
        }

        public TeamInfo(List<TeamMember> teamMembers)
        {
            TeamMembers = teamMembers;
            Name = "DefaultName";
        }

        public string Name { get; set; }

        public List<TeamMember> TeamMembers { get; set; }
    }
}