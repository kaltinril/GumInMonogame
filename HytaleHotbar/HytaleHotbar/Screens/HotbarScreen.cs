using Gum.Converters;
using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;
using HytaleHotbar.Components.Hytale;
using HytaleHotbar.Components.Hytale.PIeces;
using HytaleHotbar.Data;
using HytaleHotbar.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGameGum;
using MonoGameGum.ExtensionMethods;
using RenderingLibrary.Graphics;
using System;
using System.Linq;

namespace HytaleHotbar.Screens
{
    partial class HotbarScreen : IUpdateScreen
    {
        InventoryService _inventoryService;

        private static readonly Random _random = new Random();

        ItemSlot _grabbedItem;
        int _grabbedItemOriginIndex;
        bool isItemOnCursor;
        bool isDragging;
        bool justPushed;

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

            InitializeGrabbedItem();
            GumService.Default.PopupRoot.AddChild(_grabbedItem);
            isItemOnCursor = false;
            justPushed = false;
            isDragging = false;

            foreach (ItemSlot item in InventoryPanelInstance.ItemStackPanel.Children)
            {
                item.Click += HandleInventoryItemClick;
                item.Push += HandleInventoryItemPushed;
                item.RemovedAsPushed += HandleInventoryItemRemovedAsPushed;
                item.Dragging += HandleInventoryItemDragging;
            }
        }

