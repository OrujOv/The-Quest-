using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace The_Quest
{
    class Ghoul:Enemy
    {
        public Ghoul(Game game, Point location): base (game, location, 10) { }

        public override void Move(Random random)
        {
            if (HitPoints >= 1)
            {
                int rand = random.Next(3);
                if (rand== 1 || rand == 2)
                {
                    base.location = base.Move(FindPlayerDirection(game.PLayerLocation), game.Boundaries);
                }

                if (NearPlayer()) Attack(random);
            }
        }

        public void Attack(Random random)
        {
            game.HitPlayer(4, random);
        }
    }
}
