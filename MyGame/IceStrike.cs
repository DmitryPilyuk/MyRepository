using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class IceStrike : Ability
    {
        public IceStrike(int value = 60, int manaCost = 80)
        {
            this.value = value;
            this.manaCost = manaCost;
        }
    }
}
