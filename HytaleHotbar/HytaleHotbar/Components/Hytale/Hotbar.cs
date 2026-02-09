using Gum.Converters;
using Gum.DataTypes;
using Gum.Forms.Controls;
using Gum.Managers;
using Gum.Wireframe;
using HytaleHotbar.Services;
using Microsoft.Xna.Framework.Input;
using MonoGameGum;
using MonoGameGum.ExtensionMethods;
using RenderingLibrary.Graphics;
using System;
using System.Diagnostics;
using System.Linq;

namespace HytaleHotbar.Components.Hytale
{
    partial class Hotbar
    {
        InventoryService _inventoryService;

        public event EventHandler SelectedIndexChanged;

        public ItemSlot Slot(int i) => (ItemSlot)InnerStackPanel.Children[i];

        private int selectedIndex = -1;
        public int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                if (selectedIndex != value)
                {
                    // Clear previous selection
                    if (selectedIndex != -1)
                    {
                        Slot(selectedIndex).Selected = false;
                    }

                    selectedIndex = value;
                    Slot(selectedIndex).Selected = true;

                    SelectedIndexChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
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

                // Update the Hotbar if we just got set to visible
                if (value)
                {
                    UpdateHotbarFromInventory();
                }

                base.IsVisible = value;
            }
        }

        partial void CustomInitialize()
        {
            _inventoryService = Game1.ServiceContainer.GetService<InventoryService>();

            foreach (ItemSlot child in InnerStackPanel.Children)
            {
                child.Click += HandleItemSlotClicked;
            }
        }

        public void UpdateHotbarFromInventory()
        {
            for (int i = 0; i < 9; i++)
            {
                // These 3 could be consolidated
                var item = _inventoryService?.HotbarInventory(i);
                var itemDef = item == null ? null : _inventoryService.ItemDefinitions[item.Name];
                var slot = Slot(i);
                slot.SetSlotToItem(item, itemDef);
            }
        }

        private void HandleItemSlotClicked(object sender, EventArgs e)
        {
            ItemSlot itemSlot = (ItemSlot)sender;
            SelectedIndex = InnerStackPanel.Children.IndexOf(itemSlot);

            Debug.WriteLine($"Clicked {itemSlot.Name}");
        }

        internal void HandleKeyboardInput()
        {
            if (!this.IsVisible)
            {
                return;
            }

            var keyboard = GumService.Default.Keyboard;
            int? indexToSelect = null;
            if (keyboard.KeyPushed(Keys.D1)) indexToSelect = 0;
            if (keyboard.KeyPushed(Keys.D2)) indexToSelect = 1;
            if (keyboard.KeyPushed(Keys.D3)) indexToSelect = 2;
            if (keyboard.KeyPushed(Keys.D4)) indexToSelect = 3;
            if (keyboard.KeyPushed(Keys.D5)) indexToSelect = 4;
            if (keyboard.KeyPushed(Keys.D6)) indexToSelect = 5;
            if (keyboard.KeyPushed(Keys.D7)) indexToSelect = 6;
            if (keyboard.KeyPushed(Keys.D8)) indexToSelect = 7;
            if (keyboard.KeyPushed(Keys.D9)) indexToSelect = 8;

            if (indexToSelect != null)
            {
                SelectedIndex = indexToSelect.Value;
            }
        }
    }
}
