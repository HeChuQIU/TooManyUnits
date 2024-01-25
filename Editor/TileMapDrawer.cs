using System.Collections;
using System.Linq;
using Godot;

namespace TooManyUnits.Editor;

public partial class TileMapDrawer : Node2D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    public override void _Draw()
    {
        var xs = Enumerable.Range(0, 10);
        var ys = Enumerable.Range(0, 10);

        xs.Select(x => new Vector2(x * 64, 0))
            .ToList()
            .ForEach(v => DrawLine(v, v + new Vector2(0, 10 * 64), Colors.Red));

        ys.Select(y => new Vector2(0, y * 64))
            .ToList()
            .ForEach(v => DrawLine(v, v + new Vector2(10 * 64, 0), Colors.Red));
    }
}