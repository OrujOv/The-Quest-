using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Quest
{
    class Player:Mover
    {
        private Weapon equippedWeapon;

        public int HitPoints { get; private set; }

        private List<Weapon> inventory = new List<Weapon>();
        public IEnumerable<string> Weapons
        {
            get
            {
                List<string> names = new List<string>();
                foreach (Weapon weapon in inventory)
                    names.Add(weapon.Name);
                return names;
            }
        }

        public Player(Game game, Point location):base(game, location)
        {
            HitPoints = 10;
        }

        public void Hit(int maxDamage, Random random)
        {
            HitPoints -= random.Next(1, maxDamage);
        }

        public void IncreaseHealth(int health, Random random)
        {
            HitPoints += random.Next(1, health);
        }

        public void Equip(string weaponName)
        {
            foreach (Weapon weapon in inventory)
                if (weapon.Name==weaponName)
                    equippedWeapon = weapon;
        }

        public void Move(Direction direction)
        {
            base.location = Move(direction, game.Boundaries);
            if (!game.WeaponInRoom.PickedUp)
            {
                if (Nearby(game.WeaponInRoom.Location, 10)) // && !Weapons.Contains(game.WeaponInRoom.Name)) // Why 10?
                {
                    inventory.Add(game.WeaponInRoom);
                    if (inventory.Count == 1 ) Equip(game.WeaponInRoom.Name); //  !(inventory[0] is IPotion)
                    game.WeaponInRoom.PickUpWeapon();
                }
            }
        }

        public void Attack(Direction direction, Random random)
        {
            if (equippedWeapon != null)
            {
                equippedWeapon.Attack(direction, random);
                if (equippedWeapon is IPotion)
                {
                    IPotion temporary = equippedWeapon as IPotion;
                    if (temporary.Used) inventory.Remove(equippedWeapon);
                }
            }
            else return;
        }
    }
}
