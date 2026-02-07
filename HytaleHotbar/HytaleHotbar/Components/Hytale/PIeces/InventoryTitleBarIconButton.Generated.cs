//Code for Hytale/PIeces/InventoryTitleBarIconButton (Container)
using GumRuntime;
using System.Linq;
using MonoGameGum;
using MonoGameGum.GueDeriving;
using Gum.Converters;
using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;

using RenderingLibrary.Graphics;

using System.Linq;

namespace HytaleHotbar.Components.Hytale.PIeces;
partial class InventoryTitleBarIconButton : global::Gum.Forms.Controls.FrameworkElement
{
    [System.Runtime.CompilerServices.ModuleInitializer]
    public static void RegisterRuntimeType()
    {
        var template = new global::Gum.Forms.VisualTemplate((vm, createForms) =>
        {
            var visual = new global::MonoGameGum.GueDeriving.ContainerRuntime();
            var element = ObjectFinder.Self.GetElementSave("Hytale/PIeces/InventoryTitleBarIconButton");
#if DEBUG
if(element == null) throw new System.InvalidOperationException("Could not find an element named Hytale/PIeces/InventoryTitleBarIconButton - did you forget to load a Gum project?");
#endif
            element.SetGraphicalUiElement(visual, RenderingLibrary.SystemManagers.Default);
            if(createForms) visual.FormsControlAsObject = new InventoryTitleBarIconButton(visual);
            return visual;
        });
        global::Gum.Forms.Controls.FrameworkElement.DefaultFormsTemplates[typeof(InventoryTitleBarIconButton)] = template;
        ElementSaveExtensions.RegisterGueInstantiation("Hytale/PIeces/InventoryTitleBarIconButton", () => 
        {
            var gue = template.CreateContent(null, true) as InteractiveGue;
            return gue;
        });
    }
    public NineSliceRuntime Background { get; protected set; }
    public SpriteRuntime IconSprite { get; protected set; }

    public int StartX
    {
        get => IconSprite.TextureLeft;
        set => IconSprite.TextureLeft = value;
    }

    public int StartY
    {
        get => IconSprite.TextureTop;
        set => IconSprite.TextureTop = value;
    }

    public InventoryTitleBarIconButton(InteractiveGue visual) : base(visual)
    {
    }
    public InventoryTitleBarIconButton()
    {



    }
    protected override void ReactToVisualChanged()
    {
        base.ReactToVisualChanged();
        Background = this.Visual?.GetGraphicalUiElementByName("Background") as global::MonoGameGum.GueDeriving.NineSliceRuntime;
        IconSprite = this.Visual?.GetGraphicalUiElementByName("IconSprite") as global::MonoGameGum.GueDeriving.SpriteRuntime;
        CustomInitialize();
    }
    //Not assigning variables because Object Instantiation Type is set to By Name rather than Fully In Code
    partial void CustomInitialize();
}
