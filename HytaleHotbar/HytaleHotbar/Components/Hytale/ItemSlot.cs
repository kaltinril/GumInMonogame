using Gum.Converters;
using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;
using HytaleHotbar.Components.Hytale.PIeces;
using HytaleHotbar.Data;
using Microsoft.Xna.Framework;
using RenderingLibrary.Graphics;

using System.Linq;

namespace HytaleHotbar.Components.Hytale
{
    partial class ItemSlot
    {
        public event System.EventHandler Click;

        partial void CustomInitialize()
        {
            this.Visual.Click += (_, args) => Click.Invoke(this, args);
        }

        public void SetSlotToItem(InventoryItem item, InventoryItemDefinition itemDef)
        {
            if (item == null || itemDef == null)
            {
                this.HasItemState = HasItem.False;
                this.HasDamageState = HasDamage.False;
                this.HasQuantityState = HasQuantity.False;

                return;
            }

            if (itemDef.ItemCatgegory == ItemCatergories.Weapon || itemDef.ItemCatgegory == ItemCatergories.Tool)
            {
                SetDurability(item.Durability);
                Quantity = "1";
                this.HasQuantityState = HasQuantity.False;
            }
            else
            {
                Quantity = item.Quantity.ToString();
                if (string.IsNullOrWhiteSpace(Quantity) || Quantity == "0" || Quantity == "1")
                {
                    this.HasQuantityState = HasQuantity.False;
                }
                else
                {
                    this.HasQuantityState = HasQuantity.True;
                }
            }

            this.Rarity = item.Rarity;

            // Pull static info from Item Definition
            this.IconLeft = (int)itemDef.TextureTopLeft.X;
            this.IconTop = (int)itemDef.TextureTopLeft.Y;
        }

        private void SetDurability(float duraility)
        {
            DurabilityRatio = duraility;

            if (DurabilityRatio < 100)
            {
                HasDamageState = ItemSlot.HasDamage.True;
                DurabilityRatio = DurabilityRatio;

                //Set to green
                DurabilityIndicatorInstance.ForegroundBar.Color = new Color(41, 142, 68);

                // Change color based on damage
                if (DurabilityRatio < 5)
                {
                    DurabilityIndicatorInstance.ForegroundBar.Color = Color.Red;
                }
                else if (DurabilityRatio < 25)
                {
                    DurabilityIndicatorInstance.ForegroundBar.Color = Color.Orange;
                }
                else if (DurabilityRatio < 50)
                {
                    DurabilityIndicatorInstance.ForegroundBar.Color = Color.Yellow;
                }
            }
            else
            {
                HasDamageState = ItemSlot.HasDamage.False;
                DurabilityRatio = 100;
            }
        }
    }
}
