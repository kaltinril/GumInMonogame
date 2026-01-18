//Code for V2 is Dead
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

partial class V2_is_Dead : global::Gum.Forms.Controls.FrameworkElement
{
    [System.Runtime.CompilerServices.ModuleInitializer]
    public static void RegisterRuntimeType()
    {
        var template = new global::Gum.Forms.VisualTemplate((vm, createForms) =>
        {
            var visual = new global::MonoGameGum.GueDeriving.ContainerRuntime();
            var element = ObjectFinder.Self.GetElementSave("V2 is Dead");
#if DEBUG
if(element == null) throw new System.InvalidOperationException("Could not find an element named V2 is Dead - did you forget to load a Gum project?");
#endif
            element.SetGraphicalUiElement(visual, RenderingLibrary.SystemManagers.Default);
            if(createForms) visual.FormsControlAsObject = new V2_is_Dead(visual);
            visual.Width = 0;
            visual.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToParent;
            visual.Height = 0;
            visual.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToParent;
            return visual;
        });
        global::Gum.Forms.Controls.FrameworkElement.DefaultFormsTemplates[typeof(V2_is_Dead)] = template;
        ElementSaveExtensions.RegisterGueInstantiation("V2 is Dead", () => 
        {
            var gue = template.CreateContent(null, true) as InteractiveGue;
            return gue;
        });
    }
    public SpriteRuntime SpriteInstance2 { get; protected set; }
    public ContainerRuntime ContainerInstance1 { get; protected set; }
    public TextRuntime TextInstance3 { get; protected set; }
    public ContainerRuntime ContainerInstance2 { get; protected set; }
    public SpriteRuntime SpriteInstance { get; protected set; }
    public TextRuntime TextInstance { get; protected set; }
    public TextRuntime TextInstance1 { get; protected set; }
    public TextRuntime TextInstance2 { get; protected set; }
    public ContainerRuntime ContainerInstance3 { get; protected set; }

    public V2_is_Dead(InteractiveGue visual) : base(visual)
    {
        InitializeInstances();
        CustomInitialize();
    }
    public V2_is_Dead() : base(new ContainerRuntime())
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
        TextInstance3 = new global::MonoGameGum.GueDeriving.TextRuntime();
        TextInstance3.ElementSave = ObjectFinder.Self.GetStandardElement("Text");
        if (TextInstance3.ElementSave != null) TextInstance3.AddStatesAndCategoriesRecursivelyToGue(TextInstance3.ElementSave);
        if (TextInstance3.ElementSave != null) TextInstance3.SetInitialState();
        TextInstance3.Name = "TextInstance3";
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
        ContainerInstance3 = new global::MonoGameGum.GueDeriving.ContainerRuntime();
        ContainerInstance3.ElementSave = ObjectFinder.Self.GetStandardElement("Container");
        if (ContainerInstance3.ElementSave != null) ContainerInstance3.AddStatesAndCategoriesRecursivelyToGue(ContainerInstance3.ElementSave);
        if (ContainerInstance3.ElementSave != null) ContainerInstance3.SetInitialState();
        ContainerInstance3.Name = "ContainerInstance3";
        base.RefreshInternalVisualReferences();
    }
    protected virtual void AssignParents()
    {
        ContainerInstance1.AddChild(SpriteInstance2);
        this.AddChild(ContainerInstance1);
        this.AddChild(TextInstance3);
        ContainerInstance1.AddChild(ContainerInstance2);
        this.AddChild(SpriteInstance);
        ContainerInstance3.AddChild(TextInstance);
        ContainerInstance3.AddChild(TextInstance1);
        ContainerInstance3.AddChild(TextInstance2);
        this.AddChild(ContainerInstance3);
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

        this.TextInstance3.SetProperty("ColorCategoryState", "Warning");
        this.TextInstance3.Font = @"Proxima Nova Rg";
        this.TextInstance3.FontSize = 250;
        this.TextInstance3.Height = -119f;
        ((TextRuntime)this.TextInstance3).HorizontalAlignment = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
        this.TextInstance3.IsBold = true;
        this.TextInstance3.OutlineThickness = 3;
        this.TextInstance3.Rotation = 0f;
        this.TextInstance3.Text = @"V2";
        this.TextInstance3.UseFontSmoothing = true;
        ((TextRuntime)this.TextInstance3).VerticalAlignment = global::RenderingLibrary.Graphics.VerticalAlignment.Center;
        this.TextInstance3.Width = 69f;
        this.TextInstance3.X = 258f;
        this.TextInstance3.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
        this.TextInstance3.XUnits = global::Gum.Converters.GeneralUnitType.PixelsFromMiddle;
        this.TextInstance3.Y = 298f;
        this.TextInstance3.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Center;
        this.TextInstance3.YUnits = global::Gum.Converters.GeneralUnitType.PixelsFromMiddle;

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

        this.SpriteInstance.Height = 60.303055f;
        this.SpriteInstance.SourceFileName = @"gumlogo.png";
        this.SpriteInstance.Width = 70.44269f;
        this.SpriteInstance.X = 14f;
        this.SpriteInstance.Y = 108.05571f;
        this.SpriteInstance.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Center;
        this.SpriteInstance.YUnits = global::Gum.Converters.GeneralUnitType.Percentage;

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

        this.ContainerInstance3.ChildrenLayout = global::Gum.Managers.ChildrenLayout.LeftToRightStack;
        this.ContainerInstance3.Height = 0f;
        this.ContainerInstance3.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;
        this.ContainerInstance3.Width = 0f;
        this.ContainerInstance3.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;
        this.ContainerInstance3.X = 248f;
        this.ContainerInstance3.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
        this.ContainerInstance3.XUnits = global::Gum.Converters.GeneralUnitType.PixelsFromMiddle;
        this.ContainerInstance3.Y = 3f;
        this.ContainerInstance3.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Top;
        this.ContainerInstance3.YUnits = global::Gum.Converters.GeneralUnitType.PixelsFromSmall;

    }
    partial void CustomInitialize();
}
