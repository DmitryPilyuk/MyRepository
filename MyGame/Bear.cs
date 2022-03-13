using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Bear : Enemy
    {
        public Bear()
        {
            name = "Bear";
            healPoints = 250;
            damage = 30;
            mana = 0;
            selfDamageCoeff = 0.7;
            experiencePointsReward = 200;
            ability = new DamageUp(15, 50);
        }
    }
}
