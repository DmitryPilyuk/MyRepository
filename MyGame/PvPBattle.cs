using System;
using System.Collections.Generic;

namespace MyGame
{
	class PvPBattle : Battle
	{
		protected List<Hero> players;

		public PvPBattle(Hero player1, Hero player2)
		{
			players = new List<Hero>() { player1, player2 };
		}

		public void ToAttack(int i)     //Hero's attack
		{
			players[(i + 1) % 2].SetHealPoints(players[(i + 1) % 2].GetHealPoints() - players[i].GetDamage());
			players[i].SetHealPoints(players[i].GetHealPoints() - (int)(players[(i + 1) % 2].GetDamage()*players[i].GetSelfDamageCoeff()));
		}

		public void TakeDefence(int i)      //Skipping a move, additional mana is added
		{
			players[i].SetMana(players[i].GetMana() + 30);
		}

		public void UseGetHealed(int i)     //Recovering the hero's health
		{
			players[i].SetHealPoints(players[i].GetHealPoints() + players[i].getHealed.GetValue());
			players[i].SetMana(players[i].GetMana() - players[i].getHealed.GetManaCost());
		}

		public void UseStrongAttack(int i)      //Hero's strong attack without taking damage
		{
			players[(i + 1) % 2].SetHealPoints(players[(i + 1) % 2].GetHealPoints() - players[i].strongAttack.GetValue());
			players[i].SetMana(players[i].GetMana() - players[i].strongAttack.GetManaCost());
		}

		public void UseIceStrike(int i)     //An attack that freezes the opponent for 1 turn
		{
			players[(i + 1) % 2].SetHealPoints(players[(i + 1) % 2].GetHealPoints() - players[i].iceStrike.GetValue());
			players[i].SetMana(players[i].GetMana() - players[i].strongAttack.GetManaCost());
			Console.WriteLine("Your opponent is frozen and skips a turn. Go again");
			PlayerMove(i);
		}

		public void PlayerMove(int i)
		{
			PrintPlayerOptions(players[i]);
			int a;
			bool flag;
			int maxValue = 1;        //Finding the maximum allowable value for input
			if (players[i].GetLevel() >= 2 && players[i].GetMana() >= players[i].getHealed.GetManaCost())
			{
				maxValue += 1;
			}
			if (players[i].GetLevel() >= 3 && players[i].GetMana() >= players[i].strongAttack.GetManaCost())
			{
				maxValue += 1;
			}
			if (players[i].GetLevel() >= 4 && players[i].GetMana() >= players[i].iceStrike.GetManaCost())
			{
				maxValue += 1;
			}
			do
			{
				flag = Int32.TryParse(Console.ReadLine(), out a);       //Control of input characters
				if (!flag || a > maxValue || a < 0)
				{
					Console.WriteLine("Wrong input");
					Console.WriteLine($"Select from 0 to {maxValue}");
				}
			}
			while (!flag || a > maxValue || a < 0);

			switch (a)          //Character action selection
			{
				case 0:
					TakeDefence(i);
					break;
				case 1:
					ToAttack(i);
					break;
				case 2:
					UseGetHealed(i);
					break;
				case 3:
					UseStrongAttack(i);
					break;
				case 4:
					UseIceStrike(i);
					break;
			}
			players[i].SetMana(players[i].GetMana() + 10);
		}

		public void DoBattle()
		{
			Random rnd = new();
			int i = rnd.Next(0, 2);     //Random selection of the first move
			while (players[0].IsAlive() && players[1].IsAlive())
			{
				Console.Clear();
				players[0].PrintCharacteristics();
				players[1].PrintCharacteristics();
				PlayerMove(i);
				i = (i + 1) % 2;
			}
			if (!players[0].IsAlive() && !players[1].IsAlive())
			{
				Console.WriteLine("Draw");
			}
			else if (players[0].IsAlive())
			{
				Console.WriteLine($"{players[0].GetName()} win");
			}
			else
			{
				Console.WriteLine($"{players[1].GetName()} win");
			}
			Console.WriteLine("Press any button to go to the main menu.");
			Console.ReadKey();
		}

	}
}
