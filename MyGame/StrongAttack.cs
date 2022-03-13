using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class StrongAttack : Ability
    {
        public StrongAttack(int value = 70, int manaCost = 60)
        {
            this.value = value;
            this.manaCost = manaCost;
        }
    }
}
