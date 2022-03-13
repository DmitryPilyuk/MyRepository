using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Draugr : Enemy
    {
        public Draugr()
        {
            name = "Draugr";
            healPoints = 250;
            damage = 30;
            mana = 0;
            selfDamageCoeff = 0.7;
            experiencePointsReward = 200;
            ability = new GetHealed(50, 40);
        }
    }
}
