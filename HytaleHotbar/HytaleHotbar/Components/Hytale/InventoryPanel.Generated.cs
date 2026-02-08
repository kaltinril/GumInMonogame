//Code for Hytale/InventoryPanel (Container)
using Gum.Converters;
using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;
using GumRuntime;
using HytaleHotbar.Components.Controls;
using HytaleHotbar.Components.Hytale;
using HytaleHotbar.Components.Hytale.PIeces;
using MonoGameGum;
using MonoGameGum.GueDeriving;
using RenderingLibrary.Graphics;
using System.Linq;
namespace HytaleHotbar.Components.Hytale;
partial class InventoryPanel : global::Gum.Forms.Controls.FrameworkElement
{
    [System.Runtime.CompilerServices.ModuleInitializer]
    public static void RegisterRuntimeType()
    {
        var template = new global::Gum.Forms.VisualTemplate((vm, createForms) =>
        {
            var visual = new global::MonoGameGum.GueDeriving.ContainerRuntime();
            var element = ObjectFinder.Self.GetElementSave("Hytale/InventoryPanel");
#if DEBUG
if(element == null) throw new System.InvalidOperationException("Could not find an element named Hytale/InventoryPanel - did you forget to load a Gum project?");
#endif
            element.SetGraphicalUiElement(visual, RenderingLibrary.SystemManagers.Default);
            if(createForms) visual.FormsControlAsObject = new InventoryPanel(visual);
            return visual;
        });
        global::Gum.Forms.Controls.FrameworkElement.DefaultFormsTemplates[typeof(InventoryPanel)] = template;
        ElementSaveExtensions.RegisterGueInstantiation("Hytale/InventoryPanel", () => 
        {
            var gue = template.CreateContent(null, true) as InteractiveGue;
            return gue;
        });
    }
    public ItemSlot ItemSlotInstance1 { get; protected set; }
    public ItemSlot ItemSlotInstance2 { get; protected set; }
    public ItemSlot ItemSlotInstance3 { get; protected set; }
    public ItemSlot ItemSlotInstance4 { get; protected set; }
    public ItemSlot ItemSlotInstance5 { get; protected set; }
    public ItemSlot ItemSlotInstance6 { get; protected set; }
    public ItemSlot ItemSlotInstance7 { get; protected set; }
    public ItemSlot ItemSlotInstance8 { get; protected set; }
    public ItemSlot ItemSlotInstance9 { get; protected set; }
    public ItemSlot ItemSlotInstance10 { get; protected set; }
    public ItemSlot ItemSlotInstance11 { get; protected set; }
    public ItemSlot ItemSlotInstance12 { get; protected set; }
    public ItemSlot ItemSlotInstance13 { get; protected set; }
    public ItemSlot ItemSlotInstance14 { get; protected set; }
    public ItemSlot ItemSlotInstance15 { get; protected set; }
    public ItemSlot ItemSlotInstance16 { get; protected set; }
    public ItemSlot ItemSlotInstance17 { get; protected set; }
    public ItemSlot ItemSlotInstance18 { get; protected set; }
    public ItemSlot ItemSlotInstance19 { get; protected set; }
    public ItemSlot ItemSlotInstance20 { get; protected set; }
    public ItemSlot ItemSlotInstance21 { get; protected set; }
    public ItemSlot ItemSlotInstance22 { get; protected set; }
    public ItemSlot ItemSlotInstance23 { get; protected set; }
    public ItemSlot ItemSlotInstance24 { get; protected set; }
    public ItemSlot ItemSlotInstance25 { get; protected set; }
    public ItemSlot ItemSlotInstance26 { get; protected set; }
    public ItemSlot ItemSlotInstance27 { get; protected set; }
    public ItemSlot ItemSlotInstance28 { get; protected set; }
    public ItemSlot ItemSlotInstance29 { get; protected set; }
    public ItemSlot ItemSlotInstance30 { get; protected set; }
    public ItemSlot ItemSlotInstance31 { get; protected set; }
    public ItemSlot ItemSlotInstance32 { get; protected set; }
    public ItemSlot ItemSlotInstance33 { get; protected set; }
    public ItemSlot ItemSlotInstance34 { get; protected set; }
    public ItemSlot ItemSlotInstance35 { get; protected set; }
    public ItemSlot ItemSlotInstance36 { get; protected set; }
    public ItemSlot ItemSlotInstance37 { get; protected set; }
    public ItemSlot ItemSlotInstance38 { get; protected set; }
    public ItemSlot ItemSlotInstance39 { get; protected set; }
    public ItemSlot ItemSlotInstance40 { get; protected set; }
    public ItemSlot ItemSlotInstance41 { get; protected set; }
    public ItemSlot ItemSlotInstance42 { get; protected set; }
    public ItemSlot ItemSlotInstance43 { get; protected set; }
    public ItemSlot ItemSlotInstance44 { get; protected set; }
    public ItemSlot ItemSlotInstance45 { get; protected set; }
    public NineSliceRuntime Background { get; protected set; }
    public StackPanel ItemStackPanel { get; protected set; }
    public InventoryTitleBar InventoryTitleBarInstance { get; protected set; }
    public ContainerRuntime MainContainer { get; protected set; }

