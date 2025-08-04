using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RenderingLibrary;
using StronglyTypedComponents.Components;
//using StronglyTypedComponents.Components.Custom;
using System.Diagnostics;

namespace StronglyTypedComponents
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        CharacterStatsRuntime Root;
        double timeSinceHealthRegen = 0;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            MonoGameGum.GumService.Default.Initialize(this, "gumDir/GumProj.gumx");

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Root = new CharacterStatsRuntime();
            Root.AddToManagers();

            Root.Health = 100;
            Root.Experience = 0;
            Root.Mana = 25;
            Root.Level = 1;
            Root.X = 20;
            Root.Y = 20;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MonoGameGum.GumService.Default.Update(this, gameTime, Root);

            timeSinceHealthRegen += gameTime.ElapsedGameTime.TotalSeconds;

            if (timeSinceHealthRegen >= 1)
            {
                Root.Health++;
                timeSinceHealthRegen -= 1;
            }


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
