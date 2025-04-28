
# Intro
Welcome back for another video.

Today is a short video.

Lets get a UI up and running in Monogame fast using Code Only.

Code only is one way, my other videos focus on usin the Gum Tool.  Pick the way that you enjoy best.

# Quick Monogame Gum Setup
1. Create a new project 
2. Add the Gum.MonoGame nuget package
3. Add the skeleton elements (Initialize, Update, Draw)
	First add this line to make things simpler
		GumService Gum => GumService.Default;
	Now copy and paste the initialize, update, and draw 
		Initialize	
			Gum.Initialize(this);
		Update
			Gum.Update(gameTime);
		Draw
			Gum.Draw();
			

# Creating a Button
4. Add a Stack Panel to use as our main UI container
	var mainPanel = new StackPanel();
	mainPanel.AddToRoot();

5. Add buttons to the stack panel (Play, Options, Quit)

	var playButton = new Button();
    button.Text = "Play My Game";

    mainPanel.AddChild(button);

6. Make the button do something when clicked

    playButton.Click += (_, _) =>
        button.Text = $"Clicked at {System.DateTime.Now}";
		
7. Change the basic visuals
    playButton.Visual.Width = 350;

# Styling a button

8. Change the states for hover and pressed, and enabled (which is the default appearance)
	Borrowing code directly from Vic's recent Monogame AMA.


	var buttonBackground = playButton.GetVisual<ColoredRectangleRuntime>();

	var enabledState = playButton.GetState(FrameworkElement.EnabledStateName);
	enabledState.Clear();
	enabledState.Apply = () =>
	{
		buttonBackground.Color = Color.Red;
	};

	var highlightedState = playButton.GetState(FrameworkElement.HighlightedStateName);
	highlightedState.Clear();
	highlightedState.Apply = () =>
	{
		buttonBackground.Color = Color.Pink;
	};

	var pushedState = playButton.GetState(FrameworkElement.PushedStateName);
	pushedState.Clear();
	pushedState.Apply = () =>
	{
		buttonBackground.Color = Color.DarkRed;
	};

	playButton.UpdateState();


# Full menu example

9. Simulate changing to a different set of Menu controls
	Lets create 3 menu UI containers.  
		One for the Main Menu
		One for Player select
		One for Options/Settings

Code below:

using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameGum;
using MonoGameGum.Forms.Controls;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        GumService Gum => GumService.Default;
        StackPanel mainScreenPanel;


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

            mainScreenPanel = new StackPanel();
            mainScreenPanel.Visual.AddToRoot();
            mainScreenPanel.Spacing = 3;
            mainScreenPanel.Anchor(Anchor.Center);

            var pickPlayers = new Button();
            pickPlayers.Text = "Play My Game";
            pickPlayers.Visual.Width = 200;
            pickPlayers.Click += PickPlayersButton_Click;
            mainScreenPanel.AddChild(pickPlayers);

            var optionsButton = new Button();
            optionsButton.Text = "Options";
            optionsButton.Visual.Width = 200;
            optionsButton.Click += OptionsButton_Click;
            mainScreenPanel.AddChild(optionsButton);

            var quitButton = new Button();
            quitButton.Text = "Quit";
            quitButton.Visual.Width = 200;
            quitButton.Click += QuitButton_Click;
            mainScreenPanel.AddChild(quitButton);
        }

        private void PickPlayersButton_Click(object sender, System.EventArgs e)
        {
            // This would be code in your actual Player Selection Class instead
            Gum.Root.Children.Clear();

            var gameScreenPanel = new StackPanel();
            gameScreenPanel.Visual.AddToRoot();
            gameScreenPanel.Anchor(Anchor.Center);
            gameScreenPanel.Dock(Dock.Fill);

            var label = new Label();
            label.Text = "Player Select Screen";
            label.Anchor(Anchor.Top);
            gameScreenPanel.AddChild(label);

            var buttonPanel = new StackPanel();
            buttonPanel.Anchor(Anchor.Center);
            gameScreenPanel.AddChild(buttonPanel);

            var button = new Button();
            button.Text = "Back to Main Menu";
            button.Visual.Width = 200;
            button.Click += (_, _) =>
            {
                Gum.Root.Children.Clear();
                mainScreenPanel.AddToRoot();
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
            label.Text = "Options Screen";
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

            var volumeSlider =new Slider();
            volumeSlider.Value = 75;
			volumeSlider.ValueChanged += (sender, args) => System.Diagnostics.Debug.Write(
				$"Volume Slider Value is {(sender as Slider).Value}");
            spOptions.AddChild(volumeSlider);

            var musicSlider =new Slider();
            musicSlider.Value = 50;
			musicSlider.ValueChanged += (sender, args) => System.Diagnostics.Debug.Write(
				$"Volume Slider Value is {(sender as Slider).Value}");
            spOptions.AddChild(musicSlider);

            var button = new Button();
            button.Text = "Back to Menu";
            button.Click += (_, _) =>
            {
                Gum.Root.Children.Clear();
                mainScreenPanel.AddToRoot();
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