        private void SetupRandomHotbar()
        {
            if (InventoryPanelInstance.IsVisible)
            {
                for (int i = 0; i < _inventoryService.HotbarStartIndex; i++)
                {
                    SetSlotToRandomItem(InventoryPanelInstance.Slot(i), i);
                }
                InventoryPanelInstance.UpdatePanelFromInventory();
            }
            else
            {
                for (int i = 0; i < 9; i++)
                {
                    SetSlotToRandomItem(HotbarInstance.Slot(i), i + _inventoryService.HotbarStartIndex);
                }
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
            var item = new InventoryItem(itemDef.Name, _random.Next(itemDef.MaxStackSize), _random.Next(100), randomEnumValue);

            // Update the inventory slot and the slot visual
            _inventoryService.PlayerInventory[index] = item;
            slot.SetSlotToItem(item, itemDef);
        }

        private void Randomize_Click(object sender, EventArgs e)
        {
            SetupRandomHotbar();
        }

        private void InitializeGrabbedItem()
        {
            _grabbedItem = new ItemSlot();
            _grabbedItem.IsVisible = false;
            _grabbedItem.Name = "Grabbed item";
            // So that it doesn't register as the cursor being over it:
            _grabbedItem.Visual.HasEvents = false;

            _grabbedItem.Visual.XOrigin = HorizontalAlignment.Center;
            _grabbedItem.Visual.YOrigin = VerticalAlignment.Center;
        }

        public void HandleInventoryItemPushed(object sender, EventArgs e)
        {
            if (isItemOnCursor)
            {
                return;
            }

            ItemSlot itemSlot = (ItemSlot)sender;
            if (!InventoryHasItemSlot(itemSlot))
            {
                return;
            }

            justPushed = true;
            SetGrabbedItemToItemSlot(itemSlot);
            itemSlot.HideSlot();
        }

        public void HandleInventoryItemRemovedAsPushed(object sender, EventArgs e)
        {
            if (isDragging || isItemOnCursor)
            {
                ItemSlot itemSlot = (ItemSlot)sender;
                if (!InventoryHasItemSlot(itemSlot))
                {
                    return;
                }

                isDragging = false;

                var visualOver = GumService.Default.Cursor.VisualOver;
                var itemSlotDropped = visualOver?.FormsControlAsObject as ItemSlot;

                if (isItemOnCursor && itemSlotDropped == itemSlot)
                {
                    return;
                }

                HandleGrabbedItemDrop(itemSlot, itemSlotDropped);
            }
        }

        public void HandleInventoryItemDragging(object sender, EventArgs e)
        {
            ItemSlot itemSlot = (ItemSlot)sender;
            if (justPushed)
            {
                isDragging = true;
                justPushed = false;
            }
        }

        public void HandleInventoryItemClick(object sender, EventArgs e)
        {
            ItemSlot itemSlot = (ItemSlot)sender;
            if (isItemOnCursor)
            {
                // Since the 2nd click's sender will be the TARGET, we need to lookup the source
                var originalItemSlot = (ItemSlot)InventoryPanelInstance.ItemStackPanel.Children[_grabbedItemOriginIndex];

                HandleGrabbedItemDrop(originalItemSlot, itemSlot);
            }
            else
            {
                if (itemSlot.HasItemState == ItemSlot.HasItem.True)
                {
                    justPushed = false;
                    isDragging = false;
                    isItemOnCursor = true;
                }
            }
        }

        public void HandleGrabbedItemDrop(ItemSlot itemSlotCameFrom, ItemSlot itemSlotDroppedOn)
        {
            // Should't be possible but just in case
            if (itemSlotCameFrom == null)
            {
                return;
            }

            if (itemSlotDroppedOn == itemSlotCameFrom)
            {
                itemSlotCameFrom.UnhideSlot();
                CleanupGrabbedItem();
                return;
            }


            if (itemSlotDroppedOn == null)
            {
                var x = _grabbedItem.X;
                var y = _grabbedItem.Y;

                // did we drop outside of the inventory?
                if (x < InventoryPanelInstance.AbsoluteLeft ||
                    x > InventoryPanelInstance.AbsoluteLeft + InventoryPanelInstance.ActualWidth ||
                    y > InventoryPanelInstance.AbsoluteTop + InventoryPanelInstance.ActualHeight ||
                    y < InventoryPanelInstance.AbsoluteTop)
                {
                    // We are outside the Inventory Panel, "drop" the item to the ground (simply delete it)
                    ClearInventorySlot(_grabbedItemOriginIndex, itemSlotCameFrom);
                    CleanupGrabbedItem();
                }
                else
                {
                    // Dropped into the inventory somewhere not on another slot, so lets just "cancel" this action
                    itemSlotCameFrom.UnhideSlot();
                    CleanupGrabbedItem();
                }

                return;
            }

            int targetIndex = InventoryPanelInstance.ItemStackPanel.Children.IndexOf(itemSlotDroppedOn);

            // Attempt the item move and react to the inventory change (if any)
            var moveOutcome = _inventoryService.TryMoveItem(_grabbedItemOriginIndex, targetIndex);

            // optionally we could do a SWITCH/IF here and perform specific actions on each outcome
            // we'll go simple here, and just refresh both slots.

            RefreshSlot(_grabbedItemOriginIndex);
            RefreshSlot(targetIndex);
            CleanupGrabbedItem();
        }

        private void CleanupGrabbedItem()
        {
            _grabbedItem.HasItemState = ItemSlot.HasItem.False;
            _grabbedItem.IsVisible = false;
            _grabbedItemOriginIndex = -1;
            isItemOnCursor = false;
        }

        private void SetGrabbedItemToItemSlot(ItemSlot itemSlot)
        {
            _grabbedItem.SetSlotToSlot(itemSlot);
            _grabbedItem.IsVisible = true;
            _grabbedItem.IsOnHotbarState = ItemSlot.IsOnHotbar.False;
            _grabbedItem.ItemRarityBackgroundInstance.IsVisible = false;
            MoveGrabbedIconToMouse();
            _grabbedItemOriginIndex = InventoryPanelInstance.ItemStackPanel.Children.IndexOf(itemSlot);
        }

        private void ClearInventorySlot(int index, ItemSlot itemSlot)
        {
            _inventoryService.PlayerInventory[index] = null;

            itemSlot.ClearSlot();
        }

        private void RefreshSlot(int index)
        {
            if (_inventoryService.ValidIndex(index))
            {
                var item = _inventoryService.PlayerInventory[index];
                var slot = InventoryPanelInstance.Slot(index);
                slot.UnhideSlot();
                if (item != null)
                {
                    var itemDef = _inventoryService.ItemDefinitions[item.Name];
                    slot.SetSlotToItem(item, itemDef);
                }
                else
                {
                    slot.ClearSlot();
                }
            }
        }

        private InventoryItem? GetInventoryItemFromSlot(ItemSlot itemSlot)
        {
            int index = InventoryPanelInstance.ItemStackPanel.Children.IndexOf(itemSlot);
            return _inventoryService.PlayerInventory[index];
        }

        private bool InventoryHasItemSlot(ItemSlot itemSlot)
        {
            var item = GetInventoryItemFromSlot(itemSlot);
            return InventoryHasItem(item);
        }

        private bool InventoryHasItem(InventoryItem? item)
        {
            return !(item == null);
        }

        public void Update(GameTime gameTime)
        {
            HandleKeyboardInput();

            if (_grabbedItem.IsVisible)
            {
                MoveGrabbedIconToMouse();
            }
        }
        public void MoveGrabbedIconToMouse()
        {
            var cursor = GumService.Default.Cursor;
            _grabbedItem.X = cursor.XRespectingGumZoomAndBounds();
            _grabbedItem.Y = cursor.YRespectingGumZoomAndBounds();
        }

        private void HandleKeyboardInput()
        {
            var keyboard = GumService.Default.Keyboard;
            HotbarInstance.HandleKeyboardInput();

            // Hide the hotbar and don't respond to input
            if (keyboard.KeyPushed(Keys.I))
            {
                this.HotbarInstance.IsVisible = !this.HotbarInstance.IsVisible;
                this.InventoryPanelInstance.IsVisible = !this.InventoryPanelInstance.IsVisible;
            }
        }
    }
}
