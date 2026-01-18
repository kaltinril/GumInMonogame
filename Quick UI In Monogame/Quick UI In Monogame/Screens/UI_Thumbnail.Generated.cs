//Code for UI Thumbnail
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

partial class UI_Thumbnail : global::Gum.Forms.Controls.FrameworkElement
{
    [System.Runtime.CompilerServices.ModuleInitializer]
    public static void RegisterRuntimeType()
    {
        var template = new global::Gum.Forms.VisualTemplate((vm, createForms) =>
        {
            var visual = new global::MonoGameGum.GueDeriving.ContainerRuntime();
            var element = ObjectFinder.Self.GetElementSave("UI Thumbnail");
#if DEBUG
if(element == null) throw new System.InvalidOperationException("Could not find an element named UI Thumbnail - did you forget to load a Gum project?");
#endif
            element.SetGraphicalUiElement(visual, RenderingLibrary.SystemManagers.Default);
            if(createForms) visual.FormsControlAsObject = new UI_Thumbnail(visual);
            visual.Width = 0;
            visual.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToParent;
            visual.Height = 0;
            visual.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToParent;
            return visual;
        });
        global::Gum.Forms.Controls.FrameworkElement.DefaultFormsTemplates[typeof(UI_Thumbnail)] = template;
        ElementSaveExtensions.RegisterGueInstantiation("UI Thumbnail", () => 
        {
            var gue = template.CreateContent(null, true) as InteractiveGue;
            return gue;
        });
    }
    public SpriteRuntime SpriteInstance { get; protected set; }
    public SpriteRuntime SpriteInstance2 { get; protected set; }
    public ContainerRuntime ContainerInstance { get; protected set; }
    public SpriteRuntime SpriteInstance1 { get; protected set; }
    public ContainerRuntime ContainerInstance1 { get; protected set; }
    public TextRuntime TextInstance { get; protected set; }
    public TextRuntime TextInstance1 { get; protected set; }
    public TextRuntime TextInstance2 { get; protected set; }
    public ContainerRuntime ContainerInstance2 { get; protected set; }
    public SpriteRuntime cursor { get; protected set; }

