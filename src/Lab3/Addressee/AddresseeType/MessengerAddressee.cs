using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.Recipients.SideIntegrations.MessengerIntegration;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType;

public class MessengerAddressee : IAddressee
{
    private readonly IMessenger _messenger;

    public MessengerAddressee(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void DeliverMessage(Message message)
    {
        _messenger.SendInMessenger(ConvertMessageToString(message));
    }

    private string ConvertMessageToString(Message message)
    {
        string output = $"Messenger:\n" +
                        $"Header: {message.Header}\n" +
                        $"Text: {message.Text}\n";
        return output;
    }
}