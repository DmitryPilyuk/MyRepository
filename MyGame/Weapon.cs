using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
	class Weapon
	{
		protected int damage;
		protected double selfDamageCoeff;

		public void SetDamage(int damage)
		{
			this.damage = damage;
		}

		public int GetDamage()
		{
			return damage;
		}

		public void SetSelfDamageCoeff(double selfDamageCoeff)
		{
			this.selfDamageCoeff = selfDamageCoeff;
		}

		public double GetSelfDamageCoeff()
		{
			return selfDamageCoeff;
		}
	}
}
