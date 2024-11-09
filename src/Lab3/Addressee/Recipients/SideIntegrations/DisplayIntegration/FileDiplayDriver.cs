using Itmo.ObjectOrientedProgramming.Lab3.Addressee.Recipients.SideIntegrations.DisplayIntegration.Interfaces;
using System.Drawing;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.Recipients.SideIntegrations.DisplayIntegration;

public class FileDiplayDriver : IDisplayDriver
{
    private readonly string _filePath;

    public FileDiplayDriver(string filePath)
    {
        _filePath = filePath;
    }

    public Color MessageColor { get; private set; }

    public void SetColor(Color color)
    {
        MessageColor = color;
    }

    public void Write(string message)
    {
        var coloredMessageBuilder = new StringBuilder();
        coloredMessageBuilder.Append($"{MessageColor.R},{MessageColor.G},{MessageColor.B}|");
        coloredMessageBuilder.Append(message);
        string coloredMessage = coloredMessageBuilder.ToString();

        using var writer = new StreamWriter(_filePath, false);
        writer.WriteLine(coloredMessage);
    }
}