using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using System.Drawing;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.Recipients.SideIntegrations.DisplayIntegration;

public class DisplayDriver : IDisplayDriver
{
    private readonly string _filePath;

    public Color MessageColor { get; private set; }

    public DisplayDriver(string filePath)
    {
        MessageColor = Color.Red;
        _filePath = filePath;
    }

    public void SetColor(Color color)
    {
        MessageColor = color;
    }

    public void Write(Message message)
    {
        string output = $"Header: {message.Header}\n" +
                        $"Text: {message.Text}\n";

        Console.Clear();
        Console.WriteLine(Crayon.Output.Rgb(MessageColor.R, MessageColor.G, MessageColor.B).Text(output));

        var coloredMessageBuilder = new StringBuilder();
        coloredMessageBuilder.Append($"{MessageColor.R},{MessageColor.G},{MessageColor.B}|");
        coloredMessageBuilder.Append(output);
        string coloredMessage = coloredMessageBuilder.ToString();

        using var writer = new StreamWriter(_filePath, false);
        writer.WriteLine(coloredMessage);
    }
}