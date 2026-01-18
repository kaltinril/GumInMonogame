
# 1. Intro and Overview
Welcome everyone.  This will be a longer video so please use the chapters to jump around if you already know something.

Today is video 1 in a 4-part mini-series on making UI with GUM in MonogGame.

Specifically we're going to make the Hytale UI from the In Progress video they released a month back.  Now I did notice some things when I played Hytale that are different, or that I didn't understand from the preview videos they released.  So, it's not 100% identical to Hytale when it went live on the 13th of January.

The four parts will be:
1. Making a hotbar in GUM
2. Getting the hotbar working in Monogame
3. Making the inventory system in GUM
4. Getting the inventory system working in Monogame.

I've already built the systems in GUM and Monogame, and I'll be recording videos for these and releasing them one per week.

Follow along while we explore the UI of Hytale using our Custom code in GUM and Monogame.

We will be using the Gum Tool so that we can layout our elements visually to get a really nice match to the reference image from the video.  I prefer using Gum Tool over code only, but you can also use code only if you wish.  If you do, I welcome you to make your own video and link it in the comments.

# 2. Creating a blank MonoGame project

To make things easier in the Gum Tool, it's nice to have an existing Monogame project already.

This isn't a full tutorial on downloading and installing VS or Monogame, for that see my Monogame basics part 1 video https://www.youtube.com/watch?v=F1Sj14ccuBQ

## 2.1 Create a new project

1. Open Visual Studio (2026)
2. Click Create a new project
3. Search for the appropriate monogame template, I'll select the Cross-Platform Desktop application.
4. Name and save the project
5. Click Play to make sure it works.

Blue screen should be displayed.

## 2.2 Setup your VS Project to use the Gum NUGET package

1. Tools > Nuget Package Manager > Manage Nuget Packages for Solution
2. Click on the Browser tab and search for gum.monogame
3. Checkmark your project on the right, and click Install
4. Click Play to make sure it works.

You should see the blue screen again, excellent, now lets move into the Gum Tool.

# 3. Setup Gum Tool project

## 3.1 Create the Blank Gum Project
Again, this isn't a full tutorial on everything, so for installing the gum tool, look at my other video Gum: Part 1 - Overview and install.  Note that XNA Is no longer required and the basic steps are, download the latest, unzip, run the executable.  https://www.youtube.com/watch?v=RslyJq8oNkw

1. Open gum
2. Create a new project (File > New Project)
Hold up, this is important.  We want to save the project into the Monogame projects Content folder.
3. A quick way to snag the path is back in Visual Studio, right click a file like Game1.cs and chose Open in File Explorer, now just Copy the PATH from the URL bar at the top.
4. Back in Gum Tool, paste the folder path into the URL bar at the top and hit ENTER (It should take you to the project folder)
5. Navigate down into the Content folder
6. Create a sub-folder for your Gum Project (HytaleGumProject)
7. Name and save your project (HytaleGumProject) should be good enough

Now we have a blank project.

## 3.2 Add Forms Components

We won't be using many for this video, but they provide a lot of functionality for you out-of-the box, so you might as well include them.
1. Content > Add Forms Components
2. Do not include the demo screen, and click Ok.

Now you should have some Controls and Elements under Components, including a Styles component.  This also slightly modifies the standard elements, and creates a lot of behaviors we won't go into now.

## 3.3 Setup GUM Tool Code Generation

To do the setup in Gum Tool, we need a custom element or screen.  We don't need all those forms controls just yet so lets not use one of those.

1. Create a new screen called "HotbarScreen"
2. Click on the new screen, and go to the Code tab in the bottom right
3. Click Auto under Code Generation Setup
4. Gum automatically tries to identify the project, and it should work if you placed the project into the content folder like I suggested earlier.
5. Test it out, on the HotbarScreen, click Generate on the code tab.

Notice that back in the visual studio project, there is now a Screens folder with 2 class files:
 - HotbarScreen.cs - HotbarScreen.cs is the file we can add custom functionality into.
 - HotbarScreen.Generated.cs  - We won't ever manually edit the Generated file, Gum Tool does that for us.

