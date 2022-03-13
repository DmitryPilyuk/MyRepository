using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class IceDragon : Enemy
    {
        public IceDragon()
        {
            name = "IceDragon";
            healPoints = 400;
            damage = 50;
            mana = 0;
            selfDamageCoeff = 0.1;
            experiencePointsReward = 400;
            ability = new IceStrike(70, 80);
        }
    }
}
