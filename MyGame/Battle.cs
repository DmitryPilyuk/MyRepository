using System;
using System.Collections.Generic;

namespace MyGame
{
	class Battle
	{

		public void PrintPlayerOptions(Hero player)		//Printing the main characteristics of the hero in battle
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
			if (player.GetMana() >= player.iceStrike.GetManaCost() && player.GetLevel() >= 4)
			{
				Console.WriteLine("4 - ice strike");
			}
		}
	}
}
