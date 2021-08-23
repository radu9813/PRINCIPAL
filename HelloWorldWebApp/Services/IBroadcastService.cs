namespace HelloWorldWebApp.Services
{
    public interface IBroadcastService
    {
        void NewTeamMemberAdded(string name, int id);
    }
}