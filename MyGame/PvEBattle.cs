using System;
using System.Collections.Generic;

namespace MyGame
{
	class PvEBattle : Battle
	{
		private Hero player;
		private Enemy enemy;

		public PvEBattle(Hero player, Enemy enemy)
		{
			this.player = player;
			this.enemy = enemy;
		}

		public void ToAttack()
		{
			enemy.SetHealPoints(enemy.GetHealPoints() - player.GetDamage());
			player.SetHealPoints(player.GetHealPoints() - (int)(enemy.GetDamage() * player.GetSelfDamageCoeff()));
		}

		public void EnemyAttack()
		{
			player.SetHealPoints(player.GetHealPoints() - enemy.GetDamage());
			enemy.SetHealPoints(player.GetHealPoints() - (int)(player.GetDamage() * enemy.GetSelfDamageCoeff()));
			Console.WriteLine($"{enemy.GetName()} attacked with {enemy.GetDamage()} damage");
			Console.WriteLine($"{enemy.GetName()} lost {(int)(player.GetDamage() * enemy.GetSelfDamageCoeff())} HP, while attacking");
		}

		public void TakeDefence()
		{
			player.SetMana(player.GetMana() + 20);
		}

		public void UseGetHealed()
		{
			player.SetHealPoints(player.GetHealPoints() + player.getHealed.GetValue());
			player.SetMana(player.GetMana() - player.getHealed.GetManaCost());
		}

		public void EnemyGetHealed()
		{
			enemy.SetHealPoints(enemy.GetHealPoints() + enemy.ability.GetValue());
			enemy.SetMana(enemy.GetMana() - enemy.ability.GetManaCost());
			Console.WriteLine($"{enemy.GetName()} has healed {enemy.ability.GetValue()} HP");
		}

		public void UseStrongAttack()
		{
			enemy.SetHealPoints(enemy.GetHealPoints() - player.strongAttack.GetValue());
			player.SetMana(player.GetMana() - player.strongAttack.GetManaCost());
		}

		public void EnemyStrongAttack()
		{
			player.SetHealPoints(player.GetHealPoints() - enemy.ability.GetValue());
			enemy.SetMana(enemy.GetMana() - enemy.ability.GetManaCost());
			Console.WriteLine($"{enemy.GetName()} used Strong attack with {enemy.ability.GetValue()} damage");
		}

		public void UseIceStrike()
		{
			enemy.SetHealPoints(enemy.GetHealPoints() - player.iceStrike.GetValue());
			player.SetMana(player.GetMana() - player.strongAttack.GetManaCost());
			Console.WriteLine("Your opponent is frozen and skips a turn. Go again");
			PlayerMove();
		}

		public void EnemyIceStrike()
		{
			player.SetHealPoints(player.GetHealPoints() - enemy.ability.GetValue());
			enemy.SetMana(enemy.GetMana() - enemy.ability.GetManaCost());
			Console.WriteLine($"{enemy.GetName()} used Ice Strike with {enemy.ability.GetValue()} damage");
			Console.WriteLine("You are frozen and skip a turn.");
			EnemyMove();
		}

		public void EnemyDamageUp()
		{
			enemy.SetDamage(enemy.GetDamage() + enemy.ability.GetValue());
			enemy.SetMana(enemy.GetMana() - enemy.ability.GetManaCost());
			Console.WriteLine($"{enemy.GetName()} has increased his damage by {enemy.ability.GetValue()}");
		}

		public void PlayerMove()
		{
			PrintPlayerOptions(player);
			int a;
			bool flag;
			int maxValue = 1;
			if (player.GetLevel() >= 2 && player.GetMana() >= player.getHealed.GetManaCost())
			{
				maxValue += 1;
			}
			if (player.GetLevel() >= 3 && player.GetMana() >= player.strongAttack.GetManaCost())
			{
				maxValue += 1;
			}
			if (player.GetLevel() >= 4 && player.GetMana() >= player.iceStrike.GetManaCost())
			{
				maxValue += 1;
			}
			do
			{
				flag = Int32.TryParse(Console.ReadLine(), out a);
				if (!flag || a > maxValue || a < 0)
				{
					Console.WriteLine("Wrong input");
					Console.WriteLine("Select from 0 to 4");
				}
			}
			while (!flag || a > maxValue || a < 0);

			switch (a)
			{
				case 0:
					TakeDefence();
					break;
				case 1:
					ToAttack();
					break;
				case 2:
					UseGetHealed();
					break;
				case 3:
					UseStrongAttack();
					break;
				case 4:
					UseIceStrike();
					break;
			}
			player.SetMana(player.GetMana() + 10);
		}

		public void EnemyMove()
		{
			if (enemy.GetMana() >= enemy.ability.GetManaCost())
			{
				if (enemy.GetName() == "Wolf" || enemy.GetName() == "Bear")
				{
					EnemyDamageUp();
				}
				else if (enemy.GetName() == "Draugr")
				{
					EnemyGetHealed();

				}
				else if (enemy.GetName() == "Troll" || enemy.GetName() == "Elemental")
				{
					EnemyStrongAttack();

				}
				else if (enemy.GetName() == "Ice Dragon")
				{
					EnemyIceStrike();
				}
			}
			else
			{
				EnemyAttack();
			}
			enemy.SetMana(enemy.GetMana() + 10);
			Console.WriteLine("Press any button to continue battle");
			Console.ReadKey();
		}

		public bool DoBattle()
		{
			while (IsAlive(player) && IsEnemyAlive(enemy))
			{
				Console.Clear();
				PlayerCharacteristics(player);
				EnemyCharacteristics(enemy);
				PlayerMove();
				if (IsEnemyAlive(enemy))
				{
					EnemyMove();
				}
			}
			if (!IsAlive(player) && !IsEnemyAlive(enemy))
			{
				Console.WriteLine("Draw");
				Console.WriteLine("Press any button to continue...");
				Console.ReadKey();
				return false;
			}
			else if (IsAlive(player))
			{
				Console.WriteLine($"{player.GetName()} win");
				Console.WriteLine("Press any button to continue...");
				Console.ReadKey();
				return true;
			}
			else
			{
				Console.WriteLine("You've lost, try again");
				Console.WriteLine("Press any button to continue...");
				Console.ReadKey();
				return false;
			}
		}
	}
}
