//Code for V2 to V3
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

partial class V2_to_V3 : global::Gum.Forms.Controls.FrameworkElement
{
    [System.Runtime.CompilerServices.ModuleInitializer]
    public static void RegisterRuntimeType()
    {
        var template = new global::Gum.Forms.VisualTemplate((vm, createForms) =>
        {
            var visual = new global::MonoGameGum.GueDeriving.ContainerRuntime();
            var element = ObjectFinder.Self.GetElementSave("V2 to V3");
#if DEBUG
if(element == null) throw new System.InvalidOperationException("Could not find an element named V2 to V3 - did you forget to load a Gum project?");
#endif
            element.SetGraphicalUiElement(visual, RenderingLibrary.SystemManagers.Default);
            if(createForms) visual.FormsControlAsObject = new V2_to_V3(visual);
            visual.Width = 0;
            visual.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToParent;
            visual.Height = 0;
            visual.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToParent;
            return visual;
        });
        global::Gum.Forms.Controls.FrameworkElement.DefaultFormsTemplates[typeof(V2_to_V3)] = template;
        ElementSaveExtensions.RegisterGueInstantiation("V2 to V3", () => 
        {
            var gue = template.CreateContent(null, true) as InteractiveGue;
            return gue;
        });
    }
    public SpriteRuntime SpriteInstance2 { get; protected set; }
    public ContainerRuntime ContainerInstance1 { get; protected set; }
    public TextRuntime TextInstance { get; protected set; }
    public TextRuntime TextInstance1 { get; protected set; }
    public TextRuntime TextInstance2 { get; protected set; }
    public TextRuntime TextInstance3 { get; protected set; }
    public TextRuntime TextInstance4 { get; protected set; }
    public ContainerRuntime ContainerInstance2 { get; protected set; }
    public SpriteRuntime SpriteInstance { get; protected set; }
    public Icon IconInstance { get; protected set; }

