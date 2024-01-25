using System.IO;
using System.Linq;
using Godot;
using Unity;

namespace TooManyUnits.Core;

public static class Game
{
    public static UnityContainer Container { get; } = new();

    static Game()
    {
        Enumerable.Range(0, 100).ToList().ForEach(i => Container.RegisterInstance(i.ToString(), i));
        ReadResources();
    }

    public const string ResourcePath = "res://Resource";

    private static void ReadResources()
    {
        var globalizePath = ProjectSettings.GlobalizePath(ResourcePath);
        var tilesPath = Path.Combine(globalizePath, "Tile");
        Directory.EnumerateFiles(tilesPath, "*.png", SearchOption.TopDirectoryOnly)
            .Select(s =>
            {
                GD.Print(s);
                return (Image.LoadFromFile(s), Path.GetFileNameWithoutExtension(s));
            })
            .Select(i => (ImageTexture.CreateFromImage(i.Item1),i.Item2))
            .ToList().ForEach(i => Container.RegisterInstance(i.Item2, i.Item1));
    }
}