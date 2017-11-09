using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace The_Quest
{
    abstract class Weapon:Mover
    {
        public bool PickedUp { get; private set; }

        public Weapon (Game game, Point location) :base (game, location)
        {
            PickedUp = false;
        }

        public void PickUpWeapon() { PickedUp = true; }

        public abstract string Name { get; }

        public abstract void Attack(Direction direction, Random random);

        protected bool DamageEnemy(Direction direction, int radius, int damage, Random random)
        {
            Point target = game.PLayerLocation;
            for (int distance=0; distance <radius; distance++)
            {
                foreach (Enemy enemy in game.Enemies)
                {
                    if (Nearby(enemy.Location, target, distance))
                    {
                        enemy.Hit(damage, random);
                        return true;
                    }
                }

                target = Move(direction, target, game.Boundaries);
            }
            return false;
        }

        public bool Nearby(Point locationToCheck, Point secondLocationToCheck, int distance)
        {
            if (Math.Abs(secondLocationToCheck.X - locationToCheck.X) < distance &&
                (Math.Abs(secondLocationToCheck.Y - locationToCheck.Y) < distance)) return true;
            else return false;
        }

        public Point Move(Direction direction, Point target, Rectangle boundaries)
        {
            Point newLocation = target;
            switch (direction)
            {
                case Direction.Up:
                    if (newLocation.Y - 10 >= boundaries.Top)
                        newLocation.Y -= 10;
                    break;
                case Direction.Down:
                    if (newLocation.Y + 10 <= boundaries.Bottom)
                        newLocation.Y += 10;
                    break;
                case Direction.Left:
                    if (newLocation.X - 10 >= boundaries.Left)
                        newLocation.X -= 10;
                    break;
                case Direction.Right:
                    if (newLocation.X + 10 <= boundaries.Right)
                        newLocation.X += 10;
                    break;
                default: break;
            }
            return newLocation;
        }
    }
}
