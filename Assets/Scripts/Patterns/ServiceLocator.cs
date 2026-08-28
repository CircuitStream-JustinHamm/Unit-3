using UnityEngine;

public class ServiceLocator
{
    // Actual Motd Class
    private static MOTD _motd;

    // What we see from other classes
    public static MOTD Motd {
        get
        {
            // If we try to use MOTD, and it's null...
            if (_motd == null)
            
                // Set it to the default null class.
                _motd = new MOTDNull();

            return _motd;
        }
    }

    public static void SetMotd(MOTD newMotdInstance)
    {
        _motd = newMotdInstance;
    }
}
