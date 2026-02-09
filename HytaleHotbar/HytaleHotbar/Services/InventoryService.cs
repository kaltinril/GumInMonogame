using HytaleHotbar.Components.Hytale;
using HytaleHotbar.Data;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;


namespace HytaleHotbar.Services
{
    public class InventoryService
    {
        Dictionary<string, InventoryItemDefinition> _itemDefinitions;
        public IReadOnlyDictionary<string, InventoryItemDefinition> ItemDefinitions => _itemDefinitions;

        // Inventory is 4 rows of 9 columns, and the 5th row is the 9 hotbar items
        public InventoryItem?[] PlayerInventory { get; private set; } = new InventoryItem?[9 * 5];

        // Convenience accessor to jump to index 36 for the first (0) based hotbar instance
        public InventoryItem? HotbarInventory(int index) => PlayerInventory[HotbarStartIndex + index];

        public int HotbarStartIndex = 9 * 4;

        public int MaxItemSlots => PlayerInventory.Length;
        public enum MoveOutcome
        {
            NoOp,
            Dropped,
            FullTargetStack,
            Moved,
            SourcePartiallyStacked,
            SourceStacked,
            Swapped,
            UnknownCondition
        }

        public InventoryService()
        {
            SetupItemIconPositions();
        }

        private void SetupItemIconPositions()
        {
            _itemDefinitions = new Dictionary<string, InventoryItemDefinition>();

            // Row 1 spritesheet
            AddItemIcon("Sword", new Vector2(0, 96), ItemCatergories.Weapon, 1);
            AddItemIcon("Sword2", new Vector2(96 * 1, 96), ItemCatergories.Weapon, 1);
            AddItemIcon("BattleAxe", new Vector2(96 * 2, 96), ItemCatergories.Weapon, 1);
            AddItemIcon("Mace", new Vector2(96 * 3, 96), ItemCatergories.Weapon, 1);
            AddItemIcon("Long Hammer", new Vector2(96 * 4, 96), ItemCatergories.Weapon, 1);
            AddItemIcon("Bow", new Vector2(96 * 5, 96), ItemCatergories.Weapon, 1);
            AddItemIcon("Quiver", new Vector2(96 * 6, 96), ItemCatergories.Weapon, 1);
            AddItemIcon("Arrow", new Vector2(96 * 7, 96), ItemCatergories.Item);

            // Row 2 spritesheet
            AddItemIcon("Axe", new Vector2(0, 96 * 2), ItemCatergories.Tool, 1);
            AddItemIcon("Pickaxe", new Vector2(96 * 1, 96 * 2), ItemCatergories.Tool, 1);
            AddItemIcon("Shovel", new Vector2(96 * 2, 96 * 2), ItemCatergories.Tool, 1);
            AddItemIcon("Hoe", new Vector2(96 * 3, 96 * 2), ItemCatergories.Tool, 1);
            AddItemIcon("Hammer", new Vector2(96 * 4, 96 * 2), ItemCatergories.Tool, 1);
            AddItemIcon("Chisel", new Vector2(96 * 5, 96 * 2), ItemCatergories.Tool, 1);
            AddItemIcon("Sickle", new Vector2(96 * 6, 96 * 2), ItemCatergories.Tool, 1);
            AddItemIcon("Workbench", new Vector2(96 * 7, 96 * 2), ItemCatergories.CraftingBench, 1);
            AddItemIcon("Anvil", new Vector2(96 * 8, 96 * 2), ItemCatergories.CraftingBench, 1);
            AddItemIcon("Grinder", new Vector2(96 * 9, 96 * 2), ItemCatergories.CraftingBench, 1);


            // Row 3 spritesheet
            AddItemIcon("Boards", new Vector2(0, 96 * 3), ItemCatergories.Item);
            AddItemIcon("Twigs", new Vector2(96 * 1, 96 * 3), ItemCatergories.Item);
            AddItemIcon("Hide", new Vector2(96 * 2, 96 * 3), ItemCatergories.Item);
            AddItemIcon("Rope", new Vector2(96 * 3, 96 * 3), ItemCatergories.Item);
            AddItemIcon("Coal", new Vector2(96 * 4, 96 * 3), ItemCatergories.Ore);
            AddItemIcon("Sulfur", new Vector2(96 * 5, 96 * 3), ItemCatergories.Ore);
            AddItemIcon("IronOre", new Vector2(96 * 6, 96 * 3), ItemCatergories.Ore);
            AddItemIcon("GoldOre", new Vector2(96 * 7, 96 * 3), ItemCatergories.Ore);
            AddItemIcon("IronDust", new Vector2(96 * 8, 96 * 3), ItemCatergories.Item);
            AddItemIcon("GoldDust", new Vector2(96 * 9, 96 * 3), ItemCatergories.Item);

            // Row 4 spritesheet
            AddItemIcon("Radish", new Vector2(0, 96 * 4), ItemCatergories.Food, 25);
            AddItemIcon("Potato", new Vector2(96 * 1, 96 * 4), ItemCatergories.Food, 25);
            AddItemIcon("Eggplant", new Vector2(96 * 2, 96 * 4), ItemCatergories.Food, 25);
            AddItemIcon("Carrot", new Vector2(96 * 3, 96 * 4), ItemCatergories.Food, 25);
            AddItemIcon("Mushroom Red", new Vector2(96 * 4, 96 * 4), ItemCatergories.Food, 25);
            AddItemIcon("Mushroom Brown", new Vector2(96 * 5, 96 * 4), ItemCatergories.Food, 25);
            AddItemIcon("Hay", new Vector2(96 * 6, 96 * 4), ItemCatergories.Food, 25);
            AddItemIcon("Meat", new Vector2(96 * 7, 96 * 4), ItemCatergories.Food, 25);
            AddItemIcon("Fish", new Vector2(96 * 8, 96 * 4), ItemCatergories.Food, 25);
            AddItemIcon("Bread", new Vector2(96 * 9, 96 * 4), ItemCatergories.Food, 25);

            // Row 5 spritesheet
            AddItemIcon("IronBlock", new Vector2(0, 96 * 5), ItemCatergories.Block);
            AddItemIcon("EmeraldBlock", new Vector2(96 * 1, 96 * 5), ItemCatergories.Block);
            AddItemIcon("DiamondBlock", new Vector2(96 * 2, 96 * 5), ItemCatergories.Block);
            AddItemIcon("TanzaniteBlock", new Vector2(96 * 3, 96 * 5), ItemCatergories.Block);
            AddItemIcon("Lapis lazuli", new Vector2(96 * 4, 96 * 5), ItemCatergories.Ore);
            AddItemIcon("Emerald", new Vector2(96 * 5, 96 * 5), ItemCatergories.Ore);
            AddItemIcon("Sapphire", new Vector2(96 * 6, 96 * 5), ItemCatergories.Ore);
            AddItemIcon("Ruby", new Vector2(96 * 7, 96 * 5), ItemCatergories.Ore);

            // Row 6 spritesheet
            AddItemIcon("IronIngot", new Vector2(0, 96 * 6), ItemCatergories.Ingot);
            AddItemIcon("GoldIngot", new Vector2(96 * 1, 96 * 6), ItemCatergories.Ingot);

            // Row 7 spiresheet
            AddItemIcon("Crate", new Vector2(0, 96 * 7), ItemCatergories.Container);
            AddItemIcon("Chest", new Vector2(96 * 1, 96 * 7), ItemCatergories.Container);
            AddItemIcon("Barrel", new Vector2(96 * 2, 96 * 7), ItemCatergories.Container);
            AddItemIcon("Bag", new Vector2(96 * 3, 96 * 7), ItemCatergories.Container);
            AddItemIcon("Bone", new Vector2(96 * 4, 96 * 7), ItemCatergories.Item);
        }

