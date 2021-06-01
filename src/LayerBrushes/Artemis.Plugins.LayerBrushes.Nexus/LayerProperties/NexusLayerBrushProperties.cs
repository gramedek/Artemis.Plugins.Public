using Artemis.Core;
using SkiaSharp;

namespace Artemis.Plugins.LayerBrushes.Nexus.LayerProperties
{
    public class NexusLayerBrushProperties : LayerPropertyGroup
    {
        // Color options
        public EnumLayerProperty<ColorType> ColorMode { get; set; }

        [PropertyDescription(Description = "The gradient tha defines the colors that are being used for draw the ripples")]
        public ColorGradientLayerProperty Colors { get; set; }

        [PropertyDescription(Description = "Color used to create ripples")]
        public SKColorLayerProperty Color { get; set; }

        [PropertyDescription(Description = "Width of the beam in pixels", InputAffix = "px", MinInputValue = 1)]
        public IntLayerProperty Width { get; set; }

        [PropertyDescription(Description = "Separation between beams in pixels", InputAffix = "px", MinInputValue = 0)]
        public IntLayerProperty Separation { get; set; }

        [PropertyDescription(Description = "Time in milliseconds between each beam fired", InputAffix = "ms")]

        public BoolLayerProperty FromLeftToRight { get; set; }
        [PropertyDescription(Description = "Determine if beams will be spawmed from left side of the layer")]

        public BoolLayerProperty FromTopToBottom { get; set; }
        [PropertyDescription(Description = "Determine if beams will be spawmed from top side of the layer")]

        public BoolLayerProperty FromRightToLeft { get; set; }
        [PropertyDescription(Description = "Determine if beams will be spawmed from right side of the layer")]

        public BoolLayerProperty FromBottomToUp { get; set; }
        [PropertyDescription(Description = "Determine if beams will be spawmed from bottom side of the layer")]

        public IntLayerProperty SpawnInterval { get; set; }
        [PropertyDescription(Description = "This option determine how fast a beams will advance")]
        public IntRangeLayerProperty Speed { get; set; }

        [PropertyDescription(Description = "This option determine how long the drop trail will be drawn")]
        public IntLayerProperty TrailSize { get; set; }

        [PropertyDescription(Description = "Enable this option will avoid beam overlaping")]
        public BoolLayerProperty AvoidOverlaping { get; set; }

        protected override void PopulateDefaults()
        {
            ColorMode.DefaultValue = ColorType.Random;
            Colors.DefaultValue = ColorGradient.GetUnicornBarf();
            Color.DefaultValue = new SKColor(0, 255, 0, 255);
            Width.DefaultValue = 30;
            Separation.DefaultValue = 0;
            SpawnInterval.DefaultValue = 500;
            Speed.DefaultValue = new IntRange(30, 40);
            TrailSize.DefaultValue = 300;
            AvoidOverlaping.DefaultValue = true;
            FromLeftToRight.DefaultValue = true;
            FromTopToBottom.DefaultValue = true;
            FromRightToLeft.DefaultValue = true;
            FromBottomToUp.DefaultValue = true;
        }

        protected override void EnableProperties()
        {
            Colors.IsVisibleWhen(ColorMode, c => c.CurrentValue == ColorType.Gradient || c.CurrentValue == ColorType.ColorSet);
            Color.IsVisibleWhen(ColorMode, c => c.CurrentValue == ColorType.Solid);
        }

        protected override void DisableProperties()
        {
        }
    }

    public enum ColorType
    {
        Random,
        Solid,
        Gradient,
        ColorSet
    }
}