namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class Message : IEquatable<Message>
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

    public bool Equals(Message? other)
    {
        if (other is null) return false;
        return Header == other.Header && Text == other.Text && ImportanceLevel == other.ImportanceLevel;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Message);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Header, Text, ImportanceLevel);
    }
}