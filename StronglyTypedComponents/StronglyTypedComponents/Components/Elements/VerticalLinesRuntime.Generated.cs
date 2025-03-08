//Code for Elements/VerticalLines (Container)
using Gum.Converters;
using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;

using RenderingLibrary.Graphics;

using System.Linq;

using MonoGameGum.GueDeriving;
namespace StronglyTypedComponents.Components
{
    public partial class VerticalLinesRuntime:ContainerRuntime
    {
        public SpriteRuntime LinesSprite { get; protected set; }

        public int LineAlpha
        {
            get => LinesSprite.Alpha;
            set => LinesSprite.Alpha = value;
        }

        public string LineColor
        {
            set => LinesSprite.SetProperty("ColorCategoryState", value?.ToString());
        }

        public VerticalLinesRuntime(bool fullInstantiation = true, bool tryCreateFormsObject = true)
        {
            if(fullInstantiation)
            {

                this.ClipsChildren = true;
                this.Height = 16f;
                 
                this.Width = 128f;

                InitializeInstances();

                ApplyDefaultVariables();
                AssignParents();
                CustomInitialize();
            }
        }
        protected virtual void InitializeInstances()
        {
            LinesSprite = new SpriteRuntime();
            LinesSprite.Name = "LinesSprite";
        }
        protected virtual void AssignParents()
        {
            this.Children.Add(LinesSprite);
        }
        private void ApplyDefaultVariables()
        {
            this.LinesSprite.SourceFileName = @"UISpriteSheet.png";
            this.LinesSprite.TextureAddress = global::Gum.Managers.TextureAddress.Custom;
            this.LinesSprite.TextureHeight = 32;
            this.LinesSprite.TextureLeft = 0;
            this.LinesSprite.TextureTop = 960;
            this.LinesSprite.TextureWidth = 1024;
            this.LinesSprite.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Left;
            this.LinesSprite.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Center;
            this.LinesSprite.YUnits = GeneralUnitType.PixelsFromMiddle;

        }
        partial void CustomInitialize();
    }
}
