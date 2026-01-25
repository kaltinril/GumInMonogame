using Microsoft.Xna.Framework;

namespace HytaleHotbar.Data
{

    public enum ItemCatergories
    {
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
        public ItemCatergories ItemCatgegory { get; set; }

        public InventoryItemDefinition(string name, int top, int left, ItemCatergories category)
        {
            Name = name;
            TextureTopLeft = new Vector2(left, top);
            ItemCatgegory = category;
        }

        public InventoryItemDefinition(string name, Vector2 topLeft, ItemCatergories category)
        {
            Name = name;
            TextureTopLeft = topLeft;
            ItemCatgegory = category;
        }
    }
}