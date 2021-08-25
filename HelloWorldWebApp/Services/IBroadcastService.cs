namespace HelloWorldWebApp.Services
{
    public interface IBroadcastService
    {
        void NewTeamMemberAdded(string name, int id);

        void TeamMemberDeleted(int memberId);

        void UpdatedTeamMember(int memberId, string name);
    }
}