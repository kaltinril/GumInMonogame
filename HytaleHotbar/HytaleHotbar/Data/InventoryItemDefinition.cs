using Microsoft.Xna.Framework;

namespace HytaleHotbar.Data
{

    public enum ItemCatergories
    {
        None,
        Block,
        Container,
        CraftingBench,
        Food,
        Ingot,
        Item,
        Ore,
        Tool,
        Weapon,
    }

    public class InventoryItemDefinition
    {
        public string Name { get; set; }
        public Vector2 TextureTopLeft { get; set; }
        public ItemCatergories ItemCategory { get; set; }
        public int MaxStackSize { get; }
        public bool IsStackable => MaxStackSize > 1;

        public InventoryItemDefinition(string name, int top, int left, ItemCatergories category, int maxStackSize = 100)
        {
            Name = name;
            TextureTopLeft = new Vector2(left, top);
            ItemCategory = category;
            MaxStackSize = maxStackSize;
        }

        public InventoryItemDefinition(string name, Vector2 topLeft, ItemCatergories category, int maxStackSize = 100)
        {
            Name = name;
            TextureTopLeft = topLeft;
            ItemCategory = category;
            MaxStackSize = maxStackSize;
        }
    }
}