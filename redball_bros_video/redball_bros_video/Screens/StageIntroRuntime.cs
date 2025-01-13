using Gum.Managers;
using GumRuntime;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using redball_bros_video;
using redball_bros_video.Screens;

partial class StageIntroRuntime : Gum.Wireframe.BindableGue, IMonogameGumScreen
{
    double inputDelaySeconds = 0.2;
    double currentDelaySeconds = 0.0;
    partial void CustomInitialize()
    {
    
    }

    public void Update(GameTime gameTime)
    {
        currentDelaySeconds += gameTime.ElapsedGameTime.TotalSeconds;

        // Delay so we don't jump back and forth between screens when pressing enter.
        if (currentDelaySeconds < inputDelaySeconds)
            return;

        // Next Level simulation "Press enter" to load the Game play screen UI
        if (Keyboard.GetState().IsKeyDown(Keys.Enter))
        {
            // 1. Clear old screen
            Game1.Root.RemoveFromManagers();

            // 2. Find the other screen
            var screen = ObjectFinder.Self.GumProjectSave.Screens.Find(
                item => item.Name == "GameScreenHud");

            // 3. Switch the root out to the other screen
            Game1.Root = screen.ToGraphicalUiElement(
                RenderingLibrary.SystemManagers.Default
                , addToManagers: true);
        }
    }
}