    public UI_Thumbnail(InteractiveGue visual) : base(visual)
    {
        InitializeInstances();
        CustomInitialize();
    }
    public UI_Thumbnail() : base(new ContainerRuntime())
    {


        InitializeInstances();

        ApplyDefaultVariables();
        AssignParents();
        CustomInitialize();
    }
    protected virtual void InitializeInstances()
    {
        SpriteInstance = new global::MonoGameGum.GueDeriving.SpriteRuntime();
        SpriteInstance.ElementSave = ObjectFinder.Self.GetStandardElement("Sprite");
        if (SpriteInstance.ElementSave != null) SpriteInstance.AddStatesAndCategoriesRecursivelyToGue(SpriteInstance.ElementSave);
        if (SpriteInstance.ElementSave != null) SpriteInstance.SetInitialState();
        SpriteInstance.Name = "SpriteInstance";
        SpriteInstance2 = new global::MonoGameGum.GueDeriving.SpriteRuntime();
        SpriteInstance2.ElementSave = ObjectFinder.Self.GetStandardElement("Sprite");
        if (SpriteInstance2.ElementSave != null) SpriteInstance2.AddStatesAndCategoriesRecursivelyToGue(SpriteInstance2.ElementSave);
        if (SpriteInstance2.ElementSave != null) SpriteInstance2.SetInitialState();
        SpriteInstance2.Name = "SpriteInstance2";
        ContainerInstance = new global::MonoGameGum.GueDeriving.ContainerRuntime();
        ContainerInstance.ElementSave = ObjectFinder.Self.GetStandardElement("Container");
        if (ContainerInstance.ElementSave != null) ContainerInstance.AddStatesAndCategoriesRecursivelyToGue(ContainerInstance.ElementSave);
        if (ContainerInstance.ElementSave != null) ContainerInstance.SetInitialState();
        ContainerInstance.Name = "ContainerInstance";
        SpriteInstance1 = new global::MonoGameGum.GueDeriving.SpriteRuntime();
        SpriteInstance1.ElementSave = ObjectFinder.Self.GetStandardElement("Sprite");
        if (SpriteInstance1.ElementSave != null) SpriteInstance1.AddStatesAndCategoriesRecursivelyToGue(SpriteInstance1.ElementSave);
        if (SpriteInstance1.ElementSave != null) SpriteInstance1.SetInitialState();
        SpriteInstance1.Name = "SpriteInstance1";
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
        ContainerInstance2 = new global::MonoGameGum.GueDeriving.ContainerRuntime();
        ContainerInstance2.ElementSave = ObjectFinder.Self.GetStandardElement("Container");
        if (ContainerInstance2.ElementSave != null) ContainerInstance2.AddStatesAndCategoriesRecursivelyToGue(ContainerInstance2.ElementSave);
        if (ContainerInstance2.ElementSave != null) ContainerInstance2.SetInitialState();
        ContainerInstance2.Name = "ContainerInstance2";
        cursor = new global::MonoGameGum.GueDeriving.SpriteRuntime();
        cursor.ElementSave = ObjectFinder.Self.GetStandardElement("Sprite");
        if (cursor.ElementSave != null) cursor.AddStatesAndCategoriesRecursivelyToGue(cursor.ElementSave);
        if (cursor.ElementSave != null) cursor.SetInitialState();
        cursor.Name = "cursor";
        base.RefreshInternalVisualReferences();
    }
    protected virtual void AssignParents()
    {
        ContainerInstance.AddChild(SpriteInstance);
        ContainerInstance1.AddChild(SpriteInstance2);
        ContainerInstance1.AddChild(ContainerInstance);
        ContainerInstance.AddChild(SpriteInstance1);
        this.AddChild(ContainerInstance1);
        ContainerInstance2.AddChild(TextInstance);
        ContainerInstance2.AddChild(TextInstance1);
        ContainerInstance2.AddChild(TextInstance2);
        ContainerInstance1.AddChild(ContainerInstance2);
        ContainerInstance1.AddChild(cursor);
    }
    private void ApplyDefaultVariables()
    {
        this.Visual.Width = 0f;
        this.Visual.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToParent;
        this.Visual.Height = 0f;
        this.Visual.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToParent;
        this.SpriteInstance.SourceFileName = @"bluebutton_2.png";

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

        this.ContainerInstance.Height = 0f;
        this.ContainerInstance.HeightUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;
        this.ContainerInstance.Width = 0f;
        this.ContainerInstance.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToChildren;
        this.ContainerInstance.X = 0f;
        this.ContainerInstance.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
        this.ContainerInstance.XUnits = global::Gum.Converters.GeneralUnitType.PixelsFromMiddle;
        this.ContainerInstance.Y = -100f;
        this.ContainerInstance.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Bottom;
        this.ContainerInstance.YUnits = global::Gum.Converters.GeneralUnitType.PixelsFromLarge;

        this.SpriteInstance1.Height = 100f;
        this.SpriteInstance1.HeightUnits = global::Gum.DataTypes.DimensionUnitType.MaintainFileAspectRatio;
        this.SpriteInstance1.SourceFileName = @"monogame_dark.png";
        this.SpriteInstance1.Width = -40f;
        this.SpriteInstance1.WidthUnits = global::Gum.DataTypes.DimensionUnitType.RelativeToParent;
        this.SpriteInstance1.X = 0f;
        this.SpriteInstance1.XOrigin = global::RenderingLibrary.Graphics.HorizontalAlignment.Center;
        this.SpriteInstance1.XUnits = global::Gum.Converters.GeneralUnitType.PixelsFromMiddle;
        this.SpriteInstance1.Y = 0f;
        this.SpriteInstance1.YOrigin = global::RenderingLibrary.Graphics.VerticalAlignment.Center;
        this.SpriteInstance1.YUnits = global::Gum.Converters.GeneralUnitType.PixelsFromMiddle;

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

        this.cursor.Height = 75f;
        this.cursor.SourceFileName = @"cursor2.png";
        this.cursor.Width = 75f;
        this.cursor.X = 755f;
        this.cursor.Y = 460f;

    }
    partial void CustomInitialize();
}
