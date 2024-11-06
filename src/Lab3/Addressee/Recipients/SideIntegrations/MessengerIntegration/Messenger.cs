using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.Recipients.SideIntegrations.MessengerIntegration;

public class Messenger : IMessenger
{
    public void SendInMessenger(Message message)
    {
        string output = $"Messenger:\n" +
                        $"Header: {message.Header}\n" +
                        $"Text: {message.Text}\n";
        Console.WriteLine(output);
    }
}