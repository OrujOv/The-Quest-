using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace The_Quest
{
    class Axe : Weapon
    {
        public Axe(Game game, Point location):base (game, location) { }

        public override string Name
        {
            get
            {
                return "Axe";
            }
        }

        public override void Attack(Direction direction, Random random)
        {
            DamageEnemy(direction, 20, 2, random);
        }
    }
}
