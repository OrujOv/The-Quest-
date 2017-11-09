using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Quest
{
    class Mace : Weapon
    {
        public Mace(Game game, Point location):base (game, location) { }

        public override string Name
        {
            get
            {
                return "Mace";
            }
        }

        public override void Attack(Direction direction, Random random)
        {
            bool damaged = DamageEnemy(direction, 20, 6, random);
            int i = 0;
            while (!damaged && i < 4)
            {
                Direction newDirection;

                    if ((int)direction == 3)
                        newDirection = Direction.Left;
                    else newDirection = (Direction)((int)direction + 1);
                i++;
                damaged = DamageEnemy(newDirection, 20, 6, random);
            }
        }
    }
}
