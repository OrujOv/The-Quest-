using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace The_Quest
{
    class Ghost:Enemy
    {
        public Ghost(Game game, Point location): base (game, location, 8) { }

        public override void Move(Random random)
        {
            if (HitPoints >= 1)
            {
                if (random.Next(3) == 1)
                {
                    base.location = base.Move(FindPlayerDirection(game.PLayerLocation), game.Boundaries);
                }
                //else
                //{
                //    base.Move((Direction)random.Next(4), game.Boundaries);
                //}

                if (NearPlayer()) Attack(random);
                //else return;
            }
        }

        public void Attack(Random random)
        {
            game.HitPlayer(3, random);
        }
    }
}
