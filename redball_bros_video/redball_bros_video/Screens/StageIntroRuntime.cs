using Gum.Converters;
using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;

using RenderingLibrary.Graphics;

using System.Linq;

using MonoGameGum.GueDeriving;
using GumRuntime;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using redball_bros_video;
using redball_bros_video.Screens;
partial class StageIntroRuntime : Gum.Wireframe.BindableGue, MonogameGumScreen
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

        // Next Level simulation "Press enter"
        if (Keyboard.GetState().IsKeyDown(Keys.Enter))
        {
            // Clear old screen, find other screen, switch
            Game1.Root.RemoveFromManagers();
            var screen = ObjectFinder.Self.GumProjectSave.Screens.Find(item => item.Name == "GameScreenHud");
            Game1.Root = screen.ToGraphicalUiElement(RenderingLibrary.SystemManagers.Default, addToManagers: true);
        }
    }
}
