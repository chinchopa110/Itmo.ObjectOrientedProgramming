using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.Recipients.SideIntegrations.DisplayIntegration;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType;

public class DisplayAddressee : IAddressee
{
    private readonly IDisplay _display;

    public DisplayAddressee(IDisplay display)
    {
        _display = display;
    }

    public void DeliverMessage(Message message)
    {
        _display.DisplayMessage(message);
    }
}