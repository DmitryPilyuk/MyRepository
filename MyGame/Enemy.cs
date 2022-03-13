using System;
using System.Collections.Generic;

namespace MyGame
{
	class Enemy : Unit
	{
		protected int experiencePointsReward;
		public Ability ability;

		public void SetExperiencePointsReward(int experiencePointsReward)
		{
			this.experiencePointsReward = experiencePointsReward;
		}

		public int GetExperiencePointsReward()
		{
			return experiencePointsReward;
		}

	}
}
