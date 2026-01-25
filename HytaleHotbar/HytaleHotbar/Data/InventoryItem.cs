using FlatRedBall.Glue.StateInterpolation;
using HytaleHotbar.Components.Hytale.PIeces;

namespace HytaleHotbar.Data
{
    public class InventoryItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        private int _durability;
        public int Durability
        {
            get
            {
                return _durability;
            }
            set
            {
                if (value > 100)
                {
                    _durability = 100;
                }
                else if (value < 0)
                {
                    _durability = 0;
                }
                else
                {
                    _durability = value;
                }
            }
        }

        public ItemRarityBackground.RarityCategory Rarity;

        public InventoryItem(string name, int quantity, int durability, ItemRarityBackground.RarityCategory rarity)
        {
            Name = name;
            Quantity = quantity;
            Durability = durability;
            Rarity = rarity;
        }
    }
}