        private void AddItemIcon(string name, Vector2 topLeft, ItemCatergories category, int maxStackSize = 100)
        {
            _itemDefinitions.Add(name, new InventoryItemDefinition(name, topLeft, category, maxStackSize));
        }

        public bool ValidIndex(int index)
        {
            if (index < 0 || index >= MaxItemSlots)
            {
                return false;
            }
            return true;
        }


        public MoveOutcome TryMoveItem(int sourceIndex, int targetIndex)
        {
            // protect against situations and early out
            if (!ValidIndex(sourceIndex)
                || !ValidIndex(targetIndex)
                || sourceIndex == targetIndex)
            {
                return MoveOutcome.NoOp;
            }

            // NOTE: Logic for targetIndex being null should be done in the UI (this means the click was outside InventoryPanel or inside but not on a slot)

            // Nothing to move if the source of the move is empty
            if (PlayerInventory[sourceIndex] == null)
            {
                return MoveOutcome.NoOp;
            }

            // Is there an item here?
            if (PlayerInventory[targetIndex] == null)
            {
                // Dropped on empty slot
                PlayerInventory[targetIndex] = PlayerInventory[sourceIndex];
                PlayerInventory[sourceIndex] = null;
                return MoveOutcome.Moved;
            }

            var outcome = CombineTwoStacks(sourceIndex, targetIndex);
            if (outcome != MoveOutcome.UnknownCondition)
            {
                return outcome;
            }

            // Must be a simple swap
            var oldItem = PlayerInventory[targetIndex];
            PlayerInventory[targetIndex] = PlayerInventory[sourceIndex];
            PlayerInventory[sourceIndex] = oldItem;

            return MoveOutcome.Swapped;
        }

