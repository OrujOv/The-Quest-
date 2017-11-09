using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace The_Quest
{
    class BluePotion : Weapon, IPotion
    {
        public BluePotion(Game game, Point location):base (game, location) { }

        public override string Name
        {
            get
            {
                return "Blue potion";
            }
        }

        private bool used;
        public bool Used { get {return used; } }

        public override void Attack(Direction direction, Random random)
        {
            game.IncreasePlatersHealth(5, random);
            used = true;
        }
    }
}
