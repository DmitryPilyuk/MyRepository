using System;
using System.Collections.Generic;

namespace MyGame
{
    class Wolf : Enemy
    {
        public Wolf()
        {
            name = "Wolf";
            healPoints = 150;
            damage = 25;
            mana = 0;
            selfDamageCoeff = 1;
            experiencePointsReward = 200;
            ability = new DamageUp(10, 40);
        }
    }
}
