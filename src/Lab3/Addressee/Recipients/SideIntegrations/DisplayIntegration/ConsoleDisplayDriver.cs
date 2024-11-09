using Itmo.ObjectOrientedProgramming.Lab3.Addressee.Recipients.SideIntegrations.DisplayIntegration.Interfaces;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.Recipients.SideIntegrations.DisplayIntegration;

public class ConsoleDisplayDriver : IDisplayDriver
{
    public Color MessageColor { get; private set; }

    public ConsoleDisplayDriver()
    {
        MessageColor = Color.Red;
    }

    public void SetColor(Color color)
    {
        MessageColor = color;
    }

    public void Write(string message)
    {
        Console.Clear();
        Console.WriteLine(Crayon.Output.Rgb(MessageColor.R, MessageColor.G, MessageColor.B).Text(message));
    }
}