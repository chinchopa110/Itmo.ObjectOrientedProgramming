using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.Recipients.UserRecipients;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType;

public class UserAddressee : IAddressee
{
    private readonly User _user;

    public UserAddressee(User user)
    {
        _user = user;
    }

    public void DeliverMessage(Message message)
    {
        _user.ReceiveMessage(message);
    }
}