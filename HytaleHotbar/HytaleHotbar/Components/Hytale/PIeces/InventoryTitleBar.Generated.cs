//Code for Hytale/PIeces/InventoryTitleBar (Container)
using Gum.Converters;
using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;
using GumRuntime;
using HytaleHotbar.Components.Controls;
using HytaleHotbar.Components.Hytale.PIeces;
using MonoGameGum;
using MonoGameGum.GueDeriving;
using RenderingLibrary.Graphics;
using System.Linq;
namespace HytaleHotbar.Components.Hytale.PIeces;
partial class InventoryTitleBar : global::Gum.Forms.Controls.FrameworkElement
{
    [System.Runtime.CompilerServices.ModuleInitializer]
    public static void RegisterRuntimeType()
    {
        var template = new global::Gum.Forms.VisualTemplate((vm, createForms) =>
        {
            var visual = new global::MonoGameGum.GueDeriving.ContainerRuntime();
            var element = ObjectFinder.Self.GetElementSave("Hytale/PIeces/InventoryTitleBar");
#if DEBUG
if(element == null) throw new System.InvalidOperationException("Could not find an element named Hytale/PIeces/InventoryTitleBar - did you forget to load a Gum project?");
#endif
            element.SetGraphicalUiElement(visual, RenderingLibrary.SystemManagers.Default);
            if(createForms) visual.FormsControlAsObject = new InventoryTitleBar(visual);
            return visual;
        });
        global::Gum.Forms.Controls.FrameworkElement.DefaultFormsTemplates[typeof(InventoryTitleBar)] = template;
        ElementSaveExtensions.RegisterGueInstantiation("Hytale/PIeces/InventoryTitleBar", () => 
        {
            var gue = template.CreateContent(null, true) as InteractiveGue;
            return gue;
        });
    }
    public InventoryTitleBarButton Title { get; protected set; }
    public InventoryTitleBarIconButton FilterWeapons { get; protected set; }
    public InventoryTitleBarIconButton FilterArmor { get; protected set; }
    public InventoryTitleBarIconButton FilterItems { get; protected set; }
    public InventoryTitleBarButton Autosort { get; protected set; }
    public InventoryTitleBarButton ChangeSort { get; protected set; }
    public NineSliceRuntime Background { get; protected set; }
    public StackPanel StackPanelInstance { get; protected set; }

    public InventoryTitleBar(InteractiveGue visual) : base(visual)
    {
    }
    public InventoryTitleBar()
    {



    }
    protected override void ReactToVisualChanged()
    {
        base.ReactToVisualChanged();
        Title = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<InventoryTitleBarButton>(this.Visual,"Title");
        FilterWeapons = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<InventoryTitleBarIconButton>(this.Visual,"FilterWeapons");
        FilterArmor = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<InventoryTitleBarIconButton>(this.Visual,"FilterArmor");
        FilterItems = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<InventoryTitleBarIconButton>(this.Visual,"FilterItems");
        Autosort = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<InventoryTitleBarButton>(this.Visual,"Autosort");
        ChangeSort = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<InventoryTitleBarButton>(this.Visual,"ChangeSort");
        Background = this.Visual?.GetGraphicalUiElementByName("Background") as global::MonoGameGum.GueDeriving.NineSliceRuntime;
        StackPanelInstance = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<StackPanel>(this.Visual,"StackPanelInstance");
        CustomInitialize();
    }
    //Not assigning variables because Object Instantiation Type is set to By Name rather than Fully In Code
    partial void CustomInitialize();
}
