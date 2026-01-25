# 1. Intro and Overview

Hey there everyone, welcome back.

Today we're going to wire up the Hotbar UI we made in the last video.  90% of this video will be us working in Monogame.

1. We'll be able to click or press buttons to change the selected hotbar item.
2. We'll add code so we can set a slot item
3. We'll add a button to our screen so we can randomly change the hotbar items.
4. We'll add a label so we can show how to retrieve information about the selected item

Code I'm using to make everything larger for the video
```csharp
// ZOOM IN but retain the same spots/perspective
Camera camera = SystemManagers.Default.Renderer.Camera;
camera.Zoom = 2.0f;
GraphicalUiElement.CanvasWidth = _graphics.PreferredBackBufferWidth / camera.Zoom;
GraphicalUiElement.CanvasHeight = _graphics.PreferredBackBufferHeight / camera.Zoom;
```

# 2. Gum Tool Work

First lets add in that button and label to the screen in Gum Tool

1. Open Gum tool and your project
2. Drag a Forms Component Button up to our Hotbar screen named `Randomize`
3. Drag a Forms Components Label up to our Hotbar screen named `StatusInfo`

Next, we need to update the ItemSlot.  Because we have such a complex component, we need to tell all the child elements to ignore events (like click).  Otherwise in code we won't be able to ever click on the "parent" Component because all the children components and elements will take focus.

1. Click on the ItemSlot
2. Scroll to the bottom of the Variables
3. Un-check Expose Children Events

Also, I forgot to Expose `QuantityTextInstance.Text` as `Quantity` up to the Parent ItemSlot Component in the previous video, lets do that now.
1. Open the Gum project, drill down to Components > Hytale > ItemSlot and click on QuantityTextInstance
2. Right-click on Text and Expose it as `Quantity`

Now when we click the ItemSlot the other components like ItemIconInstance won't eat the click causing no action in game.


Last change, lets update the Hotbar Slot Number on each ItemSlotInstance under the InnerStackPanel on the Hotbar so the values are 1-9. Alternatively if you wish you can do this in code.


Ok that's is for Gum, lets get over into monogame

# 3. Add per-frame updates on screens

We need to do a little work at add functionality so we can update things every frame inside our HotbarScreen.

1. Create a new interface in the Screens folder with the other class files (HotbarScreen.cs and HotbarScreen.Generated.cs)
2. Name it `IUpdateScreen.cs`
3. Make your interface class look like this (But with your project name instead)
    ```csharp
    using Microsoft.Xna.Framework;

    namespace YourProject.Screens;
    internal interface IUpdateScreen
    {
        void Update(GameTime gameTime);
    }
    ```
4. Update `HotbarScreen.cs` to implement the interface and define an empty Update method
    ```csharp
    public void Update(GameTime gameTime) { }
    ```
5. You'll probably need to add this Using statement:
    ```csharp
    using Microsoft.Xna.Framework;
    ```

Ok, now we can work on the ItemSlot selection for Mouse Clicks


# 4. Setup slot selection

Lets add some quick code just to see if we can get clicking to work

1. Jump over to the `Hotbar.cs` file in the `CustomInitialize` method add this
    ```csharp
    foreach (FrameworkElement child in InnerStackPanel.Children)
    {
        child.Visual.Click += HandleItemSlotClicked;
    }
    ```
2. Add the required `Using statement` for FrameworkElement
    ```csharp
    using Gum.Forms.Controls;
    ```
3. Create the `HandleItemSlotClicked` method
    ```csharp
    private void HandleItemSlotClicked(object sender, EventArgs e)
    {
        var frameworkEement = (sender as Gum.Wireframe.InteractiveGue).FormsControlAsObject;
        var itemSlot = (ItemSlot)frameworkEement;
        itemSlot.Selected = true;

        Debug.WriteLine($"Clicked {itemSlot.Name}");
    }
    ```

Ok, now when we run the project and click on a Slot, it should hightlight and print out the slot name.  However, if we click on a 2nd slot, the previous one remains.

Lets Make this better by keeping track of the selected index and setting the old one to unselected, we'll also add a convenience event handler on ItemSlot so working with it isn't as messy with casts all over the place.

First lets Update ItemSlot so it has it's own Click event.
1. Add this to the top of ItemSlot
    ```csharp
    public event System.EventHandler Click;
    ```
2. In `CustomInitialize`, Add a hook from the Visual's Click event, to our custom Click event handler using a simple Lambda function (or method if you want)
    ```csharp
    this.Visual.Click += (_, args) => Click.Invoke(this, args);
    ```


Now, lets go fix Hotbar so it uses the SelectedIndex
1. On the `HotBar.cs` Create a helper property "alias" (Typed indexer) we can use to get the slots.  This is just to make things shorter
    ```csharp
    public ItemSlot Slot(int i) => (ItemSlot)InnerStackPanel.Children[i];
    ```
