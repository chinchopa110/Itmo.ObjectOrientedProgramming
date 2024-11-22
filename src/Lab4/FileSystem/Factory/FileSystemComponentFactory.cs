using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Composite;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Factory;

public class FileSystemComponentFactory
{
    public IFileSystemComponent Create(string path, int depth = -1)
    {
        if (depth < 0)
        {
            return new DirectoryComponent(string.Empty, () => Array.Empty<IFileSystemComponent>());
        }

        if (Directory.Exists(path))
        {
            string? name = Path.GetFileName(path);

            IEnumerable<string> names = Directory
                .EnumerateFileSystemEntries(path)
                .Select(Path.GetFileName)
                .Where(x => x is not null)
                .Cast<string>();

            return new DirectoryComponent(name ?? string.Empty, () =>
            {
                return names
                    .Select(entry => Path.Combine(path, entry))
                    .Select(entryPath => Create(entryPath, depth - 1))
                    .Where(component => component.Name is not "")
                    .ToArray();
            });
        }

        if (File.Exists(path))
        {
            string name = Path.GetFileName(path);
            return new FileComponent(name);
        }

        throw new InvalidOperationException($"File system component at {path} is not found");
    }
}