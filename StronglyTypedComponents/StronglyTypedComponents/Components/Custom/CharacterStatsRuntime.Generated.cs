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
        public LabelRuntime LabelInstance { get; protected set; }
        public ContainerRuntime ContainerInstance { get; protected set; }
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
                var element = ObjectFinder.Self.GetElementSave("Custom/CharacterStats");
                element?.SetGraphicalUiElement(this, global::RenderingLibrary.SystemManagers.Default);
            }



        }
        public override void AfterFullCreation()
        {
            HealthPercentBar = this.GetGraphicalUiElementByName("HealthPercentBar") as PercentBarIconRuntime;
            LabelInstance = this.GetGraphicalUiElementByName("LabelInstance") as LabelRuntime;
            ContainerInstance = this.GetGraphicalUiElementByName("ContainerInstance") as ContainerRuntime;
            HealthPotionButton = this.GetGraphicalUiElementByName("HealthPotionButton") as ButtonStandardRuntime;
            TakeDamageButton = this.GetGraphicalUiElementByName("TakeDamageButton") as ButtonStandardRuntime;
            ManaPercentBar = this.GetGraphicalUiElementByName("ManaPercentBar") as PercentBarIconRuntime;
            AddManaButton = this.GetGraphicalUiElementByName("AddManaButton") as ButtonStandardRuntime;
            UseManaButton = this.GetGraphicalUiElementByName("UseManaButton") as ButtonStandardRuntime;
            ExpPercentBar = this.GetGraphicalUiElementByName("ExpPercentBar") as PercentBarIconRuntime;
            AddExpButton = this.GetGraphicalUiElementByName("AddExpButton") as ButtonStandardRuntime;
            HealthRowContainer = this.GetGraphicalUiElementByName("HealthRowContainer") as ContainerRuntime;
            ManaRowContainer = this.GetGraphicalUiElementByName("ManaRowContainer") as ContainerRuntime;
            ExpRowContainer = this.GetGraphicalUiElementByName("ExpRowContainer") as ContainerRuntime;
            CustomInitialize();
        }
        //Not assigning variables because Object Instantiation Type is set to By Name rather than Fully In Code
        partial void CustomInitialize();
    }
}
