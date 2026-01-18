//Code for comp1 (Container)
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

partial class comp1 : global::Gum.Forms.Controls.FrameworkElement
{
    [System.Runtime.CompilerServices.ModuleInitializer]
    public static void RegisterRuntimeType()
    {
        var template = new global::Gum.Forms.VisualTemplate((vm, createForms) =>
        {
            var visual = new global::MonoGameGum.GueDeriving.ContainerRuntime();
            var element = ObjectFinder.Self.GetElementSave("comp1");
#if DEBUG
if(element == null) throw new System.InvalidOperationException("Could not find an element named comp1 - did you forget to load a Gum project?");
#endif
            element.SetGraphicalUiElement(visual, RenderingLibrary.SystemManagers.Default);
            if(createForms) visual.FormsControlAsObject = new comp1(visual);
            return visual;
        });
        global::Gum.Forms.Controls.FrameworkElement.DefaultFormsTemplates[typeof(comp1)] = template;
        ElementSaveExtensions.RegisterGueInstantiation("comp1", () => 
        {
            var gue = template.CreateContent(null, true) as InteractiveGue;
            return gue;
        });
    }
    public ColoredRectangleRuntime ColoredRectangleInstance { get; protected set; }

    public comp1(InteractiveGue visual) : base(visual)
    {
        InitializeInstances();
        CustomInitialize();
    }
    public comp1() : base(new ContainerRuntime())
    {


        InitializeInstances();

        ApplyDefaultVariables();
        AssignParents();
        CustomInitialize();
    }
    protected virtual void InitializeInstances()
    {
        ColoredRectangleInstance = new global::MonoGameGum.GueDeriving.ColoredRectangleRuntime();
        ColoredRectangleInstance.ElementSave = ObjectFinder.Self.GetStandardElement("ColoredRectangle");
        if (ColoredRectangleInstance.ElementSave != null) ColoredRectangleInstance.AddStatesAndCategoriesRecursivelyToGue(ColoredRectangleInstance.ElementSave);
        if (ColoredRectangleInstance.ElementSave != null) ColoredRectangleInstance.SetInitialState();
        ColoredRectangleInstance.Name = "ColoredRectangleInstance";
        base.RefreshInternalVisualReferences();
    }
    protected virtual void AssignParents()
    {
        this.AddChild(ColoredRectangleInstance);
    }
    private void ApplyDefaultVariables()
    {

    }
    partial void CustomInitialize();
}
