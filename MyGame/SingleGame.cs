using System;
using System.Collections.Generic;

namespace MyGame
{
	class SingleGame
	{
		private Hero player;
		private Enemy enemy;
		private PvEBattle battle;
		public SingleGame(Hero player)
		{
			this.player = player;
		}

		public void GameProcess()
		{
			bool[] levels = new bool[6] {true, false, false, false, false, false};  //Progress of available enemies
			int choice;
			do
			{
				int lastTrue = 1;
				for (int i = 0; i < 6; i++)
				{
					if (levels[i])
					{
						lastTrue = i + 1;
					}
				}
				Console.Clear();
				player.PrintAllCharacteristics();
				Console.WriteLine("Select the level:");         //Printing single-player menu options
				Console.WriteLine("1 - battle with The Wolf");
				if (lastTrue < 2)
				{
					Console.WriteLine("2 - battle with The Bear(closed)");
					Console.WriteLine("3 - battle with The Draugr(closed)");
					Console.WriteLine("4 - battle with The Troll(closed)");
					Console.WriteLine("5 - battle with The Elemental(closed)");
					Console.WriteLine("6 - battle with The Ice Dragon(closed)");
				}
				else
				{
					Console.WriteLine("2 - battle with The Bear");
					if (lastTrue < 3)
					{
						Console.WriteLine("3 - battle with The Draugr(closed)");
						Console.WriteLine("4 - battle with The Troll(closed)");
						Console.WriteLine("5 - battle with The Elemental(closed)");
						Console.WriteLine("6 - battle with The Ice Dragon(closed)");
					}
					else
					{
						Console.WriteLine("3 - battle with The Draugr");
						if (lastTrue < 4)
						{
							Console.WriteLine("4 - battle with The Troll(closed)");
							Console.WriteLine("5 - battle with The Elemental(closed)");
							Console.WriteLine("6 - battle with The Ice Dragon(closed)");
						}
						else
						{
							Console.WriteLine("4 - battle with The Troll");
							if (lastTrue < 5)
							{
								Console.WriteLine("5 - battle with The Elemental(closed)");
								Console.WriteLine("6 - battle with The Ice Dragon(closed)");
							}
							else
							{
								Console.WriteLine("5 - battle with The Elemental");
								if (lastTrue < 5)
								{
									
									Console.WriteLine("6 - battle with The Ice Dragon(closed)");
								}
								else
								{
									Console.WriteLine("6 - battle with The Ice Dragon");
								}
							}
						}
					}
				}
				Console.WriteLine("-------------------------------");
				Console.WriteLine("0 - Exit to the main menu");
				Console.WriteLine("7 - Change weapon");
				bool flag;
				do
				{
					flag = Int32.TryParse(Console.ReadLine(), out choice);  //Control of input characters
					if (!flag || choice > lastTrue && choice !=7 || choice < 0)
					{
						Console.WriteLine("Wrong input or level closed");
					}
				}
				while (!flag || choice > lastTrue && choice != 7 || choice < 0);
				switch (choice)		// Enemy selection
				{
					case 0:
						break;
					case 1:
						enemy = new Wolf();
						break;
					case 2:
						enemy = new Bear();
						break;
					case 3:
						enemy = new Draugr();
						break;
					case 4:
						enemy = new Troll();
						break;
					case 5:
						enemy = new Elemental();
						break;
					case 6:
						enemy = new IceDragon();
						break;
					case 7:
						NewWeapon();
						break;
				}
				if (choice != 0 && choice != 7)
				{
					Hero playerCopy = player.Clone();		//Creating copy and starting battle
					battle = new PvEBattle(playerCopy, enemy);
					if (battle.DoBattle())
					{
						player.SetExperiencePoints(player.GetExperiencePoints() + enemy.GetExperiencePointsReward()); //Adding XP
						levels[choice] = true;
					}
				}
				if (player.GetExperiencePoints() >= 400) // Level Updating
				{
					player.LevelUp();
					player.SetExperiencePoints(0);
					switch (player.GetLevel())
					{
						case 2:
							Console.WriteLine("Level up. New ability, Get Healed, was added.");
							break;
						case 3:
							Console.WriteLine("Level up. New ability, Strong Attack, was added.");
							break;
						case 4:
							Console.WriteLine("Level up. New ability, Ice Strike, was added.");
							break;
					}
					Console.WriteLine("Press any button to continue");
				}
			}
			while (choice != 0);
		}

		public void NewWeapon() //Changing the weapon
		{
			Console.Clear();
			Console.WriteLine("Select weapon:");
			Console.WriteLine("1 - Axe");
			Console.WriteLine("2 - Sword and shield");
			Console.WriteLine("3 - Bow");
			int choice;
			bool flag;
			do
			{
				flag = Int32.TryParse(Console.ReadLine(), out choice);      //Control of input characters
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
					player.ChangeWeapon(new Axe());
					break;
				case 2:
					player.ChangeWeapon(new SwordAndShield());
					break;
				case 3:
					player.ChangeWeapon(new Bow());
					break;
			}
		}
	}
}