        public void SortInventoryBy(string sortKey)
        {
            // Default sort by name
            IOrderedEnumerable<InventoryItem> sortLogic =
                PlayerInventory[0..HotbarStartIndex]
                    .OrderBy(x => x == null) // Guard against empty objects and make sure they sort last
                    .ThenBy(x => x?.Name);

            if (sortKey == null || sortKey.ToLower() == "name")
            {
                // Do nothing, use default sort
            }
            else if (sortKey.ToLower() == "armortype")
            {
                // I actually don't have any armor items, so lets use tool here
                sortLogic = PlayerInventory[0..HotbarStartIndex]
                    .OrderBy(x => x == null)
                    .ThenBy(x => x is not null && ItemDefinitions[x.Name].ItemCategory != ItemCatergories.Tool)
                    .ThenBy(x => x is null ? Data.ItemCatergories.None : ItemDefinitions[x.Name].ItemCategory)
                    .ThenBy(x => x?.Name);
            }
            else if (sortKey.ToLower() == "weapontype")
            {
                sortLogic = PlayerInventory[0..HotbarStartIndex]
                    .OrderBy(x => x == null)
                    .ThenBy(x => x is not null && ItemDefinitions[x.Name].ItemCategory != ItemCatergories.Weapon)
                    .ThenBy(x => x is null ? Data.ItemCatergories.None : ItemDefinitions[x.Name].ItemCategory)
                    .ThenBy(x => x?.Name);
            }
            else if (sortKey.ToLower() == "itemstype")
            {
                sortLogic = PlayerInventory[0..HotbarStartIndex]
                    .OrderBy(x => x == null)
                    // Bool sorts false first, so anything that's a weapon or tool will sort last (true sorts last)
                    .ThenBy(x => x is not null
                        && (ItemDefinitions[x.Name].ItemCategory == ItemCatergories.Weapon
                            || ItemDefinitions[x.Name].ItemCategory == ItemCatergories.Tool))
                    .ThenBy(x => x is null ? Data.ItemCatergories.None : ItemDefinitions[x.Name].ItemCategory)
                    .ThenBy(x => x?.Name);
            }

            Array.Copy(sortLogic.ToArray(), 0, PlayerInventory, 0, HotbarStartIndex);
            CombineAndCompactInventory();
        }

