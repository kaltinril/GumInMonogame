

# 0.) Overview and Intro
	Hello, thank you for joining me again for another video on Gum.  I've been using it recently more.

	In this video I'm going to cover Strongly Typed Components, show how to create them, and finally use them in monogame.

	We covered Strongly Typed Components before briefly, but this video will be a more detailed review of them.


	Quick reminder before we begin, Gum has 2 main parts.  The gum tool, and the gum runtime.

	The gum tool is the editor that lets you build up a complex hierarchy of objects visually by clicking, dragging, and setting values.  It gives you direct feedback visually by allowing you to layout your design in real time.

	The gum runtime is the nuget package (dll file) that your game or project will need.  It is the layout engine.


# 1.) What is a Strongly Typed Component (or screen)

	A Strongly Typed Component (or screen) is just a custom Component or screen.  

	A code file can be generated so you can use that class file in your monogame project.


# 2.) How do you create a Strongly Typed Component (In gum tool)

	The short answer is, you just click Generate Code on your component from the code tab.  
	
	The longer answer is...
	
		Lets create a quick component, I've already got the project setup to work with a blank monogame project. 
			If you need help getting that setup, see my other videos in this series.
		
		(TODO: Figure out what to create here.  Then live on video create a component of some kind using forms controls.)
		
		Now that I have a Custom Component, I can generate the code for this to use in my game.


# 3.) Generating Code for Strongly Typed Components

	Lets take a look at some settings you'll want to use to generate the code files.
	
	I'll take you through the settings I'm using.
	
	This will be a quick overview of the Code tab.
	
	(INTERNAL NOTE: In the steps below, i will be taking the viewer through the tab and doing a high level overview)
	
## 3.1) First you want enable the two checkmarks:
	"Is CodeGen Plugin Enabled"  -  https://docs.flatredball.com/gum/gum-tool/code-tab/is-codegen-plugin-enabled
		This allows the gum tool to automatically generate updates
		to your Strongly Typed Component as you make changes to it'
		
	"Show CodeGen Preview"  -  https://docs.flatredball.com/gum/gum-tool/code-tab/show-codegen-preview
		This allows you to see what the code gen file will look like

## 3.2) Inheritance Location  -  https://docs.flatredball.com/gum/gum-tool/code-tab/inheritance-location
	This is simply where you want gum to put the parent class that your component class will inherit from.
	I recommend putting it in the Generated Code file so you don't have to think about it.
	
## 3.3) Generation Scope
	Set this to Selected Object.  We want the class to be created, not the data/configuration.  The configuraiton for how it is defined will come from the gumx project file and it's associated XML files.

	Alternatively, you can chose Selected State, however this will only be the variable values for the objects inside your component.
	The variable values for the standard elements and other Components.

## 3.4) Project-Wide Code Configuration

### 3.4.1) OutPut Library: 
		Monogame
		
### 3.4.2) Object Instantiation: 
		FindByName - Recommended (I just use the gumx project file)
		FullyInCode - Optional (Useful if you do not want to do I/O like loading the gumx project file)

### 3.4.3) Project Wide Using statements:
		If you have specific classes or libraries you know you need to always include for all GUM classes
		you can include it here to have it automatically placed at the top of the generated gum class files.

### 3.4.4) Code Project Root:
		This is the location where your *.csproj file is located

### 3.4.5) Root Namespace:
		In your project, if you've defined a namespace, you'll want to include that here

## 3.5) Element Code Generation

### 3.5.1) Generation Behavior:
		For this one I would change it to GenerateAutomaticallyOnPropertyChange.

		This will make sure if you edit something in the gum tool, it will be reflected in the generated code file.


All the rest leave of the settings I leave alone.


# 4.) How do you instantiate a Strongly Typed Component (In monogame)

	Now that the component's code has been generated, lets go over to monogame and get it working in our game.

## 4.1) Code file overview
	Over on the side here, we can see under the Components folder is our component we created.  There are actually 2 files.

		1. The first is the Custom Code file.  This is the name of the component.cs.  
		2. The second is the Generated Code file.  This has .generated added to the name of the file.

	Both of these files as you see from me opening them, are the same class, but they are a PARTIAL class.

	At compile time, visual studio will combine these 2 files together into a full class.

	Having these split allows auto generated code from the gum tool to not overwrite your custom code you write.

	Inside the Custom Code file, the only method we really have to override is CustomInitialize().  
	You can add code to this method that will run when an instance of the component is created.

