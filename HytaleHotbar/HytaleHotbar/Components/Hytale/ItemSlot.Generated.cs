//Code for Hytale/ItemSlot (Container)
using Gum.Converters;
using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;
using GumRuntime;
using HytaleHotbar.Components.Hytale.PIeces;
using MonoGameGum;
using MonoGameGum.GueDeriving;
using RenderingLibrary.Graphics;
using System.Linq;
namespace HytaleHotbar.Components.Hytale;
partial class ItemSlot : global::Gum.Forms.Controls.FrameworkElement
{
    [System.Runtime.CompilerServices.ModuleInitializer]
    public static void RegisterRuntimeType()
    {
        var template = new global::Gum.Forms.VisualTemplate((vm, createForms) =>
        {
            var visual = new global::MonoGameGum.GueDeriving.ContainerRuntime();
            var element = ObjectFinder.Self.GetElementSave("Hytale/ItemSlot");
#if DEBUG
if(element == null) throw new System.InvalidOperationException("Could not find an element named Hytale/ItemSlot - did you forget to load a Gum project?");
#endif
            element.SetGraphicalUiElement(visual, RenderingLibrary.SystemManagers.Default);
            if(createForms) visual.FormsControlAsObject = new ItemSlot(visual);
            return visual;
        });
        global::Gum.Forms.Controls.FrameworkElement.DefaultFormsTemplates[typeof(ItemSlot)] = template;
        ElementSaveExtensions.RegisterGueInstantiation("Hytale/ItemSlot", () => 
        {
            var gue = template.CreateContent(null, true) as InteractiveGue;
            return gue;
        });
    }
    public enum HasItem
    {
        True,
        False,
    }
    public enum HasDamage
    {
        True,
        False,
    }
    public enum HasQuantity
    {
        True,
        False,
    }
    public enum IsOnHotbar
    {
        True,
        False,
    }

    HasItem? _hasItemState;
    public HasItem? HasItemState
    {
        get => _hasItemState;
        set
        {
            _hasItemState = value;
            if(value != null)
            {
                if(Visual.Categories.ContainsKey("HasItem"))
                {
                    var category = Visual.Categories["HasItem"];
                    var state = category.States.Find(item => item.Name == value.ToString());
                    this.Visual.ApplyState(state);
                }
                else
                {
                    var category = ((global::Gum.DataTypes.ElementSave)this.Visual.Tag).Categories.FirstOrDefault(item => item.Name == "HasItem");
                    var state = category.States.Find(item => item.Name == value.ToString());
                    this.Visual.ApplyState(state);
                }
            }
        }
    }

    HasDamage? _hasDamageState;
    public HasDamage? HasDamageState
    {
        get => _hasDamageState;
        set
        {
            _hasDamageState = value;
            if(value != null)
            {
                if(Visual.Categories.ContainsKey("HasDamage"))
                {
                    var category = Visual.Categories["HasDamage"];
                    var state = category.States.Find(item => item.Name == value.ToString());
                    this.Visual.ApplyState(state);
                }
                else
                {
                    var category = ((global::Gum.DataTypes.ElementSave)this.Visual.Tag).Categories.FirstOrDefault(item => item.Name == "HasDamage");
                    var state = category.States.Find(item => item.Name == value.ToString());
                    this.Visual.ApplyState(state);
                }
            }
        }
    }

    HasQuantity? _hasQuantityState;
    public HasQuantity? HasQuantityState
    {
        get => _hasQuantityState;
        set
        {
            _hasQuantityState = value;
            if(value != null)
            {
                if(Visual.Categories.ContainsKey("HasQuantity"))
                {
                    var category = Visual.Categories["HasQuantity"];
                    var state = category.States.Find(item => item.Name == value.ToString());
                    this.Visual.ApplyState(state);
                }
                else
                {
                    var category = ((global::Gum.DataTypes.ElementSave)this.Visual.Tag).Categories.FirstOrDefault(item => item.Name == "HasQuantity");
                    var state = category.States.Find(item => item.Name == value.ToString());
                    this.Visual.ApplyState(state);
                }
            }
        }
    }

    IsOnHotbar? _isOnHotbarState;
    public IsOnHotbar? IsOnHotbarState
    {
        get => _isOnHotbarState;
        set
        {
            _isOnHotbarState = value;
            if(value != null)
            {
                if(Visual.Categories.ContainsKey("IsOnHotbar"))
                {
                    var category = Visual.Categories["IsOnHotbar"];
                    var state = category.States.Find(item => item.Name == value.ToString());
                    this.Visual.ApplyState(state);
                }
                else
                {
                    var category = ((global::Gum.DataTypes.ElementSave)this.Visual.Tag).Categories.FirstOrDefault(item => item.Name == "IsOnHotbar");
                    var state = category.States.Find(item => item.Name == value.ToString());
                    this.Visual.ApplyState(state);
                }
            }
        }
    }
    public ItemRarityBackground ItemRarityBackgroundInstance { get; protected set; }
    public ItemIcon ItemIconInstance { get; protected set; }
    public SlotNumber SlotNumberInstance { get; protected set; }
    public DurabilityIndicator DurabilityIndicatorInstance { get; protected set; }
    public TextRuntime QuantityTextInstance { get; protected set; }
    public NineSliceRuntime HighlightIndicator { get; protected set; }

    public float DurabilityRatio
    {
        get => DurabilityIndicatorInstance.DurabilityRatio;
        set => DurabilityIndicatorInstance.DurabilityRatio = value;
    }

    public bool Selected
    {
        get => HighlightIndicator.Visible;
        set => HighlightIndicator.Visible = value;
    }

    public int IconLeft
    {
        get => ItemIconInstance.IconLeft;
        set => ItemIconInstance.IconLeft = value;
    }

    public int IconTop
    {
        get => ItemIconInstance.IconTop;
        set => ItemIconInstance.IconTop = value;
    }

    public ItemRarityBackground.RarityCategory? Rarity
    {
        get => ItemRarityBackgroundInstance.RarityCategoryState;
        set => ItemRarityBackgroundInstance.RarityCategoryState = value;
    }

    public string Quantity
    {
        get => QuantityTextInstance.Text;
        set => QuantityTextInstance.Text = value;
    }

    public string HotbarSlotNumber
    {
        get => SlotNumberInstance.Text;
        set => SlotNumberInstance.Text = value;
    }

    public ItemSlot(InteractiveGue visual) : base(visual)
    {
    }
    public ItemSlot()
    {



    }
    protected override void ReactToVisualChanged()
    {
        base.ReactToVisualChanged();
        ItemRarityBackgroundInstance = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemRarityBackground>(this.Visual,"ItemRarityBackgroundInstance");
        ItemIconInstance = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<ItemIcon>(this.Visual,"ItemIconInstance");
        SlotNumberInstance = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<SlotNumber>(this.Visual,"SlotNumberInstance");
        DurabilityIndicatorInstance = global::Gum.Forms.GraphicalUiElementFormsExtensions.TryGetFrameworkElementByName<DurabilityIndicator>(this.Visual,"DurabilityIndicatorInstance");
        QuantityTextInstance = this.Visual?.GetGraphicalUiElementByName("QuantityTextInstance") as global::MonoGameGum.GueDeriving.TextRuntime;
        HighlightIndicator = this.Visual?.GetGraphicalUiElementByName("HighlightIndicator") as global::MonoGameGum.GueDeriving.NineSliceRuntime;
        CustomInitialize();
    }
    //Not assigning variables because Object Instantiation Type is set to By Name rather than Fully In Code
    partial void CustomInitialize();
}
