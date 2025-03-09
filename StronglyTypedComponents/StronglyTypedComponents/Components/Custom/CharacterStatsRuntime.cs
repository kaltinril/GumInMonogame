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
            HealthPotionButton.Click += UseHealthPotion;
            TakeDamageButton.Click += ApplyDamage;

            AddManaButton.Click += AddManaClicked;
            UseManaButton.Click += UseManaClicked;
            
            AddExpButton.Click += GainExperienceClicked;

        }

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
                Debug.WriteLine($"{_experience} {value}");
                _experience = value;
                if (_experience > _expToNextLevel)
                { 
                    _level++;
                    _experience = 0;
                }


                this.ExpPercentBar.BarPercent = _experience;
            }
        }


    }
}

