using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Interfaces;

public interface IAddressee
{
    public void DeliverMessage(Message message);
}