using Gum.Converters;
using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;
using HytaleHotbar.Components.Hytale;
using HytaleHotbar.Components.Hytale.PIeces;
using HytaleHotbar.Data;
using HytaleHotbar.Services;
using Microsoft.Xna.Framework;
using RenderingLibrary.Graphics;
using System;
using System.Linq;

namespace HytaleHotbar.Screens
{
    partial class HotbarScreen : IUpdateScreen
    {
        InventoryService _inventoryService;

        private static readonly Random _random = new Random();

        partial void CustomInitialize()
        {
            _inventoryService = Game1.ServiceContainer.GetService<InventoryService>();
            SetupRandomHotbar();

            Randomize.Text = "Randomize";

            Randomize.Click += Randomize_Click;

            // Fire when the Selected Index changes on the HotBar component
            HotbarInstance.SelectedIndexChanged += (_, _) =>
            {
                var index = HotbarInstance.SelectedIndex;
                var slotItem = HotbarInstance.Slot(index);
                var itemDef = _inventoryService.HotbarInventory(index);

                StatusInfo.Text = $"Selected index {HotbarInstance.SelectedIndex}\n@ {DateTime.Now}\n{slotItem.Quantity} {itemDef.Name}";
            };
        }

        private void SetupRandomHotbar()
        {
            for (int i = 0; i < 9; i++)
            {
                SetSlotToRandomItem(HotbarInstance.Slot(i), i);
            }
        }

        private void SetSlotToRandomItem(ItemSlot slot, int index)
        {
            // Get the Definition for a random item
            var itemDictKV = _inventoryService.ItemDefinitions.ElementAt(_random.Next(_inventoryService.ItemDefinitions.Count));
            InventoryItemDefinition itemDef = itemDictKV.Value;

            // Pick a random rarity for it (excluding the first one "None")
            var values = Enum.GetValues<ItemRarityBackground.RarityCategory>();
            var randomEnumValue = values[_random.Next(values.Length - 1) + 1];

            // Create the inventory item with the values
            var item = new InventoryItem(itemDef.Name, _random.Next(64), _random.Next(100), randomEnumValue);

            // Update the inventory slot and the slot visual
            _inventoryService.PlayerInventory[_inventoryService.HotbarStartIndex + index] = item;
            slot.SetSlotToItem(item, itemDef);
        }

        private void Randomize_Click(object sender, EventArgs e)
        {
            SetupRandomHotbar();
        }

        public void Update(GameTime gameTime)
        {
            HotbarInstance.HandleKeyboardInput();
        }
    }
}
