//Code for StageIntro
using Gum.Converters;
using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;

using RenderingLibrary.Graphics;

using System.Linq;

using MonoGameGum.GueDeriving;
public partial class StageIntroRuntime:Gum.Wireframe.BindableGue
{
    [System.Runtime.CompilerServices.ModuleInitializer]
    public static void RegisterRuntimeType()
    {
        GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("StageIntro", typeof(StageIntroRuntime));
    }
    public ContainerRuntime WorldContainer { get; protected set; }
    public TextRuntime WorldLabel { get; protected set; }
    public TextRuntime WorldNumber { get; protected set; }
    public ContainerRuntime LivesContainer { get; protected set; }
    public SpriteRuntime FRBManSprite { get; protected set; }
    public TextRuntime XText { get; protected set; }
    public TextRuntime LivesText { get; protected set; }
    public ContainerRuntime StageIntroContainer { get; protected set; }

    public StageIntroRuntime(bool fullInstantiation = true, bool tryCreateFormsObject = true)
    {


    }
    public override void AfterFullCreation()
    {
        WorldContainer = this.GetGraphicalUiElementByName("WorldContainer") as ContainerRuntime;
        WorldLabel = this.GetGraphicalUiElementByName("WorldLabel") as TextRuntime;
        WorldNumber = this.GetGraphicalUiElementByName("WorldNumber") as TextRuntime;
        LivesContainer = this.GetGraphicalUiElementByName("LivesContainer") as ContainerRuntime;
        FRBManSprite = this.GetGraphicalUiElementByName("FRBManSprite") as SpriteRuntime;
        XText = this.GetGraphicalUiElementByName("XText") as TextRuntime;
        LivesText = this.GetGraphicalUiElementByName("LivesText") as TextRuntime;
        StageIntroContainer = this.GetGraphicalUiElementByName("StageIntroContainer") as ContainerRuntime;
        CustomInitialize();
    }
    //Not assigning variables because Object Instantiation Type is set to By Name rather than Fully In Code
    partial void CustomInitialize();
}
