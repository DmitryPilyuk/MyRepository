using System;
using System.Collections.Generic;

namespace MyGame
{
	class Game
	{
		public void StartPvPGame()
		{
			List<Hero> players = new() { };
			for (int i = 0; i <= 1; i++)
			{
				Console.Clear();
				Console.WriteLine($"Player {i + 1}, enter your name:");
				string name = Console.ReadLine();
				Console.WriteLine("Select weapon:");
				Console.WriteLine("1 - Axe");
				Console.WriteLine("2 - Sword and shield");
				Console.WriteLine("3 - Bow");
				int choice;
				bool flag;
				do
				{
					flag = Int32.TryParse(Console.ReadLine(), out choice);
					if (!flag || choice > 3 || choice < 1)
					{
						Console.WriteLine("Wrong input");
						Console.WriteLine("Select from 1 to 3:");
					}
				}
				while (!flag || choice > 3 || choice < 1);
				switch (choice)
				{
					case 1:
						players.Add(new Hero(name, new Axe(), 4));
						break;
					case 2:
						players.Add(new Hero(name, new SwordAndShield(), 4));
						break;
					case 3:
						players.Add(new Hero(name, new Bow(), 4));
						break;
				}
			}
			PvPBattle battle = new(players[0], players[1]);
			battle.DoBattle();
		}
		public void StartPvEGame()
		{
			SingleGame game;
			Console.Clear();
			Console.WriteLine($"Enter your name:");
			string name = Console.ReadLine();
			Console.WriteLine("Select weapon:");
			Console.WriteLine("1 - Axe");
			Console.WriteLine("2 - Sword and shield");
			Console.WriteLine("3 - Bow");
			int choice;
			bool flag;
			do
			{
				flag = Int32.TryParse(Console.ReadLine(), out choice);
				if (!flag || choice > 3 || choice < 1)
				{
					Console.WriteLine("Wrong input");
					Console.WriteLine("Select from 1 to 3:");
				}
			}
			while (!flag || choice > 3 || choice < 1);
			if (choice == 1)
			{
				game = new SingleGame(new Hero(name, new Axe()));
			}
			else if (choice == 2)
			{
				game = new SingleGame(new Hero(name, new SwordAndShield()));
			}
			else
			{
				game = new SingleGame(new Hero(name, new Bow()));
			}
			game.GameProcess();
		}
	}
}