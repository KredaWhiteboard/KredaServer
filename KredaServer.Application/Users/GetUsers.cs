namespace KredaServer.Application;

public class GetUsers(List<string> usersList)
{
    public string[] Execute()
    {
        
        return usersList.ToArray();
    }
}
