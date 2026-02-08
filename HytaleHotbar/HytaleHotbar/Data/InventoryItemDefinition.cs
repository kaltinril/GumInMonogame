using Microsoft.Xna.Framework;
using System.Runtime.InteropServices.Marshalling;

namespace HytaleHotbar.Data
{

    public enum ItemCatergories
    {
        None,
        Weapon,
        Tool,
        CraftingBench,
        Block,
        Ore,
        Ingot,
        Food,
        Container,
        Item
    }

    public class InventoryItemDefinition
    {
        public string Name { get; set; }
        public Vector2 TextureTopLeft { get; set; }
        public ItemCatergories ItemCategory { get; set; }
        public int MaxStackSize { get; set; }
        public bool IsStackable {  get; set; }

        public InventoryItemDefinition(string name, int top, int left, ItemCatergories category, int maxStackSize = 100)
        {
            Name = name;
            TextureTopLeft = new Vector2(left, top);
            ItemCategory = category;
            this.MaxStackSize = maxStackSize;

            if (MaxStackSize > 1)
            {
                IsStackable = true;
            }
        }

        public InventoryItemDefinition(string name, Vector2 topLeft, ItemCatergories category, int maxStackSize = 100)
        {
            Name = name;
            TextureTopLeft = topLeft;
            ItemCategory = category;
            this.MaxStackSize = maxStackSize;
            if (MaxStackSize > 1)
            {
                IsStackable = true;
            }
        }
    }
}

