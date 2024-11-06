namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class Message
{
    public string Header { get; }

    public string Text { get; }

    public int ImportanceLevel { get; }

    public Message(string header, string text, int importanceLevel)
    {
        Header = header;
        Text = text;
        ImportanceLevel = importanceLevel;
    }
}