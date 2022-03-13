using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
	class Ability
	{
		protected int manaCost;
		protected int value;
		
		public void SetManaCost(int manaCost)
		{
			this.manaCost = manaCost;
		}

		public int GetManaCost()
		{
			return manaCost;
		}

		public void SetValue(int value)
		{
			this.value = value;
		}

		public int GetValue()
		{
			return value;
		}
	}
}
