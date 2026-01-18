//Code for Hytale/PIeces/ItemRarityBackground (Container)
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
partial class ItemRarityBackground : global::Gum.Forms.Controls.FrameworkElement
{
    [System.Runtime.CompilerServices.ModuleInitializer]
    public static void RegisterRuntimeType()
    {
        var template = new global::Gum.Forms.VisualTemplate((vm, createForms) =>
        {
            var visual = new global::MonoGameGum.GueDeriving.ContainerRuntime();
            var element = ObjectFinder.Self.GetElementSave("Hytale/PIeces/ItemRarityBackground");
#if DEBUG
if(element == null) throw new System.InvalidOperationException("Could not find an element named Hytale/PIeces/ItemRarityBackground - did you forget to load a Gum project?");
#endif
            element.SetGraphicalUiElement(visual, RenderingLibrary.SystemManagers.Default);
            if(createForms) visual.FormsControlAsObject = new ItemRarityBackground(visual);
            return visual;
        });
        global::Gum.Forms.Controls.FrameworkElement.DefaultFormsTemplates[typeof(ItemRarityBackground)] = template;
        ElementSaveExtensions.RegisterGueInstantiation("Hytale/PIeces/ItemRarityBackground", () => 
        {
            var gue = template.CreateContent(null, true) as InteractiveGue;
            return gue;
        });
    }
    public enum RarityCategory
    {
        None,
        Common,
        Uncommon,
        Rare,
        Epic,
        Legerndary,
    }

    RarityCategory? _rarityCategoryState;
    public RarityCategory? RarityCategoryState
    {
        get => _rarityCategoryState;
        set
        {
            _rarityCategoryState = value;
            if(value != null)
            {
                if(Visual.Categories.ContainsKey("RarityCategory"))
                {
                    var category = Visual.Categories["RarityCategory"];
                    var state = category.States.Find(item => item.Name == value.ToString());
                    this.Visual.ApplyState(state);
                }
                else
                {
                    var category = ((global::Gum.DataTypes.ElementSave)this.Visual.Tag).Categories.FirstOrDefault(item => item.Name == "RarityCategory");
                    var state = category.States.Find(item => item.Name == value.ToString());
                    this.Visual.ApplyState(state);
                }
            }
        }
    }
    public NineSliceRuntime Background { get; protected set; }

    public ItemRarityBackground(InteractiveGue visual) : base(visual)
    {
    }
    public ItemRarityBackground()
    {



    }
    protected override void ReactToVisualChanged()
    {
        base.ReactToVisualChanged();
        Background = this.Visual?.GetGraphicalUiElementByName("Background") as global::MonoGameGum.GueDeriving.NineSliceRuntime;
        CustomInitialize();
    }
    //Not assigning variables because Object Instantiation Type is set to By Name rather than Fully In Code
    partial void CustomInitialize();
}
