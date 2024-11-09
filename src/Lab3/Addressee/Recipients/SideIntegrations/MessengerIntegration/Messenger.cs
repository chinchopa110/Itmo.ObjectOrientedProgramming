using Itmo.ObjectOrientedProgramming.Lab3.Addressee.Recipients.SideIntegrations.MessengerIntegration.ConsoleProvaider;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.Recipients.SideIntegrations.MessengerIntegration;

public class Messenger : IMessenger
{
    private readonly IConsoleWriter _consoleWriter;

    public Messenger(IConsoleWriter consoleWriter)
    {
        _consoleWriter = consoleWriter;
    }

    public void SendInMessenger(string message)
    {
        _consoleWriter.Write(message);
    }
}