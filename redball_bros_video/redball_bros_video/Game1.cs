using Gum.Wireframe;
using GumRuntime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using redball_bros_video.Screens;

namespace redball_bros_video
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Add a root object we can change out from other classes
        public static GraphicalUiElement Root;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            var gumProject = MonoGameGum.GumService.Default.Initialize(
                this.GraphicsDevice,
                "GumProject/GumProject.gumx");      // This is relative to Content directory

            // Get the StageIntro screen, then convert that data into the Graphical UI layout
            Gum.DataTypes.ScreenSave stageIntro = gumProject.Screens.Find(item => item.Name == "StageIntro");
            Root = stageIntro.ToGraphicalUiElement(RenderingLibrary.SystemManagers.Default, addToManagers: true);

            base.Initialize();  
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Update all components as needed
            MonoGameGum.GumService.Default.Update(this, gameTime);

            // To create a common method on both "Screen" classes we create an interface
            // and then each screen implements the interface (MonogameGumScreen)
            // This allows us to call Update on them
            var convertedRoot = (IMonogameGumScreen)Root;
            convertedRoot.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Draw all components that Gum is aware of (Root)
            MonoGameGum.GumService.Default.Draw();

            base.Draw(gameTime);
        }
    }
}
