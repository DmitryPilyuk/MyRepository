using System;
using System.Collections.Generic;

namespace MyGame
{
	class Menu : Game
	{
		public void MainMenu()
		{
			int a;
			do
			{
				Console.Clear();
				Console.WriteLine("Main Menu");
				Console.WriteLine("Select gaming mode:");
				Console.WriteLine("1 - Single player");
				Console.WriteLine("2 - PvP Battle");
				Console.WriteLine("0 - Exit game");

				bool flag;
				do
				{
					flag = Int32.TryParse(Console.ReadLine(), out a);		//Control of input characters
					if (!flag || a > 2 || a < 0)
					{
						Console.WriteLine("Wrong input");
						Console.WriteLine("Select from 0 to 2:");
					}
				}
				while (!flag || a > 2 || a < 0);
				if (a == 1)
				{
					StartPvEGame();
				}
				else if (a == 2)
				{
					StartPvPGame();
				}

			}
			while (a != 0);
		}
	}
}
