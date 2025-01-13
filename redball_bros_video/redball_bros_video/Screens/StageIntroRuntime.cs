using Gum.Managers;
using GumRuntime;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using redball_bros_video;
using redball_bros_video.Screens;

partial class StageIntroRuntime : Gum.Wireframe.BindableGue, IMonogameGumScreen
{
    int totalCoints = 0;
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
            Game1.Root.RemoveFromManagers();                // Clear old screen

            var screen = ObjectFinder.Self.GumProjectSave.Screens.Find(
                item => item.Name == "GameScreenHud");      // Find the other screen

            Game1.Root = screen.ToGraphicalUiElement(
                RenderingLibrary.SystemManagers.Default
                , addToManagers: true);                     // Switch the root out
        }
    }
}
