using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Proxy;

public class LevelFilterProxy : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly int _level;

    public LevelFilterProxy(IAddressee addressee, int level)
    {
        _addressee = addressee;
        _level = level;
    }

    public void SendMessage(Message message)
    {
        if (message.ImportanceLevel >= _level) _addressee.SendMessage(message);
    }
}