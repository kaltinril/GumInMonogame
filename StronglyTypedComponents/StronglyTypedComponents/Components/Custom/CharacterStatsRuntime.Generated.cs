//Code for Custom/CharacterStats (Container)
using GumRuntime;
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
        [System.Runtime.CompilerServices.ModuleInitializer]
        public static void RegisterRuntimeType()
        {
            GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Custom/CharacterStats", typeof(CharacterStatsRuntime));
        }
        public PercentBarIconRuntime HealthPercentBar { get; protected set; }
        public LabelRuntime HealthBarLabel { get; protected set; }
        public ContainerRuntime HealthBarContainer { get; protected set; }
        public ContainerRuntime ManaBarContainer { get; protected set; }
        public ContainerRuntime ExpBarContainer { get; protected set; }
        public PercentBarIconRuntime ExpPercentBar { get; protected set; }
        public ButtonStandardRuntime HealthPotionButton { get; protected set; }
        public ButtonStandardRuntime TakeDamageButton { get; protected set; }
        public PercentBarIconRuntime ManaPercentBar { get; protected set; }
        public LabelRuntime ManaBarLabel { get; protected set; }
        public LabelRuntime ExpBarLabel { get; protected set; }
        public ButtonStandardRuntime AddManaButton { get; protected set; }
        public ButtonStandardRuntime UseManaButton { get; protected set; }
        public ButtonStandardRuntime AddExpButton { get; protected set; }
        public ContainerRuntime HealthRowContainer { get; protected set; }
        public ContainerRuntime ManaRowContainer { get; protected set; }
        public ContainerRuntime ExpRowContainer { get; protected set; }
        public ContainerRuntime LevelContainer { get; protected set; }
        public LabelRuntime LevelLabel { get; protected set; }
        public LabelRuntime LevelAmountLabel { get; protected set; }
        public ColoredRectangleRuntime ColoredRectangleInstance { get; protected set; }
        public ContainerRuntime ContainerInstance { get; protected set; }

        public CharacterStatsRuntime(bool fullInstantiation = true, bool tryCreateFormsObject = true)
        {
            if(fullInstantiation)
            {
                var element = ObjectFinder.Self.GetElementSave("Custom/CharacterStats");
                element?.SetGraphicalUiElement(this, global::RenderingLibrary.SystemManagers.Default);
            }



        }
        public override void AfterFullCreation()
        {
            HealthPercentBar = this.GetGraphicalUiElementByName("HealthPercentBar") as PercentBarIconRuntime;
            HealthBarLabel = this.GetGraphicalUiElementByName("HealthBarLabel") as LabelRuntime;
            HealthBarContainer = this.GetGraphicalUiElementByName("HealthBarContainer") as ContainerRuntime;
            ManaBarContainer = this.GetGraphicalUiElementByName("ManaBarContainer") as ContainerRuntime;
            ExpBarContainer = this.GetGraphicalUiElementByName("ExpBarContainer") as ContainerRuntime;
            ExpPercentBar = this.GetGraphicalUiElementByName("ExpPercentBar") as PercentBarIconRuntime;
            HealthPotionButton = this.GetGraphicalUiElementByName("HealthPotionButton") as ButtonStandardRuntime;
            TakeDamageButton = this.GetGraphicalUiElementByName("TakeDamageButton") as ButtonStandardRuntime;
            ManaPercentBar = this.GetGraphicalUiElementByName("ManaPercentBar") as PercentBarIconRuntime;
            ManaBarLabel = this.GetGraphicalUiElementByName("ManaBarLabel") as LabelRuntime;
            ExpBarLabel = this.GetGraphicalUiElementByName("ExpBarLabel") as LabelRuntime;
            AddManaButton = this.GetGraphicalUiElementByName("AddManaButton") as ButtonStandardRuntime;
            UseManaButton = this.GetGraphicalUiElementByName("UseManaButton") as ButtonStandardRuntime;
            AddExpButton = this.GetGraphicalUiElementByName("AddExpButton") as ButtonStandardRuntime;
            HealthRowContainer = this.GetGraphicalUiElementByName("HealthRowContainer") as ContainerRuntime;
            ManaRowContainer = this.GetGraphicalUiElementByName("ManaRowContainer") as ContainerRuntime;
            ExpRowContainer = this.GetGraphicalUiElementByName("ExpRowContainer") as ContainerRuntime;
            LevelContainer = this.GetGraphicalUiElementByName("LevelContainer") as ContainerRuntime;
            LevelLabel = this.GetGraphicalUiElementByName("LevelLabel") as LabelRuntime;
            LevelAmountLabel = this.GetGraphicalUiElementByName("LevelAmountLabel") as LabelRuntime;
            ColoredRectangleInstance = this.GetGraphicalUiElementByName("ColoredRectangleInstance") as ColoredRectangleRuntime;
            ContainerInstance = this.GetGraphicalUiElementByName("ContainerInstance") as ContainerRuntime;
            CustomInitialize();
        }
        //Not assigning variables because Object Instantiation Type is set to By Name rather than Fully In Code
        partial void CustomInitialize();
    }
}