## 3.4 Setup Visual Studio to find Gum files.

We need to setup Monogame and Visual Studio so that all the Gum Project files can be loaded as needed.

1. Over in Visual Studio, navigate down in VS project > Content > HytaleGumProject > and single left-click on HytaleGumProject.gumx
2. Under the properties window, update Copy to Output Directory to "Copy if Newer"
3. Double-click on your Project name in the Solution Explorer to open the XML of the project definition.
4. Find the section that shows `<None Update="Content\HytaleGumProject\HytaleGumProject.gumx">`
5. Change this to `<None Update="Content\HytaleGumProject\**\*.*">`

Now any files in your Gum Tool project will be copied to the output directory so we have access to them.

# 4. Making the ItemSlot in Gum Tool

First, to make things easier in code later, we're going to make a bunch of Pieces for our components.

As can can see from this image from the UI we end up building, we need 6 parts
1. Background
2. ItemIcon
3. SlotNumber (For the hotbar)
4. DurabilityBar
5. Quantity
6. Highlight


## 4.1 Create folder structure
1. Create a new folder under Components called Hytale
2. Create a new folder under Hytale called Pieces

Thats all the Component pieces we are going to create, the rest will be standard elements.


## 4.2 Add your custom sprite sheet

I've purchased or downloaded free assets from Kenney.nl, itch.io, and OpenGameArt.org for this video.

https://maellemarylloup.itch.io/tools-weapons-icons
https://jordanholmes.itch.io/free-blacksmith-tool-set-pbr-textures-included
https://free-game-assets.itch.io/50-rpg-mining-icons
https://free-game-assets.itch.io/free-rpg-hunting-game-512512-icons
https://free-game-assets.itch.io/rpg-vegetable-game-icons
https://free-game-assets.itch.io/high-quality-rpg-loot-icons
https://free-game-assets.itch.io/rpg-kobold-loot-icons
https://free-game-assets.itch.io/pirate-loot-vector-rpg-icons
https://opengameart.org/content/idylwilds-inventory
https://kenney.nl/assets/survival-kit
https://nikoichu.itch.io/pixel-icons

