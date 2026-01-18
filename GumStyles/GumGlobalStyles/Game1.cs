using Gum.DataTypes;
using Gum.DataTypes.Variables;
using Gum.Forms.Controls;
using Gum.Forms.DefaultVisuals;
using Gum.Managers;
using Gum.Wireframe;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameGum;
using MonoGameGum.GueDeriving;
using RenderingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GumGlobalStyling
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Styling defaultStyle;

        // Added for Video
        GumService GumUI => GumService.Default;
        Panel mainPanel;
        Color backColor = Color.CornflowerBlue;

        // Make it easier for us to switch styles for the demo
        Dictionary<string, Action> globalStyles;
        Action activeScreen;

        List<string> fontNames;
        //Dictionary<string, List<StateSave>> fonts;
        Dictionary<string, Action> fonts;
        string currentFontName = "Arial";

        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // Make this larger so the video is easier to see
            _graphics.PreferredBackBufferWidth = 1900;
            _graphics.PreferredBackBufferHeight = 1200;
            _graphics.ApplyChanges();

        }


        protected override void Initialize()
        {
            GumUI.Initialize(this, MonoGameGum.Forms.DefaultVisualsVersion.V2);

            // Zoom everything up times 2 so it's easier to see
            var camera = SystemManagers.Default.Renderer.Camera;
            camera.Zoom = 2f;
            GraphicalUiElement.CanvasWidth = 1900 / camera.Zoom;
            GraphicalUiElement.CanvasHeight = 1200 / camera.Zoom;

            // Store the original style before we start messing with things
            defaultStyle = Styling.ActiveStyle;

            // Setup some of the objects we'll use to make the menu system
            fontNames = new List<string>();
            fonts = new Dictionary<string, Action>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            BuildFontList();

            // We are going to apply a style across the entire UI
            BuildStyles();

            // Then we are going to create the first UI elements

            SetupMainScreen();
        }

        private void BuildFontList()
        {
            fontNames.Add("Arial");
            fontNames.Add("Book_Antiqua");
            fontNames.Add("Kenney_Mini_Square");
            fontNames.Add("Monotype_Corsiva");
            //fontNames.Add("Press_Start_2P");  // We'll load this one manually
        }

        private void BuildMenu()
        {
            var basePanel = new Panel();
            basePanel.AddToRoot();
            basePanel.Anchor(Anchor.Center);
            basePanel.Dock(Dock.Fill);

            mainPanel = new Panel();
            mainPanel.Anchor(Anchor.Center);
            basePanel.AddChild(mainPanel);

             var fileMenuPanel = new StackPanel();
            fileMenuPanel.Spacing = 2;
            fileMenuPanel.Visual.Width = _graphics.PreferredBackBufferWidth;
            basePanel.AddChild(fileMenuPanel);

            var mainMenu = new Menu();
            fileMenuPanel.AddChild(mainMenu);

            var menuFile = new MenuItem();
            menuFile.Header = "File";
            mainMenu.Items.Add(menuFile);

            var menuQuit = new MenuItem();
            menuQuit.Header = "Quit";
            menuQuit.Clicked += (s, e) =>
            {
                Exit();
            };
            menuFile.Items.Add(menuQuit);

            var menuEdit = new MenuItem();
            menuEdit.Header = "Edit";
            mainMenu.Items.Add(menuEdit);

            var menuFake = new MenuItem();
            menuFake.Header = "Fake1";
            menuEdit.Items.Add(menuFake);
            menuFake = new MenuItem();
            menuFake.Header = "Fake2";
            menuEdit.Items.Add(menuFake);

            var menuSubFake = new MenuItem();
            menuSubFake.Header = "Sub-Fake";
            menuFake.Items.Add(menuSubFake);

            menuFake = new MenuItem();
            menuFake.Header = "Fake3";
            menuEdit.Items.Add(menuFake);


            var menuView = new MenuItem();
            menuView.Header = "View";
            mainMenu.Items.Add(menuView);

            var menuBorderless = new MenuItem();
            menuBorderless.Header = "Toggle Borderless";
            menuBorderless.Clicked += (s, e) =>
            {
                Window.IsBorderless = !Window.IsBorderless;
            };
            menuView.Items.Add(menuBorderless);

            var menuStyles = new MenuItem();
            menuStyles.Header = "Styles";
            mainMenu.Items.Add(menuStyles);

            foreach (var kvp in globalStyles)
            {
                var menuStyle = new MenuItem();
                menuStyle.Header = kvp.Key;
                menuStyle.Clicked += (_,_) => {
                    kvp.Value();
                    if (kvp.Key != "Default")
                    {
                        SetFontFamily(currentFontName);
                    }
                    activeScreen();
                };
                menuStyles.Items.Add(menuStyle);
            }

            var menuFonts = new MenuItem();
            menuFonts.Header = "Fonts";
            mainMenu.Items.Add(menuFonts);

            // BitmapFont's placed at Content\FontCache\Font18yourfont.fnt
            // can be automatically loaded
            // We'll update the Global fonts to change the font name
            // from Arial to whateve the user selects in the drop down
            foreach (var fontName in fontNames)
            {
                var menuFont = new MenuItem();
                menuFont.Header = fontName;
                menuFont.Clicked += (_, _) =>
                {
                    // Change the NORMAL, STRONG, and EMPHASIS font names
                    SetFontFamily(fontName);
                    currentFontName = fontName;
                    activeScreen(); // Recreate the screen so we can see the font changes live
                };
                menuFonts.Items.Add(menuFont);
            }

            var menuFontManual = new MenuItem();
            menuFontManual.Header = "Press_Start_2P";
            menuFontManual.Clicked += (_, _) =>
            {
                UseLoadedFontExample();
                activeScreen(); // Recreate the screen so we can see the font changes live
            };
            menuFonts.Items.Add(menuFontManual);
        } 

        private void SetFontFamily(string fontName)
        {
            //var normalFont = Styling.ActiveStyle.Text.Normal.Variables.Where(f => f.Name == "Font").FirstOrDefault();
            //normalFont.Value = fontName;

            //var boldFont = Styling.ActiveStyle.Text.Strong.Variables.Where(f => f.Name == "Font").FirstOrDefault();
            //boldFont.Value = fontName;

            //var italicFont = Styling.ActiveStyle.Text.Emphasis.Variables.Where(f => f.Name == "Font").FirstOrDefault();
            //italicFont.Value = fontName;
            ExpandedExampleSetFontFamily(fontName);
        }

        // Here I am assuming that all fonts have a BOLD and an ITALIC font version
        // I am then creating a new Key/Value pair set with (Font, FontSize, IsBold, IsItalic)
        // I then overwrite the Normal, Strong, and Emphasis styling
        private void ExpandedExampleSetFontFamily(string fontName)
        {

            var normalFont = ExpandedExampleCreateFontKVPs(fontName, 18, false, false);
            var boldFont = ExpandedExampleCreateFontKVPs(fontName, 18, true, false);
            var italicFont = ExpandedExampleCreateFontKVPs(fontName, 18, false, true);

            Styling.ActiveStyle.Text.Normal = normalFont;
            Styling.ActiveStyle.Text.Strong = boldFont;
            Styling.ActiveStyle.Text.Emphasis = italicFont;
        }

        private StateSave ExpandedExampleCreateFontKVPs(string fontName, int fontSize, bool isBold, bool isItalic)
        {
            StateSave stateSave = new StateSave();

            VariableSave vsFontName = new VariableSave();
            vsFontName.Name = "Font";
            vsFontName.Type = "string";
            vsFontName.Value = fontName;
            stateSave.Variables.Add(vsFontName);

            VariableSave vsFontSize = new VariableSave();
            vsFontSize.Name = "FontSize";
            vsFontSize.Type = "int";
            vsFontSize.Value = fontSize;
            stateSave.Variables.Add(vsFontSize);

            VariableSave vsFontBold = new VariableSave();
            vsFontBold.Name = "IsBold";
            vsFontBold.Type = "bool";
            vsFontBold.Value = isBold;
            stateSave.Variables.Add(vsFontBold);

            VariableSave vsFontItalic = new VariableSave();
            vsFontItalic.Name = "IsItalic";
            vsFontItalic.Type = "bool";
            vsFontItalic.Value = isItalic;
            stateSave.Variables.Add(vsFontItalic);

            return stateSave;
        }

        private void UseLoadedFontExample()
        {
            Styling.ActiveStyle.Text.Normal = new StateSave()
            {
                Variables = new()
                {
                    new () { Name = "UseCustomFont", Type = "bool", Value = true },
                    new () { Name = "CustomFontFile", Type = "string", Value = "FontCache/Font18Press_Start_2P.fnt" }
                    //new () { Name = "FontScale", Type = "float", Value = 3f },
                }
            };

            Styling.ActiveStyle.Text.Strong = new StateSave()
            {
                Variables = new()
                {
                    new () { Name = "UseCustomFont", Type = "bool", Value = true },
                    new () { Name = "CustomFontFile", Type = "string", Value = "FontCache/Font18Press_Start_2P_Bold.fnt" }
                }
            };

            Styling.ActiveStyle.Text.Emphasis = new StateSave()
            {
                Variables = new()
                {
                    new () { Name = "UseCustomFont", Type = "bool", Value = true },
                    new () { Name = "CustomFontFile", Type = "string", Value = "FontCache/Font18Press_Start_2P_Italic.fnt" }
                }
            };
        }

        private void BuildStyles()
        {
            globalStyles = new Dictionary<string, Action>();
            globalStyles.Add("Default", SetDefaultStyle);
            globalStyles.Add("AshPersimmonSix", AshPersimmonSix);
            globalStyles.Add("MoonlightGB", MoonlightGB);
            globalStyles.Add("SunSetDrive", SunSetDrive);
            globalStyles.Add("Twilight5", Twilight5);
        }

        private void SetDefaultStyle()
        {
            Styling.ActiveStyle = defaultStyle;
            backColor = Color.CornflowerBlue;
            SetFontFamily("Arial");
        }

        private void MoonlightGB()
        {
            // https://lospec.com/palette-list/moonlight-gb
            var style = new Styling(Styling.ActiveStyle.SpriteSheet);
            style.Colors.Primary = new Color(32, 54, 113); //#203671
            style.Colors.PrimaryLight = new Color(64, 86, 145);
            style.Colors.PrimaryDark = new Color(16, 38, 97);
            style.Colors.Accent = new Color(54, 134, 143); //#36868f
            //style.Colors.Warning = new Color(74, 122, 150);
            //style.Colors.DarkGray = new Color(41, 40, 49);
            style.Colors.White = new Color(95, 199, 93); //#5fc75d
            Styling.ActiveStyle = style;

            backColor = new Color(15, 5, 45); //#0f052d
        }

        private void Twilight5()
        {
            // https://lospec.com/palette-list/twilight-5
            var style = new Styling(Styling.ActiveStyle.SpriteSheet);
            style.Colors.Primary = new Color(238, 134, 149);  // #ee8695
            style.Colors.PrimaryLight = new Color(255, 155, 175); // #ee8695 lighter than primary
            style.Colors.PrimaryDark = new Color(210, 110, 120); // #ee8695 darker than primary
            style.Colors.Accent = new Color(74, 122, 150); // #4a7a96
            style.Colors.Warning = new Color(74, 122, 150); // #4a7a96
            style.Colors.DarkGray = new Color(41, 40, 49); //#292831
            Styling.ActiveStyle = style;

            backColor = new Color(51, 63, 88); // #333f58
        }

        private void SunSetDrive()
        {
            var sunSetDrive = new Styling(Styling.ActiveStyle.SpriteSheet);
            sunSetDrive.Colors.Primary = new Color(217, 99, 48);
            sunSetDrive.Colors.PrimaryLight = new Color(229, 156, 82);
            sunSetDrive.Colors.PrimaryDark = new Color(182, 53, 27);
            sunSetDrive.Colors.White = new Color(247, 232, 181);
            sunSetDrive.Colors.Accent = new Color(144, 19, 75);
            sunSetDrive.Colors.Danger = new Color(99, 13, 72);
            Styling.ActiveStyle = sunSetDrive;

            backColor = new Color(240, 200, 132);
        }

        private void AshPersimmonSix()
        {
            var sshPersimmonSix = new Styling(Styling.ActiveStyle.SpriteSheet);
            sshPersimmonSix.Colors.Primary = new Color(98, 65, 65);
            sshPersimmonSix.Colors.White = new Color(225, 202, 209);
            sshPersimmonSix.Colors.PrimaryLight = new Color(132, 105, 100);
            sshPersimmonSix.Colors.PrimaryDark = new Color(36, 17, 18);
            sshPersimmonSix.Colors.Accent = new Color(255, 161, 74);
            Styling.ActiveStyle = sshPersimmonSix;

            backColor = new Color(225, 202, 209);
        }

        private void SetupMainScreen()
        {
            activeScreen = SetupMainScreen;
            GumUI.Root.Children.Clear();
            BuildMenu();

            var mainScreenMenu = new Panel();
           // mainScreenMenu.Anchor(Anchor.Center);
            mainPanel.AddChild(mainScreenMenu);

            var background = new NineSliceRuntime();
            background.ApplyState(Styling.ActiveStyle.NineSlice.Panel);
            background.Color = Styling.ActiveStyle.Colors.White;
            background.Texture = Styling.ActiveStyle.SpriteSheet;
            background.Dock(Dock.Fill);
            background.X = 0;
            background.Y = 0;
            background.Width = 16;
            background.Height = 16;
            mainScreenMenu.AddChild(background);

            var mainStacker = new StackPanel();
            mainStacker.Spacing = 5;
            mainScreenMenu.AddChild(mainStacker);

            var createCharacter = new Button();
            createCharacter.Text = "Play My Game";
            createCharacter.Visual.Width = 200;
            createCharacter.Click += CreateCharacterButton_Click;
            mainStacker.AddChild(createCharacter);

            var optionsButton = new Button();
            optionsButton.Text = "Options";
            optionsButton.Visual.Width = 200;
            optionsButton.Click += OptionsButton_Click;
            mainStacker.AddChild(optionsButton);

            var quitButton = new Button();
            quitButton.Text = "Quit";
            quitButton.Visual.Width = 200;
            quitButton.Click += QuitButton_Click;
            mainStacker.AddChild(quitButton);
        }

        private void CreateCharacterButton_Click(object sender, System.EventArgs e)
        {
            CharacterCreateMenu();
        }

        private void CharacterCreateMenu()
        {
            activeScreen = CharacterCreateMenu;
            // This would be code in your actual Player Selection Class instead
            GumUI.Root.Children.Clear();
            BuildMenu();

            var gamePanel = new Panel();
            gamePanel.AddToRoot();
            gamePanel.Anchor(Anchor.Center);
            gamePanel.Visual.WidthUnits = DimensionUnitType.RelativeToChildren;
            gamePanel.Visual.HeightUnits = DimensionUnitType.RelativeToChildren;

            var background = new NineSliceRuntime();
            background.ApplyState(Styling.ActiveStyle.NineSlice.Panel);
            background.Color = Styling.ActiveStyle.Colors.White;
            background.Texture = Styling.ActiveStyle.SpriteSheet;
            background.Dock(Dock.Fill);
            background.X = 0;
            background.Y = 0;
            background.Width = 16;
            background.Height = 16;
            gamePanel.AddChild(background);

            var label = new Label();
            label.Text = "Player Setup";
            label.Anchor(Anchor.Top);
            label.Y = -100;
            gamePanel.AddChild(label);

            var optionsPanel = new StackPanel();
            optionsPanel.Anchor(Anchor.Center);
            optionsPanel.Spacing = 5;
            //optionsPanel.Width = 10;
            optionsPanel.Visual.WidthUnits = DimensionUnitType.RelativeToChildren;
            optionsPanel.Width = 0;
            gamePanel.AddChild(optionsPanel);

            var contentsPanel = new StackPanel();
            contentsPanel.Orientation = Orientation.Horizontal;
            contentsPanel.Spacing = 5;
            contentsPanel.Visual.WidthUnits = DimensionUnitType.RelativeToChildren;
            contentsPanel.Width = 0;
            optionsPanel.AddChild(contentsPanel);

            /////////////// Start of labels

            var labelPanel = new StackPanel();
            labelPanel.Visual.WidthUnits = DimensionUnitType.RelativeToChildren;
            labelPanel.Width = 0;
            labelPanel.Spacing = 6;
            contentsPanel.AddChild(labelPanel);

            var labelCharName = new Label();
            labelCharName.Name = nameof(labelCharName);
            labelCharName.Text = "Character Name: ";
            labelCharName.Height = 24;
            labelCharName.Visual.HeightUnits = DimensionUnitType.Absolute;
            labelPanel.AddChild(labelCharName);

            var labelCharHeight = new Label();
            labelCharHeight.Name = nameof(labelCharHeight);
            labelCharHeight.Text = "Character Height (ft): ";
            labelCharHeight.Height = 24;
            labelCharHeight.Visual.HeightUnits = DimensionUnitType.Absolute;
            labelPanel.AddChild(labelCharHeight);

            var labelRace = new Label();
            labelRace.Name = nameof(labelRace);
            labelRace.Text = "Fantasy Race: ";
            labelRace.Height = 24;
            labelRace.Visual.HeightUnits = DimensionUnitType.Absolute;
            labelPanel.AddChild(labelRace);

            var labelDifficulty = new Label();
            labelDifficulty.Name = nameof(labelDifficulty);
            labelDifficulty.Text = "Difficulty";
            labelDifficulty.Height = 24;
            labelDifficulty.Visual.HeightUnits = DimensionUnitType.Absolute;
            labelPanel.AddChild(labelDifficulty);

            var labelNeed = new Label();
            labelNeed.Name = nameof(labelNeed);
            labelNeed.Text = "Always roll:";
            labelNeed.Height = 24;
            labelNeed.Visual.HeightUnits = DimensionUnitType.Absolute;
            labelPanel.AddChild(labelNeed);

            ////////////// End of Labels
            ////////////// Start of Values

            var valuePanel = new StackPanel();
            valuePanel.Visual.WidthUnits = DimensionUnitType.RelativeToChildren;
            valuePanel.Width = 0;
            valuePanel.Spacing = 5;
            contentsPanel.AddChild(valuePanel);

            var textName = new TextBox();
            textName.Placeholder = "Enter name";
            textName.Width = 240;
            textName.Visual.WidthUnits = DimensionUnitType.Absolute;
            valuePanel.AddChild(textName);

            var sliderStacker = new StackPanel();
            sliderStacker.Orientation = Orientation.Horizontal;
            sliderStacker.Spacing = 2;
            valuePanel.AddChild(sliderStacker);

            var sliderCharHeight = new Slider();
            sliderCharHeight.Minimum = 3;
            sliderCharHeight.Maximum = 10;
            sliderCharHeight.Value = 5;
            sliderCharHeight.Width = 216;
            sliderCharHeight.Name = nameof(sliderCharHeight);
            sliderCharHeight.Height = 24;
            sliderCharHeight.Visual.HeightUnits = DimensionUnitType.Absolute;
            sliderStacker.AddChild(sliderCharHeight);

            var labelSliderCharWidth = new Label();
            labelSliderCharWidth.Text = ((int)sliderCharHeight.Value).ToString();
            sliderStacker.AddChild(labelSliderCharWidth);

            sliderCharHeight.ValueChanged += (_, _) =>
            {
                labelSliderCharWidth.Text = ((int)sliderCharHeight.Value).ToString();
            };

            var racePicker = new ComboBox();
            racePicker.Items.Add("Dark Elf");
            racePicker.Items.Add("Halfing");
            racePicker.Items.Add("High Elf");
            racePicker.Items.Add("Human");
            racePicker.Items.Add("Orc");
            racePicker.Items.Add("Troll");
            racePicker.Items.Add("Wood Elf");
            racePicker.SelectedIndex = 6;
            racePicker.Width = 240;
            //racePicker.Visual.WidthUnits = DimensionUnitType.RelativeToChildren;
            valuePanel.AddChild(racePicker);

            var radioStack = new StackPanel();
            radioStack.Spacing = 2;
            radioStack.Orientation = Orientation.Horizontal;
            valuePanel.AddChild(radioStack);

            var radioEasy = new RadioButton();
            radioEasy.Text = "Easy";
            radioEasy.Width = 75;
            radioEasy.IsChecked = true;
            //radioEasy.Visual
            //radioEasy.Visual.WidthUnits = DimensionUnitType.RelativeToChildren;
            radioStack.AddChild(radioEasy);

            var radioMedium = new RadioButton();
            radioMedium.Text = "Medium";
            radioMedium.Width = 90;
            radioStack.AddChild(radioMedium);

            var radioHard = new RadioButton();
            radioHard.Text = "Hard";
            radioHard.Width = 75;
            radioStack.AddChild(radioHard);

            var checkStacker = new StackPanel();
            checkStacker.Spacing = 2;
            valuePanel.AddChild(checkStacker);

            var checkRollNeed = new CheckBox();
            checkRollNeed.Text = "Need";
            checkRollNeed.IsChecked = true;
            checkStacker.AddChild(checkRollNeed);

            var checkRollGreed = new CheckBox();
            checkRollGreed.Text = "Greed";
            checkStacker.AddChild(checkRollGreed);

            var checkRollPass = new CheckBox();
            checkRollPass.Text = "Pass";
            checkStacker.AddChild(checkRollPass);

            ////////////////// End of Values

            var buttonStacker = new Panel();
            buttonStacker.Width = 0;
            buttonStacker.Visual.WidthUnits = DimensionUnitType.RelativeToParent;
            optionsPanel.AddChild(buttonStacker);

            var button = new Button();
            button.Text = "Run! (go back)";
            button.Visual.Width = 200;
            //button.Visual.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
            //button.Visual.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
            button.Click += (_, _) =>
            {
                SetupMainScreen();
            };

            buttonStacker.AddChild(button);

            var playGame = new Button();
            playGame.Text = "Banjo Spawning Grounds";
            playGame.Visual.Width = 200;
            playGame.Visual.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Right;
            playGame.Visual.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
            playGame.Click += (_, _) =>
            {
                SetupMainScreen();
            };

            buttonStacker.AddChild(playGame);
        }


        private void OptionsButton_Click(object sender, System.EventArgs e)
        {
            OptionsMenuScreen();
        }

        private void OptionsMenuScreen()
        {

            activeScreen = OptionsMenuScreen;
            // This code would go into your own options class
            GumUI.Root.Children.Clear();
            BuildMenu();

            var optionsPanel = new Panel();
            optionsPanel.AddToRoot();                       // No longer need .Visual.
            optionsPanel.Anchor(Anchor.Center);
            optionsPanel.Visual.WidthUnits = DimensionUnitType.RelativeToChildren;
            optionsPanel.Visual.HeightUnits = DimensionUnitType.RelativeToChildren;

            var background = new NineSliceRuntime();
            background.ApplyState(Styling.ActiveStyle.NineSlice.Panel);
            background.Color = Styling.ActiveStyle.Colors.White;
            background.Texture = Styling.ActiveStyle.SpriteSheet;
            background.Dock(Dock.Fill);
            background.X = 0;
            background.Y = 0;
            background.Width = 16;
            background.Height = 16;
            optionsPanel.AddChild(background);

            var label = new Label();
            label.Text = "Options Panel";
            label.Anchor(Anchor.Top);
            label.Y = -100;
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
            button.Visual.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
            button.Visual.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
            button.Click += (_, _) =>
            {
                SetupMainScreen();
            };

            optionsControls.AddChild(button);
        }

        private void QuitButton_Click(object sender, System.EventArgs e)
        {
            GumUI.Root.Children.Clear();
            Exit();
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            GumUI.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);
            GraphicsDevice.Clear(backColor);

            GumUI.Draw();

            base.Draw(gameTime);
        }
    }
}
