using Itmo.ObjectOrientedProgramming.Lab3.Addressee.Recipients.SideIntegrations.DisplayIntegration.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.Recipients.SideIntegrations.DisplayIntegration;

public class Display : IDisplay
{
    private readonly ConsoleDisplayDriver _consoleDriver;
    private readonly FileDiplayDriver _fileDriver;

    public Display(string filePath)
    {
        _consoleDriver = new ConsoleDisplayDriver();
        _fileDriver = new FileDiplayDriver(filePath);
    }

    public void DisplayMessage(string message)
    {
        _consoleDriver.Write(message);
        _fileDriver.Write(message);
    }
}