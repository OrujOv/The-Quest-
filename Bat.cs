using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Quest
{
    class Bat:Enemy
    {
        public Bat(Game game, Point location): base (game, location, 6) { }

        public override void Move(Random random)
        {
            if (HitPoints>=1)
            {
                //int rand = random.Next(2);
                if (random.Next(2) == 1)
                {
                    base.location= base.Move(FindPlayerDirection(game.PLayerLocation), game.Boundaries);
                }
                else
                {
                    base.location = base.Move((Direction)random.Next(4), game.Boundaries);
                }

                if (NearPlayer()) Attack(random);
                //else return;
            }
        }

        public void Attack(Random random)
        {
            game.HitPlayer(2, random);
        }
    }
}
