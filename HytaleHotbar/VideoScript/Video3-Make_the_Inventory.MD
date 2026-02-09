# 1. Intro and Overview

Wow welcome back for the 3rd video.

Today we're going to use the Gum Tool again to make an inventory UI.  We'll use the `ItemSlot` we built in the last 2 videos.

I hope that by doing these to bring a few more of you from the CODE ONLY option of GUM over to the GUM TOOL that I enjoy.

Additionally, maybe it will help show how gum works better for others.

Here is what the Inventory UI will look like when we are done.  You can select items and change their position.  When we click on an item, we can see the details about it in a label to demonstrate how you could use this information in your game.

We'll make 4 Pieces, and then the Inventory Component.

I'm being very explicit in my names, if you want them to be shorter you can user shorter names like InvFilterButton or something.


# 2. Make the InventoryTitleBarIconButton

This is used for 3 icons that were in the preview video's that after playing hytale a few nights, for research, I still don't see in the inventory ui.  I can only assume one of three things.
1. The icons appear later in the game once I've unlocked things
2. There is a setting that enables the buttons
3. They were removed from the game UI before the beta launch.

Either way, we'll stick with the preview video from a month or so back for our work here, as it provides a good demo of some things to do in Gum.

1. Create a component called `InventoryTitleBarIconButton` under `Components/Hytale/Pieces`
2. Set the `Component's Width` to 20 with units of `Relative to Children`
3. Set the `Component's Height` to 5 with units of `Relative to Children`
4. Drag in a `Nineslice` and name it `Background`
5. Set the `Background` variable `Source File` to the `hytale.png` we used in the first video
6. Select the square background with the 2-3 pixel emtpy border at the top
7. Change all units/origin to center (Or click on the Alignment > Anchor > Middle)
8. Drag in a `Sprite` and name it `IconSprite`
9. Set the `IconSprite` variable `Source File` to the `hytale.png` we used in the first video
10. Set `Texture Address` to `Custom`
11. Select one of the small icons like the sword in the bottom left
12. Change all units/origin to center (Or click on the Alignment > Anchor > Middle)
13. Set the Color of the IconSprite to (178, 198, 210) RGB
14. Expose the `Texture Left` as `StartX`
15. Expose the `Texture Top` as `StartY`

Ok, thats our first Piece.  It should look like this.

![alt text](InventoryTitlebarIcon.png)


# 3. Make the InventoryTitleBarButton

We want to have Text that shows up centered with padding on either side, with the same titlebar background.

1. Create a new component named `InventoryAutoSortButton` under `Components/Hytale/Pieces`
2. Set the `Component's Width` to 20 with units of `Relative to Children`
3. Set the `Component's Height` to 0 with units of `Relative to Parent`
4. Scroll to the bottom of the variables and un-check `Expose Children Events`
5. Drag in a `Nineslice` and name it `Background`
6. Set the `Background` variable `Source File` to the `hytale.png`
7. Select the square background with the 2-3 pixel emtpy border at the top
8. Change all units/origin to center (Or click on the Alignment > Anchor > Middle)
9. Expose the `Texture Left` as `BackgroundStartX`
10. Expose the `Texture Top` as `BackgroundStartY`
11. Drag in a `Text` and name it `TextInstance`
12. Set the X value to 20
13. Set the Y units and origin to Center
14. Set the Text to "AUTOSORT"
15. `Expose` the Text as `Text`
16. Make the font BOLD, size 18
17. Set the Color of the IconSprite to (178, 198, 210) RGB

It's going to look weird and fill the entire area top to bottom, but once we put it into the Titlebar it will look fine.

![alt text](InventoryTitleBarButton.png)

# 4. Make the InventoryTitleBar

1. Create a new component named `InventoryTitleBar`
2. Set it's width to 960
3. Set it's height units to children
4. Add a `NineSlice` and name it `OutsidePanel`
5. Set the `Background` variable `Source File` to the `hytale.png`
6. Select the dark double-rounded square background
7. Add a `Forms StackPanel` and name it `StackPanelInstance` (Ran out of good name ideas)
8. Set it's `Width Units` to `Parent`
9. Set it's `Height Units` to `Children`
10. Set it's `Children Layout` to `Left-To-Right stack`
11. Set it's `Stack Spacing` to `1`
12. Drag an instance of TitleBarButton and name it `Title`
13. Set the Title element to 1 width with unit of ratio of parent
14. Change the Title's text to `INVENTORY`
15. Drag 3 instances of TitleBarIconButton and name them `FilterWeapons`, `FilterArmor`, and `FilterItems`
16. Drag an instance of TitleBarButton and name it `Autosort`
17. Being a bit lazy here, drag another instance of TitleBarButton and name it `ChangeSort`
18. Set it's text to the capital letter "V" to fake a down arrow (Again being lazy here)  Alternatively you could add a down arrow icon, update the InventoryTitleBarIconButton to expose it's background x and y so you can change that instead if you want a better looking down arrow.  Or, you could make another Component Piece.

That's it, now you should have what looks like an actual titlebar for the Inventory.

![alt text](InventoryTitleBar.png)


# 5. Make the InventoryUI

Alright, last one, lets make the Inventory now.

1. Add a Component to `/Components/Hytale/` called `InventoryPanel` or `InventoryUI` your choice
2. Set the Width and Hight units to Children
3. Set the Children Layout to Stack top-to-bottom
4. Drag the InventoryTitleBar onto it to create an instance named `InventoryTitleBarInstance`
5. Add a Standard Container and name it `MainContainer`
6. Set Width Units to Parent
7. Set Height to 20 and Units to Children
8. Add a Nineslice and name it `Background`
9. Set the `Background` variable `Source File` to the `hytale.png`
10. Set the units to all left/top
11. Chose the Inventory Background spirte
12. Add a Forms StackPanel
13. Set Y to 20
14. Set X units and Origin to Center
15. Set width and Height units to Children
16. Set Children Layout to Grid
17. Set Stack Spacing to 7
18. Set Auto Grid Horiztonal Cells to 9
19. Set Auto Grid Vertical Cells to 5
20. Add a single ItemSlot 
21. Copy and paste this so you have a total of 9*5 = 45 total instances of ItemSlot.
22. Rename the first one from `ItemSlotInstance` to `ItemSlotInstance45` so you have names ItemSlotInstance1 through ItemSlotInstance45
23. Drag or move the `ItemSlotInstance45` to the end of the list

That's it, now you should have a Hytale looking inventory

![alt text](InventoryPanel.png)

# 6. Outro

Well, that's it for this video.  I'll save all the monogame work for the final video 4

Until next time, have a good one.
