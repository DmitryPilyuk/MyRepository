using System;
using System.Collections.Generic;

namespace MyGame
{
	class Battle
	{

		public void PrintPlayerOptions(Hero player)
		{
			Console.WriteLine($"{player.GetName()}, select option:");
			Console.WriteLine("0 - take defence");
			Console.WriteLine("1 - simple attack");
			if (player.GetMana() >= player.getHealed.GetManaCost() && player.GetLevel() >= 2)
			{
				Console.WriteLine("2 - get healed");
			}
			if (player.GetMana() >= player.strongAttack.GetManaCost() && player.GetLevel() >= 3)
			{
				Console.WriteLine("3 - strong attak");
			}
			if (player.GetMana() >= player.iceStrike.GetManaCost() && player.GetLevel() == 4)
			{
				Console.WriteLine("4 - ice strike");
			}
		}
		
		public void PlayerCharacteristics(Hero player)
		{
			Console.WriteLine($"{player.GetName()}:");
			Console.WriteLine($"HP: {player.GetHealPoints()}");
			Console.WriteLine($"Mana: {player.GetMana()}");
			Console.WriteLine($"Damage: {player.GetDamage()}");
			Console.WriteLine($"----------------------------");
		}

		public void EnemyCharacteristics(Enemy enemy)
		{
			Console.WriteLine($"{enemy.GetName()}:");
			Console.WriteLine($"HP: {enemy.GetHealPoints()}");
			Console.WriteLine($"Mana: {enemy.GetMana()}");
			Console.WriteLine($"Damage: {enemy.GetDamage()}");
			Console.WriteLine($"----------------------------");
		}

		public bool IsAlive(Hero player)
		{
			return (player.GetHealPoints() >= 0);
		}

		public bool IsEnemyAlive(Enemy enemy)
		{
			return (enemy.GetHealPoints() >= 0);
		}
	}
}
