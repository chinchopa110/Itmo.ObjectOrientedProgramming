using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Proxy;

public class LevelFilterProxy : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly LevelCheckDelegate _levelCheck;

    public delegate bool LevelCheckDelegate(int level);

    public LevelFilterProxy(IAddressee addressee, LevelCheckDelegate levelCheck)
    {
        _addressee = addressee;
        _levelCheck = levelCheck ?? throw new ArgumentNullException(nameof(levelCheck));
    }

    public void DeliverMessage(Message message)
    {
        if (_levelCheck(message.ImportanceLevel))
        {
            _addressee.DeliverMessage(message);
        }
    }
}