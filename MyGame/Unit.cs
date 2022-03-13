using System;
using System.Collections.Generic;

namespace MyGame
{
	class Unit
	{
		protected string name;
		protected int healPoints;
		protected int damage;
		protected int mana;
		protected double selfDamageCoeff;

		public void SetName(string name)
		{
			this.name = name;
		}

		public string GetName()
		{
			return name;
		}

		public void SetHealPoints(int healPoints)
		{
			this.healPoints = healPoints;
		}

		public int GetHealPoints()
		{
			return healPoints;
		}

		public void SetDamage(int damage)
		{
			this.damage = damage;
		}

		public virtual int GetDamage()
		{
			return damage;
		}

		public void SetMana(int mana)
		{
			this.mana = mana;
		}

		public int GetMana()
		{
			return mana;
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