    public InventoryPanel(InteractiveGue visual) : base(visual)
    {
    }
    public InventoryPanel()
    {



    }
    protected override void ReactToVisualChanged()
    {
        base.ReactToVisualChanged();
        ItemSlotInstance1 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance1");
        ItemSlotInstance2 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance2");
        ItemSlotInstance3 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance3");
        ItemSlotInstance4 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance4");
        ItemSlotInstance5 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance5");
        ItemSlotInstance6 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance6");
        ItemSlotInstance7 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance7");
        ItemSlotInstance8 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance8");
        ItemSlotInstance9 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance9");
        ItemSlotInstance10 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance10");
        ItemSlotInstance11 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance11");
        ItemSlotInstance12 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance12");
        ItemSlotInstance13 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance13");
        ItemSlotInstance14 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance14");
        ItemSlotInstance15 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance15");
        ItemSlotInstance16 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance16");
        ItemSlotInstance17 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance17");
        ItemSlotInstance18 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance18");
        ItemSlotInstance19 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance19");
        ItemSlotInstance20 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance20");
        ItemSlotInstance21 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance21");
        ItemSlotInstance22 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance22");
        ItemSlotInstance23 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance23");
        ItemSlotInstance24 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance24");
        ItemSlotInstance25 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance25");
        ItemSlotInstance26 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance26");
        ItemSlotInstance27 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance27");
        ItemSlotInstance28 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance28");
        ItemSlotInstance29 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance29");
        ItemSlotInstance30 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance30");
        ItemSlotInstance31 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance31");
        ItemSlotInstance32 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance32");
        ItemSlotInstance33 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance33");
        ItemSlotInstance34 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance34");
        ItemSlotInstance35 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance35");
        ItemSlotInstance36 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance36");
        ItemSlotInstance37 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance37");
        ItemSlotInstance38 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance38");
        ItemSlotInstance39 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance39");
        ItemSlotInstance40 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance40");
        ItemSlotInstance41 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance41");
        ItemSlotInstance42 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance42");
        ItemSlotInstance43 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance43");
        ItemSlotInstance44 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance44");
        ItemSlotInstance45 = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemSlot>(this.Visual,"ItemSlotInstance45");
        Background = this.Visual?.GetGraphicalUiElementByName("Background") as global::MonoGameGum.GueDeriving.NineSliceRuntime;
        ItemStackPanel = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<StackPanel>(this.Visual,"ItemStackPanel");
        InventoryTitleBarInstance = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<InventoryTitleBar>(this.Visual,"InventoryTitleBarInstance");
        MainContainer = this.Visual?.GetGraphicalUiElementByName("MainContainer") as global::MonoGameGum.GueDeriving.ContainerRuntime;
        CustomInitialize();
    }
    //Not assigning variables because Object Instantiation Type is set to By Name rather than Fully In Code
    partial void CustomInitialize();
}
