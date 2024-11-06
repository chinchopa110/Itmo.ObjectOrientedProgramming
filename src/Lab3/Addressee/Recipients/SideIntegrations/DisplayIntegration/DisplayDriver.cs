using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.Recipients.SideIntegrations.DisplayIntegration;

public class DisplayDriver
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
        string output = $"Messenger:\nHeader: {message.Header}\nText: {message.Text}\n";

        Console.Clear();
        Console.WriteLine(Crayon.Output.Rgb(MessageColor.R, MessageColor.G, MessageColor.B).Text(output));

        string colorCode = $"{MessageColor.R},{MessageColor.G},{MessageColor.B}";
        string coloredMessage = $"{colorCode}|{output}";

        using var writer = new StreamWriter(_filePath, false);
        writer.WriteLine(coloredMessage);
    }
}