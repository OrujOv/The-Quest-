using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Quest
{
    abstract class Enemy:Mover
    {
        private const int NearPlayerDistance = 25;

        public int HitPoints { get; private set; }
        public bool Dead
        {
            get
            {
                if (HitPoints <= 0) return true;
                else return false;
            }
        }

        public Enemy(Game game, Point location, int hitPoints):base(game, location)
        {
            HitPoints = hitPoints;
        }

        public abstract void Move(Random random);

        public void Hit(int maxDamage, Random random)
        {
            HitPoints -= random.Next(1, maxDamage);
        }

        protected bool NearPlayer()
        {
            return (Nearby(game.PLayerLocation, NearPlayerDistance));
        }

        protected Direction FindPlayerDirection(Point playeLocation)
        {
            Direction directionToMove;
            if (playeLocation.X > location.X + 10) directionToMove = Direction.Right;
            else if (playeLocation.X < location.X - 10) directionToMove = Direction.Left;
            else if (playeLocation.Y < location.Y - 10) directionToMove = Direction.Up;
            else directionToMove = Direction.Down;
            return directionToMove;
        }
    }
}
