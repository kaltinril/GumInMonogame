using Gum.Converters;
using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;
using HytaleHotbar.Services;
using RenderingLibrary.Graphics;

using System.Linq;

namespace HytaleHotbar.Components.Hytale
{
    partial class InventoryPanel
    {
        // We are overriding/hiding the real IsVisible so we can add our own functionality when hiding
        // Downside, if something else sets the base IsVisible we have no "hook" into that.
        new public bool IsVisible
        {
            get
            {
                return base.IsVisible;
            }
            set
            {
                // Don't make changes to visibility if it's the same
                if (value == base.IsVisible)
                {
                    return;
                }

                // Update the InventoryPanel if we just got set to visible
                if (value)
                {
                    UpdatePanelFromInventory();
                }

                base.IsVisible = value;
            }
        }

        public ItemSlot Slot(int i) => (ItemSlot)ItemStackPanel.Children[i];

        InventoryService _inventoryService;

        partial void CustomInitialize()
        {
            _inventoryService = Game1.ServiceContainer.GetService<InventoryService>();
        }

        public void UpdatePanelFromInventory()
        {
            for (int i = 0; i < _inventoryService.PlayerInventory.Length; i++)
            {
                // These 3 could be consolidated
                var item = _inventoryService?.PlayerInventory[i];
                var itemDef = item == null ? null : _inventoryService.ItemDefinitions[item.Name];
                var slot = Slot(i);
                slot.SetSlotToItem(item, itemDef);
            }
        }
    }
}
