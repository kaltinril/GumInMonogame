//Code for Hytale/PIeces/SlotNumber (Container)
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
partial class SlotNumber : global::Gum.Forms.Controls.FrameworkElement
{
    [System.Runtime.CompilerServices.ModuleInitializer]
    public static void RegisterRuntimeType()
    {
        var template = new global::Gum.Forms.VisualTemplate((vm, createForms) =>
        {
            var visual = new global::MonoGameGum.GueDeriving.ContainerRuntime();
            var element = ObjectFinder.Self.GetElementSave("Hytale/PIeces/SlotNumber");
#if DEBUG
if(element == null) throw new System.InvalidOperationException("Could not find an element named Hytale/PIeces/SlotNumber - did you forget to load a Gum project?");
#endif
            element.SetGraphicalUiElement(visual, RenderingLibrary.SystemManagers.Default);
            if(createForms) visual.FormsControlAsObject = new SlotNumber(visual);
            return visual;
        });
        global::Gum.Forms.Controls.FrameworkElement.DefaultFormsTemplates[typeof(SlotNumber)] = template;
        ElementSaveExtensions.RegisterGueInstantiation("Hytale/PIeces/SlotNumber", () => 
        {
            var gue = template.CreateContent(null, true) as InteractiveGue;
            return gue;
        });
    }
    public NineSliceRuntime Background { get; protected set; }
    public TextRuntime SlotNumberText { get; protected set; }

    public string Text
    {
        get => SlotNumberText.Text;
        set => SlotNumberText.Text = value;
    }

    public SlotNumber(InteractiveGue visual) : base(visual)
    {
    }
    public SlotNumber()
    {



    }
    protected override void ReactToVisualChanged()
    {
        base.ReactToVisualChanged();
        Background = this.Visual?.GetGraphicalUiElementByName("Background") as global::MonoGameGum.GueDeriving.NineSliceRuntime;
        SlotNumberText = this.Visual?.GetGraphicalUiElementByName("SlotNumberText") as global::MonoGameGum.GueDeriving.TextRuntime;
        CustomInitialize();
    }
    //Not assigning variables because Object Instantiation Type is set to By Name rather than Fully In Code
    partial void CustomInitialize();
}
