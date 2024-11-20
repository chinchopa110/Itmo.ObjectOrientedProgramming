using Itmo.ObjectOrientedProgramming.Lab4.Application;
using Itmo.ObjectOrientedProgramming.Lab4.OutputWriter;
using Itmo.ObjectOrientedProgramming.Lab4.ParameterHandler;
using Itmo.ObjectOrientedProgramming.Lab4.ReaderService;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Program
{
    public static IEnumerable<string> ParseCommandLine(string commandLine)
    {
        return commandLine.Split([' '], StringSplitOptions.RemoveEmptyEntries);
    }

    public static void Main(string[] args)
    {
        var fileSystemService = new FileSystemService(new ConsoleWriter());

        IParameterHandler handler = new TreeConnectParameterHandler()
            .AddNext(new TreeMovementParameterHandler())
            .AddNext(new FileInteractionParameterHandler());

        var reader = new ConsoleReader(fileSystemService, handler);

        while (true)
        {
            string? command = Console.ReadLine();

            if (command == "exit")
            {
                break;
            }

            if (command != null)
            {
                IEnumerable<string> parsedCommand = ParseCommandLine(command);
                reader.Read(parsedCommand);
            }
        }
    }
}
