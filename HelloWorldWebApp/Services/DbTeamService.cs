using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldWebApp.Data;
using HelloWorldWebApp.Models;

namespace HelloWorldWebApp.Services
{
    public class DbTeamService : ITeamService
    {
        private readonly ApplicationDbContext context;

        public DbTeamService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int AddTeamMember(string name)
        {
            TeamMember newMember = new TeamMember() { Name = name };
            context.Add(newMember);
            context.SaveChanges();

            return newMember.Id;
        }

        public TeamMember GetMemberById(int memberId)
        {
            return context.TeamMembers.Find(memberId); ;
        }

        public TeamInfo GetTeamInfo()
        {
            var result = context.TeamMembers.ToList();
            return new TeamInfo(result);
        }

        public void RemoveMember(int memberId)
        {
            var teamMember = GetMemberById(memberId);
            context.TeamMembers.Remove(teamMember);
            context.SaveChanges();
        }

        public void UpdateMemberName(int memberId, string name)
        {
            var teamMember = GetMemberById(memberId);
            teamMember.Name = name;

            context.SaveChanges();
        }
    }
}
