using Gum.Converters;
using Gum.DataTypes;
using Gum.Managers;
using Gum.Wireframe;

using RenderingLibrary.Graphics;

using System.Linq;

using MonoGameGum.GueDeriving;
using System.Runtime.InteropServices;
using System;
using System.Diagnostics;
namespace StronglyTypedComponents.Components
{
    partial class CharacterStatsRuntime : ContainerRuntime
    {
        partial void CustomInitialize()
        {
            AddManaButton.Click += AddManaClicked;
            UseManaButton.Click += UseManaClicked;
            AddExpButton.Click += GainExperienceClicked;
        }

        private void GainExperienceClicked(object sender, EventArgs e)
        {
            Experience += 7;
            Debug.WriteLine("+7 Exp");
        }

        private void UseManaClicked(object sender, EventArgs e)
        {
            Debug.WriteLine((sender as GraphicalUiElement).Parent.Children);
            if (Mana > 30)
            {
                Mana -= 30;
                Debug.WriteLine("30 mana used");
            }
            
        }

        private void AddManaClicked(object sender, EventArgs e)
        {
            Mana += 10;
            Debug.WriteLine("+10 Mana");
        }


        // Easy properties for setting health, mana, and experience at the root component level
        private int _health = 0;
        private int maxHealth = 1000;
        public int Health
        {
            get => _health;
            set
            {
                _health = Math.Clamp(value, 0, maxHealth);
                this.HealthPercentBar.BarPercent = (_health / (float)maxHealth) * 100;
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
            }
        }

        private int _level = 1;
        private int _experience = 0;
        private int _expToNextLevel = 100;
        public int Experience
        {
            get => _experience;
            set
            {
                _experience += value;
                if (_experience > _expToNextLevel)
                    _level++;

                this.ExpPercentBar.BarPercent = _experience;
            }
        }


    }
}