## 4.2) Setup Gum and Create instance
	To create an instance of this, first lets get Gum setup in monogame, its easier now than previous videos.
		1. Since I'm using FindByName, I'll want to make sure the gum XML files created by the gum tool are copied to the output directory
		
		2. We need to make sure the GumMonogame nuget package is added.
		
		3. Next I'll create a variable to hold a reference to the component.  For simplicy sakes I'm just going to call it root.
			CharacterStatsRuntime Root;
		
		4. In the Monogame Initialize method add the gum initialization call.
            MonoGameGum.GumService.Default.Initialize(this, "gumProjFolder/gumProjExample.gumx");
		
		5. We need to update and draw the gum objects so lets add those bits of code
			MonoGameGum.GumService.Default.Update(this, gameTime, Root);
			
			MonoGameGum.GumService.Default.Draw();
		
		6. Now lets create an instance of the component and store it in the Root variable.
			Here is where the changes that were made to Gum come in handy. We just need these 2 lines of code, that's it.
			
			Root = new CharacterStatsRuntime();
            Root.AddToManagers();
			
		7. Lets run the code and watch
		
		Notice that the component is displayed in the top left of the screen.  
		
		Also notice that clicking the Health, Mana, or Experience buttons do nothing.  We need to "Wire up" this functionality in Monogame.


# 5.) How do you Interact with and Enhance a Strongly Typed Component (In monogame)

	Lets create some properties on this component that will change values in the component.

        // Easy properties for setting health, mana, and experience at the root component level
        private int _health = 0;
        private int maxHealth = 100;
        public int Health
        {
            get => _health;
            set
            {
                _health = Math.Clamp(value, 0, maxHealth);
                this.HealthPercentBar.BarPercent = (_health / (float)maxHealth) * 100;
                HealthBarLabel.LabelText = ((int)this.HealthPercentBar.BarPercent).ToString() + "%";
            }
        }

        private int _mana = 25;
        private int maxMana = 100;
        public int Mana
        {
            get => _mana;
            set
            {
                _mana = Math.Clamp(value, 0, maxMana);
                this.ManaPercentBar.BarPercent = (_mana / (float)maxMana) * 100;
                ManaBarLabel.LabelText = ((int)this.ManaPercentBar.BarPercent).ToString() + "%";
            }
        }

        private int _level = 1;
        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                LevelAmountLabel.LabelText = _level.ToString();
            }
        }

        private int _experience = 0;
        private int _expToNextLevel = 100;
        public int Experience
        {
            get => _experience;
            set
            {
                _experience = value;
                if (_experience > _expToNextLevel)
                {
                    Level++;
                    _experience -= _expToNextLevel;
                }


                this.ExpPercentBar.BarPercent = _experience;
                ExpBarLabel.LabelText = ((int)this.ExpPercentBar.BarPercent).ToString() + "%";
            }
        }





            HealthPotionButton.Click += UseHealthPotion;
            TakeDamageButton.Click += ApplyDamage;

            AddManaButton.Click += AddManaClicked;
            UseManaButton.Click += UseManaClicked;
            
            AddExpButton.Click += GainExperienceClicked;




        private void ApplyDamage(object sender, EventArgs e)
        {
            Health -= 10;
        }

        private void UseHealthPotion(object sender, EventArgs e)
        {
            Health += (int)(maxHealth * 0.30f);
        }

        private void GainExperienceClicked(object sender, EventArgs e)
        {
            Experience = Experience + 7;
        }

        private void UseManaClicked(object sender, EventArgs e)
        {
            if (Mana > 10)
            {
                Mana -= 10;
            }
        }

        private void AddManaClicked(object sender, EventArgs e)
        {
            Mana += 10;
        }




game1


        CharacterStatsRuntime Root;
        double timeSinceHealthRegen = 0;

MonoGameGum.GumService.Default.Initialize(this, "gumDir/GumProj.gumx");


            Root = new CharacterStatsRuntime();
            Root.AddToManagers();

            Root.Health = 100;
            Root.Experience = 0;
            Root.Mana = 25;
            Root.Level = 1;
            Root.X = 20;
            Root.Y = 20;


            MonoGameGum.GumService.Default.Update(this, gameTime, Root);

            timeSinceHealthRegen += gameTime.ElapsedGameTime.TotalSeconds;

            if (timeSinceHealthRegen >= 1)
            {
                Root.Health++;
                timeSinceHealthRegen -= 1;
            }

            MonoGameGum.GumService.Default.Draw();


