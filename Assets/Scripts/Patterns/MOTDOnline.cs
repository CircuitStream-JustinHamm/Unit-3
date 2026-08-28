using UnityEngine;

public class MOTDOnline : MOTD
{
    public override string GetMOTD()
    {
        return GetMessageFromServer();
    }

    private string GetMessageFromServer()
    {
        // Pretend this does something fancy...
        return "Welcome!";
    }
}
