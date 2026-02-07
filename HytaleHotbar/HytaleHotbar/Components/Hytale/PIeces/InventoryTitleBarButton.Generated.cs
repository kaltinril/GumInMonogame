//Code for Hytale/PIeces/InventoryTitleBarButton (Container)
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
partial class InventoryTitleBarButton : global::Gum.Forms.Controls.FrameworkElement
{
    [System.Runtime.CompilerServices.ModuleInitializer]
    public static void RegisterRuntimeType()
    {
        var template = new global::Gum.Forms.VisualTemplate((vm, createForms) =>
        {
            var visual = new global::MonoGameGum.GueDeriving.ContainerRuntime();
            var element = ObjectFinder.Self.GetElementSave("Hytale/PIeces/InventoryTitleBarButton");
#if DEBUG
if(element == null) throw new System.InvalidOperationException("Could not find an element named Hytale/PIeces/InventoryTitleBarButton - did you forget to load a Gum project?");
#endif
            element.SetGraphicalUiElement(visual, RenderingLibrary.SystemManagers.Default);
            if(createForms) visual.FormsControlAsObject = new InventoryTitleBarButton(visual);
            return visual;
        });
        global::Gum.Forms.Controls.FrameworkElement.DefaultFormsTemplates[typeof(InventoryTitleBarButton)] = template;
        ElementSaveExtensions.RegisterGueInstantiation("Hytale/PIeces/InventoryTitleBarButton", () => 
        {
            var gue = template.CreateContent(null, true) as InteractiveGue;
            return gue;
        });
    }
    public NineSliceRuntime Background { get; protected set; }
    public TextRuntime TextInstance { get; protected set; }

    public int BackgroundStartX
    {
        get => Background.TextureLeft;
        set => Background.TextureLeft = value;
    }

    public int BackgroundStartY
    {
        get => Background.TextureTop;
        set => Background.TextureTop = value;
    }

    public string Text
    {
        get => TextInstance.Text;
        set => TextInstance.Text = value;
    }

    public InventoryTitleBarButton(InteractiveGue visual) : base(visual)
    {
    }
    public InventoryTitleBarButton()
    {



    }
    protected override void ReactToVisualChanged()
    {
        base.ReactToVisualChanged();
        Background = this.Visual?.GetGraphicalUiElementByName("Background") as global::MonoGameGum.GueDeriving.NineSliceRuntime;
        TextInstance = this.Visual?.GetGraphicalUiElementByName("TextInstance") as global::MonoGameGum.GueDeriving.TextRuntime;
        CustomInitialize();
    }
    //Not assigning variables because Object Instantiation Type is set to By Name rather than Fully In Code
    partial void CustomInitialize();
}
