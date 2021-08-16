// <copyright file="HomeController.cs" company="Principal 33">
// Copyright (c) Principal 33. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics;
using HelloWorldWebApp.Models;
using HelloWorldWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HelloWorldWebApp.Controllers
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class HomeController : Controller
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        private readonly ILogger<HomeController> logger;
        private readonly ITeamService teamService;
        private readonly ITimeService timeService;

        public HomeController(ILogger<HomeController> logger, ITeamService teamService, ITimeService timeService)
        {
            this.logger = logger;
            this.teamService = teamService;
            this.timeService = timeService;
        }

        [HttpPost]
        public int AddTeamMember(string teamMember)
        {
            return teamService.AddTeamMember(teamMember);
        }

        [HttpDelete]
        public void RemoveMember(int memberIndex)
        {
            teamService.RemoveMember(memberIndex);
        }

        [HttpPost]
        public void UpdateMemberName(int memberId, string name)
        {
            teamService.UpdateMemberName(memberId, name);
        }

        [HttpGet]
        public int GetCount()
        {
            return teamService.GetTeamInfo().TeamMembers.Count;
        }

        public IActionResult Index()
        {
            return this.View(teamService.GetTeamInfo());
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
