using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.Recipients.SideIntegrations.DisplayIntegration;

public interface IDisplayDriver
{
    public void Write(Message message);
}