using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Composite;

public class GroupAddressee : IAddressee
{
    private readonly IReadOnlyCollection<IAddressee> _addresses;

    public GroupAddressee(IReadOnlyCollection<IAddressee> addresses)
    {
        _addresses = addresses;
    }

    public void DeliverMessage(Message message)
    {
        foreach (IAddressee addressee in _addresses)
            addressee.DeliverMessage(message);
    }
}