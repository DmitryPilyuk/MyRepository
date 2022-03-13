using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
	class DamageUp : Ability
	{
		public DamageUp(int value, int manaCost)
		{
			this.value = value;
			this.manaCost = manaCost;
		}
	}
}
