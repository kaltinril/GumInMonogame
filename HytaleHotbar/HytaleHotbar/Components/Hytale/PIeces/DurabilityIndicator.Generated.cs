//Code for Hytale/PIeces/DurabilityIndicator (Container)
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
partial class DurabilityIndicator : global::Gum.Forms.Controls.FrameworkElement
{
    [System.Runtime.CompilerServices.ModuleInitializer]
    public static void RegisterRuntimeType()
    {
        var template = new global::Gum.Forms.VisualTemplate((vm, createForms) =>
        {
            var visual = new global::MonoGameGum.GueDeriving.ContainerRuntime();
            var element = ObjectFinder.Self.GetElementSave("Hytale/PIeces/DurabilityIndicator");
#if DEBUG
if(element == null) throw new System.InvalidOperationException("Could not find an element named Hytale/PIeces/DurabilityIndicator - did you forget to load a Gum project?");
#endif
            element.SetGraphicalUiElement(visual, RenderingLibrary.SystemManagers.Default);
            if(createForms) visual.FormsControlAsObject = new DurabilityIndicator(visual);
            return visual;
        });
        global::Gum.Forms.Controls.FrameworkElement.DefaultFormsTemplates[typeof(DurabilityIndicator)] = template;
        ElementSaveExtensions.RegisterGueInstantiation("Hytale/PIeces/DurabilityIndicator", () => 
        {
            var gue = template.CreateContent(null, true) as InteractiveGue;
            return gue;
        });
    }
    public ColoredRectangleRuntime BackgroundBar { get; protected set; }
    public ColoredRectangleRuntime ForegroundBar { get; protected set; }

    public float DurabilityRatio
    {
        get => ForegroundBar.Width;
        set => ForegroundBar.Width = value;
    }

    public DurabilityIndicator(InteractiveGue visual) : base(visual)
    {
    }
    public DurabilityIndicator()
    {



    }
    protected override void ReactToVisualChanged()
    {
        base.ReactToVisualChanged();
        BackgroundBar = this.Visual?.GetGraphicalUiElementByName("BackgroundBar") as global::MonoGameGum.GueDeriving.ColoredRectangleRuntime;
        ForegroundBar = this.Visual?.GetGraphicalUiElementByName("ForegroundBar") as global::MonoGameGum.GueDeriving.ColoredRectangleRuntime;
        CustomInitialize();
    }
    //Not assigning variables because Object Instantiation Type is set to By Name rather than Fully In Code
    partial void CustomInitialize();
}
