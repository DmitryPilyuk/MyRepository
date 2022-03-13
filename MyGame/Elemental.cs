using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Elemental : Enemy
    {
        public Elemental()
        {
            name = "Elemental";
            healPoints = 250;
            damage = 40;
            mana = 0;
            selfDamageCoeff = 0.3;
            experiencePointsReward = 400;
            ability = new StrongAttack(70, 60);
        }
    }
}
