using Itmo.ObjectOrientedProgramming.Lab4.Application.Context;
using Itmo.ObjectOrientedProgramming.Lab4.OutputWriter;
using Itmo.ObjectOrientedProgramming.Lab4.ParameterParser;
using Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.Factory;
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
        var fileSystemService = new FileSystemContext();
        IParameterParser parser = ParameterParserFactory.CreateParameterHandlerChain();

        var reader = new ConsoleReader(fileSystemService, parser, new ConsoleWriter());

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
