using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Quest
{
    public partial class Form1 : Form
    {
        private Game game;
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        public void UpdateCharacters()
        {
            PlayerPictureBox.Location = game.PLayerLocation;
            playerHitPointsLabel.Text = game.PlayerHitPoints.ToString();

            bool showBat = false;
            bool showGhost = false;
            bool showGhoul = false;
            int enemiesShown = 0;

            foreach (Enemy enemy in game.Enemies)
            {
                if (enemy is Bat)
                {
                    BatPictureBox.Location = enemy.Location;
                    BatHitPointsLabel.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints>0)
                    {
                        showBat = true;
                        enemiesShown++;
                    }
                }
                if (enemy is Ghost)
                {
                    GhostPictureBox.Location = enemy.Location;
                    GhostHitPointsLabel.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhost = true;
                        enemiesShown++;
                    }
                }
                if (enemy is Ghoul)
                {
                    GhoulPictureBox.Location = enemy.Location;
                    GhoulHitPointsLabel.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhoul = true;
                        enemiesShown++;
                    }
                }
            }
            if (!showBat)
            {
                BatPictureBox.Visible = false;
                BatHitPointsLabel.Text = "";
            } else BatPictureBox.Visible = true;
            if (!showGhost)
            {
                GhostPictureBox.Visible = false;
                GhostHitPointsLabel.Text = "";
            } else GhostPictureBox.Visible = true;
            if (!showGhoul)
            {
                GhoulPictureBox.Visible = false;
                GhoulHitPointsLabel.Text = "";
            } else GhoulPictureBox.Visible = true;

            BattleSwordPictureBox.Visible = false;
            BattleAxePictureBox.Visible = false;
            BattleMacePictureBox.Visible = false;
            BattleRedPotionPictureBox.Visible = false;
            BattleBluePotionPictureBox.Visible = false;
            Control weaponControl = null;
            switch (game.WeaponInRoom.Name)
            {
                case "Sword":
                    weaponControl = BattleSwordPictureBox; break;
                case "Axe":
                    weaponControl = BattleAxePictureBox; break;
                case "Mace":
                    weaponControl = BattleMacePictureBox; break;
                case "Red potion":
                    weaponControl = BattleRedPotionPictureBox; break;
                case "Blue potion":
                    weaponControl = BattleBluePotionPictureBox; break;
            }
            weaponControl.Visible = true;

            if (game.ChekPlayerInventory("Mace")) InventoryMacePictureBox.Visible = true;
            if (game.ChekPlayerInventory("Axe")) InventoryAxePictureBox.Visible = true;
            if (game.ChekPlayerInventory("Sword")) InventorySwordPictureBox.Visible = true;
            if (game.ChekPlayerInventory("Red potion")) InventoryRedPotionPictureBox.Visible = true;
            if (game.ChekPlayerInventory("Blue potion")) InventoryBluePotionPictureBox.Visible = true;

            weaponControl.Location = game.WeaponInRoom.Location;
            if (game.WeaponInRoom.PickedUp) weaponControl.Visible = false;
            else weaponControl.Visible = true;

            if (game.PlayerHitPoints <= 0)
            {
                MessageBox.Show("You died");
                Application.Exit();
            }
            //else PlayerPictureBox.Visible = true;

            if (enemiesShown<1)
            {
                MessageBox.Show("You have defeated the enemies of this level");
                //if (game.Level > 7)
                //{
                //    MessageBox.Show("You won!");
                //    //if (DialogResult == DialogResult.OK)
                //    Application.Exit();
                //}
                game.NewLevel(random);
                UpdateCharacters();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game = new Game(new Rectangle(100,73,560,185));
            game.NewLevel(random);
            UpdateCharacters();
        }

        private void InventoryAxePictureBox_Click(object sender, EventArgs e)
        {
            if (game.ChekPlayerInventory("Axe"))
            {
                game.Equip("Axe");
                InventoryAxePictureBox.BorderStyle = BorderStyle.Fixed3D;
                InventoryMacePictureBox.BorderStyle = BorderStyle.None;
                InventorySwordPictureBox.BorderStyle = BorderStyle.None;
                InventoryBluePotionPictureBox.BorderStyle = BorderStyle.None;
                InventoryRedPotionPictureBox.BorderStyle = BorderStyle.None;

                AttackUpButton.Text = "↑";
                AttackLeftButton.Visible = true;
                AttackRightButton.Visible = true;
                AttackDownButton.Visible = true;
            }

        }

        private void InventoryMacePictureBox_Click(object sender, EventArgs e)
        {
            if (game.ChekPlayerInventory("Mace"))
            {
                game.Equip("Mace");
                InventoryAxePictureBox.BorderStyle = BorderStyle.None;
                InventoryMacePictureBox.BorderStyle = BorderStyle.Fixed3D;
                InventorySwordPictureBox.BorderStyle = BorderStyle.None;
                InventoryBluePotionPictureBox.BorderStyle = BorderStyle.None;
                InventoryRedPotionPictureBox.BorderStyle = BorderStyle.None;

                AttackUpButton.Text = "↑";
                AttackLeftButton.Visible = true;
                AttackRightButton.Visible = true;
                AttackDownButton.Visible = true;
            }
        }

        private void InventorySwordPictureBox_Click(object sender, EventArgs e)
        {
            if (game.ChekPlayerInventory("Sword"))
            {
                game.Equip("Sword");
                InventoryAxePictureBox.BorderStyle = BorderStyle.None;
                InventoryMacePictureBox.BorderStyle = BorderStyle.None;
                InventorySwordPictureBox.BorderStyle = BorderStyle.Fixed3D;
                InventoryBluePotionPictureBox.BorderStyle = BorderStyle.None;
                InventoryRedPotionPictureBox.BorderStyle = BorderStyle.None;

                AttackUpButton.Text = "↑";
                AttackLeftButton.Visible = true;
                AttackRightButton.Visible = true;
                AttackDownButton.Visible = true;
            }
        }

        private void InventoryRedPotionPictureBox_Click(object sender, EventArgs e)
        {
            if (game.ChekPlayerInventory("Red potion"))
            {
                game.Equip("Red potion");
                InventoryAxePictureBox.BorderStyle = BorderStyle.None;
                InventoryMacePictureBox.BorderStyle = BorderStyle.None;
                InventorySwordPictureBox.BorderStyle = BorderStyle.None;
                InventoryBluePotionPictureBox.BorderStyle = BorderStyle.None;
                InventoryRedPotionPictureBox.BorderStyle = BorderStyle.Fixed3D;

                AttackUpButton.Text = "Drink";
                AttackLeftButton.Visible = false;
                AttackRightButton.Visible = false;
                AttackDownButton.Visible = false;
            }
            //else InventoryRedPotionPictureBox.Visible = false;
        }

        private void InventoryBluePotionPictureBox_Click(object sender, EventArgs e)
        {
            if (game.ChekPlayerInventory("Blue potion"))
            {
                game.Equip("Blue potion");
                InventoryAxePictureBox.BorderStyle = BorderStyle.None;
                InventoryMacePictureBox.BorderStyle = BorderStyle.None;
                InventorySwordPictureBox.BorderStyle = BorderStyle.None;
                InventoryBluePotionPictureBox.BorderStyle = BorderStyle.Fixed3D;
                InventoryRedPotionPictureBox.BorderStyle = BorderStyle.None;

                AttackUpButton.Text = "Drink";
                AttackLeftButton.Visible = false;
                AttackRightButton.Visible = false;
                AttackDownButton.Visible = false;
            }
            //else InventoryBluePotionPictureBox.Visible = false;
        }

        private void MoveLeftButton_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Left, random);
            UpdateCharacters();
        }

        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Up, random);
            UpdateCharacters();
        }

        private void MoveRightButton_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Right, random);
            UpdateCharacters();
        }

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Down, random);
            UpdateCharacters();
        }

        private void AttackLeftButton_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Left, random);
            UpdateCharacters();
        }

        private void AttackUpButton_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Up, random);
            UpdateCharacters();
            if (AttackUpButton.Text=="Drink")
            {
                if (game.ChekPlayerInventory("Sword"))
                {
                    game.Equip("Sword");
                    InventoryAxePictureBox.BorderStyle = BorderStyle.None;
                    InventoryMacePictureBox.BorderStyle = BorderStyle.None;
                    InventorySwordPictureBox.BorderStyle = BorderStyle.Fixed3D;
                    InventoryBluePotionPictureBox.BorderStyle = BorderStyle.None;
                    InventoryRedPotionPictureBox.BorderStyle = BorderStyle.None;

                    AttackUpButton.Text = "↑";
                    AttackLeftButton.Visible = true;
                    AttackRightButton.Visible = true;
                    AttackDownButton.Visible = true;
                }
                else if (game.ChekPlayerInventory("Axe"))
                {
                    game.Equip("Axe");
                    InventoryAxePictureBox.BorderStyle = BorderStyle.Fixed3D;
                    InventoryMacePictureBox.BorderStyle = BorderStyle.None;
                    InventorySwordPictureBox.BorderStyle = BorderStyle.None;
                    InventoryBluePotionPictureBox.BorderStyle = BorderStyle.None;
                    InventoryRedPotionPictureBox.BorderStyle = BorderStyle.None;

                    AttackUpButton.Text = "↑";
                    AttackLeftButton.Visible = true;
                    AttackRightButton.Visible = true;
                    AttackDownButton.Visible = true;
                }
                else if (game.ChekPlayerInventory("Mace"))
                {
                    game.Equip("Mace");
                    InventoryAxePictureBox.BorderStyle = BorderStyle.None;
                    InventoryMacePictureBox.BorderStyle = BorderStyle.Fixed3D;
                    InventorySwordPictureBox.BorderStyle = BorderStyle.None;
                    InventoryBluePotionPictureBox.BorderStyle = BorderStyle.None;
                    InventoryRedPotionPictureBox.BorderStyle = BorderStyle.None;

                    AttackUpButton.Text = "↑";
                    AttackLeftButton.Visible = true;
                    AttackRightButton.Visible = true;
                    AttackDownButton.Visible = true;
                }
                if (!game.ChekPlayerInventory("Blue potion")) InventoryBluePotionPictureBox.Visible = false;
                if (!game.ChekPlayerInventory("Red potion")) InventoryRedPotionPictureBox.Visible = false;
            }
        }

        private void AttackRightButton_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Right, random);
            UpdateCharacters();
        }

        private void AttackDownButton_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Down, random);
            UpdateCharacters();
        }
    }
}
