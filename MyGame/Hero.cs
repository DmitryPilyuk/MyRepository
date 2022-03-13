using System;
using System.Collections.Generic;

namespace MyGame
{
	class Hero : Unit
	{
		private Weapon weapon;
		private int experiencePoints;
		private int level;
		public Ability getHealed;
		public Ability strongAttack;
		public Ability iceStrike;

		public Hero(string name, Weapon weapon, int healPoints = 200, int damage = 10, int level = 1)
		{
			this.name = name;
			this.weapon = weapon;
			this.level = level;
			this.healPoints = healPoints;
			this.damage = damage;
			this.experiencePoints = 0;
			selfDamageCoeff = weapon.GetSelfDamageCoeff();
			mana = 0;
			getHealed = new GetHealed();
			strongAttack = new StrongAttack();
			iceStrike = new IceStrike();

		}

		public Hero Clone()			//Creating a copy of the hero
		{
			return new Hero(name, weapon, healPoints, damage, level);
		}

		public int GetExperiencePoints()
		{
			return experiencePoints;
		}

		public void SetExperiencePoints(int experiencePoints)
		{
			this.experiencePoints = experiencePoints;
		}
		public int GetLevel()
		{
			return level;
		}

		public void SetLevel(int level)
		{
			this.level = level;
		}
		public override int GetDamage()
		{
			return damage + weapon.GetDamage();
		}

		public void ChangeWeapon(Weapon newWeapon)
		{
			this.selfDamageCoeff = newWeapon.GetSelfDamageCoeff();
			this.weapon = newWeapon;
		}

		public void LevelUp()           //Increase the level of the hero in single-player mode
		{
			this.healPoints += 50;
			this.damage += 10;
			this.level += 1;
		}

		public override void PrintCharacteristics() //Printing the main characteristics of the unit in battle
		{
			Console.WriteLine($"{GetName()}:");
			Console.WriteLine($"HP: {GetHealPoints()}");
			Console.WriteLine($"Mana: {GetMana()}");
			Console.WriteLine($"Damage: {GetDamage()}");
			Console.WriteLine($"Weapon: {weapon.GetName()}");
			Console.WriteLine($"----------------------------");
		}

		public void PrintAllCharacteristics() //Printing all characteristics of the hero in menu
		{
			Console.WriteLine($"{GetName()}:");
			Console.WriteLine($"HP: {GetHealPoints()}");
			Console.WriteLine($"Mana: {GetMana()}");
			Console.WriteLine($"Damage: {GetDamage()}");
			Console.WriteLine($"Weapon: {weapon.GetName()}");
			Console.WriteLine($"Coefficient of damage received while attacking: {selfDamageCoeff}");
			Console.WriteLine($"Level: {level}");
			Console.WriteLine($"XP: {experiencePoints}/400");
			Console.WriteLine($"-----------------------------");
		}

	}
}
