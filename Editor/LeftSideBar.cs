using System.Linq;
using Godot;
using TooManyUnits.Core;
using Unity;

namespace TooManyUnits.Editor;

public partial class LeftSideBar : VBoxContainer
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Game.Container.Registrations
            .Where(registration => registration.RegisteredType == typeof(ImageTexture))
            .ToList().ForEach(registration =>
            {
                var text = registration.Name;
                var flowContainer = new HFlowContainer();
                flowContainer.SizeFlagsHorizontal = SizeFlags.ShrinkCenter;

                var textureRect = new TextureRect();
                textureRect.Texture = Game.Container.Resolve<ImageTexture>(text);
                textureRect.ExpandMode = TextureRect.ExpandModeEnum.FitHeightProportional;
                textureRect.CustomMinimumSize = new Vector2(64, 0);
                textureRect.SizeFlagsHorizontal = SizeFlags.ExpandFill;
                flowContainer.AddChild(textureRect);

                var lineEdit = new LineEdit();
                lineEdit.Text = text;
                lineEdit.SizeFlagsHorizontal = SizeFlags.ExpandFill;
                lineEdit.Editable = false;
                lineEdit.CustomMinimumSize = new Vector2(64, 0);
                flowContainer.AddChild(lineEdit);

                AddChild(flowContainer);
            });
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}