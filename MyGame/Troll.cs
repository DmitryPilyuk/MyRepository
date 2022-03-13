using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
	class Troll : Enemy
	{
		public Troll()
		{
			name = "Troll";
			healPoints = 350;
			damage = 40;
			mana = 0;
			selfDamageCoeff = 0.9;
			experiencePointsReward = 200;
			ability = new StrongAttack(50, 50);
		}
	}
}
