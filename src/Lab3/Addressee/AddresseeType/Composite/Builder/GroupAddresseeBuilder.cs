using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Composite.Builder;

public class GroupAddresseeBuilder
{
    private readonly List<IAddressee> _addresses;

    public GroupAddresseeBuilder()
    {
        _addresses = new List<IAddressee>();
    }

    public GroupAddresseeBuilder AddAddressee(IAddressee addressee)
    {
        _addresses.Add(addressee);
        return this;
    }

    public GroupAddressee Build()
    {
        return new GroupAddressee(_addresses.AsReadOnly());
    }
}