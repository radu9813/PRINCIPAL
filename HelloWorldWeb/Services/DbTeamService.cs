using HelloWorldWeb.Data;
using HelloWorldWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Services
{
    public class DbTeamService : ITeamService
    {
        private readonly ApplicationDbContext _context;

        public DbTeamService(ApplicationDbContext context)
        {
            _context = context;
        }

        public int AddTeamMember(TeamMember member)
        {
            _context.Add(member);
            _context.SaveChanges();
            return member.Id;
        }

        public TeamInfo GetTeamInfo()
        {
            TeamInfo team = new TeamInfo();
            team.Name = "Backend Team 3";
            team.TeamMembers = _context.TeamMembers.ToList();
            return team;
        }

        public void RemoveMember(int memberIndex)
        {
            TeamMember teamMember = _context.TeamMembers.Find(memberIndex);

            _context.TeamMembers.Remove(teamMember);

            _context.SaveChanges();
        }

        public void UpdateMemberName(int memberId, string name)
        {
            TeamMember teamMember = _context.TeamMembers.Find(memberId);
            teamMember.Name = name;
            _context.SaveChanges();
        }
    }
}