    public V2_to_V3(InteractiveGue visual) : base(visual)
    {
        InitializeInstances();
        CustomInitialize();
    }
    public V2_to_V3() : base(new ContainerRuntime())
    {


        InitializeInstances();

        ApplyDefaultVariables();
        AssignParents();
        CustomInitialize();
    }
    protected virtual void InitializeInstances()
    {
        SpriteInstance2 = new global::MonoGameGum.GueDeriving.SpriteRuntime();
        SpriteInstance2.ElementSave = ObjectFinder.Self.GetStandardElement("Sprite");
        if (SpriteInstance2.ElementSave != null) SpriteInstance2.AddStatesAndCategoriesRecursivelyToGue(SpriteInstance2.ElementSave);
        if (SpriteInstance2.ElementSave != null) SpriteInstance2.SetInitialState();
        SpriteInstance2.Name = "SpriteInstance2";
        ContainerInstance1 = new global::MonoGameGum.GueDeriving.ContainerRuntime();
        ContainerInstance1.ElementSave = ObjectFinder.Self.GetStandardElement("Container");
        if (ContainerInstance1.ElementSave != null) ContainerInstance1.AddStatesAndCategoriesRecursivelyToGue(ContainerInstance1.ElementSave);
        if (ContainerInstance1.ElementSave != null) ContainerInstance1.SetInitialState();
        ContainerInstance1.Name = "ContainerInstance1";
        TextInstance = new global::MonoGameGum.GueDeriving.TextRuntime();
        TextInstance.ElementSave = ObjectFinder.Self.GetStandardElement("Text");
        if (TextInstance.ElementSave != null) TextInstance.AddStatesAndCategoriesRecursivelyToGue(TextInstance.ElementSave);
        if (TextInstance.ElementSave != null) TextInstance.SetInitialState();
        TextInstance.Name = "TextInstance";
        TextInstance1 = new global::MonoGameGum.GueDeriving.TextRuntime();
        TextInstance1.ElementSave = ObjectFinder.Self.GetStandardElement("Text");
        if (TextInstance1.ElementSave != null) TextInstance1.AddStatesAndCategoriesRecursivelyToGue(TextInstance1.ElementSave);
        if (TextInstance1.ElementSave != null) TextInstance1.SetInitialState();
        TextInstance1.Name = "TextInstance1";
        TextInstance2 = new global::MonoGameGum.GueDeriving.TextRuntime();
        TextInstance2.ElementSave = ObjectFinder.Self.GetStandardElement("Text");
        if (TextInstance2.ElementSave != null) TextInstance2.AddStatesAndCategoriesRecursivelyToGue(TextInstance2.ElementSave);
        if (TextInstance2.ElementSave != null) TextInstance2.SetInitialState();
        TextInstance2.Name = "TextInstance2";
        TextInstance3 = new global::MonoGameGum.GueDeriving.TextRuntime();
        TextInstance3.ElementSave = ObjectFinder.Self.GetStandardElement("Text");
        if (TextInstance3.ElementSave != null) TextInstance3.AddStatesAndCategoriesRecursivelyToGue(TextInstance3.ElementSave);
        if (TextInstance3.ElementSave != null) TextInstance3.SetInitialState();
        TextInstance3.Name = "TextInstance3";
        TextInstance4 = new global::MonoGameGum.GueDeriving.TextRuntime();
        TextInstance4.ElementSave = ObjectFinder.Self.GetStandardElement("Text");
        if (TextInstance4.ElementSave != null) TextInstance4.AddStatesAndCategoriesRecursivelyToGue(TextInstance4.ElementSave);
        if (TextInstance4.ElementSave != null) TextInstance4.SetInitialState();
        TextInstance4.Name = "TextInstance4";
        ContainerInstance2 = new global::MonoGameGum.GueDeriving.ContainerRuntime();
        ContainerInstance2.ElementSave = ObjectFinder.Self.GetStandardElement("Container");
        if (ContainerInstance2.ElementSave != null) ContainerInstance2.AddStatesAndCategoriesRecursivelyToGue(ContainerInstance2.ElementSave);
        if (ContainerInstance2.ElementSave != null) ContainerInstance2.SetInitialState();
        ContainerInstance2.Name = "ContainerInstance2";
        SpriteInstance = new global::MonoGameGum.GueDeriving.SpriteRuntime();
        SpriteInstance.ElementSave = ObjectFinder.Self.GetStandardElement("Sprite");
        if (SpriteInstance.ElementSave != null) SpriteInstance.AddStatesAndCategoriesRecursivelyToGue(SpriteInstance.ElementSave);
        if (SpriteInstance.ElementSave != null) SpriteInstance.SetInitialState();
        SpriteInstance.Name = "SpriteInstance";
        IconInstance = new Icon();
        IconInstance.Name = "IconInstance";
        base.RefreshInternalVisualReferences();
    }
    protected virtual void AssignParents()
    {
        ContainerInstance1.AddChild(SpriteInstance2);
        this.AddChild(ContainerInstance1);
        ContainerInstance2.AddChild(TextInstance);
        ContainerInstance2.AddChild(TextInstance1);
        ContainerInstance2.AddChild(TextInstance2);
        this.AddChild(TextInstance3);
        this.AddChild(TextInstance4);
        ContainerInstance1.AddChild(ContainerInstance2);
        this.AddChild(SpriteInstance);
        this.AddChild(IconInstance);
    }
    private void ApplyDefaultVariables()
    {
        this.Visual.Width = 0f;
        this.Visual.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToParent;
        this.Visual.Height = 0f;
        this.Visual.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToParent;
        this.SpriteInstance2.Height = -0f;
        this.SpriteInstance2.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToParent;
        this.SpriteInstance2.SourceFileName = @"gradient.png";
        this.SpriteInstance2.Width = -0f;
        this.SpriteInstance2.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToParent;
        this.SpriteInstance2.X = 0f;
        this.SpriteInstance2.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
        this.SpriteInstance2.XUnits = global::Gum.Converters.GeneralUnitType.PixelsFromMiddle;
        this.SpriteInstance2.Y = 0f;
        this.SpriteInstance2.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Center;
        this.SpriteInstance2.YUnits = global::Gum.Converters.GeneralUnitType.PixelsFromMiddle;

        this.ContainerInstance1.Height = 720f;
        this.ContainerInstance1.Width = 1280f;

        this.TextInstance.Font = @"Proxima Nova Rg";
        this.TextInstance.FontSize = 144;
        this.TextInstance.OutlineThickness = 1;
        this.TextInstance.Text = @"MONO";

        this.TextInstance1.Blue = 0;
        this.TextInstance1.Font = @"Proxima Nova Rg";
        this.TextInstance1.FontSize = 144;
        this.TextInstance1.Green = 60;
        this.TextInstance1.IsBold = true;
        this.TextInstance1.OutlineThickness = 1;
        this.TextInstance1.Red = 231;
        this.TextInstance1.Text = @"GAME";

        this.TextInstance2.Font = @"Proxima Nova Rg";
        this.TextInstance2.FontSize = 144;
        this.TextInstance2.OutlineThickness = 1;
        this.TextInstance2.Text = @" UI";

        this.TextInstance3.SetProperty("ColorCategoryState", "Warning");
        this.TextInstance3.Font = @"Proxima Nova Rg";
        this.TextInstance3.FontSize = 250;
        this.TextInstance3.Height = -119f;
        ((TextRuntime)this.TextInstance3).HorizontalAlignment = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
        this.TextInstance3.IsBold = true;
        this.TextInstance3.OutlineThickness = 3;
        this.TextInstance3.Rotation = 0f;
        this.TextInstance3.Text = @"V3";
        this.TextInstance3.UseFontSmoothing = true;
        ((TextRuntime)this.TextInstance3).VerticalAlignment = global::RenderingLibrary.Graphics.VerticalAlignment.Center;
        this.TextInstance3.Width = 69f;
        this.TextInstance3.X = 535f;
        this.TextInstance3.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
        this.TextInstance3.XUnits = global::Gum.Converters.GeneralUnitType.PixelsFromMiddle;
        this.TextInstance3.Y = 95f;
        this.TextInstance3.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Center;
        this.TextInstance3.YUnits = global::Gum.Converters.GeneralUnitType.PixelsFromMiddle;

        this.TextInstance4.SetProperty("ColorCategoryState", "Warning");
        this.TextInstance4.Font = @"Proxima Nova Rg";
        this.TextInstance4.FontSize = 250;
        this.TextInstance4.Height = -119f;
        ((TextRuntime)this.TextInstance4).HorizontalAlignment = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
        this.TextInstance4.IsBold = true;
        this.TextInstance4.OutlineThickness = 3;
        this.TextInstance4.Rotation = 0f;
        this.TextInstance4.Text = @"V2";
        this.TextInstance4.UseFontSmoothing = true;
        ((TextRuntime)this.TextInstance4).VerticalAlignment = global::RenderingLibrary.Graphics.VerticalAlignment.Center;
        this.TextInstance4.Width = 69f;
        this.TextInstance4.X = -82f;
        this.TextInstance4.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
        this.TextInstance4.XUnits = global::Gum.Converters.GeneralUnitType.PixelsFromMiddle;
        this.TextInstance4.Y = 100f;
        this.TextInstance4.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Center;
        this.TextInstance4.YUnits = global::Gum.Converters.GeneralUnitType.PixelsFromMiddle;

        this.ContainerInstance2.ChildrenLayout = global::Gum.Managers.ChildrenLayout.LeftToRightStack;
        this.ContainerInstance2.Height = 0f;
        this.ContainerInstance2.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;
        this.ContainerInstance2.Width = 0f;
        this.ContainerInstance2.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;
        this.ContainerInstance2.X = 0f;
        this.ContainerInstance2.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
        this.ContainerInstance2.XUnits = global::Gum.Converters.GeneralUnitType.PixelsFromMiddle;
        this.ContainerInstance2.Y = 50f;
        this.ContainerInstance2.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Top;
        this.ContainerInstance2.YUnits = global::Gum.Converters.GeneralUnitType.PixelsFromSmall;

        this.SpriteInstance.Height = 73.93944f;
        this.SpriteInstance.SourceFileName = @"gumlogo.png";
        this.SpriteInstance.Width = 71.74478f;
        this.SpriteInstance.X = 462f;
        this.SpriteInstance.Y = 104.33345f;
        this.SpriteInstance.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Center;
        this.SpriteInstance.YUnits = global::Gum.Converters.GeneralUnitType.Percentage;

        this.IconInstance.IconCategoryState = Icon.IconCategory.Arrow1;
        this.IconInstance.Visual.SetProperty("IconColor", "Warning");
        this.IconInstance.Visual.Height = 366f;
        this.IconInstance.Visual.Width = 996f;
        this.IconInstance.Visual.X = 142f;
        this.IconInstance.Visual.Y = 211f;

    }
    partial void CustomInitialize();
}
