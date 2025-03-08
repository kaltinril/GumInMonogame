//Code for Custom/CharacterStats (Container)
using StronglyTypedComponents.Components;
using Gum.Converters;
using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;

using RenderingLibrary.Graphics;

using System.Linq;

using MonoGameGum.GueDeriving;
namespace StronglyTypedComponents.Components
{
    public partial class CharacterStatsRuntime:ContainerRuntime
    {
        public PercentBarIconRuntime HealthPercentBar { get; protected set; }
        public ButtonStandardRuntime HealthPotionButton { get; protected set; }
        public ButtonStandardRuntime TakeDamageButton { get; protected set; }
        public PercentBarIconRuntime ManaPercentBar { get; protected set; }
        public ButtonStandardRuntime AddManaButton { get; protected set; }
        public ButtonStandardRuntime UseManaButton { get; protected set; }
        public PercentBarIconRuntime ExpPercentBar { get; protected set; }
        public ButtonStandardRuntime AddExpButton { get; protected set; }
        public ContainerRuntime HealthRowContainer { get; protected set; }
        public ContainerRuntime ManaRowContainer { get; protected set; }
        public ContainerRuntime ExpRowContainer { get; protected set; }

        public CharacterStatsRuntime(bool fullInstantiation = true, bool tryCreateFormsObject = true)
        {
            if(fullInstantiation)
            {

                this.ChildrenLayout = global::Gum.Managers.ChildrenLayout.TopToBottomStack;
                this.Height = 0f;
                this.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                this.Width = 0f;
                this.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;

                InitializeInstances();

                ApplyDefaultVariables();
                AssignParents();
                CustomInitialize();
            }
        }
        protected virtual void InitializeInstances()
        {
            HealthPercentBar = new PercentBarIconRuntime();
            HealthPercentBar.Name = "HealthPercentBar";
            HealthPotionButton = new ButtonStandardRuntime();
            HealthPotionButton.Name = "HealthPotionButton";
            TakeDamageButton = new ButtonStandardRuntime();
            TakeDamageButton.Name = "TakeDamageButton";
            ManaPercentBar = new PercentBarIconRuntime();
            ManaPercentBar.Name = "ManaPercentBar";
            AddManaButton = new ButtonStandardRuntime();
            AddManaButton.Name = "AddManaButton";
            UseManaButton = new ButtonStandardRuntime();
            UseManaButton.Name = "UseManaButton";
            ExpPercentBar = new PercentBarIconRuntime();
            ExpPercentBar.Name = "ExpPercentBar";
            AddExpButton = new ButtonStandardRuntime();
            AddExpButton.Name = "AddExpButton";
            HealthRowContainer = new ContainerRuntime();
            HealthRowContainer.Name = "HealthRowContainer";
            ManaRowContainer = new ContainerRuntime();
            ManaRowContainer.Name = "ManaRowContainer";
            ExpRowContainer = new ContainerRuntime();
            ExpRowContainer.Name = "ExpRowContainer";
        }
        protected virtual void AssignParents()
        {
            HealthRowContainer.Children.Add(HealthPercentBar);
            HealthRowContainer.Children.Add(HealthPotionButton);
            HealthRowContainer.Children.Add(TakeDamageButton);
            ManaRowContainer.Children.Add(ManaPercentBar);
            ManaRowContainer.Children.Add(AddManaButton);
            ManaRowContainer.Children.Add(UseManaButton);
            ExpRowContainer.Children.Add(ExpPercentBar);
            ExpRowContainer.Children.Add(AddExpButton);
            this.Children.Add(HealthRowContainer);
            this.Children.Add(ManaRowContainer);
            this.Children.Add(ExpRowContainer);
        }
        private void ApplyDefaultVariables()
        {
            this.HealthPercentBar.X = 0f;
            this.HealthPercentBar.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Left;
            this.HealthPercentBar.XUnits = GeneralUnitType.PixelsFromSmall;
            this.HealthPercentBar.Y = 0f;
            this.HealthPercentBar.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Center;
            this.HealthPercentBar.YUnits = GeneralUnitType.PixelsFromMiddle;

            this.HealthPotionButton.ButtonDisplayText = @"Health Potion";
            this.HealthPotionButton.Height = 16f;
            this.HealthPotionButton.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;

            this.TakeDamageButton.ButtonDisplayText = @"-10 Health";
            this.TakeDamageButton.Height = 16f;
            this.TakeDamageButton.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;
            this.TakeDamageButton.Width = 96f;

ManaPercentBar.SetProperty("BarColor", "Primary");
this.ManaPercentBar.BarIcon = IconRuntime.IconCategory.Flame2;
ManaPercentBar.SetProperty("BarIconColor", "Primary");
            this.ManaPercentBar.X = 0f;
            this.ManaPercentBar.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Left;
            this.ManaPercentBar.XUnits = GeneralUnitType.PixelsFromSmall;
            this.ManaPercentBar.Y = 0f;
            this.ManaPercentBar.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Center;
            this.ManaPercentBar.YUnits = GeneralUnitType.PixelsFromMiddle;

            this.AddManaButton.ButtonDisplayText = @"Mana Potion";
            this.AddManaButton.Height = 16f;
            this.AddManaButton.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;

            this.UseManaButton.ButtonDisplayText = @"-10 Mana";
            this.UseManaButton.Height = 16f;
            this.UseManaButton.Width = 96f;
            this.UseManaButton.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;

ExpPercentBar.SetProperty("BarColor", "Accent");
this.ExpPercentBar.BarIcon = IconRuntime.IconCategory.Trophy;
ExpPercentBar.SetProperty("BarIconColor", "Accent");
            this.ExpPercentBar.X = 0f;
            this.ExpPercentBar.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Left;
            this.ExpPercentBar.XUnits = GeneralUnitType.PixelsFromSmall;
            this.ExpPercentBar.Y = 0f;
            this.ExpPercentBar.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Center;
            this.ExpPercentBar.YUnits = GeneralUnitType.PixelsFromMiddle;

            this.AddExpButton.ButtonDisplayText = @"Add Exp";
            this.AddExpButton.Height = 16f;

            this.HealthRowContainer.ChildrenLayout = global::Gum.Managers.ChildrenLayout.LeftToRightStack;
            this.HealthRowContainer.Height = 0f;
            this.HealthRowContainer.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;
            this.HealthRowContainer.Width = 0f;
            this.HealthRowContainer.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;

            this.ManaRowContainer.ChildrenLayout = global::Gum.Managers.ChildrenLayout.LeftToRightStack;
            this.ManaRowContainer.Height = 0f;
            this.ManaRowContainer.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;
            this.ManaRowContainer.Width = 0f;
            this.ManaRowContainer.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;

            this.ExpRowContainer.AutoGridHorizontalCells = 2;
            this.ExpRowContainer.AutoGridVerticalCells = 1;
            this.ExpRowContainer.ChildrenLayout = global::Gum.Managers.ChildrenLayout.LeftToRightStack;
            this.ExpRowContainer.Height = 0f;
            this.ExpRowContainer.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;
            this.ExpRowContainer.Width = 0f;
            this.ExpRowContainer.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;

        }
        partial void CustomInitialize();
    }
}
