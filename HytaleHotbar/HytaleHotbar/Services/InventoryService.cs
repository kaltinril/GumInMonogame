using HytaleHotbar.Data;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using HytaleHotbar.Components.Hytale;


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

        public InventoryService()
        {
            SetupItemIconPositions();
        }

        private void SetupItemIconPositions()
        {
            _itemDefinitions = new Dictionary<string, InventoryItemDefinition>();

            // Row 1 spritesheet
            AddItemIcon("Sword", new Vector2(0, 96), ItemCatergories.Weapon);
            AddItemIcon("Sword2", new Vector2(96 * 1, 96), ItemCatergories.Weapon);
            AddItemIcon("BattleAxe", new Vector2(96 * 2, 96), ItemCatergories.Weapon);
            AddItemIcon("Mace", new Vector2(96 * 3, 96), ItemCatergories.Weapon);
            AddItemIcon("Long Hammer", new Vector2(96 * 4, 96), ItemCatergories.Weapon);
            AddItemIcon("Bow", new Vector2(96 * 5, 96), ItemCatergories.Weapon);
            AddItemIcon("Quiver", new Vector2(96 * 6, 96), ItemCatergories.Weapon);
            AddItemIcon("Arrow", new Vector2(96 * 7, 96), ItemCatergories.Item);

            // Row 2 spritesheet
            AddItemIcon("Axe", new Vector2(0, 96 * 2), ItemCatergories.Tool);
            AddItemIcon("Pickaxe", new Vector2(96 * 1, 96 * 2), ItemCatergories.Tool);
            AddItemIcon("Shovel", new Vector2(96 * 2, 96 * 2), ItemCatergories.Tool);
            AddItemIcon("Hoe", new Vector2(96 * 3, 96 * 2), ItemCatergories.Tool);
            AddItemIcon("Hammer", new Vector2(96 * 4, 96 * 2), ItemCatergories.Tool);
            AddItemIcon("Chisel", new Vector2(96 * 5, 96 * 2), ItemCatergories.Tool);
            AddItemIcon("Sickle", new Vector2(96 * 6, 96 * 2), ItemCatergories.Tool);
            AddItemIcon("Workbench", new Vector2(96 * 7, 96 * 2), ItemCatergories.CraftingBench);
            AddItemIcon("Anvil", new Vector2(96 * 8, 96 * 2), ItemCatergories.CraftingBench);
            AddItemIcon("Grinder", new Vector2(96 * 9, 96 * 2), ItemCatergories.CraftingBench);


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
            AddItemIcon("Radish", new Vector2(0, 96 * 4), ItemCatergories.Food);
            AddItemIcon("Potato", new Vector2(96 * 1, 96 * 4), ItemCatergories.Food);
            AddItemIcon("Eggplant", new Vector2(96 * 2, 96 * 4), ItemCatergories.Food);
            AddItemIcon("Carrot", new Vector2(96 * 3, 96 * 4), ItemCatergories.Food);
            AddItemIcon("Mushroom Red", new Vector2(96 * 4, 96 * 4), ItemCatergories.Food);
            AddItemIcon("Mushroom Brown", new Vector2(96 * 5, 96 * 4), ItemCatergories.Food);
            AddItemIcon("Hay", new Vector2(96 * 6, 96 * 4), ItemCatergories.Food);
            AddItemIcon("Meat", new Vector2(96 * 7, 96 * 4), ItemCatergories.Food);
            AddItemIcon("Fish", new Vector2(96 * 8, 96 * 4), ItemCatergories.Food);
            AddItemIcon("Bread", new Vector2(96 * 9, 96 * 4), ItemCatergories.Food);

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

        private void AddItemIcon(string name, Vector2 topLeft, ItemCatergories category)
        {
            _itemDefinitions.Add(name, new InventoryItemDefinition(name, topLeft, category));
        }
    }
}