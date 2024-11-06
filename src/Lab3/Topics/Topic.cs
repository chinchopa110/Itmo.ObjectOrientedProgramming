using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public class Topic
{
    private readonly IReadOnlyCollection<IAddressee> _addresses;

    public string Name { get; }

    public Topic(string name, IReadOnlyCollection<IAddressee> addresses)
    {
        Name = name;
        _addresses = addresses;
    }

    public void DeliverMessage(Message message)
    {
        foreach (IAddressee addressee in _addresses) addressee.SendMessage(message);
    }
}