2. Create a private variable and property for SelectedIndex
    ```csharp
    private int selectedIndex = -1;
    public int SelectedIndex
    {
        get => selectedIndex;
        set
        {
            if (selectedIndex != value)
            {
                // Clear previous selection
                if (selectedIndex != -1)
                {
                    Slot(selectedIndex).Selected = false;
                }

                selectedIndex = value;
                Slot(selectedIndex).Selected = true;
            }
        }
    }
    ```
3. Update the CustomInitialize foreach loop so we loop over ItemSlots and call their Click methods directly
    ```csharp
    foreach (ItemSlot child in InnerStackPanel.Children)
    {
        child.Click += HandleItemSlotClicked;
    }
    ```
4. Update HandleItemSlotClicked so it simply sets the SelectedIndex and that's it
    ```csharp
    private void HandleItemSlotClicked(object sender, EventArgs e)
    {
        ItemSlot itemSlot = (ItemSlot)sender;
        SelectedIndex = InnerStackPanel.Children.IndexOf(itemSlot);

        Debug.WriteLine($"Clicked {itemSlot.Name}"); // Optionally remove this debug now
    }
    ```
5. You'll also need to add this using statement for the IndexOf extension method
    ```csharp
    using MonoGameGum.ExtensionMethods;
    ```

Now when we run this, when we click on a slot, it will first set the previously selected slot visibility to false.


# 5. Lets add in pressing the 1-9 on the digit row

For now we'll simply create a method on `Hotbar` to handle the input, in the future you may have a more complex keyboard strategy.

1. Add a new method called `HandleKeyboardInput` to `Hotbar.cs`
    ```csharp
    internal void HandleKeyboardInput()
    {
        var keyboard = GumService.Default.Keyboard;
        int? indexToSelect = null;
        if (keyboard.KeyPushed(Keys.D1)) indexToSelect = 0;
        if (keyboard.KeyPushed(Keys.D2)) indexToSelect = 1;
        if (keyboard.KeyPushed(Keys.D3)) indexToSelect = 2;
        if (keyboard.KeyPushed(Keys.D4)) indexToSelect = 3;
        if (keyboard.KeyPushed(Keys.D5)) indexToSelect = 4;
        if (keyboard.KeyPushed(Keys.D6)) indexToSelect = 5;
        if (keyboard.KeyPushed(Keys.D7)) indexToSelect = 6;
        if (keyboard.KeyPushed(Keys.D8)) indexToSelect = 7;
        if (keyboard.KeyPushed(Keys.D9)) indexToSelect = 8;

        if (indexToSelect != null)
        {
            SelectedIndex = indexToSelect.Value;
        }
    }
    ```
2. We need to call this method from the Update method on the HotbarScreen every frame, so go add this to the Empty Update method we created earlier on `HotbarScreen.cs`
    ```csharp
    HotbarInstance.HandleKeyboardInput();
    ```
3. Now we need to update `Game1.cs` to call the HotbarScreen's Update method.  We'll do a little hackery dackery doo here for now.  Add this to the `Game1.Update` method.
    ```csharp
    foreach (var item in GumService.Default.Root.Children)
    {
        if (item is InteractiveGue asInteractiveGue)
        {
            (asInteractiveGue.FormsControlAsObject as IUpdateScreen)?.Update(gameTime);
        }
    }
    ```

Now when you run the game, you should be able to press the digits above the homerow (Not the number pad) to change the selected hotbar slot.


# 6. Setup Item Creation

Lets create a real Item class that we can pass into the slots to tell the slot what it should display.

1. Create a folder in the project called Data
2. Create a new class in Data called `InventoryItem` that is public
    ```csharp
    namespace YourProject.Data
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

            ublic ItemRarityBackground.RarityCategory Rarity;

            public InventoryItem(string name, int quantity, int durability, ItemRarityBackground.RarityCategory rarity)
            {
                Name = name;
                Quantity = quantity;
                Durability = durability;
                Rarity = rarity;
            }
        }
    }
    ```
3. You should notice you have an error on Rarity.  This is because I made InventoryItem public but all gum objects are created without a designator like public, private, or protected, which defaults them to Internal.  Since internal is more restrictive than Public we get this error. There are a few ways to fix this, we'll just do the easiest and make our ItemRarityBackground public also.  Open the `Components\Hytale\Pieces\ItemRarirtyBackground.cs` file (Not the generated one) and change it to the following.  This works because something less restrictive can always be made more restrictive without issues.  But not the other way around.
    ```csharp
    public partial class ItemRarityBackground
    ```
4. Create a 2nd class in Data called `InventoryItemDefinition` that will contain the non-changing attributes about an item like the sprite's top left, Item name, and Type like Tool or Weapon.
    ```csharp
    using Microsoft.Xna.Framework;

    namespace YourProject.Data
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
    ```
5. Create a folder in the project called `Services`
6. Create a new class in Services called `InventoryService`.  We'll use this to build up a dictionary of items as InventoryItemDefinition
7. Paste the following into it, adjust the items stored into the dictionary based on your spritesheet
    ```csharp
    using Microsoft.Xna.Framework;
    using YourProject.Components.Hytale;
    using YourProject.Data;
    using System.Collections.Generic;

    namespace YourProject.Services
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

    ```
