using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace The_Quest
{
    class Sword:Weapon
    {
        public Sword (Game game, Point location):base (game, location) { }

        public override string Name
        {
            get
            {
                return "Sword";
            }
        }

        public override void Attack(Direction direction, Random random)
        {
            bool damaged = DamageEnemy(direction, 10, 3, random);
            int i=0;
            while (!damaged && i<2)
            {
                Direction newDirection;
                    if (i == 0)
                    {
                        if ((int)direction == 3)
                            newDirection = Direction.Left;
                        else newDirection = (Direction)((int)direction + 1);
                    }
                    else
                    {
                        if ((int)direction == 0)
                            newDirection = Direction.Down;
                        else newDirection = (Direction)((int)direction - 1);
                    }
                i++;
                damaged = DamageEnemy(newDirection, 10, 3, random);
            }
        }
    }
}
