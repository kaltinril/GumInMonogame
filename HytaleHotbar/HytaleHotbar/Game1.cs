using Gum.Forms;
using Gum.Forms.Controls;
using Gum.Managers;
using Gum.Wireframe;
using HytaleHotbar.Screens;
using HytaleHotbar.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameGum;
using RenderingLibrary;

namespace HytaleHotbar
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        GumService GumUI => GumService.Default;

        public static GameServiceContainer ServiceContainer { get; private set; }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 2400;
            _graphics.PreferredBackBufferHeight = 1300;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            ServiceContainer = Services; ServiceContainer = Services;
            Services.AddService<InventoryService>(new InventoryService());

            GumUI.Initialize(this, "HytaleGumProject/HytaleGumProject.gumx");

            // ZOOM IN but retain the same spots/perspective
            Camera camera = SystemManagers.Default.Renderer.Camera;
            camera.Zoom = 2.0f;
            GraphicalUiElement.CanvasWidth = _graphics.PreferredBackBufferWidth / camera.Zoom;
            GraphicalUiElement.CanvasHeight = _graphics.PreferredBackBufferHeight / camera.Zoom;

            var screen = ObjectFinder.Self.GumProjectSave.Screens[0].ToGraphicalUiElement();
            screen.AddToRoot();

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

            GumUI.Update(gameTime);

            foreach (var item in GumService.Default.Root.Children)
            {
                if (item is InteractiveGue asInteractiveGue)
                {
                    (asInteractiveGue.FormsControlAsObject as IUpdateScreen)?.Update(gameTime);
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            GumUI.Draw();

            base.Draw(gameTime);
        }
    }
}
