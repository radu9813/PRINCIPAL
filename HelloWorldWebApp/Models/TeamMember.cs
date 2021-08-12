// <copyright file="TeamInfo.cs" company="Principal 33">
// Copyright (c) Principal 33. All rights reserved.
// </copyright>

using System;
using HelloWorldWebApp.Services;

namespace HelloWorldWebApp.Models
{
    public class TeamMember
    {
        private static int idGenerator = 0;
        private readonly ITimeService timeService;

        public TeamMember(string name, ITimeService timeService)
        {
            Id = idGenerator;
            Name = name;
            idGenerator++;

            this.timeService = timeService;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public int GetAge()
        {
            var age = timeService.GetCurrentDate().Subtract(Birthday).Days;
            return age / 365;
        }
    }
}