I created a combined spritesheet (Note you'll have to download or acquire each of these assets or use your own spritesheet).

1. Right-click on the Hytale folder you created and chose `View in Explorer`
2. Copy your spritesheet into the folder, I named mine `hytale.png`

NOTE: This is optional, you could put it somewhere else if you wish, but it's nice to have it near the gum components


## 4.3 Build the `ItemIcon`

Lets build each piece before we try to build the `ItemSlot` as a whole.

1. Create a new component under Pieces named `ItemIcon`
2. Add a standard `Sprite` element to `ItemIcon`
3. Set the `Source file` to your png file you copied into the folder
4. Set the `Texture Address` to Custom and use the `Texture Coordinates` screen to select something like a sword or pickaxe for now.
5. Change the width/height and units to 0 with relative to parent.  This will allow us to "Scale" the image automatically if we make the component larger.
6. Set the parent `ItemIcon` size to 96x96 (or whatever your sprites are)
7. Expose `Texture Left` as "IconLeft"
8. Expose `Texture Top` as "IconTop"

This one was pretty easy, just a single Standard Element Sprite under it.  This seems weird, but we are doing this component wrapper so we can work with it in code easier.  Additionally we can all custom functionality to the ItemIcon in the future if we wish and it will flow down into the ItemSlot.


## 4.4 Build the SlotNumber

1. Create another component under Pieces named `SlotNumber`
2. Set the SlotNumber to 25x25 (width/height)
3. Add a `NineSlice`standard element to the `SlotNumber` component under pieces and name this `Background`.     (Alternatively you can chose sprite or a colored rectangle)
4. Add a `Text` standard element to the `SlotNumber` component and name this `SlotNumberText`.
5. For the background NineSlice, again I'm changing the Source File to my png, and selecting the region for the slot number background
6. I'll do the same thing with 0 (width/height) with Relative to parent size units.
7. For the `SlotNumberText` Set all units to center values.
8. I set the font size to 14 and left it at arial, you can get creative here if you'd like.
9. Set the ColorCategory to Gray
10. Lets expose the Text variable up to the component (Right-click Text and select Expose Variable and Name it Text).  This will make it easier to access the TEXT variable without needing to go down deep into children of the Component.  You can see on the Component it's now exposed as Text
11. Put a value like 6 in so it isn't showing Hello text


## 4.5 Build the DurabilityIndicator

1. Create another component under Pieces named `DurabilityIndicator`
2. Add 2 `ColoredRectangles` named `BackgroundBar` and `ForegroundBar`
3. Set both width and height on both ColoredRectangles to 100 (% of parent)
4. Set BackgroundBar to the color Black
5. Set ForegroundBar to some sort of green color  (41, 142, 68) #2A8E44
6. Set the Parent `DurabilityIndicator` width to 76 and height to 2
7. Expose the ForegroundBar.width value as "DurabilityRatio".  Again this makes it easier in code


## 4.6 Build the ItemRarityBackground

### 4.6.1 Build the basics of the component
In hytale, items can have rarity like None, Common, uncommon, Rare, epic, and legendary.  Each tints the item in the hotbar or inventory slightly.

We'll create a component with these different rarities built into it as a category with states

1. Create the component under Pieces and name it `ItemRarityBackground`
2. Add a `NineSlice` standard element or Sprite to it and name it `Background`
3. Set the Components Width and Height to 96
4. For the Background set the Source File to our png spritesheet again
5. Select the First empty Blue box background

### 4.6.2 Add categories and states

We want to be able to easily change the rarity without manually manipulating colors so lets build some states.
1. Right-click in the Category and States panel and chose Add Category, name it `RarityCategory`
2. Add the 6 states (None, Common, uncommon, Rare, epic, and legendary) by right-clicking the Category and showing Add State
3. For none, we want to select the same Background as default
4. For Common, leave the color at white with #89B6EC
5. For Uncommon, set the color to a very white greenish color #D9FFD1
6. For Rare, set the color to a very white blueish color #778AFF
7. For Epic, set the color to a very white purpleish color #D394FF
8. For Legendary, set the color to a very white goldish color #FFEC7E
9. For all states except None, set the Texture to the greyscale sprite on the spritesheet so we can tint it


## 4.7 Now lets build the ItemSlot from all the components

1. Under Hytale, create a component called `ItemSlot`
2. Set the width and height to 96x96 or whatever your sprite size is

### 4.7.1 Setup the background
1. Add an `ItemRarityBackground` and name it `ItemRarityBackgroundInstance`
2. Expose the Rarity Category State as simply Rarity

### 4.7.2 Setup the ItemIcon
We'll handle changing the images in code for this instead of by states like with the Background.

1. Add an `ItemIcon` and name it `ItemIconInstance`
2. Expose the IconLeft and IconTop again so they bubble up to the ItemSlot component

### 4.7.3 Setup the SlotNumber
1. Add an `SlotNumber` and name it `SlotNumberInstance`
2. Expose Text as HotbarSlotNumber

### 4.7.4 Setup the Durability indicator
1. Add an `DurabilityIndicator` and name it `DurabilityIndicatorInstance`
2. Set the XUnits to Pixels from Center
3. Set the XOrigin to Center
4. Set the YUnits to Pixels from Bottom
5. Set the YOrigin to Bottom
6. Set the Y value to -5
7. Expose the DurabiltyRatio up again to the parent container

### 4.7.5 Setup the Quantity Text
1. Add a `Text` standard element and name it `QuantityTextInstance`
2. Set the XUnits to Pixels from Right
3. Set the XOrigin to Right
4. Set the YUnits to Pixels from Bottom
5. Set the YOrigin to Bottom
6. Set the X and Y values to -5 each
7. Change the font to something like Times New Roman size 18, BOLD
8. Set the Text to a number like 54

### 4.7.6 Setup the Highlight indicator

We want this to be just outside the item slot

1. Add a `NineSlice` standard element and name it `HighlightIndicator`
2. Set the Source File to the PNG we've been using
3. Pick the Yellow border for the Texture
4. Set the XUnits to Pixels from Left
5. Set the XOrigin to Left
6. Set the YUnits to Pixels from Top
7. Set the YOrigin to Top
8. Set the X and Y values to -5 each
9. Set the X and Y to -5
10. Set the width and height to 10
11. Expose the Text as Quantity
12. Set Visibility to False

### 4.7.7 Setup category and states

To make things easier for us, we can setup categories with TRUE/FALSE values that we can set in code.  Mostly we're just hiding things so we "COULD" just set Visilibty in code to false, but the category helps make code more readable for intention.

1. Add the following Categories (HasItem, HasDamage, HasQuantity, IsOnHotbar), with 2 states in each (True/False)
2. For HasItem.False: 
    Set ItemIconInstance.Visible = False
    Set ItemRarityBackgroundInstance.RarityCategory = None
3. For HasDamage.False:
    Set DurabilityIndicatorInstance.Visible = False
4. For HasQuantity.False:
    Set QuantityTextInstance.Visible = False
5. For IsOnHotbar.False:
    Set SlotNumberInstance.Visible = False

You can see how you can easily add other functionality by adding categories and states.  Just be careful if you have multiple states in different categories setting different values for the same variables.

Alternatively we could have exposed the Visible variable on some as the name of the category.  Doing it this way future proofs if we need to add more functionality for a specific state.

# 5 Create the Hotbar

Now that we've got a well made Component we can reuse, lets build the hotbar finally.

1. Create a new Component under Hytale called `Hotbar`
2. Add a forms `StackPanel` control and name it "InnerStackPanel"
3. Set the InnerStackPanel Width and Height equal to 0 relative to children
4. Set the InnerStackPanel ChildrenLayout to Left to Right Stack with a spacing of 7
5. Add 10 instances of ItemSlot into the InnerStackPanel
6. Delete the first instance named `ItemSlotInstance` so we are left with 1-9
7. Set the Hotbar component's Width and Height equal to 0 relative to children
8. Set the Alignment to Bottom Middle
9. Set the Y to -20 so the hotbar isn't at the exact bottom


# 6 Quick Preview in Monogame (Gum Initial Setup)

Lets do some small code to show this in monogame.

You'll need to do the steps for initializing gum and loading a project
https://docs.flatredball.com/gum/code/getting-started/setup/loading-a-gum-project-.gumx
and some code from 
https://docs.flatredball.com/gum/code/getting-started/setup/adding-initializing-gum/monogame-kni-fna

1. Add the Hotbar as an instance on the HoatBarScreen
2. Go to visual studio
3. Add the following using statements the Game1 class
    - `using MonoGameGum;`
    - `using Gum.Forms;`
    - `using Gum.Forms.Controls;`
4. Add this variable to the Game1 class
    - `GumService GumUI => GumService.Default;`
5. Load the Gum Project in the Initialize method in Game1
    - `GumUI.Initialize(this, "HytaleGumProject/HytaleGumProject.gumx");`
6. Make sure Gum can update positioning, add this line to the Update method in Game1
    - `GumUI.Update(gameTime);`
7. Make sure Gum can draw it's UI, add this line to the Draw method in Game1
    - `GumUI.Draw();`

Ok, if you correclty set the screen and component up, correctly configured the project to copy your files to the output, you should be able to run your project and see the hotbar in monogame.

Notice we can't see the entire thing, this is because the screensize for Monogame by default is very small.  Lets increase it slightly.

In the Game1's Constructor, add this below the _graphics variable instantiation.
```csharp
_graphics.PreferredBackBufferWidth = 1280;
_graphics.PreferredBackBufferHeight = 720;
```

# 7 Review and Outro

Ok, that is the component built and displayed in Monogame.  This video turned into a longer video than I planned so I'm splitting the Component building, and Monogame implementation into 2 videos.

Let me know if you like that or not.

In the next video will cover how to add functionality to this component so we can change items in slots including attributes like quantity, durability, and rarity.

The video after will be how to build the Inventory UI in Gum Tool, followed by the implementation in Monogame.

