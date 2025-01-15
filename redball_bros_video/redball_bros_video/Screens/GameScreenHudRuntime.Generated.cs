//Code for GameScreenHud
using Gum.Converters;
using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;

using RenderingLibrary.Graphics;

using System.Linq;

using MonoGameGum.GueDeriving;
public partial class GameScreenHudRuntime:Gum.Wireframe.BindableGue
{
    [System.Runtime.CompilerServices.ModuleInitializer]
    public static void RegisterRuntimeType()
    {
        GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("GameScreenHud", typeof(GameScreenHudRuntime));
    }
    public ContainerRuntime BackgroundContainer { get; protected set; }
    public ContainerRuntime GameScreenHudContainer { get; protected set; }
    public ContainerRuntime PointsContainer { get; protected set; }
    public TextRuntime FRBPointsLabel { get; protected set; }
    public TextRuntime FRBPoints { get; protected set; }
    public ContainerRuntime CoinsContainer { get; protected set; }
    public ContainerRuntime WorldContainer { get; protected set; }
    public ContainerRuntime TimeContainer { get; protected set; }
    public SpriteRuntime CoinSprite { get; protected set; }
    public TextRuntime XText { get; protected set; }
    public TextRuntime CoinsNumber { get; protected set; }
    public TextRuntime WorldLabel { get; protected set; }
    public TextRuntime TimeLabel { get; protected set; }
    public TextRuntime WorldNumber { get; protected set; }
    public TextRuntime TimeNumber { get; protected set; }
    public SpriteRuntime BackgroundSprite { get; protected set; }

    public GameScreenHudRuntime(bool fullInstantiation = true, bool tryCreateFormsObject = true)
    {


    }
    public override void AfterFullCreation()
    {
        BackgroundContainer = this.GetGraphicalUiElementByName("BackgroundContainer") as ContainerRuntime;
        GameScreenHudContainer = this.GetGraphicalUiElementByName("GameScreenHudContainer") as ContainerRuntime;
        PointsContainer = this.GetGraphicalUiElementByName("PointsContainer") as ContainerRuntime;
        FRBPointsLabel = this.GetGraphicalUiElementByName("FRBPointsLabel") as TextRuntime;
        FRBPoints = this.GetGraphicalUiElementByName("FRBPoints") as TextRuntime;
        CoinsContainer = this.GetGraphicalUiElementByName("CoinsContainer") as ContainerRuntime;
        WorldContainer = this.GetGraphicalUiElementByName("WorldContainer") as ContainerRuntime;
        TimeContainer = this.GetGraphicalUiElementByName("TimeContainer") as ContainerRuntime;
        CoinSprite = this.GetGraphicalUiElementByName("CoinSprite") as SpriteRuntime;
        XText = this.GetGraphicalUiElementByName("XText") as TextRuntime;
        CoinsNumber = this.GetGraphicalUiElementByName("CoinsNumber") as TextRuntime;
        WorldLabel = this.GetGraphicalUiElementByName("WorldLabel") as TextRuntime;
        TimeLabel = this.GetGraphicalUiElementByName("TimeLabel") as TextRuntime;
        WorldNumber = this.GetGraphicalUiElementByName("WorldNumber") as TextRuntime;
        TimeNumber = this.GetGraphicalUiElementByName("TimeNumber") as TextRuntime;
        BackgroundSprite = this.GetGraphicalUiElementByName("BackgroundSprite") as SpriteRuntime;
        CustomInitialize();
    }
    //Not assigning variables because Object Instantiation Type is set to By Name rather than Fully In Code
    partial void CustomInitialize();
}
