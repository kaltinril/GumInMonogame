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

        public static GraphicalUiElement Root;
        private Gum.DataTypes.ScreenSave StageIntro;
        private Gum.DataTypes.ScreenSave GameScreenHud;

        string activeScreen = "StageIntro";

        Keys lastKeyDown = Keys.None;

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
                // This is relative to Content:
                "GumProject/GumProject.gumx");


            StageIntro = gumProject.Screens.Find(item => item.Name == "StageIntro");
            Root = StageIntro.ToGraphicalUiElement(RenderingLibrary.SystemManagers.Default, addToManagers: true);
            

            GameScreenHud = gumProject.Screens.Find(item => item.Name == "GameScreenHud");

            base.Initialize();  
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            MonoGameGum.GumService.Default.Update(this, gameTime);

            var convertedRoot = (MonogameGumScreen)Root;
            convertedRoot.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            MonoGameGum.GumService.Default.Draw();

            base.Draw(gameTime);
        }
    }
}
