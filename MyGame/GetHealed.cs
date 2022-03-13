using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class GetHealed : Ability
    {
        public GetHealed(int value = 40, int manaCost = 40)
        {
            this.value = value;
            this.manaCost = manaCost;
        }
    }
}
