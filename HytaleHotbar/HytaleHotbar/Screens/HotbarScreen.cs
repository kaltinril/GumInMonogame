using Gum.Wireframe;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGameGum;
using MonoGameGum.ExtensionMethods;
using HytaleHotbar.Components.Hytale;
using HytaleHotbar.Components.Hytale.PIeces;
using HytaleHotbar.Data;
using HytaleHotbar.Services;
using RenderingLibrary.Graphics;
using System;
using System.Linq;

namespace HytaleHotbar.Screens
{
    partial class HotbarScreen : IUpdateScreen
    {
        InventoryService _inventoryService;
        private static readonly Random _random = new Random();

        bool isDragging;
        bool justPushed;
        bool isItemOnCursor;

        ItemSlot _grabbedItem;
        int _grabbedItemOriginIndex;

        partial void CustomInitialize()
        {
            _inventoryService = Game1.ServiceContainer.GetService<InventoryService>();

            SetupRandomHotbar();

            Randomize.Click += Randomize_Click;

            HotbarInstance.SelectedIndexChanged += (_, _) =>
            {
                var index = HotbarInstance.SelectedIndex;
                var slotItem = HotbarInstance.Slot(index);
                var itemDef = _inventoryService.HotbarInventory(index);

                StatusInfo.Text = $"Selected index {HotbarInstance.SelectedIndex}\n@ {DateTime.Now}\n{slotItem.Quantity} {itemDef.Name}";
            };

            CreateGrabbedItem();

            GumService.Default.PopupRoot.AddChild(_grabbedItem);

            justPushed = false;
            isDragging = false;
            isItemOnCursor = false;
            foreach (ItemSlot item in InventoryPanelInstance.ItemStackPanel.Children)
            {
                item.Push += HandleInventoryItemPushed;
                item.Click += HandleInventoryItemClick;
                item.RemovedAsPushed += HandleInventoryItemRemovedAsPushed;
                item.Dragging += HandleInventoryItemDragging;
            }

        }

        private void Randomize_Click(object sender, EventArgs e)
        {
            SetupRandomHotbar();
        }

        private void SetupRandomHotbar()
        {
            if (InventoryPanelInstance.IsVisible)
            {
                for (int i = 0; i < 9 * 4; i++)
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

        private void CreateGrabbedItem()
        {
            _grabbedItem = new ItemSlot();
            _grabbedItem.IsVisible = false;
            _grabbedItem.Name = "Grabbed item";
            // So that it doesn't register as the cursor being over it:
            _grabbedItem.Visual.HasEvents = false;

            _grabbedItem.Visual.XOrigin = HorizontalAlignment.Center;
            _grabbedItem.Visual.YOrigin = VerticalAlignment.Center;
        }


        // Push happens before click, so either way we need this to put the item on the mouse   
        // We'll just change functionality on "dropping" the item based on RemovePushed or Click firing first
        public void HandleInventoryItemPushed(object sender, EventArgs e)
        {
            if (isItemOnCursor)
            {
                return;
            }

            ItemSlot itemSlot = (ItemSlot)sender;
            var item = GetInventoryItemFromSlot(itemSlot);
            if (!InventoryHasItem(item))
            {
                return; 
            }

            System.Diagnostics.Debug.WriteLine("Push");
            justPushed = true;

            _grabbedItem.SetSlotToSlot(itemSlot);
            _grabbedItem.IsVisible = true;
            _grabbedItem.IsOnHotbarState = ItemSlot.IsOnHotbar.False;
            _grabbedItem.ItemRarityBackgroundInstance.IsVisible = false;
            MoveGrabbedIconToMouse();
            _grabbedItemOriginIndex = InventoryPanelInstance.ItemStackPanel.Children.IndexOf(itemSlot);
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

                System.Diagnostics.Debug.WriteLine("RemoveAsPushed");
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

        public void HandleInventoryItemClick(object sender, EventArgs e)
        {
            ItemSlot itemSlot = (ItemSlot)sender;
            if (isItemOnCursor)
            {
                // Since the 2nd click's sender will be the TARGET, we need to lookup the source
                System.Diagnostics.Debug.WriteLine("Click");
                var originalItemSlot = (ItemSlot)InventoryPanelInstance.ItemStackPanel.Children[_grabbedItemOriginIndex];
                
                HandleGrabbedItemDrop(originalItemSlot, itemSlot);
            }
            else
            {
                if (itemSlot.HasItemState == ItemSlot.HasItem.True)
                {
                    System.Diagnostics.Debug.WriteLine("Click");
                    justPushed = false;
                    isDragging = false;
                    isItemOnCursor = true;
                }
            }
        }

        public void HandleInventoryItemDragging(object sender, EventArgs e)
        {
            ItemSlot itemSlot = (ItemSlot)sender;
            if (justPushed)
            {
                isDragging = true;
                justPushed = false;
                System.Diagnostics.Debug.WriteLine("Dragging");
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
                } else
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
            _grabbedItem.ClearSlot();
            _grabbedItem.IsVisible = false;
            _grabbedItemOriginIndex = -1;
            justPushed = false;
            isDragging = false;
            isItemOnCursor = false;
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


            if ((isDragging || isItemOnCursor) && _grabbedItem.IsVisible)
            {
                MoveGrabbedIconToMouse();
            }
        }

        private void HandleKeyboardInput()
        {
            var keyboard = GumService.Default.Keyboard;
            HotbarInstance.HandleKeyboardInput();

            // Hide the hotbar and don't respond to input
            if (keyboard.KeyPushed(Keys.I))
            {
                this.HotbarInstance.IsVisible = !this.HotbarInstance.IsVisible;

                this.InventoryPanelInstance.IsVisible =!this.InventoryPanelInstance.IsVisible;
            }
        }

        private void SetSlotToRandomItem(ItemSlot slot, int index)
        {
            // Get the Definition for a random item
            var itemDictKV = _inventoryService.ItemDefinitions.ElementAt(_random.Next(_inventoryService.ItemDefinitions.Count));
            InventoryItemDefinition itemDef = itemDictKV.Value;

            // Pick a random rarity for it
            var values = Enum.GetValues<ItemRarityBackground.RarityCategory>();
            var randomEnumValue = values[_random.Next(values.Length - 1) + 1];

            // Create the inventory item with the values
            var item = new InventoryItem(itemDef.Name, _random.Next(itemDef.MaxStackSize), _random.Next(100), randomEnumValue);

            // Update the inventory slot and the slot visual
            _inventoryService.PlayerInventory[index] = item;
            slot.SetSlotToItem(item, itemDef);
        }

        public void MoveGrabbedIconToMouse()
        {
            var cursor = GumService.Default.Cursor;
            _grabbedItem.X = cursor.XRespectingGumZoomAndBounds();
            _grabbedItem.Y = cursor.YRespectingGumZoomAndBounds();
        }

    }
}
