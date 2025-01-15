using Gum.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using redball_bros_video;
using GumRuntime;
using redball_bros_video.Screens;

partial class GameScreenHudRuntime : Gum.Wireframe.BindableGue, IMonogameGumScreen
{
    int totalCoins = 0;
    int totalPoints = 0;
    double inputDelaySeconds = 0.2;
    double currentDelaySeconds = 0.0;
    int secondsRemaining = 400;
    partial void CustomInitialize()
    {
        this.CoinsNumber.Text = totalCoins.ToString();
    }

    public void Update(GameTime gameTime)
    {
        currentDelaySeconds += gameTime.ElapsedGameTime.TotalSeconds;

        // NES seconds were calculated at about 1 "time" unit per 24 frames
        double nesConversionRatio = 60.0d/ 24.0d;
        double convertedSecondsPassed = (gameTime.TotalGameTime.TotalSeconds * nesConversionRatio);
        int nesSecondsToDisplay = (int)(secondsRemaining - convertedSecondsPassed);
        this.TimeNumber.Text = (nesSecondsToDisplay).ToString("D3");

        // Delay so we don't jump back and forth between screens when pressing enter.
        if (currentDelaySeconds < inputDelaySeconds)
            return;

        // Next Level simulation "Press enter"
        if (Keyboard.GetState().IsKeyDown(Keys.Enter))
        {
            Game1.Root.RemoveFromManagers();

            var screen = ObjectFinder.Self.GumProjectSave.Screens.Find(item => item.Name == "StageIntro");
            Game1.Root = screen.ToGraphicalUiElement(RenderingLibrary.SystemManagers.Default, addToManagers: true);
        }

        // Simulate coin gathered
        if (Keyboard.GetState().IsKeyDown(Keys.C))
        {
            totalCoins++;
            this.CoinsNumber.Text = totalCoins.ToString();
        }

        // Simulate points gained
        if (Keyboard.GetState().IsKeyDown(Keys.P))
        {
            totalPoints += 5;
            this.FRBPoints.Text = ((int)totalPoints).ToString("D6");
        }
    }
}
