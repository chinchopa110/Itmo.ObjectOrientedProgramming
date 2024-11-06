using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.Recipients.SideIntegrations.DisplayIntegration;

public class Display : IDisplay
{
    private readonly DisplayDriver _driver;

    public Display(string filePath)
    {
        _driver = new DisplayDriver("filePath");
    }

    public void DisplayMessage(Message message)
    {
        _driver.Write(message);
    }
}