8. Back in Game1 we need to keep track of the services and create this service, Add this variable to Game1.cs so we can access it from other components.
    ```csharp
    public static GameServiceContainer ServiceContainer { get; private set; }
    ```
9. Set the ServiceContainer in `Initialize` and create an instance of the inventory
    ```csharp
    ServiceContainer = Services;ServiceContainer = Services;
    Services.AddService<InventoryService>(new InventoryService());
    ```
10. Over in `HotbarScreen` Create a variable for the service and get access to it
    ```csharp
    InventoryService _inventoryService;
    ```
11. In `HotbarScreen` add this to the CustomInitialize() method
    ```csharp
    _inventoryService = Game1.ServiceContainer.GetService<InventoryService>();
    SetupRandomHotbar();
    ```
12. Create a method called `SetupRandomHotbar()` we can call in CustomInitialize
    ```csharp
    private void SetupRandomHotbar()
    {
        for (int i = 0; i < 9; i++)
        {
            SetSlotToRandomItem(HotbarInstance.Slot(i), i);
        }
    }
    ```
13. Add a reference to random at the top of HotbarScreen.cs
    ```csharp
    private static readonly Random _random = new Random();
    ```
14. Create the `SetSlotToRandomItem` method (Copy paste below)
    ```csharp
    private void SetSlotToRandomItem(ItemSlot slot, int index)
    {
        // Get the Definition for a random item
        var itemDictKV = _inventoryService.ItemDefinitions.ElementAt(_random.Next(_inventoryService.ItemDefinitions.Count));
        InventoryItemDefinition itemDef = itemDictKV.Value;

        // Pick a random rarity for it (excluding the first one "None")
        var values = Enum.GetValues<ItemRarityBackground.RarityCategory>();
        var randomEnumValue = values[_random.Next(values.Length - 1) + 1];

        // Create the inventory item with the values
        var item = new InventoryItem(itemDef.Name, _random.Next(64), _random.Next(100), randomEnumValue);

        // Update the inventory slot and the slot visual
        _inventoryService.PlayerInventory[_inventoryService.HotbarStartIndex + index] = item;
        slot.SetSlotToItem(item, itemDef);
    }
    ```
15. Now lets create the `SetSlotToItem` and `SetDurability` methods on `ItemSlot`
    ```csharp
    public void SetSlotToItem(InventoryItem item, InventoryItemDefinition itemDef)
    {
        if (item == null || itemDef == null) {
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
    ```
16. You may have to add some using statements
    ```csharp
    using YourProject.Components.Hytale.PIeces;
    using YourProject.Data;
    using Microsoft.Xna.Framework;
    ```

This was a lot, so lets run it to make sure it's working, nothing will appear to change, but it should compile and run without errors.


# 7. Configure the Button and Label

Ok now lets add 2 more things, code for the randomize button

1. Add this to `CustomInitialize` on `HotbarScreen.cs`
    ```csharp
    Randomize.Click += Randomize_Click;
    ```
2. And Create the method `Randomize_Click` as this
    ```csharp
    private void Randomize_Click(object sender, EventArgs e)
    {
        SetupRandomHotbar();
    }
    ```

Lets test this button.

Ok, and the last part is the configure the label.  We need a way to know when the Hotbar's SelectedIndex value has changed up in the HotbarScreen.  We could pole for this every frame, but that's a bit excessive.  Instead, we can use a custom event that is basically just a "call my function" we can subscribe to.

1. Add an event handler to `HotBar.cs`
    ```csharp
    public event EventHandler SelectedIndexChanged;
    ```
2. In the `SelectedIndex property's set`, at the end we need to invoke this event so anything listening for it will fire off.
    ```csharp
    SelectedIndexChanged?.Invoke(this, EventArgs.Empty);
    ```
3. Now back over in `HotbarScreen.cs`, we need to subscribe/listen to this event and write code that will run whenever that event is fired.  Add this to CustomInitialize()
    ```csharp
    HotbarInstance.SelectedIndexChanged += (_, _) =>
    {
        var index = HotbarInstance.SelectedIndex;
        var slotItem = HotbarInstance.Slot(index);
        var itemDef = _inventoryService.HotbarInventory(index);

        StatusInfo.Text = $"Selected index {HotbarInstance.SelectedIndex}\n@ {DateTime.Now}\n{slotItem.Quantity} {itemDef.Name}";
    };
    ```

Lets fire it up and test it out

# 8. Outro

Ok, I know this was a lot of code, but we now have full control to create new Item definitions, instances, and set those to a specific slot in the hotbar.  We also have an inventory service.  

All of this work is going to be reused in the Inventory video's coming up.  In-fact, those videos should be much shorter since we've already written the foundational code for our inventory system for the Hotbar.

Thank you for watching, stop by the discord, contribute on github, or comment below!

