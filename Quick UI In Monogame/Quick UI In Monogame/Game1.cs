using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameGum;
using MonoGameGum.Forms.Controls;
using MonoGameGum.GueDeriving;

namespace Quick_UI_In_Monogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        GumService Gum => GumService.Default;
        StackPanel mainPanel;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Gum.Initialize(this);

            SetupMainMenu();

            base.Initialize();
        }

        private void SetupMainMenu()
        {
            Gum.Root.Children.Clear();

            mainPanel = new StackPanel();
            mainPanel.Visual.AddToRoot();
            mainPanel.Spacing = 3;
            mainPanel.Anchor(Anchor.Center);

            var pickPlayers = new Button();
            pickPlayers.Text = "Play My Game";
            pickPlayers.Visual.Width = 200;
            pickPlayers.Click += PickPlayersButton_Click;
            //StyleButton(pickPlayers);
            mainPanel.AddChild(pickPlayers);

            var optionsButton = new Button();
            optionsButton.Text = "Options";
            optionsButton.Visual.Width = 200;
            optionsButton.Click += OptionsButton_Click;
            mainPanel.AddChild(optionsButton);

            var quitButton = new Button();
            quitButton.Text = "Quit";
            quitButton.Visual.Width = 200;
            quitButton.Click += QuitButton_Click;
            mainPanel.AddChild(quitButton);
        }

        private void StyleButton(Button button)
        {
            var buttonBackground = button.GetVisual<ColoredRectangleRuntime>();

            var enabledState = button.GetState(FrameworkElement.EnabledStateName);
            enabledState.Clear();
            enabledState.Apply = () =>
            {
                buttonBackground.Color = Color.Red;
            };

            var highlightedState = button.GetState(FrameworkElement.HighlightedStateName);
            highlightedState.Clear();
            highlightedState.Apply = () =>
            {
                buttonBackground.Color = Color.Pink;
            };

            var pushedState = button.GetState(FrameworkElement.PushedStateName);
            pushedState.Clear();
            pushedState.Apply = () =>
            {
                buttonBackground.Color = Color.DarkRed;
            };

            button.UpdateState();
        }

        private void PickPlayersButton_Click(object sender, System.EventArgs e)
        {
            // This would be code in your actual Player Selection Class instead
            Gum.Root.Children.Clear();

            var gamePanel = new StackPanel();
            gamePanel.Visual.AddToRoot();
            gamePanel.Anchor(Anchor.Center);
            gamePanel.Dock(Dock.Fill);

            var label = new Label();
            label.Text = "Player Select";
            label.Anchor(Anchor.Top);
            gamePanel.AddChild(label);

            var buttonPanel = new StackPanel();
            buttonPanel.Anchor(Anchor.Center);
            gamePanel.AddChild(buttonPanel);

            var button = new Button();
            button.Text = "Back to Main Menu";
            button.Visual.Width = 200;
            button.Click += (_, _) =>
            {
                Gum.Root.Children.Clear();
                mainPanel.AddToRoot();
            };

            buttonPanel.AddChild(button);
        }

        private void OptionsButton_Click(object sender, System.EventArgs e)
        {
            // This code would go into your own options class
            Gum.Root.Children.Clear();
            var optionsPanel = new StackPanel();
            optionsPanel.Visual.AddToRoot();
            optionsPanel.Anchor(Anchor.Center);
            optionsPanel.Dock(Dock.Fill);

            var label = new Label();
            label.Text = "Options Panel";
            label.Anchor(Anchor.Top);
            optionsPanel.AddChild(label);

            var optionsControls = new StackPanel();
            optionsControls.Anchor(Anchor.Center);
            optionsControls.Spacing = 3;
            optionsPanel.AddChild(optionsControls);

            var fullScreenCheck = new CheckBox();
            fullScreenCheck.IsChecked = false;
            fullScreenCheck.Text = "Full Screen";
            fullScreenCheck.Checked += (sender, args) => System.Diagnostics.Debug.WriteLine(
                $"Checkbox checked? {(sender as CheckBox).IsChecked}");
            fullScreenCheck.Unchecked += (sender, args) => System.Diagnostics.Debug.WriteLine(
                $"Checkbox checked? {(sender as CheckBox).IsChecked}");
            optionsControls.AddChild(fullScreenCheck);

            var twoColumn = new StackPanel();
            twoColumn.Visual.ChildrenLayout = ChildrenLayout.LeftToRightStack;
            twoColumn.Visual.WidthUnits = DimensionUnitType.RelativeToChildren;
            optionsControls.AddChild(twoColumn);

            var spLabels = new StackPanel();
            spLabels.Spacing = 3;
            twoColumn.AddChild(spLabels);

            var volumeLabel = new Label();
            volumeLabel.Text = "Volume";
            spLabels.AddChild(volumeLabel);

            var musicLabel = new Label();
            musicLabel.Text = "Music";
            spLabels.AddChild(musicLabel);

            var spOptions = new StackPanel();
            spOptions.Spacing = 3;
            twoColumn.AddChild(spOptions);

            var volumeSlider = new Slider();
            volumeSlider.Value = 75;
            volumeSlider.ValueChanged += (sender, args) => System.Diagnostics.Debug.WriteLine(
                $"Volume Slider Value is {(sender as Slider).Value}");
            spOptions.AddChild(volumeSlider);

            var musicSlider = new Slider();
            musicSlider.Value = 50;
            musicSlider.ValueChanged += (sender, args) => System.Diagnostics.Debug.WriteLine(
                $"Music Slider Value is {(sender as Slider).Value}");
            spOptions.AddChild(musicSlider);

            var button = new Button();
            button.Text = "Back to Menu";
            button.Click += (_, _) =>
            {
                Gum.Root.Children.Clear();
                mainPanel.AddToRoot();
            };

            optionsControls.AddChild(button);
        }

        private void QuitButton_Click(object sender, System.EventArgs e)
        {
            Gum.Root.Children.Clear();
            Exit();
        }


        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Gum.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Gum.Draw();

            base.Draw(gameTime);
        }
    }
}
