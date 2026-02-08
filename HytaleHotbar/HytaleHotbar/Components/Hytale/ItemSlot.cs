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
        public event System.EventHandler Push;
        public event System.EventHandler RemovedAsPushed;
        public event System.EventHandler Dragging;

        partial void CustomInitialize()
        {
            this.Visual.Click += (_, args) => Click?.Invoke(this, args);
            this.Visual.Dragging += (_, args) => Dragging?.Invoke(this, args);
            this.Visual.Push += (_, args) => Push?.Invoke(this, args);
            this.Visual.RemovedAsPushed += (_, args) => RemovedAsPushed?.Invoke(this, args);
        }

        public void ClearSlot()
        {
            this.HasItemState = HasItem.False;
            this.IconLeft = 0;
            this.IconTop = 0;
            this.HasQuantityState = HasQuantity.False;
            this.Quantity = "0";
            this.Rarity = ItemRarityBackground.RarityCategory.None;
            this.HasDamageState = HasDamage.False;
            this.DurabilityRatio = 0;
            this.DurabilityIndicatorInstance.ForegroundBar.Color = Color.White;
        }

        public void HideSlot()
        {
            ItemIconInstance.IsVisible = false;
            DurabilityIndicatorInstance.IsVisible = false;
            QuantityTextInstance.Visible = false;
        }

        public void UnhideSlot()
        {
            ItemIconInstance.IsVisible = true;
            DurabilityIndicatorInstance.IsVisible = true;
            QuantityTextInstance.Visible = true;

            SetStatesFromValues(DurabilityRatio, Quantity);
        }

        public void SetSlotToSlot(ItemSlot itemSlot)
        {
            this.HasItemState = itemSlot.HasItemState;
            this.IconLeft = itemSlot.IconLeft;
            this.IconTop = itemSlot.IconTop;
            this.HasQuantityState = itemSlot.HasQuantityState;
            this.Quantity = itemSlot.Quantity;
            this.Rarity = itemSlot.Rarity;
            this.HasDamageState = itemSlot.HasDamageState;
            this.DurabilityRatio = itemSlot.DurabilityRatio;
            this.DurabilityIndicatorInstance.ForegroundBar.Color = itemSlot.DurabilityIndicatorInstance.ForegroundBar.Color;
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

            // Setup defaults
            this.HasItemState = HasItem.True;
            this.HasDamageState = HasDamage.False;
            this.HasQuantityState = HasQuantity.False;

            if (itemDef.ItemCategory == ItemCatergories.Weapon || itemDef.ItemCategory == ItemCatergories.Tool)
            {
                SetStatesFromValues(item.Durability, "1");
            }
            else
            {
                SetStatesFromValues(100, item.Quantity.ToString());
            }

            this.Rarity = item.Rarity;

            // Pull static info from Item Definition
            this.IconLeft = (int)itemDef.TextureTopLeft.X;
            this.IconTop = (int)itemDef.TextureTopLeft.Y;
        }

        private void SetStatesFromValues(float durabilityRatio, string quantity)
        {
            SetDurability(durabilityRatio);
            SetQuantity(quantity);
        }

        private void SetQuantity(string quantity)
        {
            Quantity = quantity;
            if (string.IsNullOrWhiteSpace(Quantity) || Quantity == "0" || Quantity == "1")
            {
                this.HasQuantityState = HasQuantity.False;
            }
            else
            {
                this.HasQuantityState = HasQuantity.True;
            }
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