        public void CombineAndCompactInventory()
        {
            int readPosition = 1;
            int writePosition = 0;
            bool keepCompacting = true;
            while (keepCompacting)
            {
                if (PlayerInventory[writePosition] == null && PlayerInventory[readPosition] == null)
                {
                    // if both slots are empty, lets push both slots forward 1
                    writePosition++;
                    readPosition++;
                }
                else if (PlayerInventory[writePosition] == null)
                {
                    // current write slot is empty, simply move next read item here
                    PlayerInventory[writePosition] = PlayerInventory[readPosition];
                    PlayerInventory[readPosition] = null;
                }
                else if (PlayerInventory[readPosition] == null)
                {
                    // If we are at the end with read, and it was null
                    // nothing else we can swap/combine/move, so end
                    if (readPosition < HotbarStartIndex - 1)
                    {
                        readPosition++;
                    }
                    else
                    {
                        keepCompacting = false;
                    }
                }
                else if (PlayerInventory[writePosition].Name == PlayerInventory[readPosition].Name)
                {
                    var readItemDef = ItemDefinitions[PlayerInventory[readPosition].Name];

                    // combine the items
                    if (readItemDef.IsStackable)
                    {
                        var outcome = CombineTwoStacks(readPosition, writePosition);
                        if (outcome == MoveOutcome.SourcePartiallyStacked || outcome == MoveOutcome.FullTargetStack)
                        {
                            // This item is maxed, move the write position
                            writePosition++;
                        }
                        else if (outcome == MoveOutcome.SourceStacked)
                        {
                            // read position was fully stacked into the write position
                            // unsure if write position is full
                            if (readPosition < HotbarStartIndex - 1)
                            {
                                readPosition++;
                            }
                            else
                            {
                                // If we are at the end with read, and it was null
                                // nothing else we can swap/combine/move, so end
                                keepCompacting = false;
                            }
                        }
                    }
                    else
                    {
                        // items are the same, but not stackable, bump by 1 position each
                        writePosition++;
                    }
                }
                else
                {
                    // Items are different, advance write ahead only
                    writePosition++;
                }

                if (writePosition == readPosition)
                {
                    readPosition++;
                }

                if (readPosition >= HotbarStartIndex - 1 &&
                    writePosition >= HotbarStartIndex - 1)
                {
                    keepCompacting = false;
                }
            }
        }

        private MoveOutcome CombineTwoStacks(int sourceIndex, int targetIndex)
        {
            // safety checks
            if (!ValidIndex(sourceIndex) || !ValidIndex(targetIndex))
            {
                return MoveOutcome.NoOp;
            }

            var sourceItem = PlayerInventory[sourceIndex];
            var targetItem = PlayerInventory[targetIndex];

            // Can't combine items if there are no items
            if (sourceItem == null)
            {
                return MoveOutcome.NoOp;
            }

            // This is the simple swap item to empty spot, shouldn't happen in TryMoveItem, might happen in CombineAndCompactInventory
            if (targetItem == null)
            {
                return MoveOutcome.UnknownCondition;
            }

            // Load singleton definitions for each (NOTE: You may want to guard against missing key lookup errors KeyNotFoundException)
            var targetItemDef = ItemDefinitions[targetItem.Name];
            var sourceItemDef = ItemDefinitions[sourceItem.Name];

            // Same same
            if (targetItem.Name == sourceItem.Name)
            {
                if (sourceItemDef.IsStackable)
                {
                    // Stack is already maxed, cancel drag
                    if (targetItem.Quantity >= targetItemDef.MaxStackSize)
                    {
                        return MoveOutcome.FullTargetStack;
                    }

                    // Combine stacks
                    if (targetItem.Quantity + sourceItem.Quantity > targetItemDef.MaxStackSize)
                    {
                        int takable = targetItemDef.MaxStackSize - targetItem.Quantity;
                        targetItem.Quantity += takable;
                        sourceItem.Quantity -= takable;
                        return MoveOutcome.SourcePartiallyStacked;
                    }
                    else
                    {
                        targetItem.Quantity += sourceItem.Quantity;
                        PlayerInventory[sourceIndex] = null;
                        return MoveOutcome.SourceStacked;
                    }
                }
            }

            return MoveOutcome.UnknownCondition;
        }
